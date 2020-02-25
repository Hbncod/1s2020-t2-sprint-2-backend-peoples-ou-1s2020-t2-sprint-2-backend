using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
             FuncionarioDomain funcionario = _funcionarioRepository.BuscarPorId(id);
            return Ok($"Nome : {funcionario.Nome} {funcionario.Sobrenome}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FuncionarioDomain funcionarioExiste = _funcionarioRepository.BuscarPorId(id);
            if (funcionarioExiste == null)
            {
                return Ok("Funcionario Não encontrado");
            }
            else
            {
                _funcionarioRepository.Deletar(id);
                return Ok("Funcionario deletado");
            }

        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, FuncionarioDomain funcionario)
        {
            funcionario.Id = id;
            FuncionarioDomain funcionarioExiste = _funcionarioRepository.BuscarPorId(funcionario.Id);
            if (funcionarioExiste == null)
            {
                return Ok("Funcionario Não encontrado");
            }
            else
            {
                _funcionarioRepository.Atualizar(funcionario);
                return Ok("Dados Atualizados");
            }

        }
        [HttpPost]
        public IActionResult Inserir(FuncionarioDomain funcionario)
        {
            _funcionarioRepository.Inserir(funcionario);

            return Ok("Funcionario Inserido");
        }
        [HttpPost("{nome}")]
        public IEnumerable<FuncionarioDomain> PostNome(string nome)
        {
            
            return _funcionarioRepository.BuscarPorNome(nome);
        }
        
    }
}
