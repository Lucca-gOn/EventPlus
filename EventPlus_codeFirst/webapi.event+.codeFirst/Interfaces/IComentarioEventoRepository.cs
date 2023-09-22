using webapi.event_.codeFirst.Domains;

namespace webapi.event_.codeFirst.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentariosEvento novoComentario);

        void Deletar(Guid id);

        List<ComentariosEvento> Listar();

        ComentariosEvento BuscarPorId(Guid id);

    }
}
