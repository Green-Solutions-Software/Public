namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ContainerItem : Entity
    {
        public long ContainerItemID { get; set; }

        public EntityReference Article { get; set; }
        public EntityReference Video { get; set; }
        public EntityReference Report { get; set; }
        public EntityReference Page { get; set; }
        public EntityReference Leaflet { get; set; }
        public EntityReference Audio { get; set; }
        public EntityReference CalendarItem { get; set; }
        public EntityReference News { get; set; }
        public EntityReference Category { get; set; }
        //public EntityReference Container { get; set; }
        public PictureEntityReference Picture { get; set; }

        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public long? PictureID { get; set; }

        public string Details { get; set; }
        public string PictureSmall { get; set; }
        public string PictureMedium { get; set; }
        public string PictureLarge { get; set; }


    }
}
