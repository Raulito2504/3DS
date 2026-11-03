using VContainer;
using VContainer.Unity;

public class PruebaLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Economia>(Lifetime.Scoped);
    }
}
