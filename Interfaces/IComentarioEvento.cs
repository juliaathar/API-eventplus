using apiweb.eventplus.Domains;

namespace apiweb.eventplus.Interfaces
{
    public interface IComentarioEvento
    {
        void Comentar(ComentariosEvento comentario);

        List<ComentariosEvento> Listar();

        void Deletar(Guid id);

        ComentariosEvento BuscarPorId(Guid id);
    }
}
