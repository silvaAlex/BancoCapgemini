using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancoCapgeminiApi.Data;
using BancoCapgeminiApi.Models;
using System.Linq;

namespace BancoCapgeminiApi.Repositories
{
    public class ContaRepository
    {
        public static double GetSaldo(DataContext context, int id)
        {
            List<Conta> contas = context
            .Contas.Include(x => x.Titular).Where(x => x.Titular.Id == id).ToList();

            double depositos = SomarPorTipo(contas, 'd');

            double saques = SomarPorTipo(contas, 's');

            double saldo = depositos - saques;

            return saldo > 0 ? saldo : 0;
        }

        static double SomarPorTipo(List<Conta> contas, char tipo)
        {
            return contas.Where(x => x.Tipo.Equals(tipo)).Sum(x => x.Moeda);
        }
    }
}