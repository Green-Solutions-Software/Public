using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IPaginatedCollection
    {
        int PageSize { get; }
        int PageIndex { get; }

        int TotalPages { get; }
        int TotalCount { get; }
        string Search { get; set; }

        bool HasMore { get; }

        Task Load(string search = null);

        Task LoadMore();

        bool IsLast(object t);

        Task Refresh();
    }
}
