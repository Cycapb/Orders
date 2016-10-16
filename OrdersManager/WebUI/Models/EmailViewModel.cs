using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class EmailViewModel
    {
        [Required(ErrorMessage = "Field cannot be empty")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string MailTo { get; set; }
    }
}