using System;
using System.Collections.Generic;
using InsuranceApi.Models;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InsuranceApi.Database
{
    public class ClientDatabase : List<Client>
    {
        public ClientDatabase()
        {
        }

        public void Populate(string clientData)
        {
        }
    }
}
