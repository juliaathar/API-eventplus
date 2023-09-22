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
                tipo.Descricao = evento.Descricao!;
            }

            _eventContext.Evento.Update(tipo!);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento evento = _eventContext.Evento.Select(u => new Evento
                {
                    IdEvento = u.IdEvento,
                    NomeEvento= u.NomeEvento,
                    DataEvento = u.DataEvento,
                    Descricao = u.Descricao,
                    TiposEvento = new TiposEvento
                    {
                        IdTipoEvento = u.IdTipoEvento,
                        Titulo = u.TiposEvento!.Titulo
                    },
                    Instituicao = new Instituicao
                    {
                        Id = u.IdInstituicao
                    }
                }).FirstOrDefault(u => u.IdEvento == id)!;
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento evento = _eventContext.Evento.Find(id)!;

            _eventContext.Evento.Remove(evento);

            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
