using ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Entities
{
    /*
        sealed - Não permite que essa classe seja herdada em outro projeto
     */
    public class Person 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        // INICIO - Atributo de ligação com a tabela de compras
        public ICollection<Purchase> Purchases { get; set; } // Aqui vai conter uma coleção de compras
        // FIM - Atributo de ligação com a tabela de compras

        public Person(string document, string name, string phone) // Construtor que vai ser chamando quando for a hora de ADICIONAR uma pessoa
        {
            Validation(document, name, phone);
            Purchases = new List<Purchase>();
        }

        public Person(int id, string document, string name, string phone) // Construtor que vai ser chamando quando for a hora de EDITAR uma pessoa
        {
            DomainValidationException.when(id < 0, "Id deve ser maior que 0");
            Id = id;
            Validation(document, name, phone);
            Purchases = new List<Purchase>();
        }

        private void Validation(string document, string name, string phone) {
            // Função que vai está validando os atributos pasados como parametros.
            DomainValidationException.when(string.IsNullOrEmpty(document), "Documento tem que ser informado");
            DomainValidationException.when(string.IsNullOrEmpty(name), "Nome tem que ser informado");
            DomainValidationException.when(string.IsNullOrEmpty(phone), "Celular tem que ser informado");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
