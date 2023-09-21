using apiweb.eventplus.Domains;

namespace apiweb.eventplus.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Cadastrar(TiposEvento tipoEvento);

        void Deletar(Guid id);

        List<TiposEvento> Listar();

        TiposEvento BuscarPorId (Guid id);

        void Atualizar(Guid id, TiposEvento tipoEvento);
    }
}
