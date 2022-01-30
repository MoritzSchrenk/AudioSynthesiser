using Unity;
using Unity.Lifetime;

namespace AudioSynthesiser
{
    public class DependencyInjector
    {
        private static readonly UnityContainer container = new UnityContainer();

        public static void Register<I, T>() where T: I
        {
            container.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }

        public static T Retrieve<T>()
        {
            return container.Resolve<T>();
        }

        public static void Inject<I>(I instance)
        {
            container.RegisterInstance<I>(instance, new ContainerControlledLifetimeManager());
        }
    }
}
