

using System;
using System.Threading.Tasks;
using BancoCapgeminiApi.Data;
using BancoCapgeminiApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancoCapgeminiApi.Controllers
{
    [ApiController]
    [Route("api/deposito")]
	public class DepositoController : ControllerBase
	{
		[HttpPost]
        [Route("")]
        public async Task<ActionResult<Conta>> Post([FromServices]DataContext context, Conta model)
        {
            if (ModelState.IsValid)
            {
                model.Created_At = DateTime.Now;
				model.Tipo = 'd';

                context.Contas.Add(model);
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