﻿namespace RedAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int PortalId { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
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
