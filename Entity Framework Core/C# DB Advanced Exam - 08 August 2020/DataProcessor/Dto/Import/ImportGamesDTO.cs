namespace VaporStore.DataProcessor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class ImportGamesDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        [JsonProperty("Developer")]
        public string DeveloperName { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public string GenreName { get; set; }

        [Required]
        public string[] Tags { get; set; }


    }
}
