using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public class HasPolicies
    {
        public IEnumerable<Policy> Policies { get; set; }
    }
}
