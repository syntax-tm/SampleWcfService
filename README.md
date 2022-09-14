# SampleWcfService

## Summary

WCF service to help with troubleshooting issues in deployed Docker containers.

## Service Methods

```csharp
    public interface ITestService
    {
        string Ping();

        string DisplayIntValue(int value);

        string DisplayStringValue(string value);
        
        string GetDirectoryContents(string path, string searchPattern, bool recursive);

        string GetDirectoryFiles(string path, string searchPattern, bool recursive);

        string GetDirectorySubDirectories(string path, string searchPattern, bool recursive);

        bool GetDirectoryExists(string path);
        
        string GetDirectoryInfo(string path);
        
        bool GetFileExists(string path);
        
        string GetFileInfo(string path);
        
        string GetDNSHostName();
        
        string GetLocalIPV4Address();
        
        string GetLocalIPV6Address();

        string GetEnvironmentVariable(string name);
        
        string GetMachineEnvironmentVariable(string name);
        
        string GetMachineEnvironmentVariables();
        
        string GetProcessEnvironmentVariable(string name);
        
        string GetProcessEnvironmentVariables();
        
        string GetUserEnvironmentVariable(string name);
        
        string GetUserEnvironmentVariables();
        
        string GetEnvironmentVariables();
        
        string GetOS();
        
        bool GetIs64BitOS();
        
        bool GetIs64BitProcess();
        
        string GetHostName();
        
        string GetUserDomainName();
        
        string GetUserName();
        
        string GetFullUserName();
        
        string GetWebOperationContext();
        
        string GetIncomingRequestContext();
        
        string GetIncomingResponseContext();
        
        string GetOutgoingRequestContext();
        
        string GetOutgoingResponseContext();

        Uri GetRequestUri();

        Uri GetRequestBaseUri();

        string GetRequestQueryParameters();

        string GetRequestHeaders();

        string GetRequestUriTemplateMatch();
    }
``