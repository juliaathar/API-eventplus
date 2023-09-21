using apiweb.eventplus.Domains;

namespace apiweb.eventplus.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);

        void Deletar(Guid id);

        List<Evento> Listar();

        Evento BuscarPorId(Guid id);

        void Atualizar(Guid id, Evento evento);
    }
}
