# Green Solutions Software GmbH

# Overview

With the Green Solutions REST API, all functions and data of the omni-channel system can be accessed.

In the documentation, the synonym "middleware" is used for the Green Solutions omni-channel system and the synonym "external software system" for the external software system such as ERP, merchandise management or web shop.

As an innovative software company, we have specialized 100% in the horticultural industry. With our cloud-based omni-channel solution, all relevant online and offline channels such as web shop, website, signage, newsletters, apps, social media, print media, etc. can be managed centrally from one system. In addition, the customer can access the huge Green Solutions database for all channels - with thousands of photos, videos, editorial reports, plant and product data.

# Authorization

This example shows how a connection to the middleware is defined via a vendor, a token and the endpoint.

```csharp
var var unitOfWork = new ContextUOW("<vendor>", "<token>", "<endpunkt>");
// GET api/account/info
var token = unitOfWork.Account.Info(); 
```

# External primary key

All entities have an External_Key field in which their own primary key, such as the ID of the external software system, can be stored. The entity can then be accessed on the basis of this External_Key.

# Set external primary key

This example shows how to set the primary key for the entity.

```csharp
    unitOfWork.Articles.Update(article.ArticleID, article, new string[] { "External_Key" } /* optional */);
    Console.WriteLine("Artikel wurde aktualisiert: " + newArticle.External_Key); 
```


# Query entity via external primary key

This example shows how to query an entity using a primary key.

```csharp
    var article = unitOfWork.Articles.Get(external_key);
    if (article == null)
        Console.WriteLine("Kein Artikel gefunden!");
```

# items

Article master data and movement data (price inventory) must be transferred

## Transfer article master data

This example shows how the item master data is transferred.

```csharp
var article = new Article();

article.Name = "Acer Palmatum Bloodgood";
article.Name2 = "Fächerahorn Bloodgood";
article.Description = "Dies ist eine lange Beschreibung";
article.ShortDescription = "Dies ist eine kurze Beschreibung";

// Warengruppe setzen (evtl. Hierachie beachten)
var articleGroup = unitOfWork.ArticleGroups.FindAll("Pflanzen", 0, 100, null).Items.First(); // GET api/articlegroups
article.ArticleGroups = new List<EntityReference>();
article.ArticleGroups.Add(new EntityReference() { ID = articleGroup.ArticleGroupID });

// Kategorie setzen (evtl. Hierachie beachten)
var category = unitOfWork.Categories.FindAll("Zubehör", 0, 100, null).Items.First(); // GET api/categories
article.Categories = new List<EntityReference>();
article.Categories.Add(new EntityReference() { ID = category.CategoryID });

// Texte hinzufügen
var text = new ArticleText();
article.Texts = new List<ArticleText>();
article.Texts.Add(text);
text.Type = TextType.BulletPoints;
text.Title = "Kaufargumente";
text.Value = "	* frosthart * duftend * wintergrün * Kübel geeignet";

// Verfügbarkeiten
var timePeriod = new TimePeriod();
article.Available = new List<TimePeriod>();
article.Available.Add(timePeriod);
timePeriod.FromCW = 10; // Kalendarwoche (von)
timePeriod.ToCW = 20; // Kalendarwoche (bis)
timePeriod.StockQuantity = 100; // Lagerbestand

// Varianten (Artikelnummern) hinzufügen
var articleKey = new ArticleKey();
article.Keys = new List<ArticleKey>();
article.Keys.Add(articleKey);

articleKey.Value = "47811"; // Artikelnummer
articleKey.Info = "C/  50 - 60";
articleKey.AvailableForClickAndCollect = true; // Click & Collect
articleKey.AvailableForRadiusDelivery = true; // Liefern
articleKey.AvailableForShipping = true; // Versenden
articleKey.PackingSize = 20; // VE
articleKey.StockQuantity = 10; // Bestand
articleKey.Available.Add(timePeriod);

// Steuersatz
var countries = unitOfWork.Countries.FindAll(null, 0, 100, null);
var germanySummary = countries.Items.Single(m => m.ISO == "DE");
var germany = unitOfWork.Countries.Get(germanySummary.CountryID);

var taxRate = germany.TaxRates.Single(m => m.Percent == 19); // GET api/countries
articleKey.TaxRate = new EntityReference() { ID = taxRate.TaxRateID };


// Preise
var currencies = unitOfWork.Currencies.FindAll(null, 0, 100, null);
var euro = currencies.Items.Single(m => m.NameShort == "EUR");

var articleKeyPrice = new ArticleKeyPrice();
articleKey.Prices = new List<ArticleKeyPrice>();
articleKey.Prices.Add(articleKeyPrice);
articleKeyPrice.Price = 17; // Preis
articleKeyPrice.PriceOld = 25; // Streichpreis
articleKeyPrice.PriceUnitAmount = 10; // pro 10
articleKeyPrice.ValueUnitType = PriceUnitType.Liter; // Liter
articleKeyPrice.Quantity = 1; // Ab Stückzahl
articleKeyPrice.Currency = new EntityReference() { ID = euro.CurrencyID };
articleKeyPrice.TaxIncluded = true; // Mwst. inkl?
articleKeyPrice.PriceNet = true; // Netto - Preis (keine Rabatte)

var picture = unitOfWork.Pictures.Upload(@"c:\temp\ATT00001.png");
articleKey.Photos = new List<ArticleKeyPhoto>();
articleKey.Photos.Add(new ArticleKeyPhoto()
{
    Picture = new PictureEntityReference(picture.FileID)
});

var summary = unitOfWork.Articles.Create(article, true);  // POST api/articles/create
Console.WriteLine("Artikel wurde angelegt. ID = " + summary.ArticleID);var article = new Article();

article.Name = "Acer Palmatum Bloodgood";
article.Name2 = "Fächerahorn Bloodgood";
article.Description = "Dies ist eine lange Beschreibung";
article.ShortDescription = "Dies ist eine kurze Beschreibung";

// Warengruppe setzen (evtl. Hierachie beachten)
var articleGroup = unitOfWork.ArticleGroups.FindAll("Pflanzen", 0, 100, null).Items.First(); // GET api/articlegroups
article.ArticleGroups = new List<EntityReference>();
article.ArticleGroups.Add(new EntityReference() { ID = articleGroup.ArticleGroupID });

// Kategorie setzen (evtl. Hierachie beachten)
var category = unitOfWork.Categories.FindAll("Zubehör", 0, 100, null).Items.First(); // GET api/categories
article.Categories = new List<EntityReference>();
article.Categories.Add(new EntityReference() { ID = category.CategoryID });

// Texte hinzufügen
var text = new ArticleText();
article.Texts = new List<ArticleText>();
article.Texts.Add(text);
text.Type = TextType.BulletPoints;
text.Title = "Kaufargumente";
text.Value = "	* frosthart * duftend * wintergrün * Kübel geeignet";

// Verfügbarkeiten
var timePeriod = new TimePeriod();
article.Available = new List<TimePeriod>();
article.Available.Add(timePeriod);
timePeriod.FromCW = 10; // Kalendarwoche (von)
timePeriod.ToCW = 20; // Kalendarwoche (bis)
timePeriod.StockQuantity = 100; // Lagerbestand

// Varianten (Artikelnummern) hinzufügen
var articleKey = new ArticleKey();
article.Keys = new List<ArticleKey>();
article.Keys.Add(articleKey);

articleKey.Value = "47811"; // Artikelnummer
articleKey.Info = "C/  50 - 60";
articleKey.AvailableForClickAndCollect = true; // Click & Collect
articleKey.AvailableForRadiusDelivery = true; // Liefern
articleKey.AvailableForShipping = true; // Versenden
articleKey.PackingSize = 20; // VE
articleKey.StockQuantity = 10; // Bestand
articleKey.Available.Add(timePeriod);

// Steuersatz
var countries = unitOfWork.Countries.FindAll(null, 0, 100, null);
var germanySummary = countries.Items.Single(m => m.ISO == "DE");
var germany = unitOfWork.Countries.Get(germanySummary.CountryID);

var taxRate = germany.TaxRates.Single(m => m.Percent == 19); // GET api/countries
articleKey.TaxRate = new EntityReference() { ID = taxRate.TaxRateID };


// Preise
var currencies = unitOfWork.Currencies.FindAll(null, 0, 100, null);
var euro = currencies.Items.Single(m => m.NameShort == "EUR");

var articleKeyPrice = new ArticleKeyPrice();
articleKey.Prices = new List<ArticleKeyPrice>();
articleKey.Prices.Add(articleKeyPrice);
articleKeyPrice.Price = 17; // Preis
articleKeyPrice.PriceOld = 25; // Streichpreis
articleKeyPrice.PriceUnitAmount = 10; // pro 10
articleKeyPrice.ValueUnitType = PriceUnitType.Liter; // Liter
articleKeyPrice.Quantity = 1; // Ab Stückzahl
articleKeyPrice.Currency = new EntityReference() { ID = euro.CurrencyID };
articleKeyPrice.TaxIncluded = true; // Mwst. inkl?
articleKeyPrice.PriceNet = true; // Netto - Preis (keine Rabatte)

var picture = unitOfWork.Pictures.Upload(@"c:\temp\ATT00001.png");
articleKey.Photos = new List<ArticleKeyPhoto>();
articleKey.Photos.Add(new ArticleKeyPhoto()
{
    Picture = new PictureEntityReference(picture.FileID)
});

var summary = unitOfWork.Articles.Create(article, true);  // POST api/articles/create
Console.WriteLine("Artikel wurde angelegt. ID = " + summary.ArticleID);
```

## Add channel specific article numbers

This example shows how the channel-specific article numbers are added to the article as part of the article master data.

```csharp
    var channel = unitOfWork.Channels.Get(1);
    var articleKeyChannel = new ArticleKeyChannel();
    articleKeyChannel.Channel = new EntityReference(channel.ChannelID);
    articleKeyChannel.Number = "abc";
    articleKey.Channels.Add(articleKeyChannel);
```

## Transfer article movement data

This example shows how the item movement data is transferred.

```csharp
var transactions = new List<ArticleTransactionArgs>();
var transaction = new ArticleTransactionArgs();
transaction.External_Key = "abc";
transaction.StockQuantity = 100; // Bestand
transaction.Prices = new List<ArticleTransactionPrice>();
transaction.Prices.Add(new ArticleTransactionPrice() { Quantity = 1, Price = 9.99 });
transactions.Add(transaction);

unitOfWork.Articles.Transactions(transactions.ToArray());  // POST api/articles/transaction
```

# orders

This area describes how to query new orders. 

## Query orders

This example shows how to query orders. As a result, a summary of the orders with the most relevant data is returned.

```csharp
    // Wir holen die Bestellungen nach OrderID absteigend sortiert
    // damit wir die neueste zuerst und danach die anderen bekommen
    var orders = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "OrderID desc", new GS.OmniChannelSystem.Rest.SDK.Filters.Orders()).Items; // GET api/orders/all

    // Geänderte Bestellungen (inkl. neu angelegte abfragen)
    // var ordersByModified = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "ModifiedOrCreatedOn").Items; // GET api/orders/all

```

## Query order

This example shows how to query a specific order. As a result, a complete order with all available data is returned.

```csharp
    var order = unitOfWork.Orders.Get(summary.OrderID); // GET api/orders/{id}

    Console.WriteLine("Auftragsnummer:" + order.OrderID);
    Console.WriteLine("Datum:" + order.CreatedOn.ToShortDateString());

    var owner = unitOfWork.Members.Get(order.Owner.ID); // GET api/members/{id}
    Console.WriteLine("Kunde:" + owner.MainContact.Company);

    Console.WriteLine("Rechnungsadresse:" + order.InvoiceAddress.Contact.Company + " " + order.InvoiceAddress.Address.Street + " " + order.InvoiceAddress.Address.HouseNumber);
    if (order.ShippingAddress != null)
        Console.WriteLine("Lieferadresse:" + order.ShippingAddress.Contact.Company + " " + order.ShippingAddress.Address.Street + " " + order.ShippingAddress.Address.HouseNumber);

    if (order.PaymentMethod != null)
    {
        var paymentMethod = unitOfWork.PaymentMethods.Get(order.PaymentMethod.ID); // GET api/paymentmethods/{id}
        Console.WriteLine("Bezahlart:" + paymentMethod.Name);
    }

    if (order.ShippingMethod != null)
    {
        var shippingMethod = unitOfWork.ShippingMethods.Get(order.ShippingMethod.ID); // GET api/shippingmethods/{id}
        Console.WriteLine("Versandart:" + shippingMethod.Name);
    }

    // Positionen
    foreach (var position in order.Items)
    {
        var article = unitOfWork.Articles.Get(position.Article.ID); // GET api/articles/{id}
        var articleKey = article.Keys.SingleOrDefault(m => m.ArticleKeyID == position.ArticleKey.ID);

        Console.WriteLine("Artikel:" + article.Name + " / " + article.Name2);
        Console.WriteLine("Artikelnummer:" + articleKey.Value);
        Console.WriteLine("Abwicklung:" + position.TransactionType); // CLick&Collect, Versenden u.s.w.
        Console.WriteLine("Menge:" + position.Quantity);
        Console.WriteLine("Einzelpreis:" + position.Price);
        Console.WriteLine("Gesamtpreis:" + position.TotalCosts);
        Console.WriteLine("Bestätigt:" + (position.IsConfirmed == true ? "Ja" : "Nein"));

        // Gutscheine gekauft ?
        if(position.Vouchers!=null && position.Vouchers.Any())
        {
            foreach (var voucherReference in position.Vouchers)
            {
                var voucher = unitOfWork.Vouchers.Get(voucherReference.ID);
                Console.WriteLine("Gutschein: " + voucher.Name);
                Console.WriteLine("Betrag: " + voucher.Price);
                Console.WriteLine("Guthaben: " + voucher.Remaining);
            }
        }
    }

    Console.WriteLine("Zahlungen:");
    foreach (var payment in order.Payments)
    {
        Console.WriteLine("* Preis: " + payment.Price);
        Console.WriteLine("* Info: " + payment.Info);
        Console.WriteLine("* Zahlart: " + payment.PaymentMethod != null ? payment.PaymentMethod.ID.ToString() : "--");

        // Mit Gutschein gezahlt?
        if (payment.VoucherCode != null)
        {
            var voucher = unitOfWork.Vouchers.Get(payment.VoucherCode.Voucher.ID);
            Console.WriteLine("Gutschein: " + voucher.Name);
            Console.WriteLine("Betrag: " + voucher.Price);
            Console.WriteLine("Guthaben: " + voucher.Remaining);
            Console.WriteLine("* Gutschein: " + payment.VoucherCode != null ? payment.VoucherCode.Voucher.ID.ToString() : "--");
        }
    }

```

## Update order status

This example shows how to update the order status.

## confirm order

This example shows how to mark the order status as confirmed. This function can also be used to confirm part of the order.

```csharp
Console.WriteLine("Auftrag wird bestätigt: " + order.OrderID);
Console.WriteLine();
var args = new OrderTransactionArgs();
args.Status = OrderTransactionStatusType.Confirmed;
args.StatusOn = DateTime.Now;
args.Message = "Nachricht zur Bestätigung";

var articles = new List<OrderTransactionArticle>();

var article = new OrderTransactionArticle();
article.OrderItemID = order.Items.First().OrderItemID;
// false = nicht bestätigt
article.Confirmed = true; 
// Minderstückzahl bestätigen ?
// null = nein ansonsten wieviel Stück bestätigt werden sollen
article.QuantityConfirmed = null; // St
articles.Add(article);

args.Articles = articles.ToArray();
var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);

```

## cancel order

This example shows how to cancel the entire order.

```csharp
Console.WriteLine("Auftrag wird storniert: " + order.OrderID);
Console.WriteLine();
var args = new OrderTransactionArgs();
args.Status = OrderTransactionStatusType.Cancelled;
args.StatusOn = DateTime.Now;
args.Message = "Nachricht zur Stornierung";

var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);
```

## Create shipping labels (optional)

This example shows how to create shipping labels.

```csharp
var model = new CreateShipmentOrderArgs();
model.Quantity = 2;
model.WeightsInKg = new double[] { 3, 6 };

var newShipmentOrderSummary = unitOfWork.ShipmentOrders.CreateFastForOrder(order.OrderID, transaction.OrderTransactionID, model);
var shipmentOrder = unitOfWork.ShipmentOrders.Get(newShipmentOrderSummary.ShipmentOrderID);
if(shipmentOrder.Items.Any(m => m.HasShipmentLabel))
{
    foreach (var item in shipmentOrder.Items.Where(m => m.HasShipmentLabel))
    {
        var pdf = unitOfWork.ShipmentOrders.GetLabel(item.ShipmentOrderItemID, ShipmentLabelType.Shipment);
        Process.Start(pdf);
    }
}
```

## Create delivery note

This example shows how to create a delivery note.

```csharp
var transaction = order.Transactions.First();
var pdf = unitOfWork.Documents.GetForOrder(order.OrderID, transaction.OrderTransactionID, DocumentationType.DeliverySlip);
Process.Start(pdf);
```

## send order

This example shows how to mark the order status of a partial order as shipped.

```csharp
var transaction = order.Transactions.First();
Console.WriteLine("Auftrag wird versendet: " + order.OrderID);
Console.WriteLine();
var args = new OrderTransactionArgs();
args.Status = OrderTransactionStatusType.Delivered;
args.StatusOn = DateTime.Now;
args.TrackAndTraceID = new string[] {"123456","789012" };
args.TrackAndTraceURL = "https://dhl.tracking.de/?piececode=";
args.OrderTransactionID = transaction.OrderTransactionID;
var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);

```

## complete order

This example shows how to mark the order as completed.

```csharp
 Console.WriteLine("Auftrag wird erledigt: " + order.OrderID);
Console.WriteLine();
var args = new OrderTransactionArgs();
args.Status = OrderTransactionStatusType.Ready;
args.InvoiceFilename = "Rechung.pdf";
args.InvoiceMimeType = "application/pdf";
// Base 64 encodierte Data URI mit dem Pdf
args.InvoiceURI = "data:application/pdf;base64,jhakuzbsahdga676f3jhgbsa5as6g";

var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);

```

## Embed order management (optional)

This example shows how to call up the order management.

```csharp
var dialog = unitOfWork.Articles.Dialog(article.ArticleID);
Console.WriteLine("Titel: " + dialog.Title);
Console.WriteLine("Url: " + dialog.Url);
Console.WriteLine("Breite: " + dialog.Width);
Console.WriteLine("Height: " + dialog.Height);

Console.WriteLine();
Console.Write("Broswer jetzt aufrufen (j/n)? ");
if (Console.ReadLine() == "j")
    Process.Start(dialog.Url);

```

# Messages 

Messages are work in Progress and will be defined later

## query messages

## Processing notifications

## Generate message

### Return delivery has been received

### Returns inspection passed

### Returns inspection failed

### order delivered 

### received pick-up order

### Confirmation of delivery date

### Change of delivery date

### customers not reached

### customers not found