namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using System;
using System.Collections.Generic;
using WebApi.Authorization;
using WebApi.Models.RDV;

[AuthorizeRecep]
[ApiController]
[Route("[controller]")]
    public class RendezVousController : ControllerBase
{
        private readonly IRendezVousService _rendezVousService;
	    private IMapper _mapper;


	public RendezVousController(IRendezVousService rendezVousService, IMapper mapper
)
    {
            _rendezVousService = rendezVousService;
		    _mapper = mapper;

	}

	// GET: RendezVous
	[HttpGet]
        public ActionResult<List<RendezVous>> GetAllRendezVous()
    {
            return Ok(_rendezVousService.GetAll());
        }

    // GET: RendezVous/{id}
    [AuthorizeMR]
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
        public IActionResult UpdateRendezVous([FromBody] RendezVous rendezVous)
        {
        
        try
        {
				_rendezVousService.Update(rendezVous);
				return Ok(new { message = "Rdv updated !!", rendezVous = rendezVous });
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

    // GET: RendezVous/medecinTraitant/{medecinTraitantId}
    [AuthorizeMed]
    [HttpGet("medecinTraitant/{medecinTraitantId}")]
		public ActionResult<List<RendezVous>> GetRendezVousByMedecinTraitant(int medecinTraitantId)
        {
			return Ok(_rendezVousService.GetRendezVousByMedecinTraitant(medecinTraitantId));
		}

    [AuthorizeMed]
    [HttpGet("medecinCorrespondant/{medecinCorrespondantId}")]
        public ActionResult<List<RendezVous>> GetRendezVousByMedecinCorrespondant(int medecinCorrespondantId)
    {
            return Ok(_rendezVousService.GetRendezVousByMedecinCorrespondant(medecinCorrespondantId));
    }

}

