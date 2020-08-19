namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ImportPurchaseDTO
    {
        [Required]
        [XmlAttribute("title")]
        public string GameTitle { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        [XmlElement("Key")]
        public string ProductKey { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        [XmlElement("Card")]
        public string CardNumber { get; set; }

    }
}
