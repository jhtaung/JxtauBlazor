using JxtauBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;
using System.Security.Principal;

namespace JxtauBlazor.Server.Controllers
{
    public class UsersController : BaseController
    {
        [SupportedOSPlatform("windows")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            return await Task.Run(() => {
                // String name = WindowsIdentity.GetCurrent().Name.ToString();
                // var user = new UserDto() { Name = name };

                // WindowsIdentity identity = WindowsIdentity.GetCurrent();
                // SecurityIdentifier user = identity.User;
                string userName = WindowsIdentity.GetCurrent().Name;
                UserDto userDto = new UserDto()
                {
                    UserName = userName
                };

                return Ok(userDto);
            });
        }
    }
}
