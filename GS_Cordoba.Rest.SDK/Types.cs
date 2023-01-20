using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public enum DifficultyType : short
    {
        Beginner,
        Experienced,
        Expert
    }

    public enum PlantCareEffort : short
    {
        Much,
        Medium,
        Less
    }

    public enum PlantColorType : short
    {
        LeaveAutumnColor,
        LeaveColor,
        BloomingColor,
        FruitColor,
        SummerColor,
        WinterColor,
        Shoot,
        LeafEdge,
        LeafCenter,
        LeafStipe,
        LeafVein,
        Pulp,
        Bark,
        Branches,
        Blade
    }

    public enum PlantGrowthSpeed : short
    {
        Slow,
        Average,
        Fast
    }

    public enum PlantFlowerSmellType : short
    {
        PoorFragrant,
        Fragrant,
        StrongFragrant
    }

    public enum PlantHardinessType : short
    {
        FrostResistent,
        MaybeFrostResistent,
        NotFrostResistent
    }

    public enum PlantAlwaysGreenType : short
    {
        SummerGreen,
        AlwaysGreen,
        WinterGreen
    }

    public enum PlantPruningType : short
    {
        NoPruning,
        Cutable
    }

    public enum PlantFlowerFillingType : short
    {
        Filled,
        HalfFilled,
        StrongFilled,
    }

    public enum PlantPictureStatusType : short
    {
        NotEdited,
        Edited,
        AssignedAndApproved_,
        Rejected,
        Assigned_,
        Approved
    };

    public enum PlantShapeType : short
    {
        [Description("Stamm")]
        Stamm,
        [Description("Kugel")]
        Kugel,
        [Description("Pyramide")]
        Pyramid,
        [Description("Spirale")]
        Spiral,
        [Description("Zylinder")]
        Cylinder,
        [Description("Würfel")]
        Cube,
        [Description("Kegel")]
        Cone,
        [Description("Pompon")]
        Pompon,
        [Description("Spalier")]
        Cordon,
        [Description("Figur")]
        Figure
    }

    public enum PlantPictureType : short
    {
        [Description("Freisteller")]
        Free,
        [Description("Emotional")]
        Emotional,
        [Description("Klassisch")]
        Classic,
        [Description("Foto")]
        Photo,
        [Description("360 Grad")]
        ThreeSixty
    }
}
