using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RVT_WebTerminal.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Necesar de complitat spatiu")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Format invallid")]
        [StringLength(13,ErrorMessage="Lungimea codului personal este din 13 cifre")]
        public string IDNP { get; set; }
        [Required(ErrorMessage = "Necesar de complitat spatiu")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Necesar de complitat spatiu")]
        [MaxLength(255)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Necesar de complitat spatiu")]
        [MaxLength(20)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Necesar de complitat spatiu")]
        [MaxLength(255)]
        public string Birth_date { get; set; }
        [Required(ErrorMessage = "Necesar de complitat spatiu")]
        [MaxLength(255)]
        public string Region { get; set; }
        [Required(ErrorMessage = "Necesar de complitat spatiu")]
        [MaxLength(255)]
        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")]
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "Necesar de complitat spatiu")]
        [EmailAddress(ErrorMessage ="Nu este valid formatul email")]
        public string Email { get; set; }
    }
}
