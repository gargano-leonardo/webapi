using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.ClienteData;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private IClienteData _clienteData;

        public ClientesController(IClienteData clienteData)
        {
            _clienteData = clienteData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetClientes()
        {
            return Ok(_clienteData.GetClientes());
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetCliente(Guid id)
        {
            var cliente = _clienteData.GetCliente(id);

            if (cliente != null)
            {
                return Ok(cliente);
            }

            return NotFound($"Id {id} não encontrado");

        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddCliente(Cliente cliente)
        {
            _clienteData.AddClientes(cliente);
            return Created(HttpContext.Request.Scheme +
                "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/"
                + cliente.Id,
                cliente);


        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteCliente(Guid id)
        {

            var cliente = _clienteData.GetCliente(id);

            if (cliente != null)
            {
                _clienteData.DeleteCliente(cliente);
                return Ok();
            }

            return NotFound($"Id {id} não encontrado");

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditCliente(Guid id, Cliente cliente)
        {

            var existecliente = _clienteData.GetCliente(id);

            if (existecliente != null)
            {
                cliente.Id = existecliente.Id;
                _clienteData.EditCliente(cliente);

            }

            return Ok(cliente);

        }

    }
}
