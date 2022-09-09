using application_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Delegate = application_api.Models.Delegate;
using System.Threading.Tasks;
using System.Net;
using application_api.Response;

namespace application_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegatesController : ApiController
    {
        private readonly IDelegateService _delegateService;

        public DelegatesController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            ActionResponse.Success(HttpStatusCode.OK, await _delegateService.GetAsync().ConfigureAwait(false), "get");


        [HttpPost]
        public async Task<IActionResult> Create(Delegate delegateSelected) =>
            OkOrError(await _delegateService.CreateAsync(delegateSelected).ConfigureAwait(false), "create");


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Delegate delegateSelected) =>
            OkOrError(await _delegateService.UpdateAsync(id, delegateSelected).ConfigureAwait(false), "update");


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            OkOrError(await _delegateService.DeleteAsync(id).ConfigureAwait(false), "delete");
    }
}
