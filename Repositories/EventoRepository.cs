using apiweb.eventplus.Contexts;
using apiweb.eventplus.Domains;
using apiweb.eventplus.Interfaces;

namespace apiweb.eventplus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            Evento tipo = _eventContext.Evento.Find(id)!;

            if (tipo != null)
            {
                tipo.Titulo = evento.Descricao!;
            }

            _eventContext.Evento.Update(tipo!);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento tipo = _eventContext.Evento.Select(u => new Evento
                {
                    IdEvento = u.IdEvento,
                    
                })
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
