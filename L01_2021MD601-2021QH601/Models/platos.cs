using System.ComponentModel.DataAnnotations;

namespace L01_2021MD601_2021QH601.Models
{
    public class platos
    {
        [Key]
        public int platoId { get; set; }
        public string nombrePlato { get; set; }
        public int? precio { get; set; }
    }
}
