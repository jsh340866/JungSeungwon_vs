
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Utils;
using WindowsFormsApp2.Entity;

namespace WindowsFormsApp2.Services
{
    internal class EmpService
    {
        private readonly EmployeeRepository empRepo = new EmployeeRepository();

        // 사원전체조회
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            try
            {
                return await empRepo.GetAllAsync();
            }
            catch(Exception ex) 
            {
                Logger.Instance.Error("목록 조회 실패",ex);
                throw;
            }
        }

        // 사원 추가
        public async Task AddAsync(EmployeeDto dto)
        {
            // 필수값 지정
            if (dto.DeptId <= 0) { throw new BusinessException("부서코드를 선택해주세요");}
            if (string.IsNullOrWhiteSpace(dto.EmpCode)) { throw new BusinessException("사원코드를 입력해주세요."); }
            if (string.IsNullOrWhiteSpace(dto.EmpName)) { throw new BusinessException("사원명을 입력해주세요."); }
            if (string.IsNullOrWhiteSpace(dto.LoginId)) { throw new BusinessException("로그인ID를 입력해주세요"); }
            if (string.IsNullOrWhiteSpace(dto.Password)) { throw new BusinessException("비밀번호를 입력해주세요"); }

            // 비밀번호 규칙 틀리면 메시지 담아 예외처리
            if (!ValidationRule.PasswordCheck(dto.Password))
            {
                throw new BusinessException("비밀번호는 영문,숫자 포함 8자 이상입니다.");
            }

            // 이메일이 공백이 아니고 이메일 규칙을 어겼다면 메시지 담아 예외처리
            if (!string.IsNullOrWhiteSpace(dto.Email) && !ValidationRule.EmailCheck(dto.Email))
            {
                throw new BusinessException("이메일을 다시 입력해주세요.");
            }

            // 사원정보 메모리에 담기
            var entity = new Employee
            {
                EmpId = dto.EmpId,
                DeptId = dto.DeptId,
                EmpName = dto.EmpName,
                EmpCode = dto.EmpCode,
                Gender = dto.Gender,
                LoginId = dto.LoginId,
                Password = dto.Password,
                Position = dto.Position,
                EmpType = dto.EmpType,
                Phone = dto.Phone,
                Email = dto.Email,
                MessengerId = dto.MessengerId,
                Memo = dto.Memo,
                Photo = dto.Photo,
            };
            // 사원정보 db에 저장
            try
            {
                await new EmployeeRepository().SaveAsync(entity);
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 로그인ID 중복일 경우 메세지 담아 예외처리
                if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    throw new BusinessException("이미 사용중인 로그인ID 입니다.");
                }
                // 사원코드 중복일 경우 메세지 담아 예외처리
                else if (ex.Message.Contains("UQ_Employee_EmpCode"))
                {
                    throw new BusinessException("이미 사용중인 사원코드 입니다.");
                }
                // 그 외 Sql중복오류시 메세지 담아 예외처리
                throw new BusinessException("중복된 값이 있습니다.");
            }
            // 나머지 에러발생시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("사원 추가 실패 EmpCode=" + entity.EmpCode, ex);
                throw;
            }
        }

        // 사원 수정
        public async Task EditAsync(EmployeeDto dto)
        {
            // 필수값 지정
            if (dto.DeptId <= 0) { throw new BusinessException("부서코드를 선택해주세요."); }
            if (string.IsNullOrWhiteSpace(dto.EmpCode)) { throw new BusinessException("사원코드를 입력해주세요."); }
            if (string.IsNullOrWhiteSpace(dto.EmpName)) { throw new BusinessException("사원명을 입력해주세요."); }
            // 이메일 규칙
            if (!string.IsNullOrWhiteSpace(dto.Email) && !ValidationRule.EmailCheck(dto.Email))
            {
                throw new BusinessException("이메일을 다시 입력해주세요.");
            }

            // dto -> entity 변환
            var entity = new Entity.Employee
            {
                DeptId = dto.DeptId,
                EmpCode = dto.EmpCode,
                EmpName = dto.EmpName,
                Gender = dto.Gender,
                Position = dto.Position,
                EmpType = dto.EmpType,
                Phone = dto.Phone,
                Email = dto.Email,
                MessengerId = dto.MessengerId,
                Memo = dto.Memo,
                Photo = dto.Photo,
                EmpId = dto.EmpId,
            };
            // 수정값 DB에 저장
            try
            {
                await new EmployeeRepository().UpdateAsync(entity);
            }
            // 유니크키 중복으로 Sql 에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 사원코드 중복시 메세지 담아 예외처리
                if (ex.Message.Contains("UQ_Employee_EmpCode"))
                {
                    throw new BusinessException("이미 사용중인 사원코드입니다.");
                }
                // 로그인Id 중복시 메세지 담아 예외처리
                else if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    throw new BusinessException("이미 존재하는 로그인ID입니다.");
                }
                // 그 외 중복 에러시 메세지 담아 예외처리
                throw new BusinessException("중복된 값이 존재합니다");
            }
            // 나머지 에러 발생시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("사원 수정 실패 EmpId=" + entity.EmpId, ex);
                throw;
            }
        }

        // 사원 삭제
        public async Task DeleteAsync(int empId)
        {
            try
            {
                await new EmployeeRepository().DeleteAsync(empId);
            }
            // 에러 발생시 로그 기록
            catch (System.Exception ex)
            {
                Logger.Instance.Error("사원 삭제 실패 EmpId=" + empId, ex);
                throw;
            }
        }

        // 로그인,비밀번호 수정
        public async Task LoginInfoEditAsync(string loginId, string password, int empId)
        {
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(loginId)) { throw new BusinessException("로그인ID를 입력해주세요."); }
            if (string.IsNullOrWhiteSpace(password)) { throw new BusinessException("비밀번호를 입력해주세요."); }

            // Rule에서 만든 비밀번호 규칙 넣기
            if (!ValidationRule.PasswordCheck(password)) { throw new BusinessException("비밀번호는 영문, 숫자 포함 8자 이상입니다."); }

            // 수정한 로그인정보 db에 저장
            try
            {
                await new EmployeeRepository().UpdateLoginInfoAsync(loginId, password, empId);
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 수정한 로그인ID가 중복일 경우 메세지 담아 예외처리
                if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    throw new BusinessException("이미 사용중인 로그인ID 입니다.");
                }
                // 그 외의 중복에러가 발생시 메세지 담아 예외처리
                throw new BusinessException("중복된 값이 있습니다.");
            }
            // 나머지 에러 발생시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("로그인 정보 수정 실패 EmpId=" + empId, ex);   
                throw;
            }
        }

        // 로그인 검사
        public async Task LoginAsync(string loginId, string password)
        {

            // 필수값 지정
            if (string.IsNullOrWhiteSpace(loginId)) { throw new BusinessException("ID를 입력해주세요."); }
            if (string.IsNullOrWhiteSpace(password)) { throw new BusinessException("비밀번호를 입력해주세요."); }

            // 입력한 로그인ID를 db에서 확인해 없으면 예외처리 메시지 담기, 비밀번호 확인 후 없으면 예외처리 메시지 담기
            var user = await new EmployeeRepository().LoginInfoAsync(loginId) ?? throw new BusinessException("존재하지않는 ID입니다.");
            if (user.Password != password) { throw new BusinessException("비밀번호가 정확하지 않습니다, 다시 시도해주세요"); }
        }

        // 사원 다중 추가
        public async Task MultiAddAsync(Worksheet sheet)
        {
            // 데이터입력 범위지정, 처음부터 입력한 행까지
            CellRange range = sheet.GetDataRange();
            // 시트에 입력한 컬럼 구조 데이트테이블에 넣기
            DataTable dt = sheet.CreateDataTable(range, true);
            // 만들어진 데이터테이블에 시트에 입력된 데이터 넣기
            DataTableExporter exporter = sheet.CreateDataTableExporter(range, dt, true);
            exporter.Export();

            // 아무값도 입력하지 않을시 메세지 담아 예외처리
            if (dt.Rows.Count == 0) { throw new BusinessException("입력된 데이터가 없습니다."); }

            // 필수값 지정, dt에 받은 행을 한줄씩 확인
            var dept = await new DepartmentRepository().GetAllAsync();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int row = i + 2;
                
                // 필수값 지정
                if (string.IsNullOrWhiteSpace(dr["부서코드"].ToString())) { throw new BusinessException(row + "행의 부서코드를 입력해주세요."); }
                if (string.IsNullOrWhiteSpace(dr["사원코드"].ToString())) { throw new BusinessException(row + "행의 사원코드를 입력해주세요."); }
                if (string.IsNullOrWhiteSpace(dr["사원명"].ToString())) { throw new BusinessException(row + "행의 사원명을 입력해주세요."); }
                if (string.IsNullOrWhiteSpace(dr["로그인ID"].ToString())) { throw new BusinessException(row + "행의 로그인ID를 입력해주세요."); }
                if (string.IsNullOrWhiteSpace(dr["비밀번호"].ToString())) { throw new BusinessException(row + "행의 비밀번호를 입력해주세요."); }

                // 부서db에 존재하지않는 사원코드 입력시 메세지 담아 예외처리
                if (!dept.Any(d => d.DeptCode == dr["부서코드"].ToString())) { throw new BusinessException(row + "행의 부서코드는 존재하지않습니다."); }
                // 비밀번호 및 이메일 규칙
                if (!ValidationRule.PasswordCheck(dr["비밀번호"].ToString())) { throw new BusinessException(row + "행의 비밀번호를 다시 입력해주세요. 숫자, 영문포함 8자리 이상입니다."); }
                if (!string.IsNullOrWhiteSpace(dr["이메일"].ToString()) && !ValidationRule.EmailCheck(dr["이메일"].ToString())) 
                { 
                    throw new BusinessException(row + "행의 이메일을 다시 입력해주세요. \n"); 
                }
                // 휴대전화 하이폰 규칙
                if (!string.IsNullOrWhiteSpace(dr["휴대전화"].ToString()))
                {
                    dr["휴대전화"] = ValidationRule.PhoneRule(dr["휴대전화"].ToString());
                }
            }

            // db에 입력한 사원정보 저장
            try
            {
                await new EmployeeRepository().SaveSheetAsync(dt);
                sheet.Clear(range.Offset(1, 0));
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 로그인ID 중복시 메세지 담아 예외처리
                if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    throw new BusinessException("이미 존재하는 로그인ID가 있습니다");
                }
                // 사원코드 중복시 메세지 담아 예외처리
                else if (ex.Message.Contains("UQ_Employee_EmpCode"))
                {
                    throw new BusinessException("이미 존재하는 사원코드가 있습니다.");
                }
                // 그 외 중복값 발생시 메세지 담아 예외처리
                throw new BusinessException("중복된 값이 존재합니다.");
            }
            // 나머지 에러 발생시 로그 기록
            catch (System.Exception ex)
            {
                Logger.Instance.Error("다중 사원 추가 저장 실패", ex);
                throw;
            }
        }
    }
}
