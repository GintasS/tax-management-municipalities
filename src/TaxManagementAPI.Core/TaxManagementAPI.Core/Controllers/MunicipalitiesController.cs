using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;

namespace TaxManagementAPI.Core.Controllers
{
    [ApiController]
    [Route("municipalities")]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;

        public MunicipalitiesController( IMunicipalityService municipalityService)
        {
            _municipalityService = municipalityService;
        }

        [ProducesResponseType(typeof(CreateMunicipalityResponse), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(405)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult CreateMunicipality(CreateMunicipalityRequest request)
        {
            var municipality = _municipalityService.FindMunicipality(request.Name);
            if (municipality != null)
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed, "Municipality with this name already exists.");
            }

            var newMunicipality = _municipalityService.CreateMunicipality(request.Name);
            if (newMunicipality == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error has occurred.");
            }

            var response = new CreateMunicipalityResponse
            {
                Id = newMunicipality.MunicipalityId,
                Name = newMunicipality.Name
            };

            return CreatedAtAction("CreateMunicipality", response);
        }

        [ProducesResponseType(typeof(UpdateMunicipalityNameResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(405)]
        [ProducesResponseType(500)]
        [Route("name/{oldMunicipalityName}/{newMunicipalityName}")]
        [HttpPatch]
        public IActionResult UpdateMunicipalityName(string oldMunicipalityName, string newMunicipalityName)
        {
            var oldMunicipality = _municipalityService.FindMunicipality(oldMunicipalityName);
            if (oldMunicipality == null)
            {
                return NotFound("Municipality with this oldMunicipalityName does not exist.");
            }

            var newMunicipality = _municipalityService.FindMunicipality(newMunicipalityName);
            if (newMunicipality != null)
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed, "Municipality with the newMunicipalityName already exists.");
            }

            var updatedEntity = _municipalityService.UpdateMunicipalityName(oldMunicipality, newMunicipalityName);
            if (updatedEntity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error has occurred.");
            }

            var response = new UpdateMunicipalityNameResponse
            {
                MunicipalityId = updatedEntity.MunicipalityId,
                MunicipalityName = updatedEntity.Name
            };
            return Ok(response);
        }
    }
}
