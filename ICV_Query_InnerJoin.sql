

/*Query para pegar o nome do colaborador que cadastrou um doador*/
SELECT NomeColaborador, NomeDoador
FROM TblColaborador
INNER JOIN TblDoador
ON TblColaborador.IdColaborador = TblDoador.IdDoador;