using System;
using Microsoft.AspNetCore.Mvc;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;

namespace TaxManagementAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [Route("{municipalityName}/{queryDate:datetime}")]
        [HttpGet]
        public IActionResult GetAllTaxes(string municipalityName, DateTime queryDate)
        {
            var municipalityExists = _municipalityService.MunicipalityExists(municipalityName);
            if (municipalityExists == false)
            {
                return NotFound("Tax Entity with the provided Municipality Name was not found");
            }

            var allTaxes = _taxService.GetAllTaxes(municipalityName, queryDate);
            return Ok(allTaxes);
        }

        [ProducesResponseType(typeof(UpdateSingleTaxResponse), 200)]
        [ProducesResponseType(404)]
        [Route("{taxId:int}")]
        [HttpPatch]
        public IActionResult UpdateSingleTax(int taxId, UpdateSingleTaxRequest request)
        {
            var tax = _taxService.FindSingleTax(taxId);
            if (tax == null)
            {
                return NotFound("Tax Entity with the provided TaxId was not found");
            }

            // Create new municipality if needed.
            var municipality = _municipalityService.CreateNewMunicipalityIfNotExists(request.Municipality.Name);

            // Attach taxId from url and create new(or use existing one) municipality.
            request.TaxId = taxId;
            request.Municipality = municipality;

            var allTaxes = _taxService.UpdateSingleTax(request);
            return Ok(allTaxes);
        }

        [ProducesResponseType(typeof(NewSingleTaxResponse), 200)]
        [HttpPost]
        public IActionResult InsertSingleTax(NewSingleTaxRequest request)
        {
            // Create new municipality if needed.
            var municipality = _municipalityService.CreateNewMunicipalityIfNotExists(request.MunicipalityModel.MunicipalityName);

            // Create new(or use existing one) municipality.
            request.Municipality = municipality;

            var allTaxes = _taxService.InsertSingleTax(request);
            return Ok(allTaxes);
        }
    }
}
