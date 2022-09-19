using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAtributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type?.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            if (methodAttributes != null)
            {
                classAtributes.AddRange(methodAttributes);
            }

            return classAtributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
