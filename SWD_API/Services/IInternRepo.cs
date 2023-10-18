using SWD_API.Payload.Response.Account;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IInternRepo
    {
        List<InternModel> GetAll();

        InternModel GetById(string id);

        Task<IList<GetAccountResponse>> GetInternListByWorkShiftDate(Guid teamLeaderId,string workShiftDate);
    }
}

