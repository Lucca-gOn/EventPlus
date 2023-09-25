using webapi.event_.codeFirst.Domains;

namespace webapi.event_.codeFirst.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void Cadastrar(PresencasEvento presencasEvento);

        void Deletar(Guid id);

        List<PresencasEvento> Listar();

        PresencasEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, PresencasEvento presencasEvento);
        
        //uma lista para os meus eventos;
        List<PresencasEvento> ListarMeusEventos(Guid id);
    }
}
