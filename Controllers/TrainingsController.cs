using application_api.Models;
using application_api.Response;
using application_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace application_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ApiController
    {
        private readonly ITrainingsService _trainingsService;

        public TrainingsController(ITrainingsService trainingsService)
        {
            _trainingsService = trainingsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            ActionResponse.Success(HttpStatusCode.OK, await _trainingsService.GetAsync().ConfigureAwait(false), "get");


        [HttpPost]
        public async Task<IActionResult> Create(Training training) =>
            OkOrError(await _trainingsService.CreateAsync(training).ConfigureAwait(false), "create");


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Training training) =>
            OkOrError(await _trainingsService.UpdateAsync(id, training).ConfigureAwait(false), "update");


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            OkOrError(await _trainingsService.DeleteAsync(id).ConfigureAwait(false), "delete");
    }
}
