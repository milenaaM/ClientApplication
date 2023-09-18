using ClientApplication.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Core.Entities
{
    public class Address : BaseEntity
    {
        public AddressTypes AddressType { get; set; }
        public string Name { get; set; } = null!;
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
