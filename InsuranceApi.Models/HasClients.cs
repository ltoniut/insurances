using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public class HasClients
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}
