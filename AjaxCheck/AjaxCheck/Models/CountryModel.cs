using System.ComponentModel.DataAnnotations;

namespace AjaxCheck.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
        public ICollection<StatesModel> States { get; set; }

    }
}
