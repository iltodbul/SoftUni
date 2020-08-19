namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Game")]
    public class ExportUserPurchaseGameDTO
    {
        [XmlAttribute("title")]
        public string Name { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
