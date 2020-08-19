namespace VaporStore.DataProcessor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class ImportUserDTO
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        [JsonProperty("FullName")]

        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public ImportCardDTO[] Cards { get; set; }
    }
}
