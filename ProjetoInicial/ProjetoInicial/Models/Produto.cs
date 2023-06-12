using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace ProjetoInicial.Models
{
    public class Produto
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome { get; set; }

        [Range(0,99999999, ErrorMessage ="Informe um valor adequado")]
        public int Quantidade { get; set; }

        [Range(0.1,99999999, ErrorMessage ="Informe um preço adequado"), ]
        public double Preco { get; set; }

        public double ValorEstoqueTotal()
        {
            return Preco*Quantidade;
        }
    }
}
