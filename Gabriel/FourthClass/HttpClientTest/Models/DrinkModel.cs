using System.ComponentModel.DataAnnotations;

namespace HttpClientTest.Models
{
    public class DrinkModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string Instructions { get; set; } = default!;
    }
}