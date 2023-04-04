using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class EmployeeInfo
    {
    
        public string Employee_NO { get; set; }
        [Required]
        public string Employee_Name { get; set; }
        [Required]
        public string Employee_Surname { get; set; }
    }
}

