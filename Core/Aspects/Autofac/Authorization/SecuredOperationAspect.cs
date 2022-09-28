using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Results.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Authorization
{
    public class SecuredOperationAspect : MethodIntercepiton
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly Messages messages = Messages.Instance();

        public SecuredOperationAspect(string roles)
        {
            _roles = roles.Split(',');
            if(ServiceTool.ServiceProvider != null)
                _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); 
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor?.HttpContext.User.ClaimRoles();
            if (roleClaims != null)
            {
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                    {
                        return;
                    }
                }
            }
            throw new Exception(messages.AuthorizationDenied);
        }
    }
}
