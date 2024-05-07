namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using System;
using System.Collections.Generic;
using WebApi.Authorization;
using WebApi.Models.DossiersPatients;


[AuthorizeRecep]
[ApiController]
    [Route("[controller]")]
    public class DossierPatientsController : ControllerBase
    {
        private readonly IDossierPatientService _dossierPatientService;

        public DossierPatientsController(IDossierPatientService dossierPatientService)
        {
            _dossierPatientService = dossierPatientService;
        }

	// GET: DossierPatients
	    [AuthorizeMR]
        [HttpGet]
        public ActionResult<List<DossierPatient>> GetAllDossierPatients()
        {
            return Ok(_dossierPatientService.GetAll());
        }

	// GET: DossierPatients/{id}
	    [AuthorizeMR]
        [HttpGet("{id}")]
        public ActionResult<DossierPatient> GetDossierPatientById(int id)
        {
            var dossierPatient = _dossierPatientService.GetById(id);
            if (dossierPatient == null)
            {
                return NotFound();
            }
            return Ok(dossierPatient);
        }

        // POST: DossierPatients
        [HttpPost]
        public ActionResult<DossierPatient> CreateDossierPatient([FromBody] DossierPatient dossierPatient)
        {
            try
            {
                _dossierPatientService.Create(dossierPatient);
                return CreatedAtAction(nameof(GetDossierPatientById), new { id = dossierPatient.Id }, dossierPatient);
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return BadRequest(ex.Message);
            }
        }

    // PUT: DossierPatients/{id}
    //[HttpPut("{id}")]
    //   public IActionResult UpdateDossierPatient(int id, [FromBody] DossierPatient dossierPatient)
    //   {
    //       //if (id != dossierPatient.Id)
    //       //{
    //       //    return BadRequest();
    //       //}

    //       try
    //       {
    //           //_dossierPatientService.Update(dossierPatient);
    //           _dossierPatientService.UpdateWithId(id, dossierPatient);
    //           return NoContent();
    //       }
    //       catch (Exception ex)
    //       {
    //           // Implement proper error handling, this is just a placeholder.
    //           return NotFound(ex.Message);
    //       }
    //   }

    [HttpPut("{id}")]
    public IActionResult UpdateDossierPatient(int id, [FromBody] DPUpdate updateModel)
    {
        _dossierPatientService.UpdateWithId(id, updateModel);
        var dossierPatientToReturn = _dossierPatientService.GetById(id);
        return Ok(dossierPatientToReturn);
    }

    // DELETE: DossierPatients/{id}
    [HttpDelete("{id}")]
        public IActionResult DeleteDossierPatient(int id)
        {
            try
            {
                _dossierPatientService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return NotFound(ex.Message);
            }
        }

        }
    

