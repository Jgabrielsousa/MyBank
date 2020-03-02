using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBank.Transfers.Domain;
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

   
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpGet("GetByAccountId/{id}")]
        public IActionResult GetByAccountId(int id)
        {
            try
            {
                return Ok(_service.GetByAccountId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Credit")]
        public async  Task<IActionResult> Credit([FromBody] TransferDto tranfer)
        {
            try
            {
                var debitok = await  _service.Debt(tranfer);
                if ((bool)debitok.Data) {
                    return Ok(await _service.Credit(tranfer));
                }
                return Ok(debitok);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
