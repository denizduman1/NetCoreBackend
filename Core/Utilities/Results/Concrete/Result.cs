using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public string Message { get; } = string.Empty;
        public ResultStatus ResultStatus { get; }
        public Exception? Exception { get; }

        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message) : this(resultStatus)
        {
            Message = message;
        }
        public Result(ResultStatus resultStatus, Exception exception) : this(resultStatus)
        {
            Exception = exception;
        }

        public Result(ResultStatus resultStatus, string message, Exception exception) : this(resultStatus, message)
        {
            Exception = exception;
        }

    }
}
