using System.IO;
using System.Runtime.Serialization;

namespace WcfDebug
{
    [DataContract]
    public class FileSystemSearchOptions
    {
        private const string DEFAULT_SEARCH = @"*";

        private string _searchPattern = DEFAULT_SEARCH;

        [DataMember(EmitDefaultValue = false)]
        public SearchType SearchType { get; set; } = SearchType.All;

        [DataMember(IsRequired = true)]
        public string Path { get; set; }

        [DataMember]
        public string SearchPattern
        {
            get
            {
                if (string.IsNullOrEmpty(_searchPattern))
                {
                    _searchPattern = DEFAULT_SEARCH;
                }

                return _searchPattern;
            }
            set => _searchPattern = value;
        }

        [DataMember(EmitDefaultValue = false)]
        public SearchOption SearchOption { get; set; } = SearchOption.AllDirectories;
    }
}