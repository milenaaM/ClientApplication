using ClientApplication.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientApplication.Core.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Address> Addresses { get; set; } = new List<Address>();
        public DateTime BirthDate { get; set; }
    }
}
