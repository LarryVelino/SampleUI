using System;

namespace Akoya.Test.Domain.Models
{
    public class Result
    {
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public Result(bool success, string message, Exception ex)
            : this(success, message)
        {
            Exception = ex;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
