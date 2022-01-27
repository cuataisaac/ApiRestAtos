using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestAtosModels
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El Nombre de usuario es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Password es obligatorio")]

        public string Password { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Login { get; set; }

        [Required]

        public int employeeId { get; set; }

        [Required]
        public int ProfileId { get; set; }

        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }

        public User()
        {
            CreatedDate = DateTime.Now;
            Login = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }
}
