using System;
using System.Threading.Tasks;
using BancoCapgeminiApi.Data;
using BancoCapgeminiApi.Models;
using BancoCapgeminiApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BancoCapgeminiApi.Controllers
{
    [ApiController]
    [Route("v1/contas")]
    public class ContaController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<double> Get([FromServices]DataContext context, int id)
        {
            return ContaRepository.GetSaldo(context, id);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Conta>> Post([FromServices]DataContext context, Conta model)
        {
            if (ModelState.IsValid)
            {
                double saldo = ContaRepository.GetSaldo(context, model.TitularId);
                model.Created_At = DateTime.Now;
                if (model.Tipo.Equals('d'))
                {
                    context.Contas.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else if (model.Tipo.Equals('s'))
                {
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
                    return BadRequest("tipo inválido");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
