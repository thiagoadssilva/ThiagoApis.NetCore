using System.ComponentModel.DataAnnotations;

namespace TreinamentoApi.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Idade { get; set; }
    }
}
