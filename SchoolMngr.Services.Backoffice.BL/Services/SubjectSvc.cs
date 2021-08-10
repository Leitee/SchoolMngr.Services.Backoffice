
namespace Fitnner.Trainers.Catalog.BL.Services
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using Codeit.NetStdLibrary.Base.Abstractions.DataAccess;
    using Codeit.NetStdLibrary.Base.BusinessLogic;
    using Codeit.NetStdLibrary.Base.DataAccess;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using SchoolMngr.Services.Backoffice.BL.Abstractions;
    using SchoolMngr.Services.Backoffice.BL.Dtos;
    using SchoolMngr.Services.Backoffice.Model.Entities;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SubjectSvc : BaseService<Subject, SubjectDto>, ISubjectSvc
    {
        public SubjectSvc(
            IApplicationUow applicationUow, 
            ILoggerFactory loggerFactory, 
            IConfiguration configuration, 
            IMapperCore<Subject, SubjectDto> mapperCore
        )
            : base(applicationUow, loggerFactory, configuration, mapperCore)
        {

        }

        public async Task<IBLSingleResponse<Guid>> CreateAsync(SubjectDto pDto)
        {
            var response = new BLSingleResponse<Guid>();
            try
            {
                var entity = _mapper.Map(pDto);
                var result = await _uow.GetRepository<Subject>().InsertAsync(entity);
                await _uow.CommitAsync();
                response.Payload = result.Id;
            }
            catch (Exception ex)
            {
                throw HandleSVCException(ex);
            }

            return response;
        }

        public async Task<IBLSingleResponse<bool>> DeleteAsync(SubjectDto pDto)
        {
            var response = new BLSingleResponse<bool>();
            try
            {
                await _uow.GetRepository<Subject>().DeleteAsync(pDto.Id);
                response.Payload = await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw HandleSVCException(ex);
            }

            return response;
        }

        public async Task<IBLListResponse<SubjectDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = new BLListResponse<SubjectDto>();
            try
            {
                var result = await _uow.GetRepository<Subject>().AllAsync(null, null, cancellationToken, x => x.Include(s => s.Class));
                response.Payloads = _mapper.Map(result.ToList());
            }
            catch (Exception ex)
            {
                throw HandleSVCException(ex);
            }

            return response;
        }

        public async Task<IBLSingleResponse<SubjectDto>> GetByIdAsync(Guid pId)
        {
            var response = new BLSingleResponse<SubjectDto>();
            try
            {
                var entity = await _uow.GetRepository<Subject>().FindAsync(pId);
                response.Payload = _mapper.Map(entity);
            }
            catch (Exception ex)
            {
                throw HandleSVCException(ex);
            }

            return response;
        }

        public async Task<IBLSingleResponse<bool>> UpdateAsync(SubjectDto pDto)
        {
            var response = new BLSingleResponse<bool>();
            try
            {
                var entity = _mapper.Map(pDto);
                await _uow.GetRepository<Subject>().UpdateAsync(entity);   
                response.Payload = await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw HandleSVCException(ex);
            }

            return response;
        }

        public async Task<IBLListResponse<SubjectDto>> GetAllAsync(Guid fitnerId, CancellationToken cancellationToken)
        {
            var response = new BLListResponse<SubjectDto>();
            try
            {
                var result = await _uow.GetRepository<Subject>().AllAsync(x => x.NextAvailableId == fitnerId, null, cancellationToken, x => x.Include(s => s.Grade));
                response.Payloads = _mapper.Map(result.ToList());
            }
            catch (Exception ex)
            {
                throw HandleSVCException(ex);
            }

            return response;
        }
    }
}
