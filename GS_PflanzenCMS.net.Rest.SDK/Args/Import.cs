using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using GS.PflanzenCMS.Rest.SDK.Models;

namespace GS.PflanzenCMS.Rest.SDK.Api.Args
{
    public class Import : Base
    {
        // Brands
        public Brand[] Brands { get; set; }

        // Artikel
        public Article[] Articles { get; set; }

        // Seiten
        public Page[] Pages { get; set; }
        
        // Berichte
        public Report[] Reports { get; set; }

        // Videos
        public Video[] Videos { get; set; }

        // Leaflets
        public Leaflet[] Leaflets { get; set; }

        // Producers
        public Producer[] Producers { get; set; }
        
        // Features
        public Feature[] Features { get; set; }

        // Rollen
        public Role[] Roles { get; set; }

        // Rechte
        public Right[] Rights { get; set; }

        // FeatureType
        public FeatureType[] FeatureTypes { get; set; }

        // Sprachen
        public Language[] Languages { get; set; }

        // Kategorien
        public Category[] Categories { get; set; }

        // Währungen
        public Currency[] Currencies { get; set; }

        // Länder
        public Country[] Countries { get; set; }

        // Währungen
        public TaxRate[] TaxRates { get; set; }

        // Warengruppen
        public ArticleGroup[] ArticleGroups { get; set; }

        // Warengruppen
        public CustomerGroup[] CustomerGroups { get; set; }

        // Artikeleigenschaften
        public ArticleProperty[] ArticleProperties { get; set; }

        // Zahlarten
        public PaymentMethod[] PaymentMethods { get; set; }

        // Versandarten
        public ShippingMethod[] ShippingMethods { get; set; }

        // Mailings
        public NewsletterMailing[] NewsletterMailings { get; set; }

        // News
        public News[] News { get; set; }

        // Social Media Post
        public SocialMediaPost[] SocialMediaPosts { get; set; }

        // Teasers
        public Teaser[] Teasers { get; set; }

        // Containers
        public Container[] Containers { get; set; }

        // Timelines
        public Timeline[] Timelines { get; set; }

        // Galleries
        public Gallery[] Galleries { get; set; }

        // Tags
        public Tag[] Tags { get; set; }

        // SetupConfigs
        public SetupConfig[] SetupConfigs { get; set; }

        // TagSynonyms
        public TagSynonym[] TagSynonyms { get; set; }

        // Fields
        public Field[] Fields { get; set; }

        // ContactAddress
        public ContactAddress[] ContactAddresses { get; set; }

        // Address
        public Address[] Addresses { get; set; }

        // Contact
        public Contact[] Contacts { get; set; }

        // Member
        public Member[] Members { get; set; }

        // ShippingMethod
        //public ShippingMethod[] ShippingMethods { get; set; }

        // Voucher
        public Voucher[] Vouchers { get; set; }

        // Bilder
        // Picture.Url = 'attachments://bla.png' oder 'ftp://www.gbsbecker.de/uploads/bilder/bla.png' ansonsten normale URL!
        public Picture[] Pictures { get; set; }

        public Menu[] Menus { get; set; }

        public DataFile[] DataFiles { get; set; }

        public Pricelist[] Pricelists { get; set; }

        public Order[] Orders { get; set; }
                
        // FTP Zugangsdaten
        public string FTPUserName { get; set; }
        public string FTPPassword { get; set; }

        // Externe Daten importieren
        public bool ImportExternalData { get; set; }

        public bool SetMemberExternal_Data { get; set; }

        // Artikelnummern importieren
        public bool ImportArticleKeys = true;

        // Artikel auf Deleted setzen
        public bool DeleteArticles { get; set; }
        public bool DeactivateArticles { get; set; }
        public string[] ExternalKeysArticles { get; set; }

        // Gelöschte Einträge aus Listen löschen
        public bool Remove { get; set; }
        public string RemoveTypes { get; set; } // Komma separiert z.b. Category,ArticlePhoto
        public RemoveOwnerType[] RemoveOwnerTypes { get; set; }

        public string ForceUpdateTypes { get; set; } // Komma separiert z.b. Article,ArticlePhoto
    }
}