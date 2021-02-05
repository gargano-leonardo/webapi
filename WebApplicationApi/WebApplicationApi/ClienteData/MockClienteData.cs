
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationApi.Models;

namespace WebApplicationApi.ClienteData
{
    public class MockClienteData : IClienteData
    {


        private List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente()
            {
                Id = Guid.NewGuid(),
                Name = "Employee One",
                Endereco = "Rua matiola"
            },
            new Cliente()
            {
                Id = Guid.NewGuid(),
                Name = "Employee Two",
                Endereco = "Rua nossa senhora"
            },
        };


        public Cliente AddClientes(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            clientes.Add(cliente);

            return cliente;
        }

        public void DeleteCliente(Cliente cliente)
        {
            clientes.Remove(cliente);
        }

        public Cliente EditCliente(Cliente cliente)
        {
            var existecliente = GetCliente(cliente.Id);
            existecliente.Name = cliente.Name;
            existecliente.Endereco = cliente.Endereco;
            return existecliente;
        }

        public Cliente GetCliente(Guid id)
        {
            return clientes.SingleOrDefault(x => x.Id == id);
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }
    }
}
