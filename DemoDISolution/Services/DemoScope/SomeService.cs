namespace DemoDISolution.Services.DemoScope
{
    public class SomeService : IScopedService, ITransientService, ISingletonService
    {
        Guid id;
        public SomeService()
        {
            id = Guid.NewGuid();
        }

        public Guid GetID()
        {
            return id;
        }
    }
}
