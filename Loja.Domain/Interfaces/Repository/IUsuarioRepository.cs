using Loja.Domain.Entities;
using System.Collections.Generic;

namespace Loja.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        void Salvar(Usuario usuario);
        void Remover(int id);
        Usuario Carregar(int id);
        IList<Usuario> Listar();

        Usuario CarregarPorEmail(string email);

        Usuario CarregarPorLogin(string login);
    }
}
