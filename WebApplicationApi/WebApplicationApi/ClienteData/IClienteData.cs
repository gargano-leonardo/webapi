using System;
using System.Collections.Generic;
using WebApplicationApi.Models;

namespace WebApplicationApi.ClienteData
{
    public interface IClienteData
    {

        List<Cliente> GetClientes();

        Cliente GetCliente(Guid id);


        Cliente AddClientes(Cliente cliente);


        void DeleteCliente(Cliente cliente);

        Cliente EditCliente(Cliente cliente);


    }
}
