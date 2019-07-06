using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaCEP.Models;
using Microsoft.AspNetCore.Mvc;


namespace AppCep
{
    [Route("api/Endereco")]
    public class RestCepController : Controller
    {

        private readonly Context _context;

        public RestCepController(Context context)
        {
            _context = context;
        }

        [HttpGet("Enderecos")]
        public IEnumerable<CEP> GetAll()
        {
            List<CEP> ceps = _context.Ceps.ToList();
            return ceps;
        }


        [HttpGet("Enderecos/{cep}")]
        public IEnumerable<CEP> GetPorCep(string cep)
        {
            var ceps = _context.Ceps.Where(s => s.Cep == cep);
            return ceps;
        }

        [HttpGet("EnderecosPorEstado/{uf}")]
        public IEnumerable<CEP> GetPorEstado(string uf)
        {
            List<CEP> ceps = _context.Ceps.Where(s => s.Uf == uf).ToList();
            return ceps;
        }
    }
}
