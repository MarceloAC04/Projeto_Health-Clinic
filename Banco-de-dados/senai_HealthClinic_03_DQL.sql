USE HealthClinic_Manha;
--Consultando dados da consulta e outras tabelas
SELECT NomeFantasia AS Clinica, CONCAT(NomeMedico,',',TipoEspecialidade,', CRM/SP-',CRM) AS [Medico], 
	   NomePaciente AS Paciente, 
	   DataConsulta AS [Data da Consulta], 
	   Horario, Descricao, [Status]
FROM Consulta
	   INNER JOIN Clinica		 ON Consulta.IdClinica = Clinica.IdClinica
	   INNER JOIN Medico		 ON Consulta.IdMedico = Medico.IdMedico
	   INNER JOIN Especialidade  ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
	   INNER JOIN Paciente		 ON Consulta.IdPaciente = Paciente.IdPaciente
	   INNER JOIN StatusConsulta ON Consulta.IdStatusConsulta = StatusConsulta.IdStatusConsulta

--Consultando dados do prontuario e outras tabelas
SELECT CONCAT(NomeMedico,',',TipoEspecialidade) AS [Medico], 
	   NomePaciente AS Paciente,
	   DescricaoProntuario AS [Descricao do Prontuario]
FROM Prontuario
	   LEFT JOIN Medico			ON Prontuario.IdMedico = Medico.IdMedico
	   INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
	   LEFT JOIN Paciente		ON Prontuario.IdPaciente = Paciente.IdPaciente

--Consultando dado de comentario e outras tabelas
SELECT NomeFantasia, NomePaciente AS Paciente,	
	   Comentario.Comentario
FROM Comentario
	INNER JOIN Clinica  ON Comentario.IdClinica = Clinica.IdClinica
	INNER JOIN Paciente ON Comentario.IdPaciente = Paciente.IdPaciente
