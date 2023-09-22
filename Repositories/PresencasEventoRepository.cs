using apiweb.eventplus.Contexts;
using apiweb.eventplus.Domains;
using apiweb.eventplus.Interfaces;

namespace apiweb.eventplus.Repositories
{
    public class PresencasEventoRepository : IPresencasEvento
    {
        private readonly EventContext _eventContext;

        public PresencasEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, PresencasEvento presencasEvento)
        {
            PresencasEvento presenca = _eventContext.PresencasEvento.Find(id)!;

            if (presenca != null)
            {
                presenca.Situacao = presencasEvento.Situacao;
            }

            _eventContext.Update(presenca!);

            _eventContext.SaveChanges();
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencasEvento presenca = _eventContext.PresencasEvento.Select(u => new PresencasEvento
                {
                    IdPresencaEvento = u.IdPresencaEvento,
                    Situacao = u.Situacao,
                    Usuario = new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Usuario!.Nome,
                    },
                    Evento = new Evento
                    {
                        IdEvento = u.IdEvento,
                        NomeEvento = u.Evento!.NomeEvento,
                        DataEvento = u.Evento.DataEvento
                    }
                }).FirstOrDefault(u => u.IdPresencaEvento == id)!;

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento.Add(presencasEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencasEvento presenca = _eventContext.PresencasEvento.Find(id)!;

            _eventContext.PresencasEvento.Remove(presenca);

            _eventContext.SaveChanges();
        }

        public List<PresencasEvento> ListarMinhas(Guid id)
        {
            return _eventContext.PresencasEvento.ToList();
        }
    }
}
