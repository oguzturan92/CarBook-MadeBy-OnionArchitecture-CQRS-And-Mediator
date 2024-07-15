using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontends.Dtos.FooterAddressDtos
{
    public class ResultFooterAddressDto
    {
        public int FooterAddressId { get; set; }
        public string FooterAddressDescription { get; set; }
        public string FooterAddressContent { get; set; }
        public string FooterAddressPhone { get; set; }
        public string FooterAddressMail { get; set; }
    }
}