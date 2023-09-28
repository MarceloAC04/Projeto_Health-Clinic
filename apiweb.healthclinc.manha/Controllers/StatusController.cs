﻿using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusConsultaRepository _statusConsultaRepository;

        public StatusController()
        {
            _statusConsultaRepository = new StatusConsultaRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(StatusConsulta statusConsulta)
        {
            try
            {
                _statusConsultaRepository.Cadastrar(statusConsulta);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
