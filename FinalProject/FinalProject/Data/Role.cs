using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    [Table("Role")]
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public ICollection<FeatureRole> FeatureRoles { get; set; }
        public Role()
        {
            FeatureRoles = new HashSet<FeatureRole>();
        }
    }

    [Table("UserRole")]
    public class UserRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        [ForeignKey("CustomerId")]
        public Customer User { get; set; }
    }

    [Table("Feature")]
    public class Feature
    {
        public int FeatureId { get; set; }
        [Required]
        [MaxLength(200)]
        public string FeatureName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Url { get; set; }
    }

    [Table("FeatureRole")]
    public class FeatureRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int FeatureId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }
    }
}
