using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class MaterialsInfo
    {
        [Required]
        public int MATERIALSID { get; set; }
        [Required]
        public string Materials_Used { get; set; }
        [Required]
        public int Materials_ID { get; set; }
        [Required]
        public int Job_ID { get; set; }
        [Required]
        public int JobCard_No { get; set; }
    }
}
