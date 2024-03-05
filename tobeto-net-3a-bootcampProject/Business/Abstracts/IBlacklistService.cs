using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Core.Utilities.Results;


namespace Business.Abstracts
{
    public interface IBlacklistService
    {
        Task<IDataResult<CreateBlacklistResponse>> AddAsync(CreateBlacklistRequest request);
        Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request);
        Task<IDataResult<DeleteBlacklistResponse>> DeleteAsync(DeleteBlacklistRequest request);
        Task<IDataResult<GetByIdBlacklistResponse>> GetByIdAsync(GetByIdBlacklistRequest request);
        Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync();
    }
}
