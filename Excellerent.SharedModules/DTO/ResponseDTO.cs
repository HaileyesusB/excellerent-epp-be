using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.SharedModules.DTO
{
    public enum ResponseStatus
    {
        Error,
        Success,
        Warning,
        Info
    }
    public class ResponseDTO
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string Message { get; set; }
        public Exception Ex { get; set; }
        public dynamic Data { get; set; }

    }
}
