using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace WebApplicationApi.ClienteData
{
    public class SqLClienteData : IClienteData
    {

        private ClienteContext _clienteContext;


        public SqLClienteData(ClienteContext clienteContext)
        {
            _clienteContext = clienteContext;
        }


        public Cliente AddClientes(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            _clienteContext.Clientes.Add(cliente);
            _clienteContext.SaveChanges();
            return cliente;
        }

        public void DeleteCliente(Cliente cliente)
        {
            _clienteContext.Clientes.Remove(cliente);
            _clienteContext.SaveChanges();
        }

        public Cliente EditCliente(Cliente cliente)
        {
            var existecliente = _clienteContext.Clientes.Find(cliente.Id);
            if (existecliente != null)
            {
                existecliente.Name = cliente.Name;
                existecliente.Endereco = cliente.Endereco;
                _clienteContext.Clientes.Update(existecliente);
                _clienteContext.SaveChanges();
            }

            return cliente;
        }

        public Cliente GetCliente(Guid id)
        {
            var cliente = _clienteContext.Clientes.Find(id);
            return cliente;
        }

        public List<Cliente> GetClientes()
        {
            return _clienteContext.Clientes.ToList();
        }
    }
}
