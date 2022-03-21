using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class Samples
    {

        //public void CreateArticle()
        //{
        //    var unitOfWork = new Api.Client.ContextUOW("");

        //    var article = new Article();

        //    article.Name = "Acer Palmatum Bloodgood";
        //    article.Name2 = "Fächerahorn Bloodgood";
        //    article.Description = "Dies ist eine lange Beschreibung";
        //    article.ShortDescription = "Dies ist eine kurze Beschreibung";

        //    // Warengruppe setzen (evtl. Hierachie beachten)
        //    var articleGroup = unitOfWork.ArticleGroups.FindAll("Pflanzen", 0, 100, null).Items.First(); // GET api/articlegroups
        //    article.ArticleGroups.Add(new EntityReference() { ID = articleGroup.ArticleGroupID });

        //    // Kategorie setzen (evtl. Hierachie beachten)
        //    var category = unitOfWork.Categories.FindAll("Zubehör", 0, 100, null).Items.First(); // GET api/categories
        //    article.Categories.Add(new EntityReference() { ID = category.CategoryID });

        //    // Texte hinzufügen
        //    var text = new ArticleText();
        //    article.Texts.Add(text);
        //    text.Type = Types.TextType.BulletPoints;
        //    text.Title = "Kaufargumente";
        //    text.Value = "	* frosthart * duftend * wintergrün * Kübel geeignet";

        //    // Verfügbarkeiten
        //    var timePeriod = new TimePeriod();
        //    article.Available.Add(timePeriod);
        //    timePeriod.FromCW = 10; // Kalendarwoche (von)
        //    timePeriod.ToCW = 20; // Kalendarwoche (bis)

        //    // Varianten (Artikelnummern) hinzufügen
        //    var articleKey = new ArticleKey();
        //    article.Keys.Add(articleKey);

        //    articleKey.Value = "47811"; // Artikelnummer
        //    articleKey.Info = "C/  50 - 60";
        //    articleKey.AvailableForClickAndCollect = true; // Click & Collect
        //    articleKey.AvailableForRadiusDelivery = true; // Liefern
        //    articleKey.AvailableForShipping = true; // Versenden
        //    articleKey.PackingSize = 20; // VE
        //    articleKey.StockQuantity = 10; // Bestand

        //    // Steuersatz
        //    var taxRate = unitOfWork.Countries.Get("DE").TaxRates.Single(m => m.Percent == 19); // GET api/countries
        //    articleKey.TaxRate = new EntityReference() { ID = taxRate.TaxRateID };


        //    // Preise
        //    var currency = unitOfWork.Currencies.Get("EUR"); // GET api/currencies

        //    var articleKeyPrice = new ArticleKeyPrice();
        //    articleKey.Prices.Add(articleKeyPrice);
        //    articleKeyPrice.Price = 17; // Preis
        //    articleKeyPrice.PriceOld = 25; // Streichpreis
        //    articleKeyPrice.PriceUnitAmount = 10; // pro 10
        //    articleKeyPrice.ValueUnitType = Types.PriceUnitType.Liter; // Liter
        //    articleKeyPrice.Quantity = 1; // Ab Stückzahl
        //    articleKeyPrice.Currency = new EntityReference() { ID = currency.CurrencyID };
        //    articleKeyPrice.TaxIncluded = true; // Mwst. inkl?
        //    articleKeyPrice.PriceNet = true; // Netto - Preis (keine Rabatte)

        //    unitOfWork.Articles.Create(article);  // POST api/articles/create?importExternal=true 
        //    // PUT api/articles/{id} zum updaten

        //}

        //public void GetOrders()
        //{
        //    var unitOfWork = new Api.Client.ContextUOW(null, "");
        //    var orders = unitOfWork.Orders.FindAll(null, 0, 100, "OrderID desc").Items; // GET api/orders/all

        //    foreach(var orderSummary in orders)
        //    {
        //        var order = unitOfWork.Orders.Get(orderSummary.OrderID); // GET api/orders/{id}

        //        Console.WriteLine("Auftragsnummer:" + order.OrderID);
        //        Console.WriteLine("Datum:" + order.CreatedOn.ToShortDateString());

        //        var owner = unitOfWork.Members.Get(order.Owner.ID); // GET api/members/{id}
        //        Console.WriteLine("Kunde:" + owner.MainContact.Company);

        //        Console.WriteLine("Rechnungsadresse:" + order.InvoiceAddress.Contact.Company+" "+order.InvoiceAddress.Address.Street+" "+order.InvoiceAddress.Address.HouseNumber);
        //        Console.WriteLine("Lieferadresse:" + order.ShippingAddress.Contact.Company + " " + order.ShippingAddress.Address.Street + " " + order.ShippingAddress.Address.HouseNumber);

        //        var paymentMethod = unitOfWork.PaymentMethods.Get(order.PaymentMethod.ID); // GET api/paymentmethods/{id}
        //        Console.WriteLine("Bezahlart:" + paymentMethod.Name);

        //        var shippingMethod = unitOfWork.ShippingMethods.Get(order.ShippingMethod.ID); // GET api/shippingmethods/{id}
        //        Console.WriteLine("Versandart:" + shippingMethod.Name);

        //        // Positionen
        //        foreach (var position in order.Items)
        //        {
        //            var article = unitOfWork.Articles.Get(position.Article.ID); // GET api/articles/{id}
        //            var articleKey = article.Keys.SingleOrDefault(m=>m.ArticleKeyID == position.ArticleKey.ID);

        //            Console.WriteLine("Artikel:" + article.Name+" / "+article.Name2);
        //            Console.WriteLine("Artikelnummer:" + articleKey.Value);
        //            Console.WriteLine("Abwicklung:" + position.TransactionType); // CLick&Collect, Versenden u.s.w.
        //            Console.WriteLine("Menge:" + position.Quantity); 
        //            Console.WriteLine("Einzelpreis:" + position.Price);
        //            Console.WriteLine("Gesamtpreis:" + position.TotalCosts);
        //            Console.WriteLine("Bestätigt:" + (position.IsConfirmed==true ? "Ja" : "Nein") );
        //        }



        //    }

        //}

        //public void Validate()
        //{
        //    var unitOfWork = new Api.Client.ContextUOW(null, "");
        //    var token = unitOfWork.Account.Validate("Benutzer", "Passwort"); // POST api/account/validate?user={benutzer}&password={passwort}
        //}
    }
}