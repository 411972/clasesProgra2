using clase_27_8_BANCO.Entities;
using clase_27_8_BANCO.Repositories.Contracts;
using clase_27_8_BANCO.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_27_8_BANCO.Services
{
    public class ClientesService
    {
        private IClienteRepository _clienteRepository;

        public ClientesService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public List<Cliente> GetClientes()
        {
            return _clienteRepository.GetAll();
        }
    }
}
