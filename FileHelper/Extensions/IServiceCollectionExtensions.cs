using FileHelper.FileHelper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FileHelper.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFileTool(this IServiceCollection services,Action<FileOptions> options)
        {
            services.AddSingleton<IFileTool, FileTool>();
            services.Configure(options);
            return services;
        }
    }
}
