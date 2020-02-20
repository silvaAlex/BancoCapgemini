using System;
using System.Threading.Tasks;
using BancoCapgeminiApi.Data;
using BancoCapgeminiApi.Models;
using BancoCapgeminiApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BancoCapgeminiApi.Controllers
{
    [ApiController]
    [Route("api/saque")]
	public class SaqueController : ControllerBase
	{
		[HttpPost]
        [Route("")]
        public async Task<ActionResult<Conta>> Post([FromServices]DataContext context, Conta model)
        {
            if (ModelState.IsValid)
            {
				model.Created_At = DateTime.Now;
				model.Tipo = 's';

				double saldo = ContaRepository.GetSaldo(context, model.TitularId);
				if (saldo > 0 && saldo >= model.Moeda)
				{
					context.Contas.Add(model);
					await context.SaveChangesAsync();
					return model;
				}
				else
				{
					return BadRequest("saldo indiponível");
				}
			}
			else
            {
                return BadRequest(ModelState);
            }
		}
	}
}