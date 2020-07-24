using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repository;
using Loja.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SqlServerContext context) : base(context){}

        public void Remover(int id) => base.Remover(id);

        public void Salvar(Usuario usuario)
        {
            if (usuario.ID == 0)
                base.Criar(usuario);
            else
                base.Atualizar(usuario);
        }

        public Usuario Carregar(int id) => base.Carregar(id);

        public IList<Usuario> Listar() => base.Listar();

        public Usuario CarregarPorEmail(string email)
        {
            return _dbSet.Where(u => u.Email == email).SingleOrDefault();
        }

        public Usuario CarregarPorLogin(string login)
        {
            return _dbSet.Where(u => u.Login == login).SingleOrDefault();
        }
    }
}
