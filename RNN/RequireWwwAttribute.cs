using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace RNN
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class RequireWwwAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        private bool? permanent;
        public bool Permanent
        {
            get => permanent ?? true;
            set => permanent = value;
        }

        private bool? ignoreLocalhost;
        public bool IgnoreLocalhost
        {
            get => ignoreLocalhost ?? true;
            set => ignoreLocalhost = value;
        }

        public int Order { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var req = context.HttpContext.Request;
            var host = req.Host;

            var isLocalHost = string.Equals(host.Host, "localhost", StringComparison.OrdinalIgnoreCase);

            if (IgnoreLocalhost && isLocalHost)
            {
                return;
            }

            if (host.Host.StartsWith("www", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var optionsAccessor = context.HttpContext
                .RequestServices
                .GetRequiredService<IOptions<MvcOptions>>();

            var permanentValue = permanent ?? optionsAccessor.Value.RequireHttpsPermanent;

            //carriage return below added for legibility
            //it is not actually present in the working code
            var newPath = $"{req.Scheme}://www.{host.Value}{req.PathBase}{req.Path}{req.QueryString}";

            context.Result = new RedirectResult(newPath, permanentValue);
        }

    }
}