
namespace AlphaParAPI.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Siret { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
