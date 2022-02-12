using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public GeneroProducto OGeneroProducto { get; set; }
        public RubroProducto ORubroProducto { get; set; }
        public Marca OMarcaProducto { get; set; }
        public TipoTalle OTipoTalleProducto { get; set; }
        public Estado OEstadoProducto { get; set; }
        public DateTime FechaRegistroProducto { get; set; }
    }
}
