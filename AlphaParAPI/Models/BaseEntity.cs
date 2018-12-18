
using System.ComponentModel.DataAnnotations;

namespace AlphaParAPI.Models
{
    public abstract class BaseEntity
    {
        [StringLength(36,MinimumLength = 36, ErrorMessage = "L'Id n'a pas la bonne synthaxe")]
        public string Id { get; set; } 
    }
}
