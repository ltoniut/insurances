using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApi.Models
{
    public class XRequest
    {
        [MinLength(4)]
        public string Nombre { get; set; }
        public string Mail { get; set; }
    }
}
