using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class JobTypeInfo
    {
        [Required]
        public int Job_ID { get; set; }
        [Required]
        public string JobType_Name { get; set; }
        [Required]
        public int No_Of_Days { get; set; }
        [Required]
        public decimal DailyRate{ get; set; }
    }
}
