using apiweb.eventplus.Contexts;
using apiweb.eventplus.Domains;
using apiweb.eventplus.Interfaces;

namespace apiweb.eventplus.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;
        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            TiposEvento tipoBuscado =  _eventContext.TiposEventos.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoEvento.Titulo!;
            }

            _eventContext.TiposEventos.Update(tipoBuscado!);

            _eventContext.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            try
            {
                TiposEvento tipoEvento = _eventContext.TiposEventos.Select(u => new TiposEvento
                {
                    IdTipoEvento = u.IdTipoEvento,
                    Titulo = u.Titulo
                }).FirstOrDefault(u => u.IdTipoEvento == id)!;

                if (tipoEvento != null)
                {
                    return tipoEvento;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
            _eventContext.TiposEventos.Add(tipoEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tipo = _eventContext.TiposEventos.Find(id)!;

            _eventContext.TiposEventos.Remove(tipo);

            _eventContext.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return _eventContext.TiposEventos.ToList();
        }
    }
}
