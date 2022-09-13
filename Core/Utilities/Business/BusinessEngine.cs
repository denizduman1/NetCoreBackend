

using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Business
{
    public static class BusinessEngine
    {
        public static IResult Run(params IResult[] methods)
        {
            foreach (var method in methods)
            {
                if (method.ResultStatus != ResultStatus.Success)
                {
                    return method;
                }
            }
            return methods.LastOrDefault() ?? new Result(resultStatus: ResultStatus.Warning, message: "Method bulunamadı");
        }
    }
}
