﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceCliente
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DtoCliente", Namespace="http://schemas.datacontract.org/2004/07/CapaServicioServidor")]
    public partial class DtoCliente : object
    {
        
        private string CuitField;
        
        private string DomicilioFiscalField;
        
        private System.DateTime FechaRegistroField;
        
        private int IdClienteField;
        
        private ServiceCliente.CondicionTributaria OCondicionTributariaField;
        
        private string RazonSocialField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cuit
        {
            get
            {
                return this.CuitField;
            }
            set
            {
                this.CuitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DomicilioFiscal
        {
            get
            {
                return this.DomicilioFiscalField;
            }
            set
            {
                this.DomicilioFiscalField = value;
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
        public int IdCliente
        {
            get
            {
                return this.IdClienteField;
            }
            set
            {
                this.IdClienteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceCliente.CondicionTributaria OCondicionTributaria
        {
            get
            {
                return this.OCondicionTributariaField;
            }
            set
            {
                this.OCondicionTributariaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RazonSocial
        {
            get
            {
                return this.RazonSocialField;
            }
            set
            {
                this.RazonSocialField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CondicionTributaria", Namespace="http://schemas.datacontract.org/2004/07/CapaNegocio")]
    public partial class CondicionTributaria : object
    {
        
        private string CodigoField;
        
        private string DescripcionField;
        
        private System.DateTime FechaRegistroField;
        
        private int IdCondicionTributariaField;
        
        private ServiceCliente.Estado OEstadoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigo
        {
            get
            {
                return this.CodigoField;
            }
            set
            {
                this.CodigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
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
        public int IdCondicionTributaria
        {
            get
            {
                return this.IdCondicionTributariaField;
            }
            set
            {
                this.IdCondicionTributariaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceCliente.Estado OEstado
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Estado", Namespace="http://schemas.datacontract.org/2004/07/CapaNegocio")]
    public enum Estado : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Activo = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Inactivo = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceCliente.IServiceCliente")]
    public interface IServiceCliente
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/AgregarCliente", ReplyAction="http://tempuri.org/IServiceCliente/AgregarClienteResponse")]
        bool AgregarCliente(ServiceCliente.DtoCliente oCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/AgregarCliente", ReplyAction="http://tempuri.org/IServiceCliente/AgregarClienteResponse")]
        System.Threading.Tasks.Task<bool> AgregarClienteAsync(ServiceCliente.DtoCliente oCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/ModificarCliente", ReplyAction="http://tempuri.org/IServiceCliente/ModificarClienteResponse")]
        bool ModificarCliente(ServiceCliente.DtoCliente oCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/ModificarCliente", ReplyAction="http://tempuri.org/IServiceCliente/ModificarClienteResponse")]
        System.Threading.Tasks.Task<bool> ModificarClienteAsync(ServiceCliente.DtoCliente oCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/EliminarCliente", ReplyAction="http://tempuri.org/IServiceCliente/EliminarClienteResponse")]
        bool EliminarCliente(int IdCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/EliminarCliente", ReplyAction="http://tempuri.org/IServiceCliente/EliminarClienteResponse")]
        System.Threading.Tasks.Task<bool> EliminarClienteAsync(int IdCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/ListaCliente", ReplyAction="http://tempuri.org/IServiceCliente/ListaClienteResponse")]
        System.Collections.Generic.List<ServiceCliente.DtoCliente> ListaCliente();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/ListaCliente", ReplyAction="http://tempuri.org/IServiceCliente/ListaClienteResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ServiceCliente.DtoCliente>> ListaClienteAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface IServiceClienteChannel : ServiceCliente.IServiceCliente, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class ServiceClienteClient : System.ServiceModel.ClientBase<ServiceCliente.IServiceCliente>, ServiceCliente.IServiceCliente
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceClienteClient() : 
                base(ServiceClienteClient.GetDefaultBinding(), ServiceClienteClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServiceCliente.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClienteClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceClienteClient.GetBindingForEndpoint(endpointConfiguration), ServiceClienteClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClienteClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceClienteClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClienteClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceClienteClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceClienteClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public bool AgregarCliente(ServiceCliente.DtoCliente oCliente)
        {
            return base.Channel.AgregarCliente(oCliente);
        }
        
        public System.Threading.Tasks.Task<bool> AgregarClienteAsync(ServiceCliente.DtoCliente oCliente)
        {
            return base.Channel.AgregarClienteAsync(oCliente);
        }
        
        public bool ModificarCliente(ServiceCliente.DtoCliente oCliente)
        {
            return base.Channel.ModificarCliente(oCliente);
        }
        
        public System.Threading.Tasks.Task<bool> ModificarClienteAsync(ServiceCliente.DtoCliente oCliente)
        {
            return base.Channel.ModificarClienteAsync(oCliente);
        }
        
        public bool EliminarCliente(int IdCliente)
        {
            return base.Channel.EliminarCliente(IdCliente);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarClienteAsync(int IdCliente)
        {
            return base.Channel.EliminarClienteAsync(IdCliente);
        }
        
        public System.Collections.Generic.List<ServiceCliente.DtoCliente> ListaCliente()
        {
            return base.Channel.ListaCliente();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ServiceCliente.DtoCliente>> ListaClienteAsync()
        {
            return base.Channel.ListaClienteAsync();
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceCliente))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceCliente))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:10524/ServiceCliente.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceClienteClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServiceCliente);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceClienteClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServiceCliente);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServiceCliente,
        }
    }
}
