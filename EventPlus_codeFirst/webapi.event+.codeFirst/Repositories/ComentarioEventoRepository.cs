using webapi.event_.codeFirst.Contexts;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;

namespace webapi.event_.codeFirst.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public ComentariosEvento BuscarPorId(Guid id)
        {
           return _eventContext.ComentariosEvento.FirstOrDefault(e => e.IdComentarioEvento == id)!;
        }

        public void Cadastrar(ComentariosEvento novoComentario)
        {
            _eventContext.Add(novoComentario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.ComentariosEvento.Where(e => e.IdComentarioEvento == id);

            _eventContext.SaveChanges();
        }

        public List<ComentariosEvento> Listar()
        {
            return _eventContext.ComentariosEvento.ToList();
        }
    }
}
