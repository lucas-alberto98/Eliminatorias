using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CampeonatoController : Controller
    {
        CampeonatosModel campeonato = new CampeonatosModel();
        JogoModel jogoModel = new JogoModel();
        public IActionResult Index()
        {
            ViewBag.campeonatos = "a";

            List<Campeonato> campeonatos = campeonato.listaCampeonatos();
            ViewBag.campeonatos = campeonatos;

            
            return View();
        }

        public IActionResult Lista()
        {
            List<Campeonato> campeonatos = campeonato.listaCampeonatos();
            ViewBag.campeonatos = campeonatos;

            return View();

        }
        
        public IActionResult Editar(int id_campeonato)
        {
            JogoModel jogos = new JogoModel();
            TimeModel times = new TimeModel();
            ViewBag.times = times.Listar();
            ViewBag.id_campeonato = id_campeonato;

            List<Jogo> jogos_ = jogos.Listar(id_campeonato);
            

            var jogos__ = from b in jogos_
                          group b by b.N_Rodada.ToString() into g
                          select new Group<string, Jogo> { Key = g.Key, Values = g };

            ViewBag.jogos = jogos__;
            return View();
        }

        public IActionResult Tabela(int id_campeonato)
        {
            JogoModel jogos = new JogoModel();
            TimeModel times = new TimeModel();
            ViewBag.times = times.Listar();
            ViewBag.id_campeonato = id_campeonato;

            List<Jogo> jogos_ = jogos.Listar(id_campeonato);


            var jogos__ = from b in jogos_
                          group b by b.N_Rodada.ToString() into g
                          select new Group<string, Jogo> { Key = g.Key, Values = g };

            ViewBag.jogos = jogos__;
            return View();

        }

        public IActionResult Novo(string nome)
        {
            Campeonato obj = new Campeonato();
            obj.Nome = nome;
            campeonato.Cadastrar(obj);
            return Json(new { nome = nome, success = true });
        }

        public IActionResult NovoJogo(int id_campeonato, int vs1, int vs2)
        {

            Jogo jogo = new Jogo();

            jogo.Id_Campeonato = id_campeonato;
            jogo.Id_Time1 = vs1;
            jogo.Id_Time2 = vs2;
            jogo.N_Rodada = 1;

            jogoModel.Cadastrar(jogo);

            return Json(new { success = true, });
        }
    }
}