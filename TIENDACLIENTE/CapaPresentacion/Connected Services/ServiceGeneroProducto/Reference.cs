﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceGeneroProducto
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DtoGeneroProducto", Namespace="http://schemas.datacontract.org/2004/07/CapaServicioServidor")]
    public partial class DtoGeneroProducto : object
    {
        
        private string DescripcionGeneroProductoField;
        
        private System.DateTime FechaRegistroField;
        
        private int IdGeneroProductoField;
        
        private ServiceGeneroProducto.Estado OEstadoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DescripcionGeneroProducto
        {
            get
            {
                return this.DescripcionGeneroProductoField;
            }
            set
            {
                this.DescripcionGeneroProductoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaRegistro
        {
            get
            {
                return this.FechaRegistroField;
            }
            set
            {
                this.FechaRegistroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdGeneroProducto
        {
            get
            {
                return this.IdGeneroProductoField;
            }
            set
            {
                this.IdGeneroProductoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceGeneroProducto.Estado OEstado
        {
            get
            {
                return this.OEstadoField;
            }
            set
            {
                this.OEstadoField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Estado", Namespace="http://schemas.datacontract.org/2004/07/CapaNegocio")]
    public enum Estado : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Inactivo = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Activo = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GeneroProducto", Namespace="http://schemas.datacontract.org/2004/07/CapaNegocio")]
    public partial class GeneroProducto : object
    {
        
        private string DescripcionGeneroProductoField;
        
        private System.DateTime FechaRegistroField;
        
        private int IdGeneroProductoField;
        
        private ServiceGeneroProducto.Estado OEstadoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DescripcionGeneroProducto
        {
            get
            {
                return this.DescripcionGeneroProductoField;
            }
            set
            {
                this.DescripcionGeneroProductoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaRegistro
        {
            get
            {
                return this.FechaRegistroField;
            }
            set
            {
                this.FechaRegistroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdGeneroProducto
        {
            get
            {
                return this.IdGeneroProductoField;
            }
            set
            {
                this.IdGeneroProductoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceGeneroProducto.Estado OEstado
        {
            get
            {
                return this.OEstadoField;
            }
            set
            {
                this.OEstadoField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceGeneroProducto.IServiceGeneroProducto")]
    public interface IServiceGeneroProducto
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/AgregarGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/AgregarGeneroProductoResponse")]
        bool AgregarGeneroProducto(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/AgregarGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/AgregarGeneroProductoResponse")]
        System.Threading.Tasks.Task<bool> AgregarGeneroProductoAsync(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/ModificarGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/ModificarGeneroProductoResponse")]
        bool ModificarGeneroProducto(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto, int IdGeneroProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/ModificarGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/ModificarGeneroProductoResponse")]
        System.Threading.Tasks.Task<bool> ModificarGeneroProductoAsync(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto, int IdGeneroProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/EliminarGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/EliminarGeneroProductoResponse")]
        bool EliminarGeneroProducto(int IdGeneroProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/EliminarGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/EliminarGeneroProductoResponse")]
        System.Threading.Tasks.Task<bool> EliminarGeneroProductoAsync(int IdGeneroProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/ListaGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/ListaGeneroProductoResponse")]
        ServiceGeneroProducto.DtoGeneroProducto[] ListaGeneroProducto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/ListaGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/ListaGeneroProductoResponse")]
        System.Threading.Tasks.Task<ServiceGeneroProducto.DtoGeneroProducto[]> ListaGeneroProductoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/ObtenerGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/ObtenerGeneroProductoResponse")]
        ServiceGeneroProducto.GeneroProducto ObtenerGeneroProducto(string oGeneroProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGeneroProducto/ObtenerGeneroProducto", ReplyAction="http://tempuri.org/IServiceGeneroProducto/ObtenerGeneroProductoResponse")]
        System.Threading.Tasks.Task<ServiceGeneroProducto.GeneroProducto> ObtenerGeneroProductoAsync(string oGeneroProducto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IServiceGeneroProductoChannel : ServiceGeneroProducto.IServiceGeneroProducto, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class ServiceGeneroProductoClient : System.ServiceModel.ClientBase<ServiceGeneroProducto.IServiceGeneroProducto>, ServiceGeneroProducto.IServiceGeneroProducto
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceGeneroProductoClient() : 
                base(ServiceGeneroProductoClient.GetDefaultBinding(), ServiceGeneroProductoClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServiceGeneroProducto.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceGeneroProductoClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceGeneroProductoClient.GetBindingForEndpoint(endpointConfiguration), ServiceGeneroProductoClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceGeneroProductoClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceGeneroProductoClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceGeneroProductoClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceGeneroProductoClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceGeneroProductoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public bool AgregarGeneroProducto(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto)
        {
            return base.Channel.AgregarGeneroProducto(oGeneroProducto);
        }
        
        public System.Threading.Tasks.Task<bool> AgregarGeneroProductoAsync(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto)
        {
            return base.Channel.AgregarGeneroProductoAsync(oGeneroProducto);
        }
        
        public bool ModificarGeneroProducto(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto, int IdGeneroProducto)
        {
            return base.Channel.ModificarGeneroProducto(oGeneroProducto, IdGeneroProducto);
        }
        
        public System.Threading.Tasks.Task<bool> ModificarGeneroProductoAsync(ServiceGeneroProducto.DtoGeneroProducto oGeneroProducto, int IdGeneroProducto)
        {
            return base.Channel.ModificarGeneroProductoAsync(oGeneroProducto, IdGeneroProducto);
        }
        
        public bool EliminarGeneroProducto(int IdGeneroProducto)
        {
            return base.Channel.EliminarGeneroProducto(IdGeneroProducto);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarGeneroProductoAsync(int IdGeneroProducto)
        {
            return base.Channel.EliminarGeneroProductoAsync(IdGeneroProducto);
        }
        
        public ServiceGeneroProducto.DtoGeneroProducto[] ListaGeneroProducto()
        {
            return base.Channel.ListaGeneroProducto();
        }
        
        public System.Threading.Tasks.Task<ServiceGeneroProducto.DtoGeneroProducto[]> ListaGeneroProductoAsync()
        {
            return base.Channel.ListaGeneroProductoAsync();
        }
        
        public ServiceGeneroProducto.GeneroProducto ObtenerGeneroProducto(string oGeneroProducto)
        {
            return base.Channel.ObtenerGeneroProducto(oGeneroProducto);
        }
        
        public System.Threading.Tasks.Task<ServiceGeneroProducto.GeneroProducto> ObtenerGeneroProductoAsync(string oGeneroProducto)
        {
            return base.Channel.ObtenerGeneroProductoAsync(oGeneroProducto);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceGeneroProducto))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceGeneroProducto))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:10524/ServiceGeneroProducto.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceGeneroProductoClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServiceGeneroProducto);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceGeneroProductoClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServiceGeneroProducto);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServiceGeneroProducto,
        }
    }
}
