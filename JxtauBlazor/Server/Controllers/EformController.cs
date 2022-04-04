using JxtauBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace JxtauBlazor.Server.Controllers
{
    public class EformController : BaseController
    {
        private readonly HttpClient _httpClient;

        public EformController(HttpClient httpClient) 
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://hondaati1.mpidom.mpi/");
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Authorization, "Bearer c91fba83-6ad9-4d8b-9a72-f2db322efe88");
        }

        [HttpGet("Users")]
        public async Task<ActionResult<EformResponse>> GetUsers()
        {
            var eformUsers = await _httpClient.GetFromJsonAsync<EformUsers>("manage/api/v1/admin/users");

            if (eformUsers == null) {
                return BadRequest();
            } else if (eformUsers.value == null) {
                return BadRequest();
            }

            var userList = new List<EformUser>() { };
            foreach (var eformUser in eformUsers.value) {
                userList.Add(new EformUser() { 
                    Id = eformUser.id,
                    Username = eformUser.username,
                    FirstName = eformUser.firstName,
                    LastName = eformUser.lastName,
                    Disabled = eformUser.disabled
                });
            }

            return Ok(new EformResponse() { 
                Data = userList,
                NextLink = eformUsers.NextLink
            });
        }
    }
}
