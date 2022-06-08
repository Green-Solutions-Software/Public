using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Plant : Article
    {
        public string Opener { get; set; }
        public List<PlantTask> Tasks { get; set; }
        public List<EntityReference> Groups { get; set; }
        public List<EntityReference> Usages { get; set; }
        public List<EntityReference> Tastes { get; set; }
        public List<EntityReference> Shapes { get; set; }
        public List<PlantColor> Colors { get; set; }
        public bool? LittleWater { get; set; }
        public bool? MediumWater { get; set; }
        public bool? MuchWater { get; set; }
        public double? GrowthHeightFrom { get; set; }
        public double? GrowthHeightTo { get; set; }
        public double? GrowthWidthFrom { get; set; }
        public double? GrowthWidthTo { get; set; }
        public double? GrowthAnnualFrom { get; set; }
        public double? GrowthAnnualTo { get; set; }
        public double? GrowthAnnualWidthFrom { get; set; }
        public double? GrowthAnnualWidthTo { get; set; }
        public PlantGrowthSpeed? GrowthSpeedType { get; set; }
        public PlantFlowerSmellType? FlowerSmell { get; set; }
        public bool? LocationBright { get; set; } //hell
        public bool? LocationSunny { get; set; }
        public bool? LocationHalfShadowed { get; set; }
        public bool? LocationShadowed { get; set; }
        public bool? Toxically { get; set; }
        public bool? Eatable { get; set; }
        public bool? LifeTimeAnnual { get; set; }
        public bool? LifeTimeBinual { get; set; }
        public bool? LifeTimePerennial { get; set; }
        public EntityReference Grower { get; set; }
        public EntityReference Brand { get; set; }
        public DifficultyType? DifficultyType { get; set; }
        public PlantCareEffort? CareEffort { get; set; }
        public PlantHardinessType? HardinessType { get; set; }
        public bool? RizomBarrierRequired { get; set; }
        public PlantAlwaysGreenType? FoliageAlwaysGreenType { get; set; }
        public bool? SoilDiaphanous { get; set; }
        public bool? SoilHumous { get; set; }
        public bool? SoilChalkFree { get; set; }
        public bool? SoilCalcareous { get; set; }
        public bool? SoilLoose { get; set; }
        public bool? SoilNutrientRich { get; set; }
        public bool? SoilSandy { get; set; }
        public bool? SoilSour { get; set; }
        public bool? SoilSourWeak { get; set; }
        public bool? SoilClayey { get; set; }
        public bool? SoilDry { get; set; }
        public bool? SoilUndemanded { get; set; }
        public PlantPruningType? PruningType { get; set; }
        public virtual TimePeriod BloomingTimePeriod { get; set; }
        public virtual TimePeriod BloomingTimePeriod2 { get; set; }

        public PlantFlowerFillingType? Filling { get; set; }
        public bool? FruitCone { get; set; }
        public bool? FruitBerries { get; set; }
        public bool? FruitCore { get; set; }
        public bool? FruitStone { get; set; }
        public bool? FruitAromatic { get; set; }
        public bool? FruitOrnamental { get; set; }
    }
}
