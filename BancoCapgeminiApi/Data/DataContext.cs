using BancoCapgeminiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoCapgeminiApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }

    }
}