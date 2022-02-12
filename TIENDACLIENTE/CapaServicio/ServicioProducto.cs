using CapaAbstraccion;
using ServiceProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
    //public class ServicioProducto : ICrudAsync<Producto>
    //{
    //    ServiceProductoClient client_prod = new();

    //    public async Task<bool> AddEntity(Producto entity)
    //    {
    //        _ = client_prod.ListaProducto();
    //        DtoProducto prod = new DtoProducto();
    //        prod.CodigoProducto = entity.CodigoProducto;
    //        prod.DescripcionProducto = entity.DescripcionProducto;
    //        prod.OGeneroProducto = entity.OGeneroProducto;
    //        prod.ORubroProducto = entity.ORubroProducto;
    //        prod.OMarca = entity.OMarca; 
    //        prod.OTipoTalle = entity.OTipoTalle;
    //        var request = client_prod.IngresarProducto(prod);
    //        return request;
    //    }

    //    public Task<bool> DeleteEntity(Producto entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<List<Producto>> ListEntity()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Producto> SearchEntityById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> UpdateEntity(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
