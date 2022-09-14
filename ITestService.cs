using System;
using System.ServiceModel;

namespace SampleWcfService
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        string DisplayIntValue(int value);

        [OperationContract]
        string DisplayStringValue(string value);
        
        [OperationContract]
        string GetDirectoryContents(string path, string searchPattern, bool recursive);

        [OperationContract]
        string GetDirectoryFiles(string path, string searchPattern, bool recursive);

        [OperationContract]
        string GetDirectorySubDirectories(string path, string searchPattern, bool recursive);

        [OperationContract]
        bool GetDirectoryExists(string path);
        
        [OperationContract]
        string GetDirectoryInfo(string path);
        
        [OperationContract]
        bool GetFileExists(string path);
        
        [OperationContract]
        string GetFileInfo(string path);
        
        [OperationContract]
        string GetDNSHostName();
        
        [OperationContract]
        string GetLocalIPV4Address();
        
        [OperationContract]
        string GetLocalIPV6Address();

        [OperationContract]
        string GetEnvironmentVariable(string name);
        
        [OperationContract]
        string GetMachineEnvironmentVariable(string name);
        
        [OperationContract]
        string GetMachineEnvironmentVariables();
        
        [OperationContract]
        string GetProcessEnvironmentVariable(string name);
        
        [OperationContract]
        string GetProcessEnvironmentVariables();
        
        [OperationContract]
        string GetUserEnvironmentVariable(string name);
        
        [OperationContract]
        string GetUserEnvironmentVariables();
        
        [OperationContract]
        string GetEnvironmentVariables();
        
        [OperationContract]
        string GetOS();
        
        [OperationContract]
        bool GetIs64BitOS();
        
        [OperationContract]
        bool GetIs64BitProcess();
        
        [OperationContract]
        string GetHostName();
        
        [OperationContract]
        string GetUserDomainName();
        
        [OperationContract]
        string GetUserName();
        
        [OperationContract]
        string GetFullUserName();
        
        [OperationContract]
        string GetWebOperationContext();
        
        [OperationContract]
        string GetIncomingRequestContext();
        
        [OperationContract]
        string GetIncomingResponseContext();
        
        [OperationContract]
        string GetOutgoingRequestContext();
        
        [OperationContract]
        string GetOutgoingResponseContext();

        [OperationContract]
        Uri GetRequestUri();

        [OperationContract]
        Uri GetRequestBaseUri();

        [OperationContract]
        string GetRequestQueryParameters();

        [OperationContract]
        string GetRequestHeaders();

        [OperationContract]
        string GetRequestUriTemplateMatch();
    }
}
