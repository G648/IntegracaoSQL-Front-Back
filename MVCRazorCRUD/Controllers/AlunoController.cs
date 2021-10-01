using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRazorCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Controllers
{
    //o controller recebe as requisições WEB
    [Route ("Aluno")]

    public class AlunoController : Controller 
    {
        //criando o método para receber uma ação
        //e encaminhar para a view
        public IActionResult Index()
        {
            return View();
        }

        [Route ("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection formulario)
        {
            Aluno aluno = new Aluno();

            //vamos receber os dados do formulário
            aluno.Nome = formulario["alunoNome"];
            aluno.Email = formulario["alunoEmail"];
            aluno.Endereco = formulario["alunoEnd"];
            aluno.Telefone = formulario["alunoTel"];
            aluno.Escolaridade = formulario["alunoEsc"];

            aluno.CadastroAluno(aluno);

            return LocalRedirect("/");
        }
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {    
            return View();
        }
    }
}
