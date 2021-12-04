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
            string Codigo = oProducto.Codigo;
            string Descripcion = oProducto.Descripcion;
            GeneroProducto oGeneroProducto = oProducto.OGeneroProducto;
            RubroProducto Rubro = oProducto.ORubroProducto;
            Marca oMarca = oProducto.OMarca;
            Color oColor = oProducto.OColor;
            Talle oTalle = oProducto.OTalle;
            double Costo = oProducto.Costo;
            Estado oEstado = oProducto.OEstado;
            var nuevo = new Producto(IdProducto,Codigo, Descripcion, oGeneroProducto, Rubro,oMarca,oColor,oTalle,Costo,oEstado);
            
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
            string Codigo = oProducto.Codigo;
            string Descripcion = oProducto.Descripcion;
            GeneroProducto oGeneroProducto = oProducto.OGeneroProducto;
            RubroProducto Rubro = oProducto.ORubroProducto;
            Marca oMarca = oProducto.OMarca;
            Color oColor = oProducto.OColor;
            Talle oTalle = oProducto.OTalle;
            double Costo = oProducto.Costo;
            Estado oEstado = oProducto.OEstado;
            var nuevo = new Producto(Codigo, Descripcion,oGeneroProducto,Rubro,oMarca,oColor,oTalle,Costo,oEstado);
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
                    Codigo = item.Codigo,
                    Descripcion = item.Descripcion,
                    OGeneroProducto = item.OGeneroProducto,
                    ORubroProducto = item.ORubroProducto,
                    OMarca = item.OMarca,
                    OColor = item.OColor, 
                    OTalle = item.OTalle,   
                    Costo = item.Costo,   
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
            if (oGeneroProducto.Equals("Unisex")) return GeneroProducto.Unisex;
            if (oGeneroProducto.Equals("Masculino")) return GeneroProducto.Masculino;
            return GeneroProducto.Femenino;
        }

        public Marca ObtenerMarca(string oMarca)
        {
            return BD_Marca.BuscarMarca(oMarca);
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

        public Talle ObtenerTalle(string oTalle)
        {
            return BD_Talle.BuscarTalle(oTalle);
        }
    }
}

