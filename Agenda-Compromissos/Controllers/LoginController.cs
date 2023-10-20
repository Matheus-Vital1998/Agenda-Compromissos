using Agenda_Compromissos.Context;
using Agenda_Compromissos.Models;
using Agenda_Compromissos.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agenda_Compromissos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly Contexto _context;
        private readonly INotyfService _notyfService;

        public LoginController(ILogger<LoginController> logger, Contexto context, INotyfService notyfService)
        {
            _logger = logger;
            _context = context;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuario.FirstOrDefault(x => x.Login == usuario.Login);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "Usuário não cadastrado";
                }
                else if (user.Senha != usuario.Senha)
                {
                    TempData["ErrorMessage"] = "Credenciais inválidas!";
                }
                else
                {
                    return RedirectToAction("Index", "Compromisso");
                }
            }

            else
            {
                TempData["ValidationErrors"] = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault(); 
            }

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarUsuario([Bind("Id,Nome,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}