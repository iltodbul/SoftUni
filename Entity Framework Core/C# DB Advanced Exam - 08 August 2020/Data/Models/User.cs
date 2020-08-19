namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();

    }
}
