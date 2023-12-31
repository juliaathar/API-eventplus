﻿using apiweb.eventplus.Contexts;
using apiweb.eventplus.Domains;
using apiweb.eventplus.Interfaces;
using apiweb.eventplus.Utils;

namespace apiweb.eventplus.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuario = _eventContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario= u.IdTipoUsuario,
                        Titulo = u.TiposUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.Email == email)!;

                if (usuario != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuario.Senha!);

                    if (confere)
                    {
                        return usuario;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                //_eventContext.Usuario.Include().FirstOrDefault(u => u.IdTipoUsuario == id);
                Usuario usuario = _eventContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email= u.Email,
                    Senha= u.Senha,
                    TiposUsuario = new TiposUsuario
                    {
                        Titulo = u.TiposUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                if(usuario != null)
                {
                    return usuario;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
