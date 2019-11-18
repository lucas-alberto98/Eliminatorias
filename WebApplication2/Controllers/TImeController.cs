using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TimeController : Controller
    {
        TimeModel time = new TimeModel();
        public IActionResult Index()
        {
            ViewBag.Dados = "";
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Adicionar(string nome)
        {
            Console.WriteLine(nome);

            Time obj = new Time();
            obj.Nome = nome;
            time.Adicionar(obj);

            return Json( new { nome = nome, success = true });
        }
    }
}