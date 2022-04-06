using JxtauBlazor.Shared.Models;

namespace JxtauBlazor.Client.Interfaces
{
    public interface IAppealService
    {
        Task<IEnumerable<AppealListDto>> GetAppealList();
    }
}