using E_commerceAPi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using E_commerceAPi.Dtoes;
namespace E_commerceAPi.Controllers
{
    public class ShoppingController
    {
        [ApiController]
        [Route("[controller]")]
        public class ProductController : ControllerBase 
        {
            private readonly IProduct _product;
            private readonly Response _response;

            public ProductController(IProduct _product, Response _response)
            {
                _product = product;
                _response = response;
            }

            [HttpGet("GetProduct")]
            public async Task<IActionResult> Get()
            {
                var data = await _product.GetAsync();
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpGet("GetAllProduct")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> GetAll()
            {
                var data = await _product.GetAllAsync();
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpGet("GetCourseByName")]
            public async Task<IActionResult> GetbyNAme([FromQuery] string Name)
            {
                var data = await _product.GetByNameAsync(Name);
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpPost("Create")]
            public async Task<IActionResult> Create([FromQuery] ProductPostDto dto)
            {
                var check = _response.CheckState(dto);
                if (check != null) return check;
                var data = await _product.PostAsync(dto);
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpPut("PutCourse")]
            public async Task<IActionResult> Put([FromQuery] ProductPostDto dto)
            {
                var check = _response.CheckState(dto);
                if (check != null) return check;
                var data = await _product.PutAsync(dto);
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpDelete("Delete")]
            public async Task<IActionResult> Create([FromQuery] string Name)
            {
                var data = await _product.DeleteFakeAsync(Name);

                IActionResult response;
                if (data)
                    response = _response.GetResponse("Succesful");
                else
                    response = _response.GetResponse("Failed");
                return response;
            }


            [HttpDelete("DeleteReal")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> DeleteREal([FromQuery] string Name)
            {
                var data = await _product.DeleteFakeAsync(Name);

                IActionResult response;
                if (data)
                    response = _response.GetResponse("Succesful");
                else
                    response = _response.GetResponse("Failed");
                return response;
            }
        }
    }
}
