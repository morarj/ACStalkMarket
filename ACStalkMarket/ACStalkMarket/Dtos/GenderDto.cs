using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Dtos
{
    public class GenderDto
    {
        public short Id { get; set; }

        public string GenderName { get; set; }
    }
}