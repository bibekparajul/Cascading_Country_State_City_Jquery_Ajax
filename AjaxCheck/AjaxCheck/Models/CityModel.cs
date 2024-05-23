using System.ComponentModel.DataAnnotations;

namespace AjaxCheck.Models
{
    public class CityModel
    {

        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public StatesModel States { get; set; }
    }
}
