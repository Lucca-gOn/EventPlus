using webapi.event_.codeFirst.Domains;

namespace webapi.event_.codeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);

    }
}
