using Autofac;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Services;

namespace Squawk_Security.WorkerService
{
    internal static class Dependencies
    {
        private static IContainer _container;

        public static IContainer GetContainer()
        {
            if (_container is null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<ISniffingService>().As<SharpPcapSniffingService>();
                builder.RegisterType<IAnalysisService>().As<RoleBasedAnalysisService>();
                builder.RegisterType<IPreventionService>().As<DeAuthenticationPreventionService>();
                builder.RegisterType<IReportingService>().As<SerilogReportingService>();

                _container = builder.Build();
            }

            return _container;
        }
    }
}
