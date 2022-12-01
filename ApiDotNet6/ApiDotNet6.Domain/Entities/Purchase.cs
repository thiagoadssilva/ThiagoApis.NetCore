using ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }

        // INICIO - Atributo que vão fazer o relacionamento entre as classes.
        public Person Person { get; set; }
        public Product Product { get; set; }
        // FIM - Atributo que vão fazer o relacionamento entre as classes.

        public Purchase(int productId, int personId) // Construtor que vai ser chamando quando for a hora de ADICIONAR uma pessoa
        {
            Validation(productId, personId);        
        }

        public Purchase(int id, int productId, int personId) // Construtor que vai ser chamando quando for a hora de EDITAR uma pessoa
        {
            DomainValidationException.when(id <= 0, "Id tem que ser informado");
            id = id;
            Validation(productId, personId);
        }

        public void Edit(int id, int productId, int personId) // Construtor que vai ser chamando quando for a hora de EDITAR uma pessoa
        {
            DomainValidationException.when(id <= 0, "Id tem que ser informado");
            id = id;
            Validation(productId, personId);
        }

        private void Validation(int productId, int personId) 
        {
            DomainValidationException.when(productId <= 0, "Id produto tem que ser informado");
            DomainValidationException.when(personId <= 0, "Id pessoa tem que ser informado");

            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}
