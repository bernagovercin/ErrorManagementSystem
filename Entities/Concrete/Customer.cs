using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : BaseEntity, IEntity
    {
        public int CustomerId { get; set; }
        public string ImagePath { get; set; }  // Görselin dosya yolu
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
