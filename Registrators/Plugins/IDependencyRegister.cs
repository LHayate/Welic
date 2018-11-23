using Unity;

namespace Registrators.Plugins
{
    public interface IDependencyRegister
    {
        void Register(IUnityContainer container);

        int Order { get; }
    }
}
