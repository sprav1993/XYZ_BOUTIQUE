using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XYZ.BOUTIQUE.Application.Dto;
using XYZ.BOUTIQUE.Application.Interface;

namespace XYZ.BOUTIQUE.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomersApplication _customersApplication;
        public CustomerController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region "Métodos Sincronos"
        [Authorize]
        [HttpPost]
        public IActionResult Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = _customersApplication.Insert(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = _customersApplication.Update(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [Authorize]
        [HttpDelete("{CustomerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = _customersApplication.Delete(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet("{CustomerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = _customersApplication.Get(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        #region Métodos Asincronos
        [Authorize]
        [HttpPost("async")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = await _customersApplication.InsertAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [Authorize]
        [HttpPut("async")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = await _customersApplication.UpdateAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpDelete("async/{CustomerId}")]

        //[HttpDelete("{CustomerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = await _customersApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet("async/{CustomerId}")]
        //[HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = await _customersApplication.GetAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        //[Authorize]
        [HttpGet("async")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion
    }
}
