using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_API.Repositories;
using Core_API.Models;

namespace Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department, int> _deptServ;
        // Injection
        public DepartmentController(IRepository<Department, int> serv)
        {
            _deptServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var response = await _deptServ.GetAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var response = await _deptServ.GetAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Department entity)
        {
            try
            {
                var response = await _deptServ.CreateAsync(entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(int id,Department entity)
        {
            try
            {
                var response = await _deptServ.UpdateAsync(id,entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _deptServ.DeleteAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
