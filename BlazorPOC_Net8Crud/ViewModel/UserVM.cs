using System.ComponentModel.DataAnnotations;

namespace BlazorPOC_Net8Crud.ViewModel
{
    public class UserVM
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
