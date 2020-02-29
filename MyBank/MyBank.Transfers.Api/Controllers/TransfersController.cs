using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBank.Transfers.Domain.Interfaces;

namespace MyBank.Transfers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransfersController : ControllerBase
    {


        private readonly IFinancialControlService _service;
        public TransfersController(IFinancialControlService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itens = _service.GetAll();
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
