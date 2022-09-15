using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.ServiceModel.Web;
using log4net;
using Newtonsoft.Json;

namespace WcfDebug
{
    public class DebugService : IDebugService
    {
        private const string PONG = @"Pong";
        private const string ECHO_RESPONSE_FORMAT = @"You entered: {0}";

        private static readonly ILog log = LogManager.GetLogger(typeof(DebugService));

        private static string DefaultDirectory { get; } = Environment.CurrentDirectory;
        private static string DefaultFile
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyLocation = assembly.Location;

                return assemblyLocation;
            }
        }

        [WebInvoke(Method = "GET", UriTemplate = "/ping")]
        public string Ping()
        {
            log.Info($"{nameof(Ping)}");

            return PONG;
        }
        
        public string EchoIntValue(int value)
        {
            log.Info($"{nameof(EchoIntValue)}({value})");

            return string.Format(ECHO_RESPONSE_FORMAT, value);
        }
        
        public string EchoStringValue(string value)
        {
            log.Info($"{nameof(EchoStringValue)}({value})");

            return string.Format(ECHO_RESPONSE_FORMAT, value);
        }

        public string GetDirectoryContents(FileSystemSearchOptions searchOptions)
        {
            if (searchOptions is null) throw new ArgumentNullException(nameof(searchOptions));
            
            log.Info($"{nameof(GetDirectoryContents)}");
            log.Info(JsonConvert.SerializeObject(searchOptions, Formatting.None));

            var path = string.IsNullOrEmpty(searchOptions.Path)
                ? DefaultDirectory
                : searchOptions.Path;

            var results = new List<string>();

            if (searchOptions.SearchType.HasFlag(SearchType.Directories))
            {
                var directories = Directory.GetDirectories(path, searchOptions.SearchPattern, searchOptions.SearchOption);
                results.AddRange(directories);
            }

            if (searchOptions.SearchType.HasFlag(SearchType.Files))
            {
                var files = Directory.GetFiles(path, searchOptions.SearchPattern, searchOptions.SearchOption);
                results.AddRange(files);
            }

            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        public string GetDirectoryFiles(FileSystemSearchOptions searchOptions)
        {
            if (searchOptions is null) throw new ArgumentNullException(nameof(searchOptions));

            var path = string.IsNullOrEmpty(searchOptions.Path)
                ? DefaultDirectory
                : searchOptions.Path;
            
            var contents = Directory.GetFiles(path, searchOptions.SearchPattern, searchOptions.SearchOption);
            return JsonConvert.SerializeObject(contents, Formatting.Indented);
        }
        
        public string GetDirectorySubDirectories(FileSystemSearchOptions searchOptions)
        {
            if (searchOptions is null) throw new ArgumentNullException(nameof(searchOptions));

            var path = string.IsNullOrEmpty(searchOptions.Path)
                ? DefaultDirectory
                : searchOptions.Path;
            
            var contents = Directory.GetDirectories(path, searchOptions.SearchPattern, searchOptions.SearchOption);
            return JsonConvert.SerializeObject(contents, Formatting.Indented);
        }

        public bool GetDirectoryExists(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = DefaultDirectory;
            }

            return Directory.Exists(path);
        }
        
        public string GetDirectoryInfo(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = DefaultDirectory;
            }

            var di = new DirectoryInfo(path);
            return JsonConvert.SerializeObject(di, Formatting.Indented);
        }

        public bool GetFileExists(string path)
        {
            if (!string.IsNullOrEmpty(path)) return File.Exists(path);
            
            return File.Exists(DefaultFile);
        }
        
        public string GetFileInfo(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                var fullPath = Path.GetFullPath(path);
                var fi = new FileInfo(fullPath);
                return JsonConvert.SerializeObject(fi, Formatting.Indented);
            }
            
            var assemblyFi = new FileInfo(DefaultFile);
            return JsonConvert.SerializeObject(assemblyFi, Formatting.Indented);
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
            
            return template?.RequestUri;
        }
        
        public Uri GetRequestBaseUri()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            var template = request.UriTemplateMatch;
            
            return template?.BaseUri;
        }
        
        public string GetRequestQueryParameters()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            var template = request.UriTemplateMatch;
            var queryParams = template.QueryParameters;

            return JsonConvert.SerializeObject(queryParams, Formatting.Indented);
        }

        public string GetRequestHeaders()
        {
            var context = WebOperationContext.Current ?? throw new ArgumentNullException(nameof(WebOperationContext));
            var request = context.IncomingRequest;
            var headers = request.Headers;

            return JsonConvert.SerializeObject(headers, Formatting.Indented);
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
