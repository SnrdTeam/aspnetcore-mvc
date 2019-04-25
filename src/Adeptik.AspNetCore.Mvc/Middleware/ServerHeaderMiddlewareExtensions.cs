using Microsoft.AspNetCore.Builder;
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
                context.Response.Headers.Add("Server", $"{assemblyName}/{assemblyVersion}");
                await next.Invoke();
            });
        }
    }
}
