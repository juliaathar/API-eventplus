using apiweb.eventplus.Contexts;
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
            throw new NotImplementedException();
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
                    TiposUsuario = new TiposUsuario
                    {
                        Titulo = u.TiposUsuario.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;
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
