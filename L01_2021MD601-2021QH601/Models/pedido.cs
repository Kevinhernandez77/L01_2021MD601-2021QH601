using System.ComponentModel.DataAnnotations;

namespace L01_2021MD601_2021QH601.Models
{
    public class pedido
    {
  
            [Key]
            public int pedidoId { get; set; }
            public int motoristaId { get; set; }
            public int clienteId { get; set; }
            public int platoId { get; set; }
            public int cantidad { get; set; }
            public int? precio { get; set; }
        }
    }
