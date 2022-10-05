using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodIntercepiton
    {
        private string _pattern;
        private ICacheService? _cacheService;

        public CacheRemoveAspect(string pattern)
        {
            if (ServiceTool.ServiceProvider != null)
                _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
            _pattern = pattern;
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            if (_cacheService != null)
            {
                _cacheService.RemoveByPattern(_pattern);
            }
        }
    }
}
