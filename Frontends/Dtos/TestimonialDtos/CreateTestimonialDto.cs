using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontends.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string TestimonialFullname { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialImage { get; set; }
    }
}