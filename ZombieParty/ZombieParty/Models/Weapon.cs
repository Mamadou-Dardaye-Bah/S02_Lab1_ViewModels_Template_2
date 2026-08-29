using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class Weapon : IValidatableObject
    {
        [Required]
        [StringLength(250, MinimumLength = 2)]
        [Display(Name = "Weapon's Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(2500, MinimumLength = 0)]
        [Display(Name = "Weapon's Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Range(0, 500)]
        public decimal Force { get; set; }

        [Range(0, 100000,
            ErrorMessage = "The Price has to be between 0 and 100000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Weapon's Image")]
        public string? Image { get; set; }

        public int Qty { get; set; }

        [Display(Name = "Quantity Bought")]
        public int QtyBought { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Weapon;

            if (item == null)
                yield break;

            if (string.IsNullOrWhiteSpace(item.Description))
                yield break;

            if (item.Description.Split(" ").Length <= 3)
            {
                yield return new ValidationResult(
                    "Description needs to have more than 3 words please.",
                    new[] { "Description" }
                );
            }
        }
    }
}
