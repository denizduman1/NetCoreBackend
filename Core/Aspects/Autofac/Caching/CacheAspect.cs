using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodIntercepiton
    {
        private readonly int _duration;
        private readonly ICacheService? _cacheService;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            if (ServiceTool.ServiceProvider != null)
                _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void Intercept(IInvocation invocation)
        {

            var methodName = string.Format($"{invocation?.Method?.ReflectedType?.FullName}.{invocation?.Method.Name}");
            var arguments = invocation?.Arguments.ToList();
            string key;
            if (arguments != null)
            {
                key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            }
            else
            {
                key = $"{methodName}()";
            }

            if (_cacheService != null && _cacheService.IsAdd(key) && invocation != null)
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;

            }

            invocation?.Proceed();
            _cacheService?.Add(key, invocation.ReturnValue, _duration);

        }

    }
}
