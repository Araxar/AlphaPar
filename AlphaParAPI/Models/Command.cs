using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaParAPI.Models
{
    public class Command : BaseEntity
    {
        [StringLength(36, MinimumLength = 36, ErrorMessage = "L'Id du client n'a pas la bonne synthaxe")]
        public string IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public Customer Customer { get; set; }

        [StringLength(36, MinimumLength = 36, ErrorMessage = "L'Id du Plan n'a pas la bonne synthaxe")]
        public string IdPlan { get; set; }
        [ForeignKey("IdPlan")]
        public Plan Plan { get; set; }


        public int PlanAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
