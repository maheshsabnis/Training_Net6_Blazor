using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_API.Repositories;
using Core_API.Models;
using System.Net.Mime;

namespace Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department, int> _deptServ;
        // Injection
        public DepartmentController(IRepository<Department, int> serv)
        {
            _deptServ = serv;
        }
        /// <summary>
        /// OAS 3
        /// </summary>
        /// <returns></returns>
        [HttpGet("/getall")]
        public async Task<IEnumerable<Department>> GetAsync()
        {
            try
            {
                var response = await _deptServ.GetAsync();
                return response;
            }
            catch (Exception ex)
            {
                return new List<Department>();
            }
        }

        [HttpGet("getone/{id}")]
        public async Task<Department> GetAsync(int id)
        {
            try
            {
                var response = await _deptServ.GetAsync(id);
                return  response;
            }
            catch (Exception ex)
            {
                return new Department();
            }
        }
        // [HttpPost("{deptno}/{deptname}/{capacity}/{location}")]
        //public async Task<IActionResult> PostAsync([FromBody]Department entity)
        //public async Task<IActionResult> PostAsync([FromQuery] Department entity)
        // public async Task<IActionResult> PostAsync([FromRoute] Department entity)
        [HttpPost("/createone")]
        public async Task<Department> PostAsync(Department entity)
        {
            try
            {
                var response = await _deptServ.CreateAsync(entity);
                return response;
            }
            catch (Exception ex)
            {
                return new Department();
            }
        }
        [HttpPut("/update/{id}")]
        public async Task<Department> PutAsync(int id,Department entity)
        {
            try
            {
                var response = await _deptServ.UpdateAsync(id,entity);
                return  response;
            }
            catch (Exception ex)
            {
                return new Department();
            }
        }

        [HttpDelete("/delete/{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _deptServ.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


       
    }

     
}
