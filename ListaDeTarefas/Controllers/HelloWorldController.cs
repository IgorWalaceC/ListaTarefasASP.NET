using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index(int id, string nome)
        {
            return "Olá Mundo! <br/> Meu nome é <b>" + nome + ", meu id é " + id + "</b>";
        }
        public string BemVindo()
        {
            return "Seja bem-vindo ao meu aplicativo";
        }
    }
}