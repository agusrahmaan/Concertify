using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Account
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

    }
}
