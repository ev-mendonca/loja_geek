using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Loja.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_usuarioService.Listar());
        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                if (id > 0)
                {
                    usuario = _usuarioService.Carregar(id);
                }
            }
            catch
            {
                TempData["msgErro"] = "Ocorreu um erro";
                return RedirectToAction("Index");
            }

            return View(usuario);

        }


        [HttpPost]
        public IActionResult Salvar(Usuario usuario)
        {
            try
            {
                if (usuario.ID == 0)
                {
                    _usuarioService.Criar(usuario);
                    TempData["msgSucesso"] = "Usuario criado com sucesso";
                }
                else
                {
                    _usuarioService.Atualizar(usuario);
                    TempData["msgSucesso"] = "Usuario atualizado com sucesso";
                }
            }
            catch
            {
                TempData["msgErro"] = "Um erro ocorreu";
            }

            return RedirectToAction("Index");
        }
    }
}
