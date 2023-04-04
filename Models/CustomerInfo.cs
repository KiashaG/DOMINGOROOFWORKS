using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class CustomerInfo
    {
        [Required]
        public int Customer_ID { get; set; }
        [Required]
        public string Customer_Name { get; set; }
        [Required]
        public string Customer_Surname { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
