namespace RedArborAPI.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage = "El campo CompanyId es obligatorio.")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe tener un formato válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo Password es obligatorio.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "El campo PortalId es obligatorio.")]
        public int PortalId { get; set; }

        [Required(ErrorMessage = "El campo RoleId es obligatorio.")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "El campo StatusId es obligatorio.")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "El campo Username es obligatorio.")]
        public string Username { get; set; } = null!;
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
