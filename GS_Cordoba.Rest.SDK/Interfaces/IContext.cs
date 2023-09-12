namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IContext
    {
        void InvalidateAll();
        void Invalidate(string key);
    }
}
