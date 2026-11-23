using DevExpress.Data.Async;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Entity;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Services
{
    internal class ParentService
    {
        private readonly ParentDepartmentRepository pdeptRepo = new ParentDepartmentRepository();
        private readonly DepartmentRepository deptRepo = new DepartmentRepository();

        // 상위부서 전체 조회
        public List<ParentDepartmentDto> GetAll()
        {
            try
            {
                return pdeptRepo.GetAll();
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("목록 조회 실패", ex);
                throw;
            }
        }

        // 상위부서 추가
        public void Add(ParentDepartmentDto dto)
        {
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(dto.ParentDeptCode)) { throw new BusinessException("상위부서코드는 필수기재사항입니다.");}
            if (string.IsNullOrWhiteSpace(dto.ParentDeptName)) { throw new BusinessException("상위부서명은 필수기재사항입니다.");}

            // Dto -> Entity로 변환
            var entity = new Entity.ParentDepartment
            {
                ParentDeptCode = dto.ParentDeptCode,
                ParentDeptName = dto.ParentDeptName,
                ParentMemo = dto.ParentMemo
            };
            // 레파지토리 호출 후 db저장
            try
            {
                pdeptRepo.Save(entity);
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 추가시 상위부서코드 중복일 경우 메시지 띄움
                if (ex.Message.Contains("UQ_ParentDeptCode"))
                {
                    throw new BusinessException("이미 존재하는 상위부서코드입니다.");
                }
                throw new BusinessException("중복된 값이 존재합니다.");
            }
            // 나머지 에러 예외처리 및 로그
            catch (Exception ex)
            {
                Logger.Instance.Error("상위부서 추가 실패", ex);
                throw;
            }
        }
        
        // 상위부서 수정 
        public void Edit(ParentDepartmentDto dto)
        {
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(dto.ParentDeptName)) { throw new BusinessException("상위부서명은 필수기재사항입니다."); }
            if (string.IsNullOrWhiteSpace(dto.ParentDeptCode)) { throw new BusinessException("상위부서코드는 필수기재사항입니다."); }

            // dto -> entity 변환
            var entity = new ParentDepartment
            {
                ParentDeptId = dto.ParentDeptId,
                ParentDeptCode = dto.ParentDeptCode,
                ParentDeptName = dto.ParentDeptName,
                ParentMemo = dto.ParentMemo
            };
            
            // 수정값 레파지토리 호출 후 db에 저장 
            try
            {
                pdeptRepo.Update(entity);
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 상위부서코드가 중복이면 메시지를 담아 BusinessException으로 던짐
                if (ex.Message.Contains("UQ_ParentDeptCode"))
                {
                    throw new BusinessException("이미 존재하는 상위부서코드입니다.");
                }
                // 그 외 중복값이 있을 경우 메시지를 담아 예외로 던짐
                throw new BusinessException("중복된 값이 존재합니다.");
            }
            // 나머지 에러 발생시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("상위부서 수정 실패 ParentDeptId=" + entity.ParentDeptId, ex);
                throw;
            }
        }

        public void Delete(int ParentDeptId)
        {
            // 소속된 부서가 있으면 삭제 불가, 메시지 담고 예외처리
            if (deptRepo.GetAll().Any(d => d.ParentDeptId == ParentDeptId))
            {
                throw new BusinessException("소속 부서가 존재하는 상위부서는 삭제할 수 없습니다.");
            }

            // 레파지토리 호출 후 상위부서 삭제
            try
            {
                pdeptRepo.Delete(ParentDeptId);
            }
            // 삭제 중 에러발생시 로그 기록
            catch (Exception ex)
            {
                Logger.Instance.Error("상위부서 삭제 실패 ParentDeptId =" + ParentDeptId, ex);
                throw;
            }
        }
    }
}
