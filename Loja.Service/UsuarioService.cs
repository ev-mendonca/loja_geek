using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repository;
using Loja.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Loja.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Atualizar(Usuario usuario)
        {
            var usuarioBd = Carregar(usuario.ID);

            if (usuarioBd == null)
                throw new System.Exception("Usuário informado não encontrado!");

            ValidarEmailUnico(usuario.Email, usuario.ID);
            
            usuarioBd.Email = usuario.Email;
            usuarioBd.Nome = usuario.Nome;
            
            _usuarioRepository.Salvar(usuarioBd);
        }

        public Usuario Carregar(int id) => _usuarioRepository.Carregar(id);

        public void Criar(Usuario usuario)
        {
            ValidarLoginUnico(usuario.Login);
            ValidarEmailUnico(usuario.Email, usuario.ID);
            _usuarioRepository.Salvar(usuario);
        }
        
        public IList<Usuario> Listar() => _usuarioRepository.Listar();

        public void Remover(int id) => _usuarioRepository.Remover(id);

        private void ValidarEmailUnico(string email, int usuarioID = 0)
        {
            Usuario usuarioBD = _usuarioRepository.CarregarPorEmail(email);
            if(usuarioBD != null && usuarioBD.ID != usuarioID)
                throw new System.Exception("O email informado já existe vinculado à outro usuário");
            
        }

        private void ValidarLoginUnico(string login)
        {
            Usuario usuarioBD = _usuarioRepository.CarregarPorLogin(login);
            if (usuarioBD != null)
                throw new System.Exception("O login informado já existe vinculado à outro usuário");
        }
    }
}
