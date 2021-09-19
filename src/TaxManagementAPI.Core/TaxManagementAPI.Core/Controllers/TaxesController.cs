using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;

namespace TaxManagementAPI.Core.Controllers
{
    [ApiController]
    [Route("taxes")]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxService _taxService;
        private readonly IMunicipalityService _municipalityService;

        public TaxesController(ITaxService taxService, IMunicipalityService municipalityService)
        {
            _taxService = taxService;
            _municipalityService = municipalityService;
        }

        [ProducesResponseType(typeof(MunicipalityTaxesResponse), 200)]
        [ProducesResponseType(404)]
        [Route("/{municipalityName}/taxes/date/{queryDate:datetime}")]
        [HttpGet]
        public IActionResult GetAllTaxes(string municipalityName, DateTime queryDate)
        {
            var municipality = _municipalityService.FindMunicipality(municipalityName);
            if (municipality == null)
            {
                return NotFound("Municipality with this name does not exist.");
            }

            var allTaxes = _taxService.GetAllTaxes(municipalityName, queryDate);
            var response = new MunicipalityTaxesResponse
            {
                Date = queryDate,
                MunicipalityName = municipalityName,
                Taxes = allTaxes
            };

            return Ok(response);
        }

        [ProducesResponseType(typeof(UpdateSingleTaxResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("{taxId:int}")]
        [HttpPatch]
        public IActionResult UpdateSingleTax(int taxId, UpdateSingleTaxRequest request)
        {
            var tax = _taxService.FindSingleTax(taxId);
            if (tax == null)
            {
                return NotFound("Tax Entity with the provided taxId does not exist.");
            }

            // Attach taxId to update tax entity's relationship in DB.
            request.TaxId = taxId;

            var updatedTax = _taxService.UpdateSingleTax(request);
            if (updatedTax == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error has occurred.");
            }

            var response = new UpdateSingleTaxResponse
            {
                MunicipalityModel = updatedTax.MunicipalityModel,
                TaxDateModel = updatedTax.TaxDateModel,
                TaxRateModel = updatedTax.TaxRateModel
            };

            return Ok(response);
        }

        [ProducesResponseType(typeof(NewSingleTaxResponse), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("/{municipalityName}/taxes")]
        [HttpPost]
        public IActionResult InsertSingleTax(string municipalityName, NewSingleTaxRequest request)
        {
            var municipality = _municipalityService.FindMunicipality(municipalityName);
            if (municipality == null)
            {
                return NotFound("Municipality with this name does not exist.");
            }

            request.Municipality = municipality;

            var newTax = _taxService.InsertSingleTax(request);
            if (newTax == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error has occurred.");
            }

            var response = new NewSingleTaxResponse
            {
                TaxId = newTax.TaxId,
                MunicipalityModel = newTax.MunicipalityModel,
                TaxDateModel = newTax.TaxDateModel,
                TaxRateModel = newTax.TaxRateModel
            };

            return CreatedAtAction("InsertSingleTax", response);
        }

        [ProducesResponseType(typeof(UpdateSingleTaxMunicipalityResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("{taxId:int}/municipality/{newMunicipalityName}")]
        [HttpPatch]
        public IActionResult UpdateSingleTaxMunicipality(int taxId, string newMunicipalityName)
        {
            var tax = _taxService.FindSingleTax(taxId);
            if (tax == null)
            {
                return NotFound("Tax Entity with the provided taxId does not exist.");
            }

            var municipality = _municipalityService.FindMunicipality(newMunicipalityName);
            if (municipality == null)
            {
                return NotFound("Municipality with the newMunicipalityName does not exist.");
            }

            var updatedTax = _taxService.UpdateSingleTaxMunicipality(tax, municipality);
            if (updatedTax == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error has occurred.");
            }
            
            var response = new UpdateSingleTaxMunicipalityResponse
            {
                TaxId = updatedTax.TaxId,
                Municipality = updatedTax.Municipality
            };

            return Ok(response);
        }
    }
}
