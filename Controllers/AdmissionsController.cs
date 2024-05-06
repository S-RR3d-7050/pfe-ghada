namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using System;
using System.Collections.Generic;
using WebApi.Authorization;


[AuthorizeRecep]
[ApiController]
    [Route("[controller]")]
    public class AdmissionsController : ControllerBase
    {
        private readonly IAdmissionService _admissionService;

        public AdmissionsController(IAdmissionService admissionService)
        {
            _admissionService = admissionService;
        }

        // GET: Admission
        [HttpGet]
        public ActionResult<List<Admission>> GetAllAdmissions()
        {
            return Ok(_admissionService.GetAll());
        }

        // GET: Admission/{id}
        [HttpGet("{id}")]
        public ActionResult<Admission> GetAdmissionById(int id)
        {
            var admission = _admissionService.GetById(id);
            if (admission == null)
            {
                return NotFound();
            }
            return Ok(admission);
        }

        // POST: Admission
        [HttpPost]
        public ActionResult<Admission> CreateAdmission([FromBody] Admission admission)
        {
            try
            {
                _admissionService.Create(admission);
                return CreatedAtAction(nameof(GetAdmissionById), new { id = admission.Id }, admission);
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return BadRequest(ex.Message);
            }
        }

        // PUT: Admission/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAdmission(int id, [FromBody] Admission admission)
        {
            if (id != admission.Id)
            {
                return BadRequest();
            }

            try
            {
                _admissionService.Update(admission);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return NotFound(ex.Message);
            }
        }

        // DELETE: Admission/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmission(int id)
        {
            try
            {
                _admissionService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Implement proper error handling, this is just a placeholder.
                return NotFound(ex.Message);
            }
        }
    }

