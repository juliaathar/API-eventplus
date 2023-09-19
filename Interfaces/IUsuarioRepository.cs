using apiweb.eventplus.Domains;

namespace apiweb.eventplus.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha (string email, string senha);
    }
}
