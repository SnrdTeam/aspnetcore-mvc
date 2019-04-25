using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Reflection;

namespace Adeptik.AspNetCore.Mvc.Middleware
{
    public static class ServerHeaderMiddlewareExtensions
    {
        /// <summary>
        /// Extentsion method that adds middleware, which populates server http header with app token and
        /// version info.
        /// </summary>
        public static IApplicationBuilder UseServerHeader(this IApplicationBuilder builder)
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly.GetCustomAttribute<AssemblyProductAttribute>().Product.Replace(" ", "-");
            var assemblyVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            return builder.Use(async (context, next) =>
            {
                var serverHeaderList = context.Response.Headers["Server"].ToList();

                var serverHeaderValue = $"{assemblyName}/{assemblyVersion}";
                serverHeaderList.Add(serverHeaderValue);

                context.Response.Headers["Server"] = new StringValues(serverHeaderList.ToArray());

                await next.Invoke();
            });
        }
    }
}
