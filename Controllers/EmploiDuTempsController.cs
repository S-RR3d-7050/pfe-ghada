namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using System;
using System.Collections.Generic;


    [ApiController]
    [Route("[controller]")]
    public class EmploiDuTempsController : ControllerBase
    {
        private readonly IEmploiDuTempsService _emploiDuTempsService;

        public EmploiDuTempsController(IEmploiDuTempsService emploiDuTempsService)
        {
            _emploiDuTempsService = emploiDuTempsService;
        }

        // GET: EmploiDuTemps
        [HttpGet]
        public ActionResult<List<EmploiDuTemps>> GetAllEmploiDuTemps()
        {
            return Ok(_emploiDuTempsService.GetAll());
        }

        // GET: EmploiDuTemps/{id}
        [HttpGet("{id}")]
        public ActionResult<EmploiDuTemps> GetEmploiDuTempsById(int id)
        {
            var emploiDuTemps = _emploiDuTempsService.GetById(id);
            if (emploiDuTemps == null)
            {
                return NotFound();
            }
            return Ok(emploiDuTemps);
        }

        // POST: EmploiDuTemps
        [HttpPost]
        public ActionResult<EmploiDuTemps> CreateEmploiDuTemps([FromBody] EmploiDuTemps emploiDuTemps)
        {
            try
            {
                _emploiDuTempsService.Create(emploiDuTemps);
                return CreatedAtAction(nameof(GetEmploiDuTempsById), new { id = emploiDuTemps.Id }, emploiDuTemps);
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return BadRequest(ex.Message);
            }
        }

        // PUT: EmploiDuTemps/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmploiDuTemps(int id, [FromBody] EmploiDuTemps emploiDuTemps)
        {
            if (id != emploiDuTemps.Id)
            {
                return BadRequest();
            }

            try
            {
                _emploiDuTempsService.Update(emploiDuTemps);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return NotFound(ex.Message);
            }
        }

        // DELETE: EmploiDuTemps/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmploiDuTemps(int id)
        {
            try
            {
                _emploiDuTempsService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return NotFound(ex.Message);
            }
        }
    }

