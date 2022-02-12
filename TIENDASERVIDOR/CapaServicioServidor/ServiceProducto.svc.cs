using CapaDatos;
using CapaDatos.SqlServer;
using CapaNegocio;
using System.Collections.Generic;
using CapaServicioServidor.DataObjectTransfer;
using CapaServicioServidor.Abstraction;
using CapaServicioServidor.DataObjectTransfer.Producto;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceProducto : IServiceCrud<DtoProducto>,IFormulario<DtoFormProducto>,IServiceDetalleProducto
    {
        BD_Producto bd_Producto = new BD_Producto();
        BD_MarcaProducto bd_MarcaProducto = new BD_MarcaProducto();
        BD_RubroProducto bd_RubroProducto = new BD_RubroProducto();
        BD_DetalleProducto bd_DetalleProducto = new BD_DetalleProducto();

        public bool Registrar(DtoProducto oDtoProducto)
        {
            Producto p = new Producto();
            p.CodigoProducto = oDtoProducto.CodigoProducto;
            p.DescripcionProducto = oDtoProducto.DescripcionProducto;
            p.ORubroProducto = bd_RubroProducto.BuscarByDescripcion(oDtoProducto.DescripcionRubroProducto);
            p.OMarcaProducto = bd_MarcaProducto.BuscarByDescripcion(oDtoProducto.DescripcionMarcaProducto);
            p.CostoProducto = oDtoProducto.CostoProducto;
            p.OEstado = Operaciones.BuscarByDescripcion(oDtoProducto.DescripcionEstado);
            /// falta cargar los datos del datagrid en un array
            ////
            //////
            //////IMPORTANTE//////
          
            DtoDetalleProducto detProd = new DtoDetalleProducto();
            oDtoProducto.DetallePoducto.Add(detProd);
            
            //////
            
            if (bd_Producto.Registrar(p) > 0)
            {
                foreach (var item in oDtoProducto.DetallePoducto)
                {
                    ///pasar a detalle
                    DetalleProducto det = new DetalleProducto();
                    //det.IdProducto = item.
                    //bd_DetalleProducto.Registrar(item);
                }
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool Actualizar(DtoProducto oDtoProducto)
        {
            Producto p = new Producto();

            p.IdProducto = oDtoProducto.IdProducto;
            p.CodigoProducto = oDtoProducto.CodigoProducto;
            p.DescripcionProducto = oDtoProducto.DescripcionProducto;
            p.ORubroProducto = bd_RubroProducto.BuscarByDescripcion(oDtoProducto.DescripcionRubroProducto);
            p.OMarcaProducto = bd_MarcaProducto.BuscarByDescripcion(oDtoProducto.DescripcionMarcaProducto);
            p.CostoProducto = oDtoProducto.CostoProducto;
            p.OEstado = Operaciones.BuscarByDescripcion(oDtoProducto.DescripcionEstado);
            if (bd_Producto.Actualizar(p))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool Eliminar(int IdProducto)
        {
            return bd_Producto.Eliminar(IdProducto);
        }

        public List<DtoProducto> Mostrar()
        {
            List<DtoProducto> lista = new List<DtoProducto>();
            foreach (var item in bd_Producto.Mostrar())
            { 
                DtoProducto prod = new DtoProducto
                {
                    IdProducto = item.IdProducto,
                    CodigoProducto = item.CodigoProducto,
                    DescripcionProducto = item.DescripcionProducto,
                    DescripcionRubroProducto = item.ORubroProducto.DescripcionRubroProducto,
                    DescripcionMarcaProducto = item.OMarcaProducto.DescripcionMarcaProducto,
                    CostoProducto = item.CostoProducto,
                    DescripcionEstado = item.OEstado.ToString(),
                    FechaRegistro = item.FechaRegistro
                };
                lista.Add(prod);
            }
            return lista;
        }

        public DtoFormProducto GetFormulario()
        {
            DtoFormProducto form = new DtoFormProducto();
            form.ListRubroProducto = new List<string>();
            form.ListMarcaProducto= new List<string>();
            form.ListGeneroProducto = new List<string>();
            form.ListTipoTalle = new List<string>();
            form.ListTalle = new List<(string,string)>();
            form.ListColor = new List<string>();
            form.ListEstado = new List<string>();
            var genero = BD_GeneroProducto.MostrarGeneroProducto();
            var marca = bd_MarcaProducto.Mostrar();
            var rubro = bd_RubroProducto.Mostrar();
            var tipo = BD_TipoTalle.MostrarTipoTalle();
            var talle = BD_Talle.MostrarTalle();
            var color = BD_Color.MostrarColor() ;
            form.ListEstado.Add("Activo");
            form.ListEstado.Add("Inactivo");

            foreach (var item in genero)
            {
                form.ListGeneroProducto.Add(item.DescripcionGeneroProducto);
            }
            foreach (var item in rubro)
            {
                form.ListRubroProducto.Add(item.DescripcionRubroProducto);
            }
            foreach (var item in marca)
            {
                form.ListMarcaProducto.Add(item.DescripcionMarcaProducto);
            }
            foreach (var item in tipo)
            {
                form.ListTipoTalle.Add(item.DescripcionTipoTalle);
                foreach (var item2 in talle)
                {
                    if (item.IdTipoTalle.Equals(item2.OTipoTalle.IdTipoTalle))
                    {
                        form.ListTalle.Add((item.DescripcionTipoTalle, item2.DescripcionTalle));
                    }
                }
            }

            foreach (var item in color)
            {
                form.ListColor.Add(item.DescripcionColor);
            }

            return form;
        }

        public List<DtoDetalleProducto> MostrarDetalle()
        {
            List<DtoDetalleProducto> lista = new List<DtoDetalleProducto>();
            foreach (var item in bd_DetalleProducto.Mostrar())
            {
                DtoDetalleProducto detprod = new DtoDetalleProducto
                {
                    IdDetalleProducto = item.IdDetalleProducto,
                    CodigoProducto = bd_Producto.BuscarById(item.IdProducto).CodigoProducto,
                    DescripcionProducto = bd_Producto.BuscarById(item.IdProducto).DescripcionProducto,
                    //TalleProducto
                    //ColorProducto
                    PrecioCosto = bd_Producto.BuscarById(item.IdProducto).CostoProducto,
                    MargenGanancia = bd_RubroProducto.BuscarById(bd_Producto.BuscarById(item.IdProducto).ORubroProducto.IdRubroProducto).MargenGanancia,
                    StockProducto = item.StockProducto,
                    DescripcionEstado = item.OEstado.ToString(),
            };
                lista.Add(detprod);
            }
            return lista;
        }

        public DetalleProducto BuscarDetalleProductoById(int idProductoVenta)
        {
            throw new System.NotImplementedException();
        }
    }
}

