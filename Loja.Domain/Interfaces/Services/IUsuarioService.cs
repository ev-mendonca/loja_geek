using Loja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        void Criar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(int id);
        Usuario Carregar(int id);
        IList<Usuario> Listar();

    }
}
