using Adeptik.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Adeptik.AspNetCore.Mvc.DependencyInjection
{
    /// <summary>
    /// Методы расширения для добавления сервисов MVC
    /// </summary>
    public static class MvcCoreServiceCollectionExtensions
    {
        /// <summary>
        /// Добавляет дополнительные сервисы для работы с файловыми результатами действий MVC
        /// </summary>
        /// <param name="services">Коллекция сервисов <see cref="IServiceCollection"/>, в которую добавляются новые сервисы</param>
        /// <returns>Переданный экземпляр <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddMvcFileResults(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services
                .AddSingleton<FileCallbackResultExecutor>();
        }
    }
}
