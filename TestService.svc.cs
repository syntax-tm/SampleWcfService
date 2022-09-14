using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel.Web;
using Newtonsoft.Json;

namespace SampleWcfService
{
    public class TestService : ITestService
    {
        public string Ping()
        {
            return @"Pong";
        }
        
        public string DisplayIntValue(int value)
        {
            return $"You entered: {value}";
        }
        
        public string DisplayStringValue(string value)
        {
            return $"You entered: {value}";
        }

        public string GetDirectoryContents(string path, string searchPattern = "*", bool recursive = false)
        {
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var contents = Directory.GetFileSystemEntries(path, searchPattern, searchOption);
            return JsonConvert.SerializeObject(contents, Formatting.Indented);
        }

        public string GetDirectoryFiles(string path, string searchPattern = "*", bool recursive = false)
        {
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var contents = Directory.GetFiles(path, searchPattern, searchOption);
            return JsonConvert.SerializeObject(contents, Formatting.Indented);
        }
        
        public string GetDirectorySubDirectories(string path, string searchPattern = "*", bool recursive = false)
        {
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var contents = Directory.GetDirectories(path, searchPattern, searchOption);
            return JsonConvert.SerializeObject(contents, Formatting.Indented);
        }

        public bool GetDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
        
        public string GetDirectoryInfo(string path)
        {
            var di = new DirectoryInfo(path);
            return JsonConvert.SerializeObject(di, Formatting.Indented);
        }

        public bool GetFileExists(string path)
        {
            return File.Exists(path);
        }
        
        public string GetFileInfo(string path)
        {
            var fi = new FileInfo(path);
            return JsonConvert.SerializeObject(fi, Formatting.Indented);
        }

        public string GetDNSHostName()
        {
            return Dns.GetHostName();
        }

        public string GetLocalIPV4Address()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(h => h.AddressFamily == AddressFamily.InterNetwork);

            return JsonConvert.SerializeObject(ip, Formatting.Indented);
        }

        public string GetLocalIPV6Address()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(h => h.AddressFamily == AddressFamily.InterNetworkV6);

            return JsonConvert.SerializeObject(ip, Formatting.Indented);
        }


        public string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }

        public string GetMachineEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
        }
        
        public string GetMachineEnvironmentVariables()
        {
            var variables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
            return JsonConvert.SerializeObject(variables, Formatting.Indented);
        }

        public string GetProcessEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
        
        public string GetProcessEnvironmentVariables()
        {
            var variables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
            return JsonConvert.SerializeObject(variables, Formatting.Indented);
        }

        public string GetUserEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
        }
        
        public string GetUserEnvironmentVariables()
        {
            var variables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
            return JsonConvert.SerializeObject(variables, Formatting.Indented);
        }

        public string GetEnvironmentVariables()
        {
            return JsonConvert.SerializeObject(Environment.GetEnvironmentVariables(), Formatting.Indented);
        }

        public string GetOS()
        {
            return JsonConvert.SerializeObject(Environment.OSVersion, Formatting.Indented);
        }
        
        public bool GetIs64BitOS()
        {
            return Environment.Is64BitOperatingSystem;
        }
        
        public bool GetIs64BitProcess()
        {
            return Environment.Is64BitProcess;
        }

        public string GetHostName()
        {
            return Environment.MachineName;
        }

        public string GetUserDomainName()
        {
            return Environment.UserDomainName;
        }

        public string GetUserName()
        {
            return Environment.UserName;
        }

        public string GetFullUserName()
        {
            return $"{Environment.UserDomainName}\\{Environment.UserName}";
        }
        
        public string GetWebOperationContext()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            
            return JsonConvert.SerializeObject(context, Formatting.Indented);
        }

        public string GetIncomingRequestContext()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            
            return JsonConvert.SerializeObject(request, Formatting.Indented);
        }
        
        public string GetIncomingResponseContext()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingResponse;
            
            return JsonConvert.SerializeObject(request, Formatting.Indented);
        }

        public string GetOutgoingRequestContext()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.OutgoingRequest;
            
            return JsonConvert.SerializeObject(request, Formatting.Indented);
        }
        
        public string GetOutgoingResponseContext()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.OutgoingResponse;
            
            return JsonConvert.SerializeObject(request, Formatting.Indented);
        }

        public Uri GetRequestUri()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            var template = request.UriTemplateMatch;
            
            return template.RequestUri;
        }
        
        public Uri GetRequestBaseUri()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            var template = request.UriTemplateMatch;
            
            return template.BaseUri;
        }
        
        public string GetRequestQueryParameters()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            var template = request.UriTemplateMatch;

            return JsonConvert.SerializeObject(template.QueryParameters, Formatting.Indented);
        }

        public string GetRequestHeaders()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;

            return JsonConvert.SerializeObject(request.Headers, Formatting.Indented);
        }

        public string GetRequestUriTemplateMatch()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            var template = request.UriTemplateMatch;

            return JsonConvert.SerializeObject(template, Formatting.Indented);
        }

    }
}
