using BancoCapgeminiApi.Data;
using BancoCapgeminiApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BancoCapgeminiApi.Controllers
{
    [ApiController]
    [Route("api/contas")]
    public class ContaController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<double> Get([FromServices]DataContext context, int id)
        {
            return ContaRepository.GetSaldo(context, id);
        }
    }
}
