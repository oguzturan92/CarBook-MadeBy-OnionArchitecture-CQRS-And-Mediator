using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.FooterAddresss.Mediator.Results.FooterAddressResults
{
    public class GetFooterAddressByIdQueryResult
    {
        public int FooterAddressId { get; set; }
        public string FooterAddressDescription { get; set; }
        public string FooterAddressContent { get; set; }
        public string FooterAddressPhone { get; set; }
        public string FooterAddressMail { get; set; }
    }
}