using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceProducto : IServiceProducto
    {
        public bool ActualizarProducto(DtoProducto oProducto)
        {
            int IdProducto = oProducto.IdProducto;
            string Codigo = oProducto.Codigo;
            string Descripcion = oProducto.Descripcion;
            GeneroProducto oGeneroProducto = oProducto.oGeneroProducto;
            RubroProducto Rubro = oProducto.Rubro;
            Marca oMarca = oProducto.oMarca;
            double Impuesto = oProducto.Impuesto;
            double Costo = oProducto.Costo;
            double MargenGanancia = oProducto.MargenGanancia;
            double NetoGravado = oProducto.NetoGravado;
            double PrecioVenta = oProducto.PrecioVenta;
            Estado oEstado = oProducto.oEstado;
            var nuevo = new Producto(IdProducto,Codigo, Descripcion, oGeneroProducto, Rubro, oMarca, Impuesto, Costo, MargenGanancia, NetoGravado, PrecioVenta, oEstado);
            
            if (BD_Producto.ActualizarProducto(nuevo))
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
            GeneroProducto oGeneroProducto = oProducto.oGeneroProducto;
            RubroProducto Rubro = oProducto.Rubro;
            Marca oMarca = oProducto.oMarca;
            double Impuesto = oProducto.Impuesto;
            double Costo = oProducto.Costo;
            double MargenGanancia = oProducto.MargenGanancia;
            double NetoGravado = oProducto.NetoGravado;
            double PrecioVenta = oProducto.PrecioVenta;
            Estado oEstado = oProducto.oEstado;
            var nuevo = new Producto(Codigo, Descripcion,oGeneroProducto, Rubro,oMarca,Impuesto, Costo,MargenGanancia,NetoGravado,PrecioVenta,oEstado);
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
                    oGeneroProducto = item.OGeneroProducto,
                    Rubro = item.Rubro,
                    oMarca = item.OMarca,
                    Impuesto = item.Impuesto,
                    Costo = item.Costo,
                    MargenGanancia = item.MargenGanancia,
                    NetoGravado = item.NetoGravado,
                    PrecioVenta = item.PrecioVenta,
                    oEstado = item.OEstado,
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
            return BD_RubroProducto.BuscarRubroProducto(oRubroProducto);
        }
    }
}

