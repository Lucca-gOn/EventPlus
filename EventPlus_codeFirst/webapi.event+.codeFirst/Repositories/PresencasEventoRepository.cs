using webapi.event_.codeFirst.Contexts;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;

namespace webapi.event_.codeFirst.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencasEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencasEvento presencasEvento)
        {
            throw new NotImplementedException();
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento.Add(presencasEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Increver(PresencasEvento inscrever)
        {
            throw new NotImplementedException();
        }

        public List<PresencasEvento> Listar()
        {
            return _eventContext.PresencasEvento.ToList();
        }

        public List<PresencasEvento> ListarMeusEventos()
        {
            throw new NotImplementedException();
        }
    }
}
