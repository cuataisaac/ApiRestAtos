using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestAtosModels
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Check entries")]
        [Display(Name = "Profile")]
        public string ProfileName {get; set;}
    }
}
