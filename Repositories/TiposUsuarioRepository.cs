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

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoUsuario.Titulo!;
            }

            _eventContext.TiposUsuario.Update(tipoBuscado!);

            _eventContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario tipoUsuario = _eventContext.TiposUsuario.Select(u => new TiposUsuario
                {
                    IdTipoUsuario = u.IdTipoUsuario,
                    Titulo = u.Titulo

                }).FirstOrDefault(u => u.IdTipoUsuario == id)!;

                if (tipoUsuario != null)
                {
                    return tipoUsuario;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tipoBuscado = _eventContext.TiposUsuario.Find(id)!;

            _eventContext.TiposUsuario.Remove(tipoBuscado);

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _eventContext.TiposUsuario.ToList();
        }
    }
}
