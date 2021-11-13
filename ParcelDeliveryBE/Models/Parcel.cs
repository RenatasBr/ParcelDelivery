using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryBE.Models
{
    public class Parcel
    {
        public int Id { get; set; }

        public string Receiver { get; set; }

        public double WeightInKg { get; set; }

        public string ReceiverPhoneNo { get; set; }

        public string Description { get; set; }

    }
}
