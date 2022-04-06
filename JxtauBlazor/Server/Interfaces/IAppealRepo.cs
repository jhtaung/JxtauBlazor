using JxtauBlazor.Server.Helpers;
using JxtauBlazor.Shared.Models;
using JxtauBlazor.Shared.Params;

namespace JxtauBlazor.Server.Interfaces
{
    public interface IAppealRepo
    {
        Task<PageList<AppealListDto>> GetListAsync(AppealParams appealParams);
    }
}