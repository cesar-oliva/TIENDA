using CapaDatos;
using CapaDatos.SqlServer;
using CapaNegocio;
using System.Collections.Generic;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceProducto : IServiceProducto
    {
        public bool ModificarProducto(DtoProducto oProducto)
        {
            int IdProducto = oProducto.IdProducto;
            string CodigoProducto = oProducto.CodigoProducto;
            string DescripcionProducto = oProducto.DescripcionProducto;
            GeneroProducto oGeneroProducto = oProducto.OGeneroProducto;
            RubroProducto Rubro = oProducto.ORubroProducto;
            Marca oMarca = oProducto.OMarca;
            TipoTalle oTipoTalle = oProducto.OTipoTalle;
            List<ProductoVenta> oProductoVenta = oProducto.OProductoVenta;
            Estado oEstado = oProducto.OEstado;
            var nuevo = new Producto(IdProducto,CodigoProducto, DescripcionProducto, oGeneroProducto, Rubro,oMarca,oProductoVenta,oTipoTalle,oEstado);
            
            if (BD_Producto.ModificarProducto(nuevo))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool EliminarProducto(int IdProducto)
        {
            return BD_Producto.EliminarProducto(IdProducto);
        }

        public bool IngresarProducto(DtoProducto oProducto)
        {
            string CodigoProducto = oProducto.CodigoProducto;
            string DescripcionProducto = oProducto.DescripcionProducto;
            GeneroProducto oGeneroProducto = oProducto.OGeneroProducto;
            RubroProducto Rubro = oProducto.ORubroProducto;
            Marca oMarca = oProducto.OMarca;
            TipoTalle oTipoTalle = oProducto.OTipoTalle;
            List<ProductoVenta> oProductoVenta = oProducto.OProductoVenta;
            Estado oEstado = oProducto.OEstado;
            var nuevo = new Producto(CodigoProducto, DescripcionProducto,oGeneroProducto,Rubro,oMarca,oProductoVenta,oTipoTalle,oEstado);
            if (BD_Producto.RegistrarProducto(nuevo) > 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public List<DtoProducto> ListaProducto()
        {
            List<DtoProducto> lista = new List<DtoProducto>();
            foreach (var item in BD_Producto.MostrarProducto())
            { 
                DtoProducto prod = new DtoProducto
                {
                    IdProducto = item.IdProducto,
                    CodigoProducto = item.CodigoProducto,
                    DescripcionProducto = item.DescripcionProducto,
                    OGeneroProducto = item.OGeneroProducto,
                    ORubroProducto = item.ORubroProducto,
                    OMarca = item.OMarca,
                    OProductoVenta = item.OProductoVenta, 
                    OTipoTalle = item.OTipoTalle,     
                    OEstado = item.OEstado,
                    FechaRegistro = item.FechaRegistro
                };
                lista.Add(prod);
            }
            return lista;
        }

        public Estado ObtenerEstado(string oEstado)
        {
            if (oEstado.Equals("Activo")) return Estado.Activo;
            return Estado.Inactivo;
        }

        public GeneroProducto ObtenerGeneroProducto(string oGeneroProducto)
        {
            return BD_GeneroProducto.BuscarGeneroProductoByDescripcion(oGeneroProducto);
        }

        public Marca ObtenerMarca(string oMarca)
        {
            return BD_Marca.BuscarMarcaByDescripcion(oMarca);
        }

        public RubroProducto ObtenerRubroProducto(string oRubroProducto)
        {
            return BD_RubroProducto.BuscarRubroProductoByDescripcion(oRubroProducto);
        }

        public Producto BuscarProductoById(int idProducto)
        {
            return BD_Producto.BuscarProducto(idProducto);
        }

        public Color ObtenerColor(string oColor)
        {
            return BD_Color.BuscarColor(oColor);
        }

        public TipoTalle ObtenerTipoTalle(string oTipoTalle)
        {
            return BD_TipoTalle.BuscarTipoTalleByDescripcion(oTipoTalle);
        }
        public Talle ObtenerTalle(string oTalle)
        {
            return BD_Talle.BuscarTalle(oTalle);
        }

        public ProductoVenta ObtenerProductoVenta(Color oColor, Talle oTalle, double costo, int cantidad, Estado oEstado)
        {
            ProductoVenta p = new ProductoVenta()
            {
                OColor = oColor,
                OTalle = oTalle,
                Costo = costo,
                Cantidad = cantidad,
                OEstado = oEstado
            };
            return p;
        }
    }
}

