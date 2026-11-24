
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Services
{
    internal class DeptService
    {
        private readonly DepartmentRepository deptRepo = new DepartmentRepository();

         
        // 부서 조회
        public List<DepartmentDto> GetAll()
        {
            try
            {
                return deptRepo.GetAll();
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("목록 조회 실패", ex);
                throw;
            }
        }


        // 부서 추가
        public void Add(DepartmentDto dto)
        {
            // 필수값 체크
            if (dto.ParentDeptId == null) { throw new BusinessException("상위부서코드를 선택해주세요."); }
            if (string.IsNullOrWhiteSpace(dto.DeptCode)) { throw new BusinessException("부서코드는 필수기재사항입니다"); }
            if (string.IsNullOrWhiteSpace(dto.DeptName)) { throw new BusinessException("부서명은 필수기재사항입니다."); }

            // dto -> entity 변환
            var entity = new Entity.Department
            {
                ParentDeptId = dto.ParentDeptId,
                DeptCode = dto.DeptCode,
                DeptName = dto.DeptName,
                DeptId = dto.DeptId,
                Memo = dto.Memo,
            };

            // 레파지토리 호출 후 db저장
            try
            {
                deptRepo.Save(entity);
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 부서코드 중복일 경우 메세지 담아 예외처리
                if (ex.Message.Contains("UQ_Department_DeptCode"))
                {
                    throw new BusinessException("이미 존재하는 부서코드입니다.");
                }
                // 나머지 중복값 존재시 메세지 담아 예외처리
                throw new BusinessException("중복된 값이 있습니다.");
            }
            // 나머지 예외 발생시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("부서 추가 실패 DeptCode=" + entity.DeptCode, ex);
                throw;
            }
        }

        // 부서 수정
        public void Edit(DepartmentDto dto)
        {
            // 필수값 체크
            if (dto.ParentDeptId == null) { throw new BusinessException("상위부서코드를 선택해주세요."); }
            if (string.IsNullOrWhiteSpace(dto.DeptCode)) { throw new BusinessException("부서코드를 입력해주세요."); }
            if (string.IsNullOrWhiteSpace(dto.DeptName)) { throw new BusinessException("부서명을 입력해주세요."); }

            // dto -> entity 변환
            var entity = new Entity.Department
            {
                DeptId = dto.DeptId,
                DeptCode = dto.DeptCode,
                DeptName = dto.DeptName,
                Memo = dto.Memo,
                ParentDeptId = dto.ParentDeptId
            };

            // db 저장
            try
            {
                deptRepo.Update(entity);
            }
            // 유니크키 중복 발생시 Sql에러 메세지 담아 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 부서코드 중복값일 경우 메세지 담아 예외처리
                if (ex.Message.Contains("UQ_Department_DeptCode"))
                {
                    throw new BusinessException("이미 존재하는 부서코드입니다.");
                }
                // 그 외 중복값이 존재할 경우 메세지 담아 예외처리
                throw new BusinessException("중복되는 값이 존재합니다.");
            }
            // 나머지 에러 발생시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("부서 수정 실패 DeptId=" + entity.DeptId, ex);
                throw;
            }
        }

        // 부서 삭제
        public void Delete(int deptId)
        {
            try
            {
                new DepartmentRepository().Delete(deptId);
            }
            // 소속 사원이 있는 부서를 삭제하면 외래키 졔약조건 위반이 발생
            catch (SqlException ex) when (ex.Number == 547)
            {
                // 사원이 참조 중인 부서이면 메시지 담아 예외처리
                if (ex.Message.Contains("FK_Employee_Department"))
                {
                    throw new BusinessException("소속 사원이 존재하는 부서는 삭제할 수 없습니다.");
                }
                throw new BusinessException("삭제할 수 없는 상태입니다.");
            }
            // 나머지 에러시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("부서 삭제 실패", ex);
                throw;
            }
        }

        // 부서 트리 메서드
        public DataTable TreeDataTable()
        {
            var pdept = new ParentDepartmentRepository().GetAll();
            var dept = deptRepo.GetAll();
            var emp = new EmployeeRepository().GetAll();
            

            // TreeList 데이터소스에 넣을 데이터테이블 제작
            // 테이블 내 컬럼
            DataTable dt = new DataTable();
            dt.Columns.Add("NodeId", typeof(string));   // 노드ID
            dt.Columns.Add("ParentId", typeof(string)); // 부모노드ID
            dt.Columns.Add("NodeCode", typeof(string)); // 노드코드
            dt.Columns.Add("NodeName", typeof(string)); // 노드명

            // 컬럼에 넣을 로우값 상위부서, 부서, 사원 순서
            // db의 각 Id들은 identity 자동증가로 겹칠수 있음 "P,D,E" 접두사를 붙여구분
            foreach (var p in pdept)
            {
                // P+Id, null(상위부서라 더 상위가 없음), 상위부서코드, 상위부서명
                dt.Rows.Add("P" + p.ParentDeptId, DBNull.Value, p.ParentDeptCode, p.ParentDeptName);
            }
            foreach (var d in dept)
            {
                // D+Id, null(상위가 없는경우 체크) + P+상위부서ID, 부서코드, 부서명
                dt.Rows.Add("D" + d.DeptId, d.ParentDeptId == null ? (object)DBNull.Value : "P" + d.ParentDeptId, d.DeptCode, d.DeptName);
            }
            foreach (var e in emp)
            {
                // E+Id, D+부서Id, 사원코드, 사원명
                dt.Rows.Add("E" + e.EmpId, "D" + e.DeptId, e.EmpCode, e.EmpName);
            }
            return dt;
        }

        // 부서 차트 메서드
        public List<DeptChartDto> Chart()
        {
            var pdept = new ParentDepartmentRepository().GetAll();
            var emp = new EmployeeRepository().GetAll();

            // 누적막대차트 데이터소스
            // 부서 시리즈 기준으로 상위부서, 부서명, 사원수 값을 list에 담음
            return deptRepo.GetAll().Select(d => new DeptChartDto
            {
                // 차트 x축, 상위부서의 ParentDeptId 와 부서의 ParentDeptId가 같은 pdept의 ParentDeptName을 표시, 상위부서가 없으면 null
                ParentDeptName_X = pdept.FirstOrDefault(p => p.ParentDeptId == d.ParentDeptId)?.ParentDeptName,
                // 차트의 시리즈 기준, 부서명으로 표시
                DeptName_S = d.DeptName,
                // 차트 y축, 부서의 사원수, 같은 상위부서끼리 쌓임
                Count_Y = emp.Where(e => e.DeptId == d.DeptId).Count()
            }).ToList();
        }
    }
}
