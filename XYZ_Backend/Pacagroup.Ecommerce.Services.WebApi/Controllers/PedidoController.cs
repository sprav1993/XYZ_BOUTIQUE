using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XYZ.BOUTIQUE.Application.Dto;
using XYZ.BOUTIQUE.Application.Interface;

namespace XYZ.BOUTIQUE.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedidosApplication _pedidosApplication;
        public PedidoController(IPedidosApplication pedidosApplication)
        {
            _pedidosApplication = pedidosApplication;
        }

        #region "Métodos Sincronos"
        [Authorize]
        [HttpPost]
        public IActionResult Insert([FromBody] PedidosDto pedidosDto)
        {
            if (pedidosDto == null)
            {
                return BadRequest();
            }
            var response = _pedidosApplication.Insert(pedidosDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] PedidosDto pedidosDto)
        {
            if (pedidosDto == null)
            {
                return BadRequest();
            }
            var response = _pedidosApplication.Update(pedidosDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [Authorize]
        [HttpDelete("{PedidoId}")]
        public IActionResult Delete(int pedidoId)
        {
            if (pedidoId == 0)
            {
                return BadRequest();
            }
            var response = _pedidosApplication.Delete(pedidoId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet("{PedidoId}")]
        public IActionResult Get(int pedidoId)
        {
            if (pedidoId == 0)
            {
                return BadRequest();
            }
            var response = _pedidosApplication.Get(pedidoId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _pedidosApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        #region Métodos Asincronos
        [Authorize]
        [HttpPost("async")]
        public async Task<IActionResult> InsertAsync([FromBody] PedidosDto pedidosDto)
        {
            if (pedidosDto == null)
            {
                return BadRequest();
            }
            var response = await _pedidosApplication.InsertAsync(pedidosDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [Authorize]
        [HttpPut("async")]
        public async Task<IActionResult> UpdateAsync([FromBody] PedidosDto pedidosDto)
        {
            if (pedidosDto == null)
            {
                return BadRequest();
            }
            var response = await _pedidosApplication.UpdateAsync(pedidosDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpDelete("async/{PedidoId}")]

        //[HttpDelete("{PedidoId}")]
        public async Task<IActionResult> DeleteAsync(int pedidoId)
        {
            if (pedidoId==0)
            {
                return BadRequest();
            }
            var response = await _pedidosApplication.DeleteAsync(pedidoId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet("async/{PedidoId}")]
        //[HttpGet("{PedidoId}")]
        public async Task<IActionResult> GetAsync(int pedidoId)
        {
            if (pedidoId == 0)
            {
                return BadRequest();
            }
            var response = await _pedidosApplication.GetAsync(pedidoId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        //[Authorize]
        [HttpGet("async")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _pedidosApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion
    }
}
