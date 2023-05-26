using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IUnitOfWork
    {
        string Token { get; set; }
        string Endpoint { get; set; }
        ILanguagesRepository Languages { get; }
        IPlantPicturesRepository PlantPictures { get; }
        ISearchRepository Search { get; }
        ICurrenciesRepository Currencies { get; }
        IVideosRepository Videos { get; }
        ICalendarItemsRepository CalendarItems { get; }
        IMembersRepository Members { get; }
        IArticlesRepository Articles { get; }
        IAccountRepository Account { get; }
        IMailingsRepository Mailings { get; }
        IContainersRepository Containers { get; }
        IGalleriesRepository Galleries { get; }
        IFoldersRepository Folders { get; }
        IFilesRepository Files { get; }
        ISignagesRepository Signages { get; }
        ITemplatesRepository Templates { get; }
        IFormatsRepository Formats { get; }
        IBasketsRepository Baskets { get; }
        INewsRepository News { get; }
    }
}
