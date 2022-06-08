using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest
{

    public enum Interval
    {
        None,
        Week,
        Month,
        Year
    }

    public enum ScaleMode
    {
        ProportionalSmallest,
        ProportionalBiggest,
        ProportionalExact
    }

    public enum Apellation : short
    {
        Company,
        Mr,
        Mrs,
        None
    }

    public enum AddressType : short
    {
        Main,
        Invoice,
        Deliver
    }

    public enum MemberType
    {
        Customer,
        Client
    }

    public enum PictureDisplayMode : short
    {
        Cut,
        Full
    }

    public enum ReportType : short
    {
        DecorationReport,
        FoodReport,
        IdeaReport,
        PlantInstruction,
        PlantProtectionReport,
        PracticeReport,
        BlogReport,
        ProjectReport,
        Recipe,
        SeasonalReport
    }

    public enum TextType : short
    {
        Location,
        Hardiness,
        OptimalSummerTemperature,
        OptimalWinterTemperature,


        Flower,
        FlowerColor,
        FlowerTime,
        FlowerSmell,


        Growth,
        GrowthHeight,
        GrowthWidth,
        GrowthAnnualGrowth,
        GrowthSpeed,
        GrowthShape,


        Water,


        Pruning,
        PruningFromTo,


        Fruit,
        FruitCone,
        FruitRipe,


        WaterDepth,


        Seed,
        Harvest,
        Sowing,


        Availibility,


        Foliage,
        FoliageColor,
        FoliageAutumnColor,
        AlwaysGreen,


        Soil,

        Synonym,

        Description,

        PlantPartners,
        SimilarPlants,

        Usages,

        TrademarkProtection,
        PlantVarietyProtection,

        LocaleSynonym,

        Origins,

        Tasks,

        LeaveColor,

        SeedDepth,
        SeedPlantDistance,
        SeedRowDistance,
        SeedGerminationDays,
        SeedGerminationTemperature,
        SeedTransplant,
        SeedGermination,
        SeedDistance,

        LifeTime,

        Other,

        ADR,

        SeedPlanting,

        Substances,

        Care,

        WorthKnowing,

        Specialty,

        Attributes,

        Advice,

        Hibernation,

        Claim,

        Reproduction,

        Bark,

        Wood,

        Needling,

        FreeText6,

        Output,

        WateringFertilizing,

        Fertilizing,

        Substrate,

        WaterLevel,

        RipeTime,

        Stipe,

        Cut,

        MedicalBenefit,

        Taste,

        Variety,

        Impregnation,

        Tree,

        PlantingTime,

        Planting,

        Compost,

        Difficulty,

        PlantingDistance,

        FreeText1,
        FreeText2,
        FreeText3,
        FreeText4,
        FreeText5,
        OriginCountry,
        Durability,
        StemLength,
        Tipp,
        Sustainability,
        Leave,
        Grower,
        Stem,
        FreeText7,
        FreeText8,
        FreeText9,
        FreeText10,
        FreeText11,
        FreeText12,

        Size,

        Smell,

        Opener,

        FreeText13,

        FreeText14,

        FreeText15,

        FreeText16,

        FreeText17,

        FreeText18,

        FreeText19,

        FreeText20,

        Health,

        Pulp,

        Picking,

        Stalk,

        FlowerDiameter,

        Culm,

        FreeText21,

        BulletPoints,

        Recommendation,

        Composition,

        Material,
    }

    public enum FontMultiplier
    {
        Standard,
        Middle,
        Large
    }

    public enum PictoGroup : short
    {
        Location,
        BloomingTime,
        Height,
        AnnualGrowth,
        Growth,
        Width,
        Prunning,
        ClimbingPlant,
        Water,
        Cone,
        Fruit,
        Eatable,
        HarvestTime,
        MaturationTime,
        RizomsperreRequired,
        Fragrant,
        Hardiness,
        ADR,
        BeeFriendly,
        Toxically,
        Humidity,
        AirClean
    }

    public enum Picto : short
    {
        PictoRizomsperre,
        Picto01,
        Picto01a,
        Picto02,
        Picto03,
        Picto03a,
        Picto04,
        Picto05,
        Picto05b,
        Picto05c,
        Picto06,
        Picto07,
        Picto07b,
        Picto08,
        Picto09,
        Picto10,
        Picto11,
        Picto12,
        Picto13,
        Picto14,
        Picto15,
        Picto16,
        Picto20,
        Picto21,
        Picto24,
        Picto25,
        Fragrant,
        Hardiness,
        NoHardiness,
        ADR,
        BeeFriendly,
        Toxically,
        Humidity,
        AirClean,
        SunnyShadow
    }

    public enum ProcessorType
    {
        PD,
        Chili,
        Static,
        Dummy
    }

    public enum BasketType : short
    {
        Checkout,
        List,
        Temporary,
        TemporaryPrint,
        Print,
        TemporaryCheckout
    }

    public enum BasketState : short
    {
        Open,
        Closed
    }

    public enum ItemType
    {
        Video,
        PlantPicture,
        Article,
        Shipping,
        ArticleKey,
        Signage,
        Coupon,
        SignageRequest
    }
}
