﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _03.StringOccurenceCounterHost.TestStringOccurenceCounter {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TestStringOccurenceCounter.IStringOccurenceCounter")]
    public interface IStringOccurenceCounter {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStringOccurenceCounter/GetData", ReplyAction="http://tempuri.org/IStringOccurenceCounter/GetDataResponse")]
        int GetData(string toBeMatched, string toCountFrom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStringOccurenceCounter/GetData", ReplyAction="http://tempuri.org/IStringOccurenceCounter/GetDataResponse")]
        System.Threading.Tasks.Task<int> GetDataAsync(string toBeMatched, string toCountFrom);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStringOccurenceCounterChannel : _03.StringOccurenceCounterHost.TestStringOccurenceCounter.IStringOccurenceCounter, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StringOccurenceCounterClient : System.ServiceModel.ClientBase<_03.StringOccurenceCounterHost.TestStringOccurenceCounter.IStringOccurenceCounter>, _03.StringOccurenceCounterHost.TestStringOccurenceCounter.IStringOccurenceCounter {
        
        public StringOccurenceCounterClient() {
        }
        
        public StringOccurenceCounterClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StringOccurenceCounterClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StringOccurenceCounterClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StringOccurenceCounterClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetData(string toBeMatched, string toCountFrom) {
            return base.Channel.GetData(toBeMatched, toCountFrom);
        }
        
        public System.Threading.Tasks.Task<int> GetDataAsync(string toBeMatched, string toCountFrom) {
            return base.Channel.GetDataAsync(toBeMatched, toCountFrom);
        }
    }
}
