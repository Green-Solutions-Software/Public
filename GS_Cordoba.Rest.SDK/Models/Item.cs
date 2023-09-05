using System;


namespace GS.Cordoba.Rest.SDK.Models
{
    public class Item : Entity
    {
        public long ID { get; set; }
        public long? FileID { get; set; }

        public string NamePrimary { get; set; }
        public string NameSecondary { get; set; }
        public string OwnerName { get; set; }

        public string Description { get; set; }

        public string Number { get; set; }

        public int DurationSeconds { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Type { get; set; }

        public ReportType? ReportType { get; set; }

        public string EntityKey { get; set; }
        public string Cache { get; set; }

        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public PlantPictureStatusType? PlantPictureStatus { get; set; }
    }
}