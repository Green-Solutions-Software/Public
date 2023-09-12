using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Repositories;
using System;

namespace GS.Cordoba.Rest
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected Context context = null;

        public UnitOfWork(Context context)
        {
            this.context = context;
        }

        public UnitOfWork(string vendor, string endpoint, string token, IBlobCache cache = null)
        {
            this.context = new Context("vendor="+vendor + ",token="+token+",endpoint="+endpoint, cache);
        }

        public string Token
        {
            get
            {
                return this.context.Token;
            }
            set
            {
                this.context.Token = value;
            }
        }

        public string Endpoint
        {
            get
            {
                return this.context.Endpoint;
            }
            set
            {
                this.context.Endpoint = value;
            }
        }

        public Action<string> OnExecuteRequest
        {
            get
            {
                return this.context.OnExecuteRequest;
            }
            set
            {
                this.context.OnExecuteRequest = value;
            }
        }

        public ILanguagesRepository Languages => new CORLanguagesRepository(this.context);
        public IPlantPicturesRepository PlantPictures => new CORPlantPicturesRepository(this.context);
        public ICurrenciesRepository Currencies => new CORCurrenciesRepository(this.context);
        public ICalendarItemsRepository CalendarItems => new CORCalendarItemsRepository(this.context);
        public IMembersRepository Members => new CORMembersRepository(this.context);
        public ISearchRepository Search => new CORSearchRepository(this.context);
        public IArticlesRepository Articles => new CORArticlesRepository(this.context);
        public IPlantsRepository Plants => new CORPlantsRepository(this.context);
        public IMailingsRepository Mailings => new CORMailingsRepository(this.context);
        public IAccountRepository Account => new CORAccountRepository(this.context);
        public IContainersRepository Containers => new CORContainersRepository(this.context);
        public IGalleriesRepository Galleries => new CORGalleriesRepository(this.context);
        public IFoldersRepository Folders => new CORFoldersRepository(this.context);
        public IFilesRepository Files => new CORFilesRepository(this.context);
        public ISignagesRepository Signages => new CORSignagesRepository(this.context);
        public ITemplatesRepository Templates => new CORTemplatesRepository(this.context);
        public IFormatsRepository Formats => new CORFormatsRepository(this.context);
        public IBasketsRepository Baskets => new CORBasketsRepository(this.context);
        public INewsRepository News => new CORNewsRepository(this.context);
        public IVideosRepository Videos => new CORVideosRepository(this.context);

        public void Dispose()
        {
            
        }
    }
}
