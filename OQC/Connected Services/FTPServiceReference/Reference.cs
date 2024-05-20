﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OQC.FTPServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FTPServiceReference.FTPWebServiceSoap")]
    public interface FTPWebServiceSoap {
        
        // CODEGEN: Generating message contract since element name localPath from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DownloadFile", ReplyAction="*")]
        OQC.FTPServiceReference.DownloadFileResponse DownloadFile(OQC.FTPServiceReference.DownloadFileRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DownloadFile", ReplyAction="*")]
        System.Threading.Tasks.Task<OQC.FTPServiceReference.DownloadFileResponse> DownloadFileAsync(OQC.FTPServiceReference.DownloadFileRequest request);
        
        // CODEGEN: Generating message contract since element name localPath from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UploadFile", ReplyAction="*")]
        OQC.FTPServiceReference.UploadFileResponse UploadFile(OQC.FTPServiceReference.UploadFileRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UploadFile", ReplyAction="*")]
        System.Threading.Tasks.Task<OQC.FTPServiceReference.UploadFileResponse> UploadFileAsync(OQC.FTPServiceReference.UploadFileRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DownloadFileRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DownloadFile", Namespace="http://tempuri.org/", Order=0)]
        public OQC.FTPServiceReference.DownloadFileRequestBody Body;
        
        public DownloadFileRequest() {
        }
        
        public DownloadFileRequest(OQC.FTPServiceReference.DownloadFileRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class DownloadFileRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string localPath;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string remotePath;
        
        public DownloadFileRequestBody() {
        }
        
        public DownloadFileRequestBody(string localPath, string remotePath) {
            this.localPath = localPath;
            this.remotePath = remotePath;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DownloadFileResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DownloadFileResponse", Namespace="http://tempuri.org/", Order=0)]
        public OQC.FTPServiceReference.DownloadFileResponseBody Body;
        
        public DownloadFileResponse() {
        }
        
        public DownloadFileResponse(OQC.FTPServiceReference.DownloadFileResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class DownloadFileResponseBody {
        
        public DownloadFileResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadFileRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UploadFile", Namespace="http://tempuri.org/", Order=0)]
        public OQC.FTPServiceReference.UploadFileRequestBody Body;
        
        public UploadFileRequest() {
        }
        
        public UploadFileRequest(OQC.FTPServiceReference.UploadFileRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadFileRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string localPath;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string remotePath;
        
        public UploadFileRequestBody() {
        }
        
        public UploadFileRequestBody(string localPath, string remotePath) {
            this.localPath = localPath;
            this.remotePath = remotePath;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadFileResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UploadFileResponse", Namespace="http://tempuri.org/", Order=0)]
        public OQC.FTPServiceReference.UploadFileResponseBody Body;
        
        public UploadFileResponse() {
        }
        
        public UploadFileResponse(OQC.FTPServiceReference.UploadFileResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class UploadFileResponseBody {
        
        public UploadFileResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FTPWebServiceSoapChannel : OQC.FTPServiceReference.FTPWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FTPWebServiceSoapClient : System.ServiceModel.ClientBase<OQC.FTPServiceReference.FTPWebServiceSoap>, OQC.FTPServiceReference.FTPWebServiceSoap {
        
        public FTPWebServiceSoapClient() {
        }
        
        public FTPWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FTPWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FTPWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FTPWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OQC.FTPServiceReference.DownloadFileResponse OQC.FTPServiceReference.FTPWebServiceSoap.DownloadFile(OQC.FTPServiceReference.DownloadFileRequest request) {
            return base.Channel.DownloadFile(request);
        }
        
        public void DownloadFile(string localPath, string remotePath) {
            OQC.FTPServiceReference.DownloadFileRequest inValue = new OQC.FTPServiceReference.DownloadFileRequest();
            inValue.Body = new OQC.FTPServiceReference.DownloadFileRequestBody();
            inValue.Body.localPath = localPath;
            inValue.Body.remotePath = remotePath;
            OQC.FTPServiceReference.DownloadFileResponse retVal = ((OQC.FTPServiceReference.FTPWebServiceSoap)(this)).DownloadFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OQC.FTPServiceReference.DownloadFileResponse> OQC.FTPServiceReference.FTPWebServiceSoap.DownloadFileAsync(OQC.FTPServiceReference.DownloadFileRequest request) {
            return base.Channel.DownloadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<OQC.FTPServiceReference.DownloadFileResponse> DownloadFileAsync(string localPath, string remotePath) {
            OQC.FTPServiceReference.DownloadFileRequest inValue = new OQC.FTPServiceReference.DownloadFileRequest();
            inValue.Body = new OQC.FTPServiceReference.DownloadFileRequestBody();
            inValue.Body.localPath = localPath;
            inValue.Body.remotePath = remotePath;
            return ((OQC.FTPServiceReference.FTPWebServiceSoap)(this)).DownloadFileAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OQC.FTPServiceReference.UploadFileResponse OQC.FTPServiceReference.FTPWebServiceSoap.UploadFile(OQC.FTPServiceReference.UploadFileRequest request) {
            return base.Channel.UploadFile(request);
        }
        
        public void UploadFile(string localPath, string remotePath) {
            OQC.FTPServiceReference.UploadFileRequest inValue = new OQC.FTPServiceReference.UploadFileRequest();
            inValue.Body = new OQC.FTPServiceReference.UploadFileRequestBody();
            inValue.Body.localPath = localPath;
            inValue.Body.remotePath = remotePath;
            OQC.FTPServiceReference.UploadFileResponse retVal = ((OQC.FTPServiceReference.FTPWebServiceSoap)(this)).UploadFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OQC.FTPServiceReference.UploadFileResponse> OQC.FTPServiceReference.FTPWebServiceSoap.UploadFileAsync(OQC.FTPServiceReference.UploadFileRequest request) {
            return base.Channel.UploadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<OQC.FTPServiceReference.UploadFileResponse> UploadFileAsync(string localPath, string remotePath) {
            OQC.FTPServiceReference.UploadFileRequest inValue = new OQC.FTPServiceReference.UploadFileRequest();
            inValue.Body = new OQC.FTPServiceReference.UploadFileRequestBody();
            inValue.Body.localPath = localPath;
            inValue.Body.remotePath = remotePath;
            return ((OQC.FTPServiceReference.FTPWebServiceSoap)(this)).UploadFileAsync(inValue);
        }
    }
}