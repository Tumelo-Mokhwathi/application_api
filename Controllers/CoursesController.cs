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
    public class CoursesController : ApiController
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            ActionResponse.Success(HttpStatusCode.OK, await _coursesService.GetAsync().ConfigureAwait(false), "get");


        [HttpPost]
        public async Task<IActionResult> Create(ActiveCourse course) =>
            OkOrError(await _coursesService.CreateAsync(course).ConfigureAwait(false), "create");


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ActiveCourse course) =>
            OkOrError(await _coursesService.UpdateAsync(id, course).ConfigureAwait(false), "update");


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            OkOrError(await _coursesService.DeleteAsync(id).ConfigureAwait(false), "delete");
    }
}
