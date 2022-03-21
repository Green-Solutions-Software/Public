using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public enum ArticleReferenceType : short
    {
        [Description("Ähnliche Artikel")] // 0    
        Cross,
    }

    public enum StretchMode
    {
        [Description("Exakt")]
        Exact,
        [Description("Vergrößern")]
        Resize,
        [Description("Proportional (längste Kante)")]
        ProportionalBiggest,
        [Description("Proportional (schmaleste Kante)")]
        ProportionalSmallest,
        [Description("Bühne")]
        Stage,
        [Description("Proportional Exakt")]
        ProportionalExact,
        [Description("Proportional Exakt (oben)")]
        ProportionalExactTop,
        [Description("Proportional Exakt (unten)")]
        ProportionalExactBottom,
        [Description("Proportional Exakt (links)")]
        ProportionalExactLeft
    }

    public enum StockHandling : short
    {
        [Description("Abziehen")]
        Decrement
    }

    public enum VideoSource
    {
        [Description("Lokal")]
        Custom,
        [Description("Youtube")]
        Youtube,
        [Description("Green-Solutions")]
        Cordoba
    }

    public enum GallerySlideType
    {
        [Description("Bild")]
        Picture,
        [Description("Video")]
        Video
    }

    public enum SequenceType : short
    {
        [Description("Rechnung")]
        Invoice,
        [Description("Bestellung")]
        Order
    }

    public enum InvoiceStateType : short
    {
        [Description("Fristgerecht")]
        InTime,
        [Description("Zahlungserinnerung")]
        Reminder1,
        [Description("2. Mahnung")]
        Reminder2,
        [Description("3. Mahnung")]
        Reminder3
    }

    public enum PaymentType : short
    {
        [Description("Rechnung")]
        Invoice,
        [Description("Einzug")]
        DirectDebit,
        [Description("Kreditkarte")]
        Creditcard,
        [Description("Barzahlung")]
        Cash
    }

    public enum InvoiceType : short
    {
        [Description("Rechnung")]
        Invoice,
        [Description("Gutschrift")]
        CreditNote,
        [Description("Storno Gutschrift")]
        CancellationCreditNote
    }

    public enum ShipmentLabelType
    {
        Shipment,
        Return,
        Export,
        Code
    }

    public enum ChangeFrequency
    {
        [Description("Immer")]
        Always,
        [Description("Stündlich")]
        Hourly,
        [Description("Täglich")]
        Daily,
        [Description("Wöchentlich")]
        Weekly,
        [Description("Monatlich")]
        Monthly,
        [Description("Jährlich")]
        Yearly,
        [Description("Nie")]
        Never
    }

    public enum MetaRobotIndex
    {
        [Description("index")]
        Index,
        [Description("noindex")]
        NoIndex
    }

    public enum MetaRobotFollow
    {
        [Description("follow")]
        Follow,
        [Description("nofollow")]
        NoFollow
    }

    public enum MetaRobotAdvanced
    {
        [Description("Keine")]
        None,
        [Description("Kein Bild Index")]
        NoImageIndex,
        [Description("Kein Archiv")]
        NoArchive,
        [Description("Kein Snippet")]
        NoSnippet
    }

    public enum VoucherType : short
    {
        [Description("Rabatt")]
        Discount,
        [Description("Gutschein")]
        Voucher
    }

    public enum PriceListPriceType : short
    {
        [Description("VE")]
        PU,
        [Description("Lage")]
        Tray,
        [Description("Voll")]
        Full,
        [Description("Frei")]
        Free
    }

    public enum ContainerType : short
    {
        [Description("Haupt")]
        Main,
        [Description("Unter")]
        Sub
    }

    public enum PictureType : short
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
    };

    public enum AreaType
    {
        Indoor,
        Outdoor
    }

    public enum StockType
    {
        ChainStore,
        Online
    }

    public enum PageStatusType : short
    {
        [Description("Veröffentlicht")]
        Published,
        [Description("Entwurf")]
        Draft
    }

    public enum TriggerInterval : short
    {
        [Description("Täglich")]
        Daily,
        [Description("Wöchentlich")]
        Weekly,
        [Description("Monatlich")]
        Monthly,
        [Description("Stündlich")]
        Hourly,
        [Description("Jährlich")]
        Yearly
    }

    public enum FeedInterval : short
    {
        [Description("Täglich")]
        Daily,
        [Description("Wöchentlich")]
        Weekly,
        [Description("Monatlich")]
        Monthly,
        [Description("Stündlich")]
        Hourly
        //[Description("Jährlich")]
        //Yearly // Jährlich wird (noch) nicht unterstützt
    }

    public enum FeedSource
    {
        [Description("RSS")]
        RSS,
        [Description("Green-Solutions CMS")]
        CMS,
        [Description("Social Media")]
        SocialMedia
    }

    public enum PlatformAppellation
    {
        [Description("Förmlich")]
        Formally,
        [Description("Persönlich")]
        Personally
    }

    public enum OrderType : short
    {
        [Description("Bestellung")]
        Order,
        [Description("Anfrage")]
        Inquiry,
        [Description("Entwurf")]
        Draft
    }

    public enum ReturnReason
    {
        [Description("Versehentlich bestellt")]
        OrderedByMistake,
        [Description("Preiswerter gesehen")]
        SeenCheaper,
        [Description("Kein Grund spezifizieren")]
        DontSpecifyAReason,
        [Description("Ungenügende Qualität")]
        InsufficientQuality,
        [Description("Artikel beschädigt")]
        DamagedItems,
        [Description("Lieferdatum nicht eingehalten")]
        DeliveryDateNotMet,
        [Description("Artikel unvollständig")]
        ArticleIncomplete,
        [Description("Falscher Artikel geliefert")]
        WrongArticleDelivered,
        [Description("Artikel fehlerhaft")]
        ItemFaulty,
        [Description("Gefällt mir nicht")]
        IDoNotLikeIt,
        [Description("Nicht autorisierter Kauf")]
        UnauthorizedPurchase,
        [Description("Entspricht nicht der Beschreibung")]
        DoesNotMatchTheDescription
    }

    public enum MessageType
    {
        [Description("Anfrage Stornierung")]
        CancellationRequested,
        [Description("Anfrage Retoure")]
        ReturnRequested,
        [Description("Bestellung")]
        Order,
        [Description("Bestellung Empfangsbestätigung (5)")]
        ProcessBegun,
        [Description("Ware versendet / Ware an Spedition übergeben (24)")]
        DeliveryArranged,
        [Description("Lieferung durchgeführt (21)")]
        DeliveryCompleted,
        [Description("Annahme der Lieferung verweigert (325)")]
        DeliveryRefusedByRecipient,
        [Description("Lieferung unvollständig (73)")]
        ReceiptOfGoodParticiallyAcknowledged,
        [Description("Bestätigung des Liefertermins (209)")]
        DeliveryScheduled,
        [Description("Kunde nicht angetroffen (210)")]
        DeliveryUnsuccessfullAttempt,
        [Description("Änderung des Liefertermins (212)")]
        DeliveryChangeSchedule,
        [Description("Ware beschädigt (218)")]
        Damaged,
        [Description("Kunde nicht erreicht (216)")]
        DeliveryPendingAwaitingSpecificDateTimes,
        [Description("Terminavisierung nicht möglich 243")]
        NotDeliverable,
        [Description("Abholauftrag erhalten (64)")]
        CollectionPickUpAwaited,
        [Description("Bestätigung des Abholtermins (13)")]
        CollectionDateTimeAcknowledged,
        [Description("Retourenlieferung ist eingegangen (82)")]
        CollectionPickUpCompleted,
        [Description("Retouren-Prüfung bestanden (80)")]
        ReturnsInspectionPassed,
        [Description("Retouren-Prüfung nicht bestanden (81)")]
        ReturnsInspectionFailed,
        [Description("Stornoanfrage des Kunden bestätigt (275)")]
        CancellationRequestConfirmed,
        [Description("Storno nicht mehr möglich (71)")]
        CancellationIsNoLongerPossible,
        [Description("Storno vom Lieferanten gemeldet (56)")]
        CancellationBeportedBySupplier,
        [Description("E-Mail Nachricht")]
        EMail,
        [Description("Anfrage akzeptiert")]
        RequestAccepted,
        [Description("Anfrage abgelehnt")]
        RequestRejected,
        [Description("Status aktualisieren")]
        UpdateStatus,
        [Description("Retoure (per E-Mail erhalten)")]
        ReturnViaEMail,
        [Description("Bestandsmeldung")]
        InventoryReport,
        [Description("Rechnung")]
        Invoice,
        [Description("Storno (per E-Mail erhalten)")]
        CancellationViaEmail
    }

    public enum MessageDirection
    {
        [Description("Eingehend")]
        Inbound,
        [Description("Ausgehend")]
        Outbound
    }

    public enum OrderStatusType : short
    {
        [Description("Noch nicht bearbeitet")]
        NotEdited,
        [Description("Bestätigt")]
        Confirmed,
        [Description("Storniert")]
        Canceled,
        [Description("Erledigt")]
        Ready,
        [Description("In Bearbeitung")]
        InProcess
    }
    public enum OrderTransactionActionType : short
    {
        [Description("Ersatz")]
        Replace,
        [Description("Verschieben")]
        Delay,
        [Description("Erstatten")]
        Refund,
        [Description("Aufteilen")]
        Split
    }


    public enum OrderTransactionStatusType : short
    {
        [Description("Noch nicht bearbeitet")]
        NotDelivered,
        [Description("Ausgeliefert")]
        Delivered,
        [Description("Steht Bereit")]
        Ready,
        [Description("Bestellt")]
        Ordered,
        [Description("Bestätigt")]
        Confirmed,
        [Description("Storniert")]
        Cancelled
    }

    public enum PaymentServiceType : short
    {
        [Description("Kreditkarte")]
        CreditCard,
        [Description("PayPal")]
        PayPal,
        [Description("Lastschrift")]
        DirectDebit,
        [Description("Individuell")]
        Invoice,
        [Description("Vorkasse")]
        Prepaid,
        [Description("Sofortüberweisung")]
        Sofort,
        [Description("Gutschein")]
        Voucher,
        [Description("Online banking (Giropay)")]
        Giropay,
        [Description("Online banking (EPS)")]
        EPS,
        [Description("Nachname")]
        CashOnDelivery
    }

    public enum PaymentServiceIntegration : short
    {
        [Description("Weiterleitung")]
        Redirect,
        [Description("Backend zu Backend")]
        Backend2Backend
    }

    public enum Month : short
    {
        [Description("Januar")]
        January,
        [Description("Februar")]
        February,
        [Description("März")]
        March,
        [Description("April")]
        April,
        [Description("Mai")]
        May,
        [Description("Juni")]
        June,
        [Description("Juli")]
        July,
        [Description("August")]
        August,
        [Description("September")]
        September,
        [Description("Oktober")]
        October,
        [Description("November")]
        November,
        [Description("Dezember")]
        December,
    }

    public enum Interval
    {
        [Description("<keine>")]
        None,
        [Description("Wochentlich")]
        Week,
        [Description("Monatlich")]
        Month,
        [Description("Jährlich")]
        Year
    }

    public enum Apellation : short
    {
        [Description("Firma")]
        Company,
        [Description("Herr")]
        Mr,
        [Description("Frau")]
        Mrs,
        [Description("Keine")]
        None
    }

    public enum ChainStoreType : short
    {
        [Description("Filiale")]
        ChainStore,
        [Description("Zentrale")]
        Headquarter,
        [Description("Lager")]
        Warehouse
    }

    public enum AddressType : short
    {
        [Description("Hauptadresse")]
        Main,
        [Description("Rechnungsadresse")]
        Invoice,
        [Description("Lieferadresse")]
        Deliver,
        [Description("Auslieferadresse")]
        Transaction
    }

    public enum DataSource : short
    {
        [Description("Eigene Datenbank")]
        Own,
        [Description("Systemdatenbank")]
        System,
        [Description("Eigene+Systemdatenbank")]
        Both,
        [Description("Alle")]
        All
    }

    public enum ConditionColorType : short
    {
        Green,
        Yellow,
        Red,
        Orange,
        BrightBlue,
        Gray,
        Brown,
        Silver,
        GreenLight
    }

    public enum CalculationGroupItemType
    {
        [Description("Artikelpreis")]
        ArticlePrice,
        [Description("Artikelpreis(Rabatt)")]
        ArticleDiscount,
        [Description("Lieferkosten")]
        Deliver,
        [Description("Skonto")]
        Skonto,
        [Description("Rabatt")]
        Discount,
        [Description("Versandkosten")]
        Shipping,
        [Description("Versandkosten pro Artikel")]
        ShippingPerArticle,
        [Description("Lieferkosten pro Artikel")]
        DeliverPerArticle,
        [Description("Zahlart")]
        PaymentMethod,
        [Description("Mahnkosten")]
        Reminder
    }

    public enum CalulationPrincipleType : short
    {
        [Description("Aufschlag")]
        Surcharge,
        [Description("Abzug")]
        Discount,
        [Description("Betrag")]
        Amount
    }

    public enum PercentOperationType : short
    {
        [Description("Multiplizieren")]
        Multiply,
        [Description("Dividieren")]
        Divide
    }

    public enum CalulationPrincipleValueType : short
    {
        [Description("Prozent")]
        Percent,
        [Description("Betrag")]
        Value
    }

    public enum DeliverType : short
    {
        [Description("Europalette")]
        EP,
        [Description("Halbpalette")]
        HVP,
        [Description("Umpack")]
        UP,
        [Description("Karton")]
        Box,
        [Description("Viertelpaletten-Display")]
        QuarterPalletsDisplay,
        [Description("CC-Container")]
        CC,
        [Description("Lage")]
        Tray,
        [Description("Halbpaletten-Display")]
        HalfPalletsDisplay
    }

    public enum PriceUnitType : short
    {
        [Description("Stück")] // 0
        Pcs,
        [Description("Liter")] // 1
        Liter,
        [Description("Meter")] // 2
        Meter,
        [Description("Quadratmeter")] // 3
        SquareMeter,
        [Description("Kilogramm")] // 4
        kg,
        [Description("VE")] // 5
        PackingUnit,
        [Description("Zentimeter")] // 6
        cm,
        [Description("Gramm")] // 7
        g,
        [Description("Millimeter")] // 8
        mm,
        [Description("Milliliter")] // 9
        ml,
        [Description("Paket")] // 10
        pk,
        [Description("Tafel")] // 11
        Plate,
        [Description("Kubikmeter")] // 12
        CubicMeter,
        [Description("Bündel")] // 12
        Bunch,
        [Description("Lage")] // 12
        Tray,
        [Description("Karre")] // 12
        CC,
        [Description("Korn")] // 12
        Grain,
        [Description("Pille")] // 12
        Pill
    }

    public enum PackingFormType : short
    {
        [Description("Beutel")]
        Bag,
        [Description("Sack")]
        Sack,
        [Description("Flasche")]
        Bottle,
        [Description("Comfortbeutel")]
        ComfortBag,
        [Description("Eimer")]
        Bucket,
        [Description("Ballen")]
        Bale,
        [Description("Jumbo Pack")]
        JumboPack,
        [Description("Lose")]
        Lose,
        [Description("Packung")]
        Package,
        [Description("Faltschachtel")]
        FoldingBox,
        [Description("Topf")]
        pot,
        [Description("Pouchbeutel")]
        PouchBag,
        [Description("Dose")]
        Can,
        [Description("Karton")]
        Carton,
        [Description("Schale")]
        Bowl
    }

    public enum ArticlePropertyType : short
    {
        [Description("Gewicht")]
        Weight,
        [Description("Breite")]
        Width,
        [Description("Höhe")]
        Height,
        [Description("Länge")]
        Length,
        [Description("Tiefe")]
        Depth,
        [Description("Topfgröße(cm)")]
        PotSize,
        [Description("Füllmenge")]
        FillAmount,
        [Description("Durchmesser")]
        Diameter,
        [Description("Ladekapazität")]
        LoadingCapacity,
        [Description("Größe")]
        Size,
        [Description("Qualität")]
        Quality,
        [Description("Merkmale")]
        Features,
        [Description("Zuwachs")]
        Growth,
        [Description("Aufgaben")]
        Tasks,
        [Description("Blütezeit")]
        BloomingTime,
        [Description("Botanischer Name")]
        BotanicName,
        [Description("Benutzerdefiniert")]
        Custom,
        [Description("Lieferhöhe")]
        DeliverHeight,
        [Description("Topfgröße(l)")]
        PotSizeL,
        [Description("Lokaler Name")]
        NameTranslation,
        [Description("Gewicht(ml)")]
        WeightML,
        [Description("Pflanzen pro Meter")]
        PlantsPerMeter,
        [Description("Einträge")]
        Items,
        [Description("Lieferbreite")]
        DeliverWidth,
        [Description("Lieferlänge")]
        DeliverLength,
        [Description("Vorlage")]
        Signage,
        [Description("Stammumfang")]
        Circumference

    }

    public enum FieldContentType : short
    {
        [Description("Formatierter Text")]
        Markup,
        [Description("Preis")]
        Price,
        [Description("Mehrzeiliger Text")]
        MultiLineText,
        [Description("Radios")]
        RadioGroup,
        [Description("ChexBoxen")]
        CheckBoxes
    }

    public enum FieldDataType : short
    {
        [Description("String")]
        String,
        [Description("Text")]
        Translation,
        [Description("Ganzzahl")]
        Integer,
        [Description("Kommazahl")]
        Float,
        [Description("Ja/Nein")]
        Bool,
        [Description("Datum")]
        Date
    }

    public enum TextType : short
    {
        [Description("Standort")]
        Location,
        [Description("Frosthärte")]
        Hardiness,
        [Description("Optimale Temperatur")]
        OptimalSummerTemperature,
        [Description("Optimale Winter-Temperatur")]
        OptimalWinterTemperature,


        [Description("Blüte")]
        Flower,
        [Description("Blütenfarbe")]
        FlowerColor,
        [Description("Blütezeit")]
        FlowerTime,
        [Description("Blütenduft")]
        FlowerSmell,


        [Description("Wuchs")]
        Growth,
        [Description("Wuchshöhe")]
        GrowthHeight,
        [Description("Wuchsbreite")]
        GrowthWidth,
        [Description("Jahreszuwachs")]
        GrowthAnnualGrowth,
        [Description("Wuchsgeschwindigkeit")]
        GrowthSpeed,
        [Description("Wuchsform")]
        GrowthShape,


        [Description("Wasser")]
        Water,


        [Description("Rückschnitt")]
        Pruning,
        [Description("Rückschnitt von/bis")]
        PruningFromTo,


        [Description("Frucht")]
        Fruit,
        [Description("Zapfen")]
        FruitCone,
        [Description("Fruchtreife")]
        FruitRipe,


        [Description("Wassertiefe")]
        WaterDepth,


        [Description("Saat")]
        Seed,
        [Description("Saat - Ernte")]
        Harvest,
        [Description("Saat - Aussaat")]
        Sowing,


        [Description("Verfügbarkeit")]
        Availibility,


        [Description("Laub")]
        Foliage,
        [Description("Laubfarbe")]
        FoliageColor,
        [Description("Herbstfärbung")]
        FoliageAutumnColor,
        [Description("Immergrün")]
        AlwaysGreen,


        [Description("Boden")]
        Soil,

        [Description("Synonym")]
        Synonym,

        [Description("Beschreibung")]
        Description,

        [Description("Pflanzpartner")]
        PlantPartners,
        [Description("Ähnliche Pflanzen")]
        SimilarPlants,

        [Description("Verwendungen")]
        Usages,

        [Description("Markenschutz")]
        TrademarkProtection,
        [Description("Sortenschutz")]
        PlantVarietyProtection,

        [Description("Lokales Synonym")]
        LocaleSynonym,

        [Description("Herkunft")]
        Origins,

        [Description("Aufgaben")]
        Tasks,

        [Description("Blattfarbe")]
        LeaveColor,

        [Description("Saat - Tiefe")]
        SeedDepth,
        [Description("Saat - Pflanzabstand")]
        SeedPlantDistance,
        [Description("Saat - Reihenabstand")]
        SeedRowDistance,
        [Description("Saat - Keimzeit")]
        SeedGerminationDays,
        [Description("Saat - Keimtemperatur")]
        SeedGerminationTemperature,
        [Description("Saat - Pikieren/vereinzeln")]
        SeedTransplant,
        [Description("Saat - Keimung")]
        SeedGermination,
        [Description("Saat - Abstand")]
        SeedDistance,

        [Description("Lebensdauer")]
        LifeTime,

        [Description("Sonstiges")]
        Other,

        [Description("ADR")]
        ADR,

        [Description("Saat - Auspflanzen")]
        SeedPlanting,

        [Description("Inhaltsstoffe")]
        Substances,

        [Description("Pflege")]
        Care,

        [Description("Wissenswertes")]
        WorthKnowing,

        [Description("Besonderheit")]
        Specialty,

        [Description("Eigenschaften")]
        Attributes,

        [Description("Hinweis")]
        Advice,

        [Description("Überwinterung")]
        Hibernation,

        [Description("Anspruch")]
        Claim,

        [Description("Vermehrung")]
        Reproduction,

        [Description("Rinde")]
        Bark,

        [Description("Holz")]
        Wood,

        [Description("Nadeln")]
        Needling,

        [Description("Freier Text 6")]
        FreeText6,

        [Description("Ertrag")]
        Output,

        [Description("Gießen/Düngen")]
        WateringFertilizing,

        [Description("Düngen")]
        Fertilizing,

        [Description("Erde")]
        Substrate,

        [Description("Wasserstand")]
        WaterLevel,

        [Description("Reifezeit")]
        RipeTime,

        [Description("Stängel")]
        Stipe,

        [Description("Schnitt")]
        Cut,

        [Description("Heilwirkung")]
        MedicalBenefit,

        [Description("Geschmack")]
        Taste,

        [Description("Kultur")]
        Variety,

        [Description("Befruchtung")]
        Impregnation,

        [Description("Baum")]
        Tree,

        [Description("Pflanzzeit")]
        PlantingTime,

        [Description("Pflanzung")]
        Planting,

        [Description("Kompost")]
        Compost,

        [Description("Schwierigkeitsgrad")]
        Difficulty,

        [Description("Pflanzabstand")]
        PlantingDistance,

        [Description("Freier Text 1")]
        FreeText1,
        [Description("Freier Text 2")]
        FreeText2,
        [Description("Freier Text 3")]
        FreeText3,
        [Description("Freier Text 4")]
        FreeText4,
        [Description("Freier Text 5")]
        FreeText5,
        [Description("Herkunftsland")]
        OriginCountry,
        [Description("Haltbarkeit")]
        Durability,
        [Description("Stiellänge")]
        StemLength,
        [Description("Tipp")]
        Tipp,
        [Description("Nachhaltigkeit")]
        Sustainability,
        [Description("Blatt")]
        Leave,
        [Description("Züchter")]
        Grower,
        [Description("Stamm")]
        Stem,
        [Description("Freier Text 7")]
        FreeText7,
        [Description("Freier Text 8")]
        FreeText8,
        [Description("Freier Text 9")]
        FreeText9,
        [Description("Freier Text 10")]
        FreeText10,
        [Description("Freier Text 11")]
        FreeText11,
        [Description("Freier Text 12")]
        FreeText12,

        [Description("Größe")]
        Size,

        [Description("Duft")]
        Smell,

        [Description("Einleitung")]
        Opener,

        [Description("Freier Text 13")]
        FreeText13,

        [Description("Freier Text 14")]
        FreeText14,

        [Description("Freier Text 15")]
        FreeText15,

        [Description("Freier Text 16")]
        FreeText16,

        [Description("Freier Text 17")]
        FreeText17,

        [Description("Freier Text 18")]
        FreeText18,

        [Description("Freier Text 19")]
        FreeText19,

        [Description("Freier Text 20")]
        FreeText20,

        [Description("Gesundheit")]
        Health,

        [Description("Fruchtfleisch")]
        Pulp,

        [Description("Pflückreife")]
        Picking,

        [Description("Stengel")]
        Stalk,

        [Description("Blütendurchmesser")]
        FlowerDiameter,

        [Description("Halm")]
        Culm,

        [Description("Freier Text 21")]
        FreeText21,

        [Description("Bulletpoints")]
        BulletPoints,

        [Description("Empfehlung")]
        Recommendation,

        [Description("Zusammensetzung")]
        Composition,

        [Description("Material")]
        Material,
    }

    public enum ParagraphType : long
    {
        [Description("Fließtext")]
        RunningText,

        [Description("Anlauftext")]
        WarmupText,

        [Description("Special")]
        Special,

        [Description("Aufzählung")]
        Bullet,

        [Description("Zitat")]
        Quote
    }

    public enum ReportType : short
    {
        [Description("Deko-Ideen")]
        DecorationReport,
        [Description("Genießen")]
        FoodReport,
        [Description("Garten-Ideen")]
        IdeaReport,
        [Description("Pflanz / Pflegeanleitungen")]
        PlantInstruction,
        [Description("Pflanzenschutz")]
        PlantProtectionReport,
        [Description("Garten-Praxis")]
        PracticeReport,
        [Description("Blog")]
        BlogReport,
        [Description("Projekte")]
        ProjectReport,
        [Description("Rezepte")]
        Recipe,
        [Description("Saisonale Tipps")]
        SeasonalReport,

        [Description("Bericht")]
        Report
    }


    public enum SynchronizerMappingType : short
    {
        [Description("Name")]
        Name,
        [Description("Name 1 + 2")]
        Name1Name2,
        [Description("Gruppierung")]
        Grouped
    }

    public enum ChannelType : short
    {
        [Description("Kanal")]
        Kanal,
        [Description("Monitor")]
        Monitor
    }

    public enum PictureDisplayMode : short
    {
        [Description("Abschneiden")]
        Cut,
        [Description("Komplett")]
        Full,
        [Description("Automatisch")]
        Auto
    }

    public enum FeatureEnumType : short
    {
        [Description("Giftig")]
        Toxically,
        [Description("Frosthart")]
        Freeze,
        [Description("Immergrün")]
        AlwaysGreen,
        [Description("Verwendung")]
        Usage,
        [Description("Wuchsform")]
        GrowthShape,
        [Description("Standort")]
        Location,
        [Description("Wasser")]
        Water,
        [Description("Blüte")]
        Flower,
        [Description("Farbe")]
        Color,
        [Description("Boden")]
        Soil,
        [Description("Geschmack")]
        Taste,
        [Description("Lebenszeit")]
        Lifetime,
        [Description("Schwierigkeitsgrad")]
        Difficulty,
        [Description("Pflegeaufwand")]
        CareEffort,
        [Description("Sonstiges")]
        Features,
        [Description("Duft")]
        Smell,
        [Description("Herbstfärbung")]
        LeaveAutumnColor,
        [Description("Blattfarbe")]
        LeaveColor,
        [Description("Blütenfüllung")]
        FlowerFilling,
        [Description("Wuchsgeschwindigkeit")]
        GrowthSpeed,
        [Description("Form")]
        Shape,
        [Description("Fruchtfarbe")]
        FruitColor,
        [Description("Blattrand")]
        LeaveBorder,
        [Description("Blattform")]
        LeaveShape
    }

    public enum TaskType : short
    {
        [Description("Aussaat")]
        Seed,
        [Description("Pflanzung")]
        Planting,
        [Description("Pflege")]
        Care,
        [Description("Kompost")]
        Compost,
        [Description("Vermehrung")]
        Progeny,
        [Description("Ernten")]
        Harvest,
        [Description("Benutzerdefiniert")]
        Custom
    }

    public enum BasketType : short
    {
        Checkout,
        WatchList,
        [Description("Preisanfrage")]
        RequestList,
        [Description("Bildermappe")]
        ImageDeliveryList
    }

    public enum TransactionType : short
    {
        [Description("Versenden")]
        Shipping,
        [Description("Abholen")]
        ClickAndCollect,
        [Description("Liefern")]
        RadiusDelivery,
        [Description("Herunterladen")]
        Download
    }

    public enum BasketState : short
    {
        Open,
        Closed
    }

    public enum ItemType
    {
        [Description("Artikel")]
        ArticleKey,
        [Description("Benutzerdefiniert")]
        Custom
    }

    public enum TimelineEntityType
    {
        [Description("Artikel")]
        Article,
        [Description("Berichte")]
        Report,
        [Description("Videos")]
        Video,
        [Description("Prospekt")]
        Leaflet
    }

    public enum CordobaTimelineEntityType
    {
        [Description("Pflanzen")]
        Plant,
        [Description("Berichte")]
        Report,
        [Description("Videos")]
        Video,
    }

    public enum ContainerEntityType
    {
        [Description("Artikel")]
        Article,
        [Description("Berichte")]
        Report,
        [Description("Videos")]
        Video,
        [Description("Inhalte")]
        Container,
        [Description("Kategorie")]
        Category,
        [Description("Menüeintrag")]
        MenuItem,
        [Description("Prospekt")]
        Leaflet,
        [Description("Audio")]
        Audio,
        [Description("Seite")]
        Page,
        [Description("Neuigkeit")]
        News,
        [Description("Kalendereintrag")]
        CalendarItem

    }

    /// <summary>
    /// Alle automatisch versandten E-Mail-Vorlagenschlüssel sind hier aufgelistet
    /// </summary>
    public enum StandardMailTemplate
    {
        [Description("Kunde registriert")]
        MemberRegister,
        [Description("Kunde aktiviert")]
        MemberRegisterActivated,
        [Description("Auftrag erstellt")]
        OrderCreated,
        [Description("Auftrag angenommen")]
        OrderConfirmed,
        [Description("Auftrag versendet")]
        OrderSent,
        [Description("Auftrag verschickt")]
        OrderDelivered,
        [Description("Auftrag abholbar")]
        OrderDeliveredAndReady,
        [Description("Auftrag storniert")]
        OrderCanceled,
        [Description("Merkzettel")]
        WatchList,
        [Description("Benutzerdaten vergessen")]
        UserForgotData,
        [Description("Kontaktanfrage")]
        Contact,
        [Description("Kontaktanfrage Bestätigung")]
        ContactConfirmation,
        [Description("Social Media Zugangsschlüssel abgelaufen")]
        SocialMediaTokenExpired,
        [Description("Auftrag teilweise angenommen")]
        OrderPartialConfirmed,
        [Description("Gutschein Bestellung eingegangen")]
        VoucherOrderReceived,
        [Description("Gutschein Bestellbestätigung")]
        VoucherOrderConfirmed,
        [Description("Merkzettel (Anfrage)")]
        WatchListRequest,
        [Description("Nachricht an Kunde")]
        MemberMessage,
        [Description("Bestellinformation an Filiale")]
        OrderToChainStore,
        [Description("Kunde gesperrt")]
        MemberLocked,
        [Description("Kunde entsperrt")]
        MemberUnlocked,
        [Description("Kunde freigeschaltet")]
        MemberActivated,
        [Description("Auftrag ausgeführt")]
        TaskExecuted,
        [Description("Auftrag gestartet")]
        TaskStarted,
        [Description("Auftrag im Anhang")]
        OrderAttached,
        [Description("Informationen zu Ihrem Auftrag")]
        TaskMessage,
        [Description("Preisanfrage")]
        RequestList,
        [Description("Bildermappe")]
        ImageDeliveryList,
        [Description("Shop Bewertung")]
        ShopRating,
        [Description("Auftrag erstellt für Lieferant")]
        OrderCreatedForSupplier,
        [Description("Newsletter Registrierung (Shopinhaber)")]
        NewsletterRegisterToShop,
        [Description("Newsletter Registrierung (Kunde)")]
        NewsletterRegisterToCustomer,
        [Description("Kontaktanfrage")]
        ContactAdvanced,
        [Description("Newsletter Anmeldung bestätigen")]
        NewsletterRegisterConfirm,
        [Description("Auftrag erledigt")]
        OrderReady,
        [Description("Kunde hat Passwort geändert")]
        UserChangedPassword,
        [Description("Vielen Dank für Ihr Interesse")]
        NewsletterRegisterConfirmConfirm,
        [Description("Auftrag mit Fehlern beendet")]
        TaskExecutedError
    }

    public enum StandardPrintTemplate
    {
        [Description("Lieferschein")]
        DeliverySlip,
        [Description("Packzettel")]
        PackingSlip,
        [Description("Merkzettel")]
        Watchlist
    }

    public enum EventType
    {
        [Description("Passwort vergessen")]
        UserPasswordForgotten,
        [Description("Kunde aktiviert")]
        MemberActivated,
        [Description("Kunde deaktiviert")]
        MemberDeactivated,
        [Description("Kunde gesperrt")]
        MemberLocked,
        [Description("Kunde entsperrt")]
        MemberUnlocked,
        [Description("Kunde registriert")]
        MemberRegistered,
        [Description("Kunde gelöscht")]
        MemberDeleted,
        [Description("Benutzer wegen falscher Passworteingabe gesperrt")]
        UserLockedPasswordWrong,
        [Description("Benutzer gibt Passwort falsch ein")]
        UserPasswordWrong,
        [Description("Kunde bestellt")]
        MemberOrdered,
        [Description("Social Media Zugangsschlüssel abgelaufen")]
        SocialMediaTokenExpired,
        [Description("Nachricht an Kunde")]
        MemberMessage,
        [Description("Shop Bewertung E-Mail versendet")]
        ShopRatingMailSended,
        [Description("Job gestartet")]
        JobStarted,
        [Description("Job ausgeführt")]
        JobExecuted,
        [Description("Job beendet")]
        JobFinished,
        [Description("Versandauftrag erteilt")]
        ShipmentOrderTaken,
        [Description("Versandauftrag storniert")]
        ShipmentOrderCancelled
    }

    public enum EventState
    {
        [Description("Information")]
        Info,
        [Description("System")]
        System
    }

    public enum WebshopMode
    {
        [Description("Business-to-Consumer")]
        B2C,
        [Description("Business-to-Business")]
        B2B
    }

    public enum SetupConfigType
    {
        [Description("System")]
        System,
        [Description("Kunde")]
        Customer,
    }

    public enum PlatformType
    {
        [Description("Webseite")]
        Website,
        [Description("Webshop")]
        Webshop,
        [Description("Webseite + Webshop")]
        WebsiteWebshop
    }

    public enum PlatformMemberType
    {
        [Description("Grün")]
        Green,
        [Description("Nicht grün")]
        NotGreen
    }

    public enum MemberType
    {
        [Description("Kunde")]
        Customer,
        [Description("Mandant")]
        Client,
        [Description("Lieferant")]
        Supplier
    }

    public enum SolvencyType
    {
        [Description("Niedrig (C)")]
        A,
        [Description("Mittel (B)")]
        B,
        [Description("Hoch (A)")]
        C
    }

    public enum SocialMediaPostType
    {
        [Description("Facebook")]
        Facebook
    }

    public enum SocialMediaPostContentType
    {
        [Description("Ohne")]
        None,
        [Description("Video")]
        Video,
        [Description("Artikel")]
        Article,
        [Description("Bericht")]
        Report,
        [Description("Neuigkeit")]
        News
    }

    public enum MarketPlaceType : short
    {
        [Description("Amazon")]
        Amazon,
        [Description("E-Bay")]
        EBay,
        [Description("Google Shopping")]
        GoogleShopping
    }

    public enum DocumentationType : short
    {
        [Description("Benutzerdefiniert")]
        Custom,
        [Description("Rechnung")]
        Invoice,
        [Description("Anleitung")]
        Manual,
        [Description("Lieferschein")]
        DeliverySlip,
        [Description("Packzettel")]
        PackingSlip,
        [Description("Preisanfrage")]
        RequestList,
        [Description("Lieferschein (Teilbestellung)")]
        DeliverySlipTransaction,
        [Description("Angebot")]
        Offer,
        [Description("Präsentation")]
        Presentation,
        [Description("Packzettel (Teilbestellung)")]
        PackingSlipTransaction,
        [Description("Packzettel (Bestellungen)")]
        PackingSlipOrders,
        [Description("Umlagerungsauftrag")]
        TransferOrder
    }

    public enum WorkerLocation
    {
        WebApp,
        WebJob,
        Cordoba
    }

}
