using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancoCapgeminiApi.Data;
using BancoCapgeminiApi.Models;
using System.Linq;

namespace BancoCapgeminiApi.Repositories
{
    public class ClienteRepository
    {
        public static async Task<List<Cliente>> GetListAllAsync(DataContext context)
        {
            List<Cliente> clientes = await context
            .Clientes.ToListAsync();
            return clientes;
        }

        public static async Task<Cliente> GetClienteByIdAsync(DataContext context,
        int id)
        {
            Cliente cliente = await context.Clientes
            .FirstOrDefaultAsync(x => x.Id == id);

            return cliente;
        }
    }
}