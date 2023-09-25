using Microsoft.EntityFrameworkCore;
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
            PresencasEvento buscarPresenca = _eventContext.PresencasEvento.Find(id)!;
            if (buscarPresenca != null)
            {
                buscarPresenca.Situacao = presencasEvento.Situacao;
            }

            _eventContext.Update(presencasEvento);

            _eventContext.SaveChanges();
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            return _eventContext.PresencasEvento.FirstOrDefault(e => e.IdPresencaEvento == id)!;     
        }

        public void Cadastrar(PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento.Add(presencasEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.PresencasEvento.Where(e => e.IdPresencaEvento == id).ExecuteDelete();

            _eventContext.SaveChanges();
        }

        public List<PresencasEvento> Listar()
        {
            return _eventContext.PresencasEvento.ToList();
        }

        public List<PresencasEvento> ListarMeusEventos(Guid id)
        {
            try
            {
                List<PresencasEvento> meusEventosBuscado = _eventContext.PresencasEvento
                    .Select(e => new PresencasEvento
                    {
                        IdPresencaEvento = e.IdPresencaEvento,
                        Situacao = e.Situacao,

                        Evento = new Evento
                        {
                            NomeEvento = e.Evento.NomeEvento,
                            DataEvento = e.Evento.DataEvento,
                            Descricao = e.Evento.Descricao,

                            Instituicao = new Instituicao
                            {
                                NomeFantasia = e.Evento.Instituicao.NomeFantasia
                            }
                        }
                    }).ToList();

                return meusEventosBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
