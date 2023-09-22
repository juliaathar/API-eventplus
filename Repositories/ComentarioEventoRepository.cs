using apiweb.eventplus.Contexts;
using apiweb.eventplus.Domains;
using apiweb.eventplus.Interfaces;

namespace apiweb.eventplus.Repositories
{
    public class ComentarioEventoRepository : IComentarioEvento
    {
        private readonly EventContext _eventContext;

        ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public ComentariosEvento BuscarPorId(Guid id)
        {
            try
            {
                _eventContext.ComentariosEvento.Select(u => new ComentariosEvento
                {
                    IdComentario = u.IdComentario,
                    Descricao = u.Descricao,
                    Exibe = u.Exibe,
                    Usuario = new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Usuario!.Nome
                    },
                    Evento = new Evento
                    {
                        IdEvento = u.IdEvento,
                        NomeEvento = u.Evento!.NomeEvento
                    }
                }).FirstOrDefault(u => u.IdComentario == id);

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Comentar(ComentariosEvento comentario)
        {
            _eventContext.ComentariosEvento.Add(comentario);

            _eventContext.SaveChanges();
        }
        
        public void Deletar(Guid id)
        {
           ComentariosEvento comentario = _eventContext.ComentariosEvento.Find(id)!;

            _eventContext.ComentariosEvento.Remove(comentario);

            _eventContext.SaveChanges();
        }

        public List<ComentariosEvento> Listar()
        {
            return _eventContext.ComentariosEvento.ToList();
        }
    }
}
