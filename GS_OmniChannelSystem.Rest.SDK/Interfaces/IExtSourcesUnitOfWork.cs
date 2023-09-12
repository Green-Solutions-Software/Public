namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IExtSourcesUnitOfWork
    {
        IUnitOfWork[] All { get; }
        IUnitOfWork this[string index] {get;}
        //IUnitOfWork this[long id] { get; }
    }
}
