using ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Coderp { get; private set; }
        public decimal Price { get; private set; }

        // INICIO - Atributo de ligação com a tabela de compras
        public ICollection<Purchase> Purchases { get; set; } // Aqui vai conter uma coleção de compras
        // FIM - Atributo de ligação com a tabela de compras

        public Product(string name, string coderp, decimal price) // Construtor que vai ser chamando quando for a hora de ADICIONAR uma produto
        {
            Validation(name, coderp, price);
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string coderp, decimal price) // Construtor que vai ser chamando quando for a hora de EDITAR uma produto
        {
            DomainValidationException.when(id < 0, "Id tem que ser informado");
            Id = id;
            Validation(name, coderp, price);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string coderp, decimal price) 
        {
            DomainValidationException.when(string.IsNullOrEmpty(name), "Nome tem que ser informado");
            DomainValidationException.when(string.IsNullOrEmpty(coderp), "Código erp tem que ser informado");
            DomainValidationException.when(price < 0, "Preço tem que ser informado");

            Name = name;
            Coderp = coderp;
            Price = price;
        }
    }
}
