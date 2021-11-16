namespace Akoya.Test.Domain.Models
{
    public class ResultWithData<T> : Result
    {

        public ResultWithData(T data, bool success, string message)
            : base(success, message)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}
