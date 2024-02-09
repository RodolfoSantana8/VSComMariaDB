using System.ComponentModel.DataAnnotations;

namespace VSComMariaDB.Model
{
    public class Pessoa
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(15)]
        public string? NumeroCelular { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
