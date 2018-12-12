using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaParAPI.Models
{
    public class Command : BaseEntity
    {
        public string IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public Customer Customer { get; set; }
        public string IdPlan { get; set; }
        [ForeignKey("IdPlan")]
        public Plan Plan { get; set; }
        public int PlanAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
