﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceUsuario
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseRespuesta", Namespace="http://schemas.datacontract.org/2004/07/CapaServicioServidor")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServiceUsuario.DtoUsuario))]
    public partial class BaseRespuesta : object
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DtoUsuario", Namespace="http://schemas.datacontract.org/2004/07/CapaServicioServidor")]
    public partial class DtoUsuario : ServiceUsuario.BaseRespuesta
    {
        
        private string ContraseñaField;
        
        private ServiceUsuario.Estado EstadoField;
        
        private System.DateTime FechaRegistroField;
        
        private int IdUsuarioField;
        
        private string NombreUsuarioField;
        
        private string RolField;
        
        private string TiendaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contraseña
        {
            get
            {
                return this.ContraseñaField;
            }
            set
            {
                this.ContraseñaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceUsuario.Estado Estado
        {
            get
            {
                return this.EstadoField;
            }
            set
            {
                this.EstadoField = value;
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
        public int IdUsuario
        {
            get
            {
                return this.IdUsuarioField;
            }
            set
            {
                this.IdUsuarioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuario
        {
            get
            {
                return this.NombreUsuarioField;
            }
            set
            {
                this.NombreUsuarioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Rol
        {
            get
            {
                return this.RolField;
            }
            set
            {
                this.RolField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tienda
        {
            get
            {
                return this.TiendaField;
            }
            set
            {
                this.TiendaField = value;
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceUsuario.IServiceUsuario")]
    public interface IServiceUsuario
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/AgregarUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/AgregarUsuarioResponse")]
        bool AgregarUsuario(ServiceUsuario.DtoUsuario oUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/AgregarUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/AgregarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> AgregarUsuarioAsync(ServiceUsuario.DtoUsuario oUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/ModificarUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/ModificarUsuarioResponse")]
        bool ModificarUsuario(ServiceUsuario.DtoUsuario oUsuario, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/ModificarUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/ModificarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> ModificarUsuarioAsync(ServiceUsuario.DtoUsuario oUsuario, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/EliminarUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/EliminarUsuarioResponse")]
        bool EliminarUsuario(int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/EliminarUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/EliminarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> EliminarUsuarioAsync(int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/LoginUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/LoginUsuarioResponse")]
        bool LoginUsuario(string usuario, string contraseña);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/LoginUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/LoginUsuarioResponse")]
        System.Threading.Tasks.Task<bool> LoginUsuarioAsync(string usuario, string contraseña);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/ObtenerUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/ObtenerUsuarioResponse")]
        System.Collections.Generic.List<ServiceUsuario.DtoUsuario> ObtenerUsuario();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/ObtenerUsuario", ReplyAction="http://tempuri.org/IServiceUsuario/ObtenerUsuarioResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ServiceUsuario.DtoUsuario>> ObtenerUsuarioAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/BuscarEstado", ReplyAction="http://tempuri.org/IServiceUsuario/BuscarEstadoResponse")]
        ServiceUsuario.Estado BuscarEstado(string valor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/BuscarEstado", ReplyAction="http://tempuri.org/IServiceUsuario/BuscarEstadoResponse")]
        System.Threading.Tasks.Task<ServiceUsuario.Estado> BuscarEstadoAsync(string valor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/RecuperarContraseña", ReplyAction="http://tempuri.org/IServiceUsuario/RecuperarContraseñaResponse")]
        bool RecuperarContraseña(string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/RecuperarContraseña", ReplyAction="http://tempuri.org/IServiceUsuario/RecuperarContraseñaResponse")]
        System.Threading.Tasks.Task<bool> RecuperarContraseñaAsync(string usuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface IServiceUsuarioChannel : ServiceUsuario.IServiceUsuario, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class ServiceUsuarioClient : System.ServiceModel.ClientBase<ServiceUsuario.IServiceUsuario>, ServiceUsuario.IServiceUsuario
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceUsuarioClient() : 
                base(ServiceUsuarioClient.GetDefaultBinding(), ServiceUsuarioClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServiceUsuario.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceUsuarioClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceUsuarioClient.GetBindingForEndpoint(endpointConfiguration), ServiceUsuarioClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceUsuarioClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceUsuarioClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceUsuarioClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceUsuarioClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceUsuarioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public bool AgregarUsuario(ServiceUsuario.DtoUsuario oUsuario)
        {
            return base.Channel.AgregarUsuario(oUsuario);
        }
        
        public System.Threading.Tasks.Task<bool> AgregarUsuarioAsync(ServiceUsuario.DtoUsuario oUsuario)
        {
            return base.Channel.AgregarUsuarioAsync(oUsuario);
        }
        
        public bool ModificarUsuario(ServiceUsuario.DtoUsuario oUsuario, int IdUsuario)
        {
            return base.Channel.ModificarUsuario(oUsuario, IdUsuario);
        }
        
        public System.Threading.Tasks.Task<bool> ModificarUsuarioAsync(ServiceUsuario.DtoUsuario oUsuario, int IdUsuario)
        {
            return base.Channel.ModificarUsuarioAsync(oUsuario, IdUsuario);
        }
        
        public bool EliminarUsuario(int IdUsuario)
        {
            return base.Channel.EliminarUsuario(IdUsuario);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarUsuarioAsync(int IdUsuario)
        {
            return base.Channel.EliminarUsuarioAsync(IdUsuario);
        }
        
        public bool LoginUsuario(string usuario, string contraseña)
        {
            return base.Channel.LoginUsuario(usuario, contraseña);
        }
        
        public System.Threading.Tasks.Task<bool> LoginUsuarioAsync(string usuario, string contraseña)
        {
            return base.Channel.LoginUsuarioAsync(usuario, contraseña);
        }
        
        public System.Collections.Generic.List<ServiceUsuario.DtoUsuario> ObtenerUsuario()
        {
            return base.Channel.ObtenerUsuario();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ServiceUsuario.DtoUsuario>> ObtenerUsuarioAsync()
        {
            return base.Channel.ObtenerUsuarioAsync();
        }
        
        public ServiceUsuario.Estado BuscarEstado(string valor)
        {
            return base.Channel.BuscarEstado(valor);
        }
        
        public System.Threading.Tasks.Task<ServiceUsuario.Estado> BuscarEstadoAsync(string valor)
        {
            return base.Channel.BuscarEstadoAsync(valor);
        }
        
        public bool RecuperarContraseña(string usuario)
        {
            return base.Channel.RecuperarContraseña(usuario);
        }
        
        public System.Threading.Tasks.Task<bool> RecuperarContraseñaAsync(string usuario)
        {
            return base.Channel.RecuperarContraseñaAsync(usuario);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceUsuario))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceUsuario))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:10524/ServiceUsuario.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceUsuarioClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServiceUsuario);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceUsuarioClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServiceUsuario);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServiceUsuario,
        }
    }
}