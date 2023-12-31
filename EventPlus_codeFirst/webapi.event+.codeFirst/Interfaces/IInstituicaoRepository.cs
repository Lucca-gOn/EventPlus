﻿using webapi.event_.codeFirst.Domains;

namespace webapi.event_.codeFirst.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao novaInstituicao);

        void Deletar(Guid id);

        List<Instituicao> Listar(); 
    }
}
