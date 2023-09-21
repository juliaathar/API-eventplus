using apiweb.eventplus.Domains;

namespace apiweb.eventplus.Interfaces
{
    public interface IPresencasEvento
    {
        void Cadastrar(PresencasEvento presencasEvento);

        void Deletar(Guid id);

        List<PresencasEvento> ListarMinhas(Guid id);

        PresencasEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, PresencasEvento presencasEvento);

    }
}
