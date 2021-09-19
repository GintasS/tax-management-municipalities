using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Core.Models;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;

namespace TaxManagementAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxesController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [ProducesResponseType(typeof(MunicipalityTaxesResponse), 200)]
        [ProducesResponseType(404)]
        [Route("{municipalityName}/{queryDate}")]
        [HttpGet]
        public IActionResult GetAllTaxes(string municipalityName, DateTime queryDate)
        {
            var municipalityExists = _taxService.MunicipalityExists(municipalityName);
            if (municipalityExists == false)
            {
                return NotFound("Tax Entity with the provided Municipality Name was not found");
            }

            var allTaxes = _taxService.GetAllTaxes(municipalityName, queryDate);
            return Ok(allTaxes);
        }

        [ProducesResponseType(typeof(MunicipalityTaxesResponse), 200)]
        [ProducesResponseType(404)]
        [Route("{taxId}")]
        [HttpPatch]
        public IActionResult UpdateSingleTax(int taxId, UpdateSingleTaxRequest request)
        {
            var tax = _taxService.FindSingleTax(taxId);
            if (tax == null)
            {
                return NotFound("Tax Entity with the provided TaxId was not found");
            }

            request.TaxId = taxId;
            var allTaxes = _taxService.UpdateSingleTax(request);
            return Ok(allTaxes);
        }

    }
}
