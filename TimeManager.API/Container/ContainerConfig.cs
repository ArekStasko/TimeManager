using Autofac;
using System.Reflection;

namespace TimeManager.API.DependencyInjection
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(TimeManager.API.Processors)))
                .Where(t => t.Namespace.Contains("ActivityProcessor"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + i.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(TimeManager.API.Processors)))
                .Where(t => t.Namespace.Contains("CategoryProcessor"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + i.Name));

            return builder.Build();
        }

    }
}
