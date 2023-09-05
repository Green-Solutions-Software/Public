using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Report : SEOMainEntity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ReportID { get; set; }
            public ReportType Type { get; set; }
            public string Name { get; set; }

            public ReportPhoto MainPhoto { get; set; }
        }

        public Report()
        {
            this.Categories = new List<EntityReference>();
            this.Paragraphs = new List<Paragraph>();
            this.Tags = new List<EntityReference>();
            this.Photos = new List<ReportPhoto>();
            this.Medias = new List<ReportMedia>();
            this.TimePeriods = new List<TimePeriod>();
            this.Ingredients = new List<Ingredient>();
        }

        public long ReportID { get; set; }
        public ReportType Type { get; set; }
        public string Name { get; set; }
        public List<EntityReference> Categories { get; set; }
        public List<EntityReference> Tags { get; set; }
        public List<ReportPhoto> Photos { get; set; } // M:n
        public List<ReportMedia> Medias { get; set; }
        public List<Paragraph> Paragraphs { get; set; } // M:n
        public List<TimePeriod> TimePeriods { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public bool Appetizer { get; set; }
        public bool MainDish { get; set; }
        public bool Dessert { get; set; }
        public bool Garnish { get; set; }
        public int? CountPersons { get; set; }
        public int? PreparationMinutes { get; set; }
        public int? TotalMinutes { get; set; }
        public ReportPhoto MainPhoto { get; set; }
    }
}
