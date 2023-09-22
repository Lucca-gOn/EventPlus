using Microsoft.EntityFrameworkCore;
using webapi.event_.codeFirst.Contexts;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;

namespace webapi.event_.codeFirst.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository() 
        {
            _eventContext = new EventContext(); 
        }
        
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            TiposUsuario buscarTiposUsuario = _eventContext.TiposUsuario.Find(id)!;
            if (buscarTiposUsuario != null) 
            {
                buscarTiposUsuario!.Titulo = tipoUsuario.Titulo;

                _eventContext.Update(buscarTiposUsuario);

                _eventContext.SaveChanges();
            }
            
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.TiposUsuario.Where(e => e.IdTipoUsuario == id).ExecuteDelete();
           
            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _eventContext.TiposUsuario.ToList();
        }
    }
}
