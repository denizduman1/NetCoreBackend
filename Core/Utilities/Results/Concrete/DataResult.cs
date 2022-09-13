using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data, ResultStatus resultStatus) : base(resultStatus)
        {
            Data = data;
        }

        public DataResult(T data, ResultStatus resultStatus, string message) : base(resultStatus, message)
        {
            Data = data;
        }

        public DataResult(T data, ResultStatus resultStatus, Exception exception) : base(resultStatus, exception)
        {
            Data = data;
        }

        public DataResult(T data, ResultStatus resultStatus, string message, Exception exception) : base(resultStatus, message, exception)
        {
            Data = data;
        }
    }
}
