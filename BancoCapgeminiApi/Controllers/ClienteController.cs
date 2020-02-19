using System.Collections.Generic;
using System.Threading.Tasks;
using BancoCapgeminiApi.Data;
using BancoCapgeminiApi.Models;
using BancoCapgeminiApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BancoCapgeminiApi.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClietneController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices]DataContext context)
        {
            return await ClienteRepository.GetListAllAsync(context);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Get([FromServices]DataContext context, int id){
            return await ClienteRepository.GetClienteByIdAsync(context,id);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post([FromServices]DataContext context, Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}