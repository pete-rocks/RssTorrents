using Autofac;
using System.Reflection;
using System.Linq;

namespace RssTorrents
{
	public static class AutoFacInstaller
	{
		private static IContainer _container;

		public static void Install()
		{
			var builder = new ContainerBuilder();

			// Scan an assembly for components - reigster them all
			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.Where(t => t.GetInterfaces().Any(x => x.Name == "IService"))
				.AsImplementedInterfaces();

			_container = builder.Build();
		}

		public static T Get<T>()
		{
			//using(var scope = _container.BeginLifetimeScope())
			//{
				return _container.Resolve<T>();
			//}
		}

	}
}

