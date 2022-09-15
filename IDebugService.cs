using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfDebug
{
    [ServiceContract]
    public interface IDebugService
    {
        [OperationContract]
        [WebGet]
        string Ping();

        [OperationContract]
        [WebGet(UriTemplate = "/echoIntValue/{value}")]
        string EchoIntValue(int value);

        [OperationContract]
        [WebGet(UriTemplate = "/echoStringValue/{value}")]
        string EchoStringValue(string value);
        
        [OperationContract]
        [WebInvoke(Method = HttpMethods.POST,
                   RequestFormat  = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetDirectoryContents(FileSystemSearchOptions searchOptions);

        [OperationContract]
        [WebInvoke(Method = HttpMethods.POST,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetDirectoryFiles(FileSystemSearchOptions searchOptions);

        [OperationContract]
        [WebInvoke(Method = HttpMethods.POST,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetDirectorySubDirectories(FileSystemSearchOptions searchOptions);

        [OperationContract]
        [WebInvoke(Method = HttpMethods.POST,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool GetDirectoryExists(string path);
        
        [OperationContract]
        [WebInvoke(Method = HttpMethods.POST,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetDirectoryInfo(string path);
        
        [OperationContract]
        [WebInvoke(Method = HttpMethods.POST,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool GetFileExists(string path);
        
        [OperationContract]
        [WebInvoke(Method = HttpMethods.POST,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetFileInfo(string path);
        
        [OperationContract]
        [WebGet]
        string GetDNSHostName();
        
        [OperationContract]
        [WebGet]
        string GetLocalIPV4Address();
        
        [OperationContract]
        [WebGet]
        string GetLocalIPV6Address();

        [OperationContract]
        [WebGet(UriTemplate = "/getEnvironmentVariable/{name}")]
        string GetEnvironmentVariable(string name);
        
        [OperationContract]
        [WebGet(UriTemplate = "/getMachineEnvironmentVariable/{name}")]
        string GetMachineEnvironmentVariable(string name);
        
        [OperationContract]
        [WebGet]
        string GetMachineEnvironmentVariables();
        
        [OperationContract]
        [WebGet(UriTemplate = "/getProcessEnvironmentVariable/{name}")]
        string GetProcessEnvironmentVariable(string name);
        
        [OperationContract]
        [WebGet]
        string GetProcessEnvironmentVariables();
        
        [OperationContract]
        [WebGet(UriTemplate = "/getUserEnvironmentVariable/{name}")]
        string GetUserEnvironmentVariable(string name);
        
        [OperationContract]
        [WebGet]
        string GetUserEnvironmentVariables();
        
        [OperationContract]
        [WebGet]
        string GetEnvironmentVariables();
        
        [OperationContract]
        [WebGet]
        string GetOS();
        
        [OperationContract]
        [WebGet]
        bool GetIs64BitOS();
        
        [OperationContract]
        [WebGet]
        bool GetIs64BitProcess();
        
        [OperationContract]
        [WebGet]
        string GetHostName();
        
        [OperationContract]
        [WebGet]
        string GetUserDomainName();
        
        [OperationContract]
        [WebGet]
        string GetUserName();
        
        [OperationContract]
        [WebGet]
        string GetFullUserName();
        
        [OperationContract]
        [WebGet]
        string GetWebOperationContext();
        
        [OperationContract]
        [WebGet]
        string GetIncomingRequestContext();
        
        [OperationContract]
        [WebGet]
        string GetIncomingResponseContext();
        
        [OperationContract]
        [WebGet]
        string GetOutgoingRequestContext();
        
        [OperationContract]
        [WebGet]
        string GetOutgoingResponseContext();

        [OperationContract]
        [WebGet]
        Uri GetRequestUri();

        [OperationContract]
        [WebGet]
        Uri GetRequestBaseUri();

        [OperationContract]
        [WebGet]
        string GetRequestQueryParameters();

        [OperationContract]
        [WebGet]
        string GetRequestHeaders();

        [OperationContract]
        [WebGet]
        string GetRequestUriTemplateMatch();
    }
}
