using Microsoft.Extensions.DependencyInjection;

namespace Katalog.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
