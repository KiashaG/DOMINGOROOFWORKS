using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class InvoiceInfo
    {
        [Required]
        public int JobCard_NO { get; set; }
        [Required]
        public string Customer_Name { get; set; }
        [Required]
        public string Customer_Surname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string JobType_Name{ get; set; }
        [Required]
        public string Employee_Name { get; set; }
        [Required]
        public string Employee_Surname { get; set; }
        [Required]
        public string Materials_Used { get; set; }
        [Required]
        public decimal DailyRate{ get; set; }
        [Required]
        public int No_Of_Days { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Vat{ get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}
