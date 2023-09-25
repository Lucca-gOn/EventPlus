using Microsoft.EntityFrameworkCore;
using webapi.event_.codeFirst.Contexts;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;

namespace webapi.event_.codeFirst.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Cadastrar(Instituicao novaInstituicao)
        {
            _eventContext.Instituicao.Add(novaInstituicao);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.Instituicao.Where(e => e.IdInstituicao == id).ExecuteDelete();

            _eventContext.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return _eventContext.Instituicao.ToList();
        }
    }
}
