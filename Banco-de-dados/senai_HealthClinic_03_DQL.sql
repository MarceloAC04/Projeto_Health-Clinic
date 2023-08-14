SELECT Nome, Senha, Email
FROM Usuario
LEFT JOIN Medico ON Usuario.IdUsuario = Medico.IdUsuario
LEFT JOIN Paciente ON Usuario.IdTipoUsuario = Paciente.IdUsuario
WHERE Usuario.IdUsuario = 2  Usuario.IdUsuario = 3