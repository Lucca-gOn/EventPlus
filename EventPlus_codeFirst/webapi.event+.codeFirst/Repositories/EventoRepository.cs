using Microsoft.EntityFrameworkCore;
using webapi.event_.codeFirst.Contexts;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;

namespace webapi.event_.codeFirst.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento buscarEvento = _eventContext.Evento.Find(id)!;
            if (buscarEvento != null)
            {
                buscarEvento.DataEvento = evento.DataEvento;
                buscarEvento.NomeEvento = evento.NomeEvento;
                buscarEvento.Descricao = evento.Descricao;
                buscarEvento.Instituicao = evento.Instituicao;
                buscarEvento.IdTipoEvento = evento.IdTipoEvento;
            }
            _eventContext.Update(buscarEvento);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.Evento.Where(e => e.IdEvento == id).ExecuteDelete();

            _eventContext.SaveChanges() ;
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
