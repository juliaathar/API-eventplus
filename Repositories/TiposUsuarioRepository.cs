using apiweb.eventplus.Contexts;
using apiweb.eventplus.Domains;
using apiweb.eventplus.Interfaces;

namespace apiweb.eventplus.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            TiposUsuario tipoBuscado = _eventContext.TiposUsuario.Find(id)!;

            if (tipoBuscado == null)
            {
                tipoBuscado.Titulo = tipoUsuario.Titulo;
            }

            _eventContext.TiposUsuario.Update(tipoBuscado!);

            _eventContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            TiposUsuario tipo
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TiposUsuario> Listar()
        {
            
        }
    }
}
