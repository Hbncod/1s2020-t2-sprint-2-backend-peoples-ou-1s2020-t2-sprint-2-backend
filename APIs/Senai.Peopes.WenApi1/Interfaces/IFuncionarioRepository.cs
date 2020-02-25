using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        FuncionarioDomain BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(FuncionarioDomain funcionario);

        void Inserir(FuncionarioDomain funcionario);

        List<FuncionarioDomain> BuscarPorNome(string nome);
        
        
    }
}
