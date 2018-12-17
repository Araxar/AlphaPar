using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaParWindows.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Siret { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
