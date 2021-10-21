using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Seed;
using System;
using System.Threading.Tasks;
using static Excellerent.SharedModules.Seed.IAsyncRepository;

namespace Excellerent.SharedModules.Services
{
    public class CRUD<T1,T2> where T1: BaseEntity<T2> where T2:BaseAuditModel
    {
        private readonly IAsyncRepository<T2> _repository;
        public CRUD(IAsyncRepository<T2> repository)
        {
            _repository = repository;
        }
        public async Task<ResponseDTO> Add(T1 t)
        {
            try
            {
                await _repository.AddAsync(t.MapToModel());
                return _repository.GetResponseDTO(ResponseStatus.Success, t, "Added Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseDTO();
            }
        }
        public async Task<ResponseDTO> Update(T1 t) 
        {
            try
            {
                await this._repository.UpdateAsync(t.MapToModel());
                return new ResponseDTO();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseDTO();
            }
        }
        public async Task<ResponseDTO> Delete<T>(T1 t) 
        {
            try
            {
                await this._repository.DeleteAsync(t.MapToModel());
                return new ResponseDTO()
                {
                    ResponseStatus = ResponseStatus.Success,
                    Message = "DeleteSuccess"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseDTO();
            }
        }
    }
}
