using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models.Responses
{
    public class NewSingleTaxResponse : TaxModel
    {
        public int TaxId { get; set; }
    }
}
