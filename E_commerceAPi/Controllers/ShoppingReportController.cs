﻿using E_commerceAPi.Dtoes;
using E_commerceAPi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceAPi.Controllers
{
    public class ShoppingReportController
    {
        [ApiController]
        [Route("[controller]")]
        public class ProductReportController : ControllerBase
        {
            private readonly E_commerceAPi.Services.ProductReportService _productreport;
            private readonly E_commerceAPi.Services.Response _response;

            public ProductReportController(E_commerceAPi.Services.ProductReportService productreport, E_commerceAPi.Services.Response response)
            {
                _productreport = productreport;
                _response = response;
            }


            [HttpGet("GetProduct")]
            public async Task<IActionResult> Get()
            {
                var data = await _productreport.GetAsync();
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpGet("GetAllProduct")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> GetAll()
            {
                var data = await _productreport.GetAllAsync();
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpGet("GetProductByName")]
            public async Task<IActionResult> GetbyNAme([FromQuery] int id)
            {
                var data = await _productreport.GetByIdAsync(id);
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpPost("Create")]
            public async Task<IActionResult> Create([FromQuery] ProductReportPostDto dto)
            {
                var check = _response.CheckState(dto);
                if (check != null) return check;
                var data = await _productreport.PostAsync(dto);
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpPut("PutProduct")]
            public async Task<IActionResult> Put([FromQuery] ProductReportPostDto dto)
            {
                var check = _response.CheckState(dto);
                if (check != null) return check;
                var data = await _productreport.PutAsync(dto);
                var response = _response.GetResponse(data);
                return response;
            }

            [HttpDelete("Delete")]
            public async Task<IActionResult> Create([FromQuery] int id)
            {
                var data = await _productreport.DeleteFakeAsync(id);

                IActionResult response;
                if (data)
                    response = _response.GetResponse("Succesful");
                else
                    response = _response.GetResponse("Failed");
                return response;
            }


            [HttpDelete("DeleteReal")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> DeleteREal([FromQuery] int id)
            {
                var data = await _productreport.DeleteFakeAsync(id);

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
