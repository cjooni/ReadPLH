﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.wcfHighTop {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfHighTop")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcfHighTop.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcByParam", ReplyAction="http://tempuri.org/IService1/ProcByParamResponse")]
        string ProcByParam(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcByParam", ReplyAction="http://tempuri.org/IService1/ProcByParamResponse")]
        System.Threading.Tasks.Task<string> ProcByParamAsync(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcByNoneParam", ReplyAction="http://tempuri.org/IService1/ProcByNoneParamResponse")]
        string ProcByNoneParam(string strHeader);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcByNoneParam", ReplyAction="http://tempuri.org/IService1/ProcByNoneParamResponse")]
        System.Threading.Tasks.Task<string> ProcByNoneParamAsync(string strHeader);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcInsert", ReplyAction="http://tempuri.org/IService1/ProcInsertResponse")]
        string ProcInsert(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcInsert", ReplyAction="http://tempuri.org/IService1/ProcInsertResponse")]
        System.Threading.Tasks.Task<string> ProcInsertAsync(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcUpdate", ReplyAction="http://tempuri.org/IService1/ProcUpdateResponse")]
        string ProcUpdate(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcUpdate", ReplyAction="http://tempuri.org/IService1/ProcUpdateResponse")]
        System.Threading.Tasks.Task<string> ProcUpdateAsync(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcDelete", ReplyAction="http://tempuri.org/IService1/ProcDeleteResponse")]
        string ProcDelete(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ProcDelete", ReplyAction="http://tempuri.org/IService1/ProcDeleteResponse")]
        System.Threading.Tasks.Task<string> ProcDeleteAsync(string strHeader, string strParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        WindowsFormsApp1.wcfHighTop.CompositeType GetDataUsingDataContract(WindowsFormsApp1.wcfHighTop.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WindowsFormsApp1.wcfHighTop.CompositeType> GetDataUsingDataContractAsync(WindowsFormsApp1.wcfHighTop.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WindowsFormsApp1.wcfHighTop.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WindowsFormsApp1.wcfHighTop.IService1>, WindowsFormsApp1.wcfHighTop.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public string ProcByParam(string strHeader, string strParam) {
            return base.Channel.ProcByParam(strHeader, strParam);
        }
        
        public System.Threading.Tasks.Task<string> ProcByParamAsync(string strHeader, string strParam) {
            return base.Channel.ProcByParamAsync(strHeader, strParam);
        }
        
        public string ProcByNoneParam(string strHeader) {
            return base.Channel.ProcByNoneParam(strHeader);
        }
        
        public System.Threading.Tasks.Task<string> ProcByNoneParamAsync(string strHeader) {
            return base.Channel.ProcByNoneParamAsync(strHeader);
        }
        
        public string ProcInsert(string strHeader, string strParam) {
            return base.Channel.ProcInsert(strHeader, strParam);
        }
        
        public System.Threading.Tasks.Task<string> ProcInsertAsync(string strHeader, string strParam) {
            return base.Channel.ProcInsertAsync(strHeader, strParam);
        }
        
        public string ProcUpdate(string strHeader, string strParam) {
            return base.Channel.ProcUpdate(strHeader, strParam);
        }
        
        public System.Threading.Tasks.Task<string> ProcUpdateAsync(string strHeader, string strParam) {
            return base.Channel.ProcUpdateAsync(strHeader, strParam);
        }
        
        public string ProcDelete(string strHeader, string strParam) {
            return base.Channel.ProcDelete(strHeader, strParam);
        }
        
        public System.Threading.Tasks.Task<string> ProcDeleteAsync(string strHeader, string strParam) {
            return base.Channel.ProcDeleteAsync(strHeader, strParam);
        }
        
        public WindowsFormsApp1.wcfHighTop.CompositeType GetDataUsingDataContract(WindowsFormsApp1.wcfHighTop.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApp1.wcfHighTop.CompositeType> GetDataUsingDataContractAsync(WindowsFormsApp1.wcfHighTop.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
