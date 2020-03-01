using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBank.Accounts.Domain.Dtos;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Shared.Domain.Entities;

namespace MyBank.Accounts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountsController(IAccountService service)
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

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }


   
}
