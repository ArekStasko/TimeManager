using Autofac;

namespace TimeManager.API.DependencyInjection
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            return builder.Build();
        }

    }
}
