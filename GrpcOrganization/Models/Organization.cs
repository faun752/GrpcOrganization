using System.ComponentModel.DataAnnotations;

namespace GrpcOrganization.Models
{
    public class Organization
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string OrganizationCode { get; set; }

        [Required]
        [StringLength(100)]
        public string OrganizationName { get; set; }
    }
}
