﻿using Abogado.Application;
using Abogado.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abogado.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsersServices services;

        private readonly IMemoryCache memoryCache;

        public UsuarioController(UsersServices services, IMemoryCache memoryCache)
        {
            this.services = services;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Permisos()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] Usuario usuario)
        {
            var us = await this.services.Login(usuario.Email, usuario.Password);

            memoryCache.Set("TIPO", us.TipoUsuario.GetHashCode());
            memoryCache.Set("MAIL", us.Email);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registrar()
        {   
            if (memoryCache.Get("TIPO") == null)
                return RedirectToAction("Index", "Home");
            else if (memoryCache.Get("TIPO").ToString() == "0")
                return View();

            return RedirectToAction("Permisos", "Usuario");
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(
            [Bind("Nombre,Apellido,Email,Password,TipoUsuario")]  Usuario usuario)
        {
            await this.services.Register(usuario.Nombre, usuario.Apellido,
                usuario.Email, usuario.Password, usuario.TipoUsuario);

            return RedirectToAction("Index", "Home");
        }
    }
}
