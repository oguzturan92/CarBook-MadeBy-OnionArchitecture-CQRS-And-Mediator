using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FooterAddres
    {
        public int FooterAddresId { get; set; }
        public string FooterAddresDescription { get; set; }
        public string FooterAddresContent { get; set; }
        public string FooterAddresPhone { get; set; }
        public string FooterAddresMail { get; set; }
    }
}