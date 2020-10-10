using MaquinaDeTroco.Data;
using MaquinaDeTroco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MaquinaDeTroco.Controllers
{
    [Route("caixa")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Caixa>> GetById([FromServices] DataContext context, int id)
        {
            var caixa = await context.Caixas.Include(x => x.Ativo).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return caixa;
        }

    }
}
