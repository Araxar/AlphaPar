using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaParWindows.Models
{
    public class Command : BaseEntity
    {
        public string IdCustomer { get; set; }
        public Customer Customer { get; set; }
        public string IdPlan { get; set; }
        public Plan Plan { get; set; }
        public int PlanAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
