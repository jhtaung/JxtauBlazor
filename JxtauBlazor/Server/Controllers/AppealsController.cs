using JxtauBlazor.Server.Extensions;
using JxtauBlazor.Server.Interfaces;
using JxtauBlazor.Shared.Models;
using JxtauBlazor.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace JxtauBlazor.Server.Controllers
{
    public class AppealsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppealsController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<AppealListDto>>> Get([FromQuery]AppealParams appealParams)
        {
            var appeals = await _unitOfWork.AppealRepo.GetListAsync(appealParams);
            Response.AddPageHeader(appeals.CurrentPage, appeals.PageSize, appeals.TotalCount, appeals.TotalPages);
            return Ok(appeals);
        }
    }
}