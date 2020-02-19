using System.ComponentModel.DataAnnotations;
using System;

namespace BancoCapgeminiApi.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Moeda deve ser maior do que 0.1")]
        public double Moeda { get; set; }

        ///
        ///Tipo s = saque or d = deposito
        //
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public char Tipo { get; set; }

        public DateTime? Created_At { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Titular inválido")]
        public int TitularId { get; set; }
        public Cliente Titular { get; set; }
    }
}
