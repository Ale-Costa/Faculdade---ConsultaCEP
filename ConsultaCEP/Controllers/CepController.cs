using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConsultaCEP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;



namespace ConsultaCEP.Controllers
{
    public class CepController : Controller
    {
        private readonly Context _context;

         public CepController(Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Ceps.ToList());
        }

        public IActionResult ConsultarCep(CEP Ceps)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://viacep.com.br/ws/"+Ceps.Cep+"/json/");
            CEP cep = JsonConvert.DeserializeObject<CEP>(json);
            _context.Ceps.Add(cep);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}