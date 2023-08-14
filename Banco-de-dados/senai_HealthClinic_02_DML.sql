USE HealthClinic;

INSERT INTO Clinica(Endereco, CNPJ, NomeFantasia, RazaoSoial, HorarioAbertura, HorarioEncerramento)
VALUES ('Rua Niteroi 180','12345678901234','Clinica Moirah','Clinica Medicinia Geral Moirah','06:00:00','22:00:00')

INSERT INTO TipoDeUsuario(TituloTipoUsuario)
VALUES ('Admin'),('Médico'), ('Paciente')

INSERT INTO Usuario(IdTipoUsuario,Nome, Email, Senha)
VALUES (1,'Monica','monica@gmail.com','1234'),
	   (2,'Felipe','felipe@gmail.com','4321'),
	   (3,'Kelvin','kelvin@gmail.com','4311')

INSERT INTO Especialidade(TipoEspecialidade)
VALUES ('Cardiologista')

INSERT INTO Medico(IdUsuario,IdEspecialidade, CRM)
VALUES (2,1,'123456')

INSERT INTO Paciente(IdUsuario, CPF, Telefone, Idade)
VALUES (3,'234.323.736-09','(11)7856-0967','20')

INSERT INTO StatusConsulta([Status])
VALUES ('Concluido'), ('Cancelada'), ('Agendada')

INSERT INTO Consulta(IdClinica, IdMedico, IdPaciente, DataConsulta, Horario, Descricao,  IdStatusConsulta)
VALUES(1,1,1,'2023-08-11','13:00:00','Consulta de rotina',1)

INSERT INTO Prontuario(IdMedico,IdPaciente,DescricaoProntuario)
VALUES(1,1,'Realizado exames no paciente')

INSERT INTO Comentario(IdClinica,IdPaciente,Comentario)
VALUES(1,1,'Òtimos profissionais e boa estrutura')