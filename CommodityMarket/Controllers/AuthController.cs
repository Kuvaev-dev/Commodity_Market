using CommodityMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace CommodityMarket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Nikita", "qwerty009" };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "val";
        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] User user)
        {
            var token = jwtAuthenticationManager.Authenticate(user.Username, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
