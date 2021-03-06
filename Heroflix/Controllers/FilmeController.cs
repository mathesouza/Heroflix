﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroflix.Controllers.Database;
using Heroflix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Heroflix.Controllers
{
    public class FilmeController : Controller
    {
        HeroflixContext _heroflixContext;
        public FilmeController(HeroflixContext heroflixContext)
        {
            _heroflixContext = heroflixContext;
        }
        // GET: Filme
        public ActionResult Index()
        {

            List<Filme> filmes = _heroflixContext.Filmes.ToList();

            return View(filmes);
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            List<Filme> filmes = _heroflixContext.Filmes.ToList();

            Filme filme = filmes.Where(f => f.Id == id).First();


            return View(filme);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filme Filme)
        {
            try
            {
                _heroflixContext.Add(Filme);
                _heroflixContext.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            List<Filme> filmes = _heroflixContext.Filmes.ToList();

            Filme filme = filmes.Where(f => f.Id == id).First();


            return View(filme);

        }

        // POST: Filme/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Filme FilmeNew)
        {
            try
            {
                List<Filme> filmes = _heroflixContext.Filmes.ToList();

                Filme filme = filmes.Where(f => f.Id == id).First();

                filme.AssistidoEm = FilmeNew.AssistidoEm;
                filme.Elenco = FilmeNew.Elenco;
                filme.Sinopse = FilmeNew.Sinopse;
                filme.UrlCapa = FilmeNew.UrlCapa;
                filme.Status = FilmeNew.Status;
                filme.Genero = FilmeNew.Genero;
                filme.Titulo = FilmeNew.Titulo;


                _heroflixContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int id)
        {
            List<Filme> filmes = _heroflixContext.Filmes.ToList();

            Filme filme = filmes.Where(f => f.Id == id).First();

            return View(filme);
        }

        // POST: Filme/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Filme Filme)
        {
            try
            {
                _heroflixContext.Remove(Filme);
                _heroflixContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public List<Filme> getFilmes()
        {
            List<Filme> Filmes = new List<Filme>();
            Filmes.Add(new Filme
            {
                Id = 1,
                UrlCapa = "http://statics.livrariacultura.net.br/products/capas_lg/509/42131509.jpg",
                Titulo = "Djanjo",
                Elenco = "DiCaprio, o negão foda e l'Jackson",
                Genero = "Aventura, drama",
                Status = Models.Enums.StatusFilme.Assistido,
                Sinopse = "Escravo Livre",
                AssistidoEm = DateTime.Now
            });

            Filmes.Add(new Filme
            {
                Id = 2,
                Titulo = "Djanjo",
                Elenco = "DiCaprio, o negão foda e l'Jackson",
                Genero = "Aventura, drama",
                Status = Models.Enums.StatusFilme.Assistido,
                Sinopse = "Escravo Livre",
                AssistidoEm = DateTime.Now
            });

            Filmes.Add(new Filme
            {
                Id = 3,
                Titulo = "Os Incriveis",
                Elenco = "GELADO",
                Genero = "Aventura,comedia, animação",
                Status = Models.Enums.StatusFilme.Planejado,
                Sinopse = "Hérois fodas",
            });

            Filmes.Add(new Filme
            {
                Id = 4,
                Titulo = "Djanjo",
                Elenco = "DiCaprio, o negão foda e l'Jackson",
                Genero = "Aventura, drama",
                Status = Models.Enums.StatusFilme.Assistido,
                Sinopse = "Escravo Livre",
                AssistidoEm = DateTime.Now
            });

            Filmes.Add(new Filme
            {
                Id = 5,
                Titulo = "PulpFiction",
                Elenco = "Travolta e l'Jackson",
                Genero = "Aventura, drama",
                Status = Models.Enums.StatusFilme.Assistido,
                Sinopse = "Tempos de violencia",
                AssistidoEm = DateTime.Now
            });

            return Filmes;
        }
    }
}