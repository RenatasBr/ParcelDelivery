using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryBE.Models
{
    public class PostMachine
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Code { get; set; }

        public int MaxCapacity { get; set; }

        public int? ParcelId { get; set; }

        public Parcel Parcel { get; set; }
    }
}
