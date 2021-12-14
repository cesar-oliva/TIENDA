using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Producto
    {
        private int idProducto;
        private string codigo;
        private string descripcion;
        private GeneroProducto oGeneroProducto;
        private RubroProducto oRubroProducto;
        private Marca oMarca;
        private TipoTalle oTipoTalle;
        private List<ProductoVenta> oProductoVenta;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public GeneroProducto OGeneroProducto { get => oGeneroProducto; set => oGeneroProducto = value; }
        public RubroProducto ORubroProducto { get => oRubroProducto; set => oRubroProducto = value; }
        public Marca OMarca { get => oMarca; set => oMarca = value; }
        public TipoTalle OTipoTalle { get => oTipoTalle; set => oTipoTalle = value; }
        public List<ProductoVenta> OProductoVenta { get => oProductoVenta; set => oProductoVenta = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Producto(int idProducto, string codigo, string descripcion, GeneroProducto oGeneroProducto, RubroProducto oRubroProducto, Marca oMarca, List<ProductoVenta> oProductoVenta, TipoTalle oTipoTalle,Estado oEstado)
        {
            IdProducto = idProducto;
            Codigo = codigo;
            Descripcion = descripcion;
            OGeneroProducto = oGeneroProducto;
            ORubroProducto = oRubroProducto;
            OMarca = oMarca;
            OProductoVenta = oProductoVenta;
            OTipoTalle = oTipoTalle;
            OEstado = oEstado;
        }

        public Producto(string codigo, string descripcion, GeneroProducto oGeneroProducto, RubroProducto oRubroProducto, Marca oMarca, List<ProductoVenta> oProductoVenta, TipoTalle oTipoTalle,Estado oEstado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            OGeneroProducto = oGeneroProducto;
            ORubroProducto = oRubroProducto;
            OMarca = oMarca;
            OProductoVenta = oProductoVenta;
            OTipoTalle = oTipoTalle;
            OEstado = oEstado;
        }
        public Producto()
        {
        }

    }
    

}
