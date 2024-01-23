using System.ComponentModel.DataAnnotations;

namespace BlazorPOC_Net8Crud.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNo { get; set; }
        public string? Designation { get; set; }
    }
}
