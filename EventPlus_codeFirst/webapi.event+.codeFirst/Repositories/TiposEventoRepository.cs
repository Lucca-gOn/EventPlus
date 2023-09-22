using Microsoft.EntityFrameworkCore;
using webapi.event_.codeFirst.Contexts;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;

namespace webapi.event_.codeFirst.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            TiposEvento buscarTipoEvento = _eventContext.TiposEvento.Find(id)!;
            if (buscarTipoEvento != null)
            {
                buscarTipoEvento.Titulo = tipoEvento.Titulo;

                _eventContext.Update(buscarTipoEvento);

                _eventContext.SaveChanges();
            }
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            return _eventContext.TiposEvento.FirstOrDefault(e => e.IdTipoEvento == id)!;
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
            _eventContext.TiposEvento.Add(tipoEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.TiposEvento.Where(e => e.IdTipoEvento == id).ExecuteDelete();
            _eventContext.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return _eventContext.TiposEvento.ToList();
        }
    }
}
