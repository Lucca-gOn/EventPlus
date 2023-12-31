--DQL Data Query Language

USE [Event+_manha];

SELECT 
    Usuario.Nome AS [Nome do Usuario],
    TipoDeUsuario.TituloTipoUsuario AS [Tipo de Usuario],
    Evento.DataEvento AS [Data do Evento],
    Instituicao.NomeFantasia AS [Institui��o],
	--CONCAT (Instituicao.NomeFantasia, Instituicao.Endereco) AS [Local],
    TipoDeEvento.TituloTipoEvento AS [Tipo de Evento],
    Evento.NomeDoEvento AS [Nome do Evento],
    Evento.Descricao AS [Descri��o],
	CASE WHEN PresencasDeEvento.Situacao =1 THEN 'Confirmada' ELSE 'N�o confirmada' END AS [Situa��o],
    Comentario.DescricaoComentario AS [Coment�rio]
FROM 
    Usuario

LEFT JOIN 
    TipoDeUsuario ON Usuario.IdTipoDeUsuario = TipoDeUsuario.IdTipoDeUsuario
LEFT JOIN 
    PresencasDeEvento ON Usuario.IdUsuario = PresencasDeEvento.IdUsuario
LEFT JOIN 
    Evento ON PresencasDeEvento.IdEvento = Evento.IdEvento
LEFT JOIN 
    TipoDeEvento ON Evento.IdTipoDeEvento = TipoDeEvento.IdTipoDeEvento
LEFT JOIN 
    Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
LEFT JOIN 
    Comentario ON Usuario.IdUsuario = Comentario.IdUsuario
	

