namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using System;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
    public class RendezVousController : ControllerBase
{
        private readonly IRendezVousService _rendezVousService;

        public RendezVousController(IRendezVousService rendezVousService)
    {
            _rendezVousService = rendezVousService;
        }

    // GET: RendezVous
    [HttpGet]
        public ActionResult<List<RendezVous>> GetAllRendezVous()
    {
            return Ok(_rendezVousService.GetAll());
        }

    // GET: RendezVous/{id}
    [HttpGet("{id}")]
        public ActionResult<RendezVous> GetRendezVousById(int id)
    {
            var rendezVous = _rendezVousService.GetById(id);
            if (rendezVous == null)
        {
                return NotFound();
            }
            return Ok(rendezVous);
        }

    // POST: RendezVous
    [HttpPost]
        public ActionResult<RendezVous> CreateRendezVous([FromBody] RendezVous rendezVous)
    {
            try
        {
                _rendezVousService.Create(rendezVous);
                return CreatedAtAction(nameof(GetRendezVousById), new { id = rendezVous.Id }, rendezVous);
            }
            catch (Exception ex)
        {
                // Implement proper error handling, this is just a placeholder.
                return BadRequest(ex.Message);
            }
        }

    // PUT: RendezVous/{id}
    [HttpPut("{id}")]
        public IActionResult UpdateRendezVous(int id, [FromBody] RendezVous rendezVous)
    {
            if (id != rendezVous.Id)
        {
                return BadRequest();
            }

            try
        {
                _rendezVousService.Update(rendezVous);
                return NoContent();
            }
            catch (Exception ex)
        {
                // Implement proper error handling, this is just a placeholder.
                return BadRequest(ex.Message);
            }
        }

    // DELETE: RendezVous/{id}
    [HttpDelete("{id}")]
        public IActionResult DeleteRendezVous(int id)
        {
            _rendezVousService.Delete(id);
            return NoContent();
        }
    }