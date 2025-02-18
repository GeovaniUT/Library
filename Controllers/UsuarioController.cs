using Biblioteca_Guzman_Geovani.Models.Domain;
using Biblioteca_Guzman_Geovani.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Biblioteca_Guzman_Geovani.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) {

            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {
            var result = _usuarioService.ObtenerUsuarios();
            return View(result);
        }

        [HttpGet]
        public IActionResult Crear () {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario request) { 
        
            _usuarioService.CrearUsuario(request);

            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public IActionResult Editar(int id)
        {
            Usuario usuario = _usuarioService.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar2(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                bool resultado = _usuarioService.EditarUsuario(usuario);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Error al editar el usuario.");
            }

            return View("/Views/Usuario/Editar.cshtml", usuario);
        }

       
        public IActionResult Eliminar(int id)
        {
            var usuario = _usuarioService.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return PartialView("Eliminar", usuario); 
        }

       
        [HttpPost]
        public IActionResult EliminarUsuario(int id)
        {
            bool eliminado = _usuarioService.EliminarUsuario(id);

            if (!eliminado)
            {
                return NotFound(); 
            }

            return RedirectToAction("Index"); 
        }
    }



}

