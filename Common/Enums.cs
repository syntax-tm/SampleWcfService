using System;
using System.Runtime.Serialization;

namespace WcfDebug
{
    [Flags]
    [DataContract(Name = nameof(SearchType))]
    public enum SearchType
    {
        /// <summary>
        /// Default invalid search type
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// Search only for files
        /// </summary>
        [EnumMember]
        Files = 1,
        /// <summary>
        /// Search only for directories
        /// </summary>
        [EnumMember]
        Directories = 2,
        /// <summary>
        /// Search for both files and directories
        /// </summary>
        [EnumMember]
        All = Files | Directories
    }
}