using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address : BaseEntity, IEntity

    {
        public int Id { get; set; }
        public string Type { get; set; } // e.g., Home, Work
        public string Location { get; set; } // Tam Adres
        public int CustomerId { get; set; }
    }
}
