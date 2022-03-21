using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class SetupConfig : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long SetupConfigID { get; set; }
            public string Template { get; set; }
            public string Title { get; set; }
            public PlatformType Platform { get; set; }
            public PlatformMemberType PlatformMember { get; set; }
            public WebshopMode Mode { get; set; }
            public PictureEntityReference Thumbnail { get; set; }

            public string GetDisplayName(long languageID)
            {
                return Template + " " + Title;
            }
        }

        public long SetupConfigID { get; set; }
        public List<SetupConfigPage> Pages { get; set; }
        public List<EntityReference> DependentPages { get; set; }
        public List<EntityReference> DependentContainers { get; set; }
        public List<EntityReference> DependentMenus { get; set; }
        public EntityReference ZipFile { get; set; }

        public DateTime? LastConfiguredOn { get; set; }
        public string Domain { get; set; }
        public string Title { get; set; }
        public string Template { get; set; }
        public string GoogleAnalyticsID { get; set; }
        public string Ceo { get; set; }
        public string Fax { get; set; }
        public bool PageImprint { get; set; }
        public bool UpdatePictos { get; set; }
        public bool PageAGB { get; set; }
        public bool CanNotPersonalizeColors { get; set; }
        public PlatformType Platform { get; set; }
        public PlatformMemberType PlatformMember { get; set; }
        public Apellation Apellation { get; set; }
        public WebshopMode Mode { get; set; }
        public EntityReference Language { get; set; }
        public PictureEntityReference Favicon { get; set; }
        public PictureEntityReference Thumbnail { get; set; }
        public PictureEntityReference Picture { get; set; }
        public PictureEntityReference Logo { get; set; }
        public PictureEntityReference LogoAlternative { get; set; }
        public PictureEntityReference Icon { get; set; }
        public bool DontGenerateBeforeAttributesAutomatically { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSeed { get; set; }
        public virtual EntityReference Currency { get; set; }
        public virtual EntityReference Country { get; set; }
        public bool PriceTaxIncluded { get; set; }
        public int? BaseStock { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Postbox { get; set; }
        public string AppKey { get; set; }
        public string AppTemplate { get; set; }
        public string OriginalTemplate { get; set; }
        public bool UpdatePages { get; set; }
        public string TemplateCSSRunningTextFontFamily { get; set; }
        public string TemplateCSSHeadlineTextFontFamily { get; set; }
        public string TemplateCSSH1FontFamily { get; set; }
        public bool TemplateCSSH1UpperCase { get; set; }
        public string TemplateCSSH1LineHeight { get; set; }
        public string TemplateCSSH1Margin { get; set; }
        public string TemplateCSSH2LineHeight { get; set; }
        public bool TemplateCSSH2UpperCase { get; set; }
        public string TemplateCSSH2Margin { get; set; }
        public string TemplateCSSH3LineHeight { get; set; }
        public bool TemplateCSSH3UpperCase { get; set; }
        public string TemplateCSSH3Margin { get; set; }
        public string TemplateCSSH4LineHeight { get; set; }
        public bool TemplateCSSH4UpperCase { get; set; }
        public string TemplateCSSH4Margin { get; set; }
        public string TemplateCSSH5LineHeight { get; set; }
        public bool TemplateCSSH5UpperCase { get; set; }
        public string TemplateCSSH5Margin { get; set; }
        public string TemplateCSSH6LineHeight { get; set; }
        public bool TemplateCSSH6UpperCase { get; set; }
        public string TemplateCSSH6Margin { get; set; }
        public string TemplateCSSH2FontFamily { get; set; }
        public string TemplateCSSH3FontFamily { get; set; }
        public string TemplateCSSH4FontFamily { get; set; }
        public string TemplateCSSH5FontFamily { get; set; }
        public string TemplateCSSH6FontFamily { get; set; }
        public string TemplateCSSPrimaryColor { get; set; }
        public string TemplateCSSPrimaryLightColor { get; set; }
        public string TemplateCSSSecondaryColor { get; set; }
        public string TemplateCSSFontSize { get; set; }
        public string TemplateCSSFontColor { get; set; }
        public string TemplateCSSLineHeight { get; set; }
        public string TemplateCSSH1FontSize { get; set; }
        public string TemplateCSSH1FontColor { get; set; }
        public string TemplateCSSH2FontSize { get; set; }
        public string TemplateCSSH2FontColor { get; set; }
        public string TemplateCSSH3FontSize { get; set; }
        public string TemplateCSSH3FontColor { get; set; }
        public string TemplateCSSH4FontSize { get; set; }
        public string TemplateCSSH4FontColor { get; set; }
        public string TemplateCSSH5FontSize { get; set; }
        public string TemplateCSSH5FontColor { get; set; }
        public string TemplateCSSH6FontSize { get; set; }
        public string TemplateCSSH6FontColor { get; set; }
        public string TemplateHeaderBackgroundColor { get; set; }
        public string TemplateHeader2BackgroundColor { get; set; }
        public string TemplateHeader3BackgroundColor { get; set; }
        public string TemplateFooterBackgroundColor { get; set; }
        public string TemplateFooter2BackgroundColor { get; set; }
        public string TemplateFooter3BackgroundColor { get; set; }
        public virtual PictureEntityReference TemplateHeaderPicture { get; set; }
        public virtual PictureEntityReference TemplateHeader2Picture { get; set; }
        public virtual PictureEntityReference TemplateHeaderBackground { get; set; }
        public virtual PictureEntityReference TemplateHeader2Background { get; set; }
        public string TemplateCSSHeaderFontColor1 { get; set; }
        public bool TemplateCSSHeaderFont1UpperCase { get; set; }
        public string TemplateCSSHeaderFontColor2 { get; set; }
        public bool TemplateCSSHeaderFont2UpperCase { get; set; }
        public string TemplateCSSHeaderItemPadding { get; set; }
        public virtual PictureEntityReference TemplateFooterPicture { get; set; }
        public virtual PictureEntityReference TemplateFooter2Picture { get; set; }
        public virtual PictureEntityReference TemplateFooterBackground { get; set; }
        public virtual PictureEntityReference TemplateFooter2Background { get; set; }
        public string TemplateCSSFooterFontColor1 { get; set; }
        public bool TemplateCSSFooterFont1UpperCase { get; set; }
        public string TemplateCSSFooterFontColor2 { get; set; }
        public bool TemplateCSSFooterFont2UpperCase { get; set; }
        public virtual PictureEntityReference TemplateDisturberOverlayPicture { get; set; }
        public virtual string TemplateDisturberH1FontSize { get; set; }
        public virtual string TemplateDisturberH1FontFamily { get; set; }
        public virtual string TemplateDisturberH1FontColor { get; set; }
        public virtual string TemplateDisturberH1LineHeight { get; set; }
        public virtual string TemplateDisturberH1Margin { get; set; }
        public virtual bool TemplateDisturberH1UpperCase { get; set; }
        public virtual bool TemplateDisturberH1ShadowEnabled { get; set; }
        public virtual string TemplateDisturberH2FontSize { get; set; }
        public virtual string TemplateDisturberH2FontFamily { get; set; }
        public virtual string TemplateDisturberH2FontColor { get; set; }
        public virtual string TemplateDisturberH2LineHeight { get; set; }
        public virtual string TemplateDisturberH2Margin { get; set; }
        public virtual bool TemplateDisturberH2UpperCase { get; set; }
        public virtual bool TemplateDisturberH2ShadowEnabled { get; set; }
        public virtual string TemplateButtonBackgroundColor { get; set; }
        public virtual string TemplateButtonHoverBackgroundColor { get; set; }
        public virtual string TemplateButtonFontColor { get; set; }
        public virtual string TemplateButtonBorderRadius { get; set; }
        public virtual string TemplateButtonBorderWidth { get; set; }
        public virtual string TemplateButtonBorderColor { get; set; }
        public virtual Picture TemplateHoverPictureLandscape { get; set; }
        public virtual Picture TemplateHoverPicturePortrait { get; set; }
        public virtual string TemplateHoverFontColor { get; set; }
        public virtual bool TemplateHoverFontUpperCase { get; set; }
        public virtual Picture TemplateHomeSliderPriceBackground { get; set; }
        public virtual Picture TemplatePageFallbackPicture { get; set; }
        public string TemplateCSSHomeSliderH1FontSize { get; set; }
        public bool TemplateCSSHomeSliderH1UpperCase { get; set; }
        public string TemplateCSSHomeSliderH1FontColor { get; set; }
        public string TemplateCSSHomeSliderH1FontFamily { get; set; }
        public string TemplateCSSHomeSliderH2FontSize { get; set; }
        public bool TemplateCSSHomeSliderH2UpperCase { get; set; }
        public string TemplateCSSHomeSliderH2FontColor { get; set; }
        public string TemplateCSSHomeSliderH2FontFamily { get; set; }
        public string TemplateCSSHomeSliderH3FontSize { get; set; }
        public bool TemplateCSSHomeSliderH3UpperCase { get; set; }
        public string TemplateCSSHomeSliderH3FontColor { get; set; }
        public string TemplateCSSHomeSliderH3FontFamily { get; set; }
        public bool TemplateEnablePanelShadow { get; set; }
        public string TemplateCSSOverride { get; set; }
        public string TemplateCSSPriceFontColor { get; set; }
        public string TemplateCSSOfferPriceFontColor { get; set; }
        public string TemplateCSSHRMargin { get; set; }
        public string TemplateCSSHRBackgroundColor { get; set; }
        public string TemplateCSSHRHeight { get; set; }
        public DateTime? OpenWeekdaysFrom { get; set; }
        public DateTime? OpenWeekdaysTo { get; set; }
        public DateTime? OpenMondaysFrom { get; set; }
        public DateTime? OpenMondaysTo { get; set; }
        public DateTime? OpenTuesdaysFrom { get; set; }
        public DateTime? OpenTuesdaysTo { get; set; }
        public DateTime? OpenWednesdaysFrom { get; set; }
        public DateTime? OpenWednesdaysTo { get; set; }
        public DateTime? OpenThursdaysFrom { get; set; }
        public DateTime? OpenThursdaysTo { get; set; }
        public DateTime? OpenFridaysFrom { get; set; }
        public DateTime? OpenFridaysTo { get; set; }
        public DateTime? OpenSaturdaysFrom { get; set; }
        public DateTime? OpenSaturdaysTo { get; set; }
        public DateTime? OpenSundaysFrom { get; set; }
        public DateTime? OpenSundaysTo { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramURL { get; set; }
        public string GooglePlusURL { get; set; }
        public string PinterestURL { get; set; }
        public string YoutubeURL { get; set; }
        public bool TemplateHideOpeningTimes { get; set; }
        public bool TemplateHideSearch { get; set; }
        public bool TemplateHideContact { get; set; }
        public string SystemPictoColor { get; set; }
    }
}
