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
                var itens = _service.GetAll();
                return Ok(itens);
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
                var itens = _service.GetByAccountId(id);
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Credit")]
        public IActionResult Credit([FromBody] TransferDto tranfer)
        {
            try
            {
                _service.Credit(tranfer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Debit")]
        public IActionResult Debit([FromBody] TransferDto tranfer)
        {
            try
            {
                _service.Debt(tranfer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
