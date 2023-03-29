﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PLMVC.AlumnoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AlumnoService.IAlumnoService")]
    public interface IAlumnoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Add", ReplyAction="http://tempuri.org/IAlumnoService/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        ML.Result Add(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Add", ReplyAction="http://tempuri.org/IAlumnoService/AddResponse")]
        System.Threading.Tasks.Task<ML.Result> AddAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Update", ReplyAction="http://tempuri.org/IAlumnoService/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        ML.Result Update(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Update", ReplyAction="http://tempuri.org/IAlumnoService/UpdateResponse")]
        System.Threading.Tasks.Task<ML.Result> UpdateAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Delete", ReplyAction="http://tempuri.org/IAlumnoService/DeleteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        ML.Result Delete(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Delete", ReplyAction="http://tempuri.org/IAlumnoService/DeleteResponse")]
        System.Threading.Tasks.Task<ML.Result> DeleteAsync(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetAll", ReplyAction="http://tempuri.org/IAlumnoService/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        ML.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetAll", ReplyAction="http://tempuri.org/IAlumnoService/GetAllResponse")]
        System.Threading.Tasks.Task<ML.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetById", ReplyAction="http://tempuri.org/IAlumnoService/GetByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        ML.Result GetById(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetById", ReplyAction="http://tempuri.org/IAlumnoService/GetByIdResponse")]
        System.Threading.Tasks.Task<ML.Result> GetByIdAsync(int idAlumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnoServiceChannel : PLMVC.AlumnoService.IAlumnoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnoServiceClient : System.ServiceModel.ClientBase<PLMVC.AlumnoService.IAlumnoService>, PLMVC.AlumnoService.IAlumnoService {
        
        public AlumnoServiceClient() {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ML.Result Add(ML.Alumno alumno) {
            return base.Channel.Add(alumno);
        }
        
        public System.Threading.Tasks.Task<ML.Result> AddAsync(ML.Alumno alumno) {
            return base.Channel.AddAsync(alumno);
        }
        
        public ML.Result Update(ML.Alumno alumno) {
            return base.Channel.Update(alumno);
        }
        
        public System.Threading.Tasks.Task<ML.Result> UpdateAsync(ML.Alumno alumno) {
            return base.Channel.UpdateAsync(alumno);
        }
        
        public ML.Result Delete(int idAlumno) {
            return base.Channel.Delete(idAlumno);
        }
        
        public System.Threading.Tasks.Task<ML.Result> DeleteAsync(int idAlumno) {
            return base.Channel.DeleteAsync(idAlumno);
        }
        
        public ML.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ML.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ML.Result GetById(int idAlumno) {
            return base.Channel.GetById(idAlumno);
        }
        
        public System.Threading.Tasks.Task<ML.Result> GetByIdAsync(int idAlumno) {
            return base.Channel.GetByIdAsync(idAlumno);
        }
    }
}
