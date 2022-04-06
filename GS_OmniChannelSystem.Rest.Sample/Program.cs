
using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Client;
using GS.OmniChannelSystem.Rest.SDK.Extensions;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_PflanzenCMS.Net.Rest.Sample
{
    class Program
    {
        static void createMember(ContextUOW unitOfWork)
        {
            var currencyEUR = unitOfWork.Currencies.Get(1); // EUR ?? 
            var roleMember = unitOfWork.Roles.Get(1); // Customer

            User user = new User();
            Member member = new Member();
            member.External_Key = "abc";
            member.Currency = new EntityReference(currencyEUR.CurrencyID);

            member.MainContact = new Contact();
            member.MainContact.Apellation = Apellation.Mr;
            member.MainContact.FirstName = "Jon";
            member.MainContact.LastName = "Doe";
            member.MainContact.EMail = "jon@doe.com";
            member.Roles = new List<EntityReference>();
            member.Roles.Add(new EntityReference(unitOfWork.Roles.GetByKey("member").RoleID));

            var contact = new Contact();
            contact.Apellation = Apellation.Mr;
            contact.FirstName = "Jon";
            contact.LastName = "Doe";

            var address = new Address();
            address.Street = "Street";
            address.Zip = "26802";

            member.Adresses.Add(address);

            var contactAddress = new ContactAddress();
            contactAddress.Type = AddressType.Main;
            contactAddress.Contact = contact;
            contactAddress.Address = address;
            member.ContactAddresses.Add(contactAddress);

            user.Contact = member.MainContact;
            user.EMail = "jondoe@test.de!";
            user.Login = user.EMail;
            user.Password = "password";
            user.AutomaticPassword = true;
            user.Roles.Add(new EntityReference(unitOfWork.Roles.GetByKey("member").RoleID));
            member.CustomerGroup = new EntityReference(unitOfWork.CustomerGroups.GetByKey("standard").CustomerGroupID);

            member.Users.Add(user);

            unitOfWork.Members.Create(member);
        }      

        static void createArticle(ContextUOW unitOfWork)
        {
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

            // Kanal Artiklenummern
            var channel = unitOfWork.Channels.Get(1);
            var articleKeyChannel = new ArticleKeyChannel();
            articleKeyChannel.Channel = new EntityReference(channel.ChannelID);
            articleKeyChannel.Number = "abc";
            articleKey.Channels.Add(articleKeyChannel);

            var summary = unitOfWork.Articles.Create(article, true);  // POST api/articles/create
            Console.WriteLine("Artikel wurde angelegt. ID = " + summary.ArticleID);

        }

        static void createOrder(ContextUOW unitOfWork)
        {
            var args = new CreateOrderArgs();

            var currencies = unitOfWork.Currencies.FindAll(null, 0, 100, null); // GET api/currencies
            var euro = currencies.Items.Single(m => m.NameShort == "EUR");

            var countries = unitOfWork.Countries.FindAll(null, 0, 100, null); // GET api/countries
            var germanySummary = countries.Items.Single(m => m.ISO == "DE");
            var germany = unitOfWork.Countries.Get(germanySummary.CountryID);
            var taxRate7 = germany.TaxRates.Single(m => m.Percent == 7); 

            // Rechnungsadresse - Adresse
            args.InvoiceAddress = new CreateOrderArgs.ContactAddress();
            args.InvoiceAddress.Type = AddressType.Main;
            args.InvoiceAddress.Address = new CreateOrderArgs.Address();
            args.InvoiceAddress.Address.Street = "Musterstraße";
            args.InvoiceAddress.Address.HouseNumber = "47a";
            args.InvoiceAddress.Address.Zip = "26777";
            args.InvoiceAddress.Address.City = "Musterstadt";
            args.InvoiceAddress.Address.Postbox = "711";
            args.InvoiceAddress.Address.Country = "DE";
            args.InvoiceAddress.Address.Type = AddressType.Main;
            args.InvoiceAddress.Address.Info = "Oberste Etage";

            // Rechnungsadresse - Kontakt
            args.InvoiceAddress.Contact = new CreateOrderArgs.Contact();
            args.InvoiceAddress.Contact.Apellation = Apellation.Mr;
            args.InvoiceAddress.Contact.FirstName = "Max";
            args.InvoiceAddress.Contact.LastName = "Mustermann";
            args.InvoiceAddress.Contact.Phone = "0491/2201";
            args.InvoiceAddress.Contact.Mobile = "0176/2201";
            args.InvoiceAddress.Contact.Fax = "0491/2201";
            args.InvoiceAddress.Contact.Homepage = "http://mustermann.de";
            args.InvoiceAddress.Contact.EMail = "info@mustermann.de";
            args.InvoiceAddress.Contact.Company = "Musterfirma";
            args.InvoiceAddress.Contact.Language = "de-DE";

            // Lieferadresse = Rechnungsadresse 
            // Könnte aber auch wie oben getrennt sein
            args.ShippingAddress = args.InvoiceAddress;
            args.Notes = "Dies ist eine Bemerkung";

            // Bezahlart
            var paymentMethod = unitOfWork.PaymentMethods.FindAll(null, 0, 1, null).Items.First(); // GET api/paymentmethods
            args.PaymentMethodID = paymentMethod.PaymentMethodID;

            // Versandart
            var shippingMethod = unitOfWork.ShippingMethods.FindAll(null, 0, 1, null).Items.First(); // GET api/shippingmethods
            args.ShippingMethodID = shippingMethod.ShippingMethodID;

            // Minimum Alter (nur für Alkohol)
            args.MinimumAge = null; // 18 / 16

            // Währung
            args.Currency = "EUR";

            // Gewünschtes Lieferdatum
            args.WantedShippingDate = DateTime.Now;

            // Status auf erledigt setzen (z.B. bei alten Bestellungen)
            // dadurch würde die Bestellung direkt als erledigt markiert
            // args.OrderStatus = OrderStatusType.Ready;

            var items = new List<OrderItem>();
            var item = new OrderItem();
            item.Date = DateTime.Now;
            item.DeliveryDate = DateTime.Now.AddDays(3);
            item.Info = "Acer Palmatum Bloodgood";
            item.Info2 = "Fächerahorn Bloodgood";
            item.Info3 = "T10";
            item.ArticleKey = new ArticleKeyEntityReference() { External_Key = "4711" };
            item.Notes = "Bemerkungen zum Artikel";
            item.Type = ItemType.ArticleKey;
            item.Currency = new EntityReference(euro.CurrencyID);
            item.Quantity = 1;
            item.Position = 1;
            item.TaxRate = new TaxRateEntityReference(taxRate7.TaxRateID);

            var summary = unitOfWork.Orders.Create(args);  // POST api/orders/create
            Console.WriteLine("Bestellung wurde angelegt. ID = " + summary.OrderID);
        }

        static void createCashDesk(ContextUOW unitOfWork)
        {
            var args = new CreateCashdeskArgs();

            var currencies = unitOfWork.Currencies.FindAll(null, 0, 100, null); // GET api/currencies
            var euro = currencies.Items.Single(m => m.NameShort == "EUR");

            var countries = unitOfWork.Countries.FindAll(null, 0, 100, null); // GET api/countries
            var germanySummary = countries.Items.Single(m => m.ISO == "DE");
            var germany = unitOfWork.Countries.Get(germanySummary.CountryID);
            var taxRate7 = germany.TaxRates.Single(m => m.Percent == 7);

            // Bezahlart
            var paymentMethod = unitOfWork.PaymentMethods.FindAll(null, 0, 1, null).Items.First(); // GET api/paymentmethods
            args.PaymentMethodID = paymentMethod.PaymentMethodID;

            // Währung
            args.Currency = "EUR";

            // Kunde
            args.OwnerMemberID = 1;

            var items = new List<CreateCashdeskArgs.OrderItem>();
            var item = new CreateCashdeskArgs.OrderItem();
            item.Date = DateTime.Now;
            item.Info = "Acer Palmatum Bloodgood";
            item.ArticleKey = "4711";
            item.Notes = "Bemerkungen zum Artikel";
            item.Type = ItemType.ArticleKey;
            item.Currency = "EUR";
            item.Quantity = 1;
            item.Position = 1;
            item.TaxRate = 19.0;
            items.Add(item);

            args.Items = items;
            var summary = unitOfWork.Orders.CreateCashDesk(args);  // POST api/orders/create
            Console.WriteLine("Bestellung wurde angelegt. ID = " + summary.OrderID);
        }

        static void getOrders(ContextUOW unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                // Wir holen die Bestellungen nach OrderID absteigend sortiert
                // damit wir die neueste zuerst und danach die anderen bekommen
                var orders = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "OrderID desc", new GS.OmniChannelSystem.Rest.SDK.Filters.Orders()).Items; // GET api/orders/all

                // Geänderte Bestellungen (inkl. neu angelegte abfragen)
                // var ordersByModified = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "ModifiedOrCreatedOn").Items; // GET api/orders/all

                Console.WriteLine("Seite: " + (pageIndex + 1));
                Console.WriteLine("(+) - Nächste Seite");
                Console.WriteLine("(-) - Vorherige Seite");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var orderSummary in orders)
                {
                    Console.WriteLine("(" + i + ") - Auftragsnummer " + orderSummary.OrderID + " vom " + orderSummary.CreatedOn.ToShortDateString());

                    i++;
                }

                Console.WriteLine();
                Console.Write("Auswahl: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "+":
                        pageIndex++;
                        Console.Clear();
                        break;
                    case "-":
                        pageIndex--;
                        Console.Clear();
                        break;
                    default:
                        if (!string.IsNullOrEmpty(selection))
                        {
                            Console.Clear();
                            getOrder(unitOfWork, orders.ElementAt(Convert.ToInt16(selection)));
                        }
                        break;

                }

            } while (selection == "+" || selection == "-");

        }

        static void getOrdersForStatusupdate(ContextUOW unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                // Wir holen die Bestellungen nach OrderID absteigend sortiert
                // damit wir die neueste zuerst und danach die anderen bekommen
                var orders = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "OrderID desc", new GS.OmniChannelSystem.Rest.SDK.Filters.Orders()).Items; // GET api/orders/all

                // Geänderte Bestellungen (inkl. neu angelegte abfragen)
                // var ordersByModified = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "ModifiedOrCreatedOn").Items; // GET api/orders/all

                Console.WriteLine("Seite: " + (pageIndex + 1));
                Console.WriteLine("(+) - Nächste Seite");
                Console.WriteLine("(-) - Vorherige Seite");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var orderSummary in orders)
                {
                    Console.WriteLine("(" + i + ") - Auftragsnummer " + orderSummary.OrderID + " vom " + orderSummary.CreatedOn.ToShortDateString());

                    i++;
                }

                Console.WriteLine();
                Console.Write("Auswahl: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "+":
                        pageIndex++;
                        Console.Clear();
                        break;
                    case "-":
                        pageIndex--;
                        Console.Clear();
                        break;
                    default:
                        if (!string.IsNullOrEmpty(selection))
                        {
                            Console.Clear();
                            updateOrderStatus(unitOfWork, orders.ElementAt(Convert.ToInt16(selection)));
                        }
                        break;

                }

            } while (selection == "+" || selection == "-");

        }

        static void getChainStores(ContextUOW unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                var chainStores = unitOfWork.ChainStores.FindAll(null, pageIndex, 10, null).Items; // GET api/orders/all

                Console.WriteLine("Seite: " + (pageIndex + 1));
                Console.WriteLine("(+) - Nächste Seite");
                Console.WriteLine("(-) - Vorherige Seite");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var chainStoreSummary in chainStores)
                {
                    Console.WriteLine("(" + i + ") - "+chainStoreSummary.Name);

                    i++;
                }

                Console.WriteLine();
                Console.Write("Auswahl: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "+":
                        pageIndex++;
                        Console.Clear();
                        break;
                    case "-":
                        pageIndex--;
                        Console.Clear();
                        break;
                    default:
                        if (!string.IsNullOrEmpty(selection))
                        {
                            Console.Clear();
                            getChainStore(unitOfWork, chainStores.ElementAt(Convert.ToInt16(selection)));
                        }
                        break;

                }

            } while (selection == "+" || selection == "-");

        }

        static void getMembers(ContextUOW unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                // Wir fragen die Kunden absteigend sortiert nach der MemberID ab
                // dadurch bekommen wir den zuletzt angelegten zuerst
                var members = unitOfWork.Members.FindAll(null, pageIndex, 10, "MemberID desc").Items; // GET api/orders/all

                Console.WriteLine("Seite: " + (pageIndex + 1));
                Console.WriteLine("(+) - Nächste Seite");
                Console.WriteLine("(-) - Vorherige Seite");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var memberSummary in members)
                {
                    Console.WriteLine("(" + i + ") - " + memberSummary.MainContact+", "+ memberSummary.MainAddress);

                    i++;
                }

                Console.WriteLine();
                Console.Write("Auswahl: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "+":
                        pageIndex++;
                        Console.Clear();
                        break;
                    case "-":
                        pageIndex--;
                        Console.Clear();
                        break;
                    default:
                        if (!string.IsNullOrEmpty(selection))
                        {
                            Console.Clear();
                            getMember(unitOfWork, members.ElementAt(Convert.ToInt16(selection)));
                        }
                        break;

                }

            } while (selection == "+" || selection == "-");

        }

        static void getOrder(ContextUOW unitOfWork, Order.Summary summary)
        {
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

            Console.WriteLine("Bitte wählen Sie eine Funktion:");
            Console.WriteLine("(1) - Aktualisieren");
            Console.WriteLine("(2) - Auftrag bestätigen");
            Console.WriteLine("(3) - Ersatzlieferung");
            Console.WriteLine("(4) - Auftrag stornieren");
            Console.WriteLine("(5) - Versandbestätigung");
            Console.WriteLine("(6) - Auftrag ist verspätet");
            Console.WriteLine("(7) - Auftrag erledigen");
            Console.WriteLine("(8) - Auftrag erstatten");
            Console.WriteLine("(9) - Auftrag splitten");
            Console.WriteLine("(A) - Auftragstatus auf Positionsebene aktualisieren");
            Console.WriteLine();
            Console.Write("Auswahl: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    updateOrder(unitOfWork, order);
                    break;
                case "2":
                    Console.Clear();
                    confirmOrder(unitOfWork, order);
                    break;
                case "3":
                    Console.Clear();
                    replaceOrder(unitOfWork, order);
                    break;
                case "4":
                    Console.Clear();
                    cancelOrder(unitOfWork, order);
                    break;
                case "5":
                    Console.Clear();
                    shipOrder(unitOfWork, order);
                    break;
                case "6":
                    Console.Clear();
                    delayOrder(unitOfWork, order);
                    break;
                case "7":
                    Console.Clear();
                    finishOrder(unitOfWork, order);
                    break;
                case "8":
                    Console.Clear();
                    refundOrder(unitOfWork, order);
                    break;
                case "9":
                    Console.Clear();
                    splitOrder(unitOfWork, order);
                    break;
                case "A":
                    Console.Clear();
                    updateOrderPositionStatus(unitOfWork);
                    break;
            }

        }

        static void updateOrderPositionStatusConfirm(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positionen:");            
            var positions = Console.ReadLine();
            Console.WriteLine();

            // Auftragskopf
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions)
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Auftragsposition
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Confirmed;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Auftrag wurde aktualisiert: " + result.Length + " Aktalisierungen");
        }

        static void updateOrderPositionStatusCancel(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positionen:");
            var positions = Console.ReadLine();
            Console.WriteLine();

            // Auftragskopf
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Auftragsposition
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Cancelled;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Auftrag wurde aktualisiert: " + result.Length + " Aktalisierungen");
        }

        static void updateOrderPositionReduceQuantity(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positionen:");
            var positions = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Anzahl:");
            var quantity = Console.ReadLine();
            Console.WriteLine();

            // Auftragskopf
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Auftragsposition
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity-Convert.ToInt16(quantity);
                positionTransaction.Status = OrderTransactionStatusType.Cancelled;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Auftrag wurde aktualisiert: " + result.Length + " Aktalisierungen");
        }

        static void updateOrderPositionStatusDeliver(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positionen:");
            var positions = Console.ReadLine();
            Console.WriteLine();

            // Auftragskopf
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Auftragsposition
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Delivered;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Auftrag wurde aktualisiert: " + result.Length + " Aktalisierungen");
        }

        static void updateOrderPositionStatusSplit(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positionen:");
            var positions = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Tage:");
            var days = Console.ReadLine();
            Console.WriteLine();

            // Auftragskopf
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Auftragsposition
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn.Value.AddDays(Convert.ToInt16(days));
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Confirmed;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Auftrag wurde aktualisiert: " + result.Length + " Aktalisierungen");
        }

        static void updateOrderStatus(ContextUOW unitOfWork, Order.Summary summary)
        {
            do
            {
                unitOfWork.Invalidate();
                var order = unitOfWork.Orders.Get(summary.OrderID); // GET api/orders/{id}

                Console.Clear();
                Console.WriteLine("Auftragsnummer:" + order.OrderID);
                Console.WriteLine("Datum:" + order.CreatedOn.ToShortDateString());
                Console.WriteLine("Status: " + order.Status);
                Console.WriteLine("Rechnungsadresse:" + order.InvoiceAddress.Contact.Company + " " + order.InvoiceAddress.Address.Street + " " + order.InvoiceAddress.Address.HouseNumber);
                if (order.ShippingAddress != null)
                    Console.WriteLine("Lieferadresse:" + order.ShippingAddress.Contact.Company + " " + order.ShippingAddress.Address.Street + " " + order.ShippingAddress.Address.HouseNumber);

                order = unitOfWork.Orders.Get(summary.OrderID); // GET api/orders/{id}

                Console.WriteLine();
                StringBuilder sb = new StringBuilder();
                sb.Append("Nr", 5);
                sb.Append("Artikel", 30);
                sb.Append("Best.", 5);
                sb.Append("Menge", 8);
                sb.Append("Preis", 8);
                sb.Append("Gesamt", 8);
                sb.Append("Intern", 60);
                Console.WriteLine(sb.ToString());

                // Positionen
                foreach (var position in order.Items)
                {
                    var transaction = order.Transactions.Single(m => m.OrderTransactionID == position.Transaction.ID);
                    sb.Clear();
                    sb.Append(position.Position.ToString(), 5);
                    sb.Append(position.Info, 30);
                    sb.Append(position.IsConfirmed == true ? "Ja" : position.Confirmed == null ? "??" : "Nein", 5);
                    sb.Append((position.QuantityConfirmed != null ? position.QuantityConfirmed+" statt " : "") + position.Quantity.ToString(), 8);
                    sb.Append(Math.Round(position.Price, 2).ToString(), 8);
                    sb.Append(Math.Round(position.TotalCosts, 2).ToString(), 8);
                    sb.Append(
                        "ID: " + position.OrderItemID+", "+
                        "S: " + position.Status+", "+ 
                        "A.: " + (position.AvailableOn != null ? position.AvailableOn.Value.ToShortDateString() : "--") +", "+ 
                        "Q: " + position.QuantityAvailable+", "+
                        "T: "+ transaction.Status+"-"+(transaction.AvailableOn != null ? transaction.AvailableOn.Value.ToShortDateString() : "--")
                        , 60);
                    Console.WriteLine(sb.ToString());
                }

                Console.WriteLine();
                Console.WriteLine("Bitte wählen Sie eine Funktion:");
                Console.WriteLine("(0) - Stückzahl verringern");
                Console.WriteLine("(1) - Splitten");
                Console.WriteLine("(2) - Bestätigen");
                Console.WriteLine("(3) - Liefern");
                Console.WriteLine("(4) - Stornieren");
                Console.WriteLine("(X) - Beenden");
                Console.WriteLine();
                Console.Write("Auswahl: ");
                switch (Console.ReadLine())
                {
                    case "2":
                        updateOrderPositionStatusConfirm(unitOfWork, order);
                        break;
                    case "1":
                        updateOrderPositionStatusSplit(unitOfWork, order);
                        break;
                    case "3":
                        updateOrderPositionStatusDeliver(unitOfWork, order);
                        break;
                    case "4":
                        updateOrderPositionStatusCancel(unitOfWork, order);
                        break;
                    case "0":
                        updateOrderPositionReduceQuantity(unitOfWork, order);
                        break;
                    case "x":
                    case "X":
                        return;
                }
            } while (true);
        }

        static void getChainStore(ContextUOW unitOfWork, ChainStore.Summary summary)
        {
            var chainStore = unitOfWork.ChainStores.Get(summary.ChainStoreID); // GET api/chainstores/{id}

            Console.WriteLine("Name:" + chainStore.Name);
            Console.WriteLine("Name 2:" + chainStore.Name2);
            

            Console.WriteLine("Adresse:" + (chainStore.Contact!=null ? chainStore.Contact.Company : "") + " " + chainStore.Address.Street + " " + chainStore.Address.HouseNumber);
        }

        static void getMember(ContextUOW unitOfWork, Member.Summary summary)
        {
            var member = unitOfWork.Members.Get(summary.MemberID); // GET api/chainstores/{id}

            Console.WriteLine("Firma:" + member.MainContact.Company);
            Console.WriteLine("Kundennummer:" + member.Number);

            Console.WriteLine("Bitte wählen Sie eine Funktion:");
            Console.WriteLine("(1) - Aktualisieren");
            Console.WriteLine();
            Console.Write("Auswahl: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    updateMember(unitOfWork, member);
                    break;
            }
        }

        static void deleteArticle(ContextUOW unitOfWork, Article article, bool permanent)
        {
            unitOfWork.Articles.Delete(article.ArticleID, permanent);

            // Permanentes löschen (Standard ist logisch)
            // Wird nur für bestimmte Entitäten unterstützt
            // unitOfWork.Articles.Delete(article.ArticleID, true);

            Console.WriteLine("Artikel wurde gelöscht");
        }

        static void setExternal_Key(ContextUOW unitOfWork, Article article)
        {
            Console.WriteLine("Alle Entitäten haben ein Feld External_Key in das die eigene ID");
            Console.WriteLine("der Warenwirtschaft hinterlegt werden keann.");
            Console.WriteLine("auf Basis dieses External_Keys kann dann zugegriffen werden:");
            Console.WriteLine();
            Console.Write("External_Key: ");
            article.External_Key = Console.ReadLine();
            var newArticle = unitOfWork.Articles.Update(article.ArticleID, article, new string[] { "External_Key" } /* optional */);
            Console.WriteLine("Artikel wurde aktualisiert: " + newArticle.External_Key);
        }

        static void updateArticle_enUS(ContextUOW unitOfWork, Article article)
        {
            using (var unitOfWork_enUS = unitOfWork.Clone("en-US"))
            {
                var enUsArticle = unitOfWork_enUS.Articles.Get(article.ArticleID, new string[] { "Name" });

                Console.WriteLine("Name: " + enUsArticle.Name);
                Console.WriteLine();
                Console.Write("Neuer Name: ");
                
                enUsArticle.Name = Console.ReadLine();
                unitOfWork_enUS.Articles.Update(enUsArticle.ArticleID, enUsArticle, new string[] { "Name" } /* optional */);
                Console.WriteLine("Artikel wurde aktualisiert: " + enUsArticle.Name);
            }
        }

        static void updateArticle(ContextUOW unitOfWork, Article article)
        {
            Console.WriteLine("Name 2: " + article.Name2);
            Console.WriteLine();
            Console.Write("Neuer Name 2: ");
            article.Name2 = Console.ReadLine();
            var newArticle = unitOfWork.Articles.Update(article.ArticleID, article, new string[] { "Name2" } /* optional */);
            Console.WriteLine("Artikel wurde aktualisiert: " + newArticle.Name2);
        }

        static void updateMember(ContextUOW unitOfWork, Member member)
        {
            Console.WriteLine("Kundennummer: " + member.Number);
            Console.WriteLine();
            Console.Write("Neue Nummer: ");
            member.Number = Console.ReadLine();
            var newMember = unitOfWork.Members.Update(member.MemberID, member); // PUT api/members
            Console.WriteLine("Kunde wurde aktualisiert: " + newMember.Number);
        }

        static void updateOrder(ContextUOW unitOfWork, Order order)
        {
            Console.WriteLine("Notiz: " + order.Notes);
            Console.WriteLine();
            Console.Write("Neue Notiz: ");
            order.Notes = Console.ReadLine();
            var newOrder = unitOfWork.Orders.Update(order.OrderID, order, new string[] { "Notes" } /* optional */);
            Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);
        }

        static void confirmOrder(ContextUOW unitOfWork, Order order)
        {
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
        }

        static void updateOrderPositionStatus(ContextUOW unitOfWork)
        {
            Console.WriteLine("Auftrag wird auf Positionsebene aktualisiert");
            Console.WriteLine();

            // Auftragskopf
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            // Tracking URL
            orderTransaction.TrackAndTraceURL = "http://dpd.com/?code=";
            orderTransaction.TrackAndTraceID = new string[] { "abc", "def"};
            // Rechnung
            orderTransaction.InvoiceFilename = "Rechung.pdf";
            orderTransaction.InvoiceMimeType = "application/pdf";
            // Base 64 encodierte Data URI mit dem Pdf
            orderTransaction.InvoiceURI = "data:application/pdf;base64,jhakuzbsahdga676f3jhgbsa5as6g";

            // Auftragsposition
            var positionTransaction = new OrderTransactionPosition();
            // Positionsnummer
            positionTransaction.OrderItemID = 123;
            // Artikel
            positionTransaction.External_Key = "abcdef";
            // Menge
            positionTransaction.Quantity = 10;
            // Lieferdatum
            positionTransaction.AvailableOn = new DateTime(2020, 12, 24);
            // Geliefert
            positionTransaction.Status = OrderTransactionStatusType.Delivered;
            // Bestätigt
            positionTransaction.Status = OrderTransactionStatusType.Confirmed;
            // Storniert
            positionTransaction.Status = OrderTransactionStatusType.Cancelled;
            orderTransaction.Positions.Add(positionTransaction);

            var result = unitOfWork.Orders.UpdatePositions(44, orderTransaction);
            Console.WriteLine("Auftrag wurde aktualisiert: " + result.Length+" Aktalisierungen");
        }

        static void splitOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Auftrag wird gesplittet: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Action = OrderTransactionActionType.Split;
            args.OrderTransactionID = transaction.OrderTransactionID;

            // Neuer Termin
            args.EarliestShippingDate = DateTime.Now.AddDays(14);

            var articles = new List<OrderTransactionArticle>();
            var article = new OrderTransactionArticle();
            article.OrderItemID = order.Items.First().OrderItemID;
            articles.Add(article);

            args.Articles = articles.ToArray();
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Auftrag wurde gesplittet: " + order.Notes);
        }

        static void cancelOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Auftrag wird storniert: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Status = OrderTransactionStatusType.Cancelled;
            args.StatusOn = DateTime.Now;
            args.OrderTransactionID = transaction.OrderTransactionID;
            args.Message = "Nachricht zur Stornierung";

            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);
        }

        static void shipOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            // Versandetikett anlegen
            var model = new CreateShipmentOrderArgs();
            model.Quantity = 1;
            model.WeightsInKg = new double[] { 3 };
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
        }

        static void replaceOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Auftrag wird ersetzt: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Action = OrderTransactionActionType.Replace;

            var replacements = new List<OrderTransactionArticle>();

            var replacement = new OrderTransactionArticle();
            replacement.OrderItemID = order.Items.First().OrderItemID;
            replacement.Replacement_External_Key = "4711";
            replacements.Add(replacement);

            args.Articles = replacements.ToArray();
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);
        }

        static void refundOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Auftrag wird erstattet: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Action = OrderTransactionActionType.Refund;

            var replacements = new List<OrderTransactionArticle>();

            var replacement = new OrderTransactionArticle();
            replacement.OrderItemID = order.Items.First().OrderItemID;
            replacements.Add(replacement);

            args.Articles = replacements.ToArray();
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);
        }

        static void delayOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Auftrag wird verspätet: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Action = OrderTransactionActionType.Delay;
            args.EarliestShippingDate = DateTime.Now.AddDays(7);
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Auftrag wurde aktualisiert: " + order.Notes);
        }

        static void finishOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

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
        }

        static void startArticleDialog(ContextUOW unitOfWork, Article article)
        {
            var dialog = unitOfWork.Articles.Dialog(article.ArticleID);
            Console.WriteLine("Titel: " + dialog.Title);
            Console.WriteLine("Url: " + dialog.Url);
            Console.WriteLine("Breite: " + dialog.Width);
            Console.WriteLine("Height: " + dialog.Height);

            Console.WriteLine();
            Console.Write("Broswer jetzt aufrufen (j/n)? ");
            if (Console.ReadLine() == "j")
                Process.Start(dialog.Url);
        }

        static void startOrdersDialog(ContextUOW unitOfWork)
        {
            var dialog = unitOfWork.Orders.Dialog();
            Console.WriteLine("Titel: " + dialog.Title);
            Console.WriteLine("Url: " + dialog.Url);
            Console.WriteLine("Breite: " + dialog.Width);
            Console.WriteLine("Height: " + dialog.Height);

            Console.WriteLine();
            Console.Write("Broswer jetzt aufrufen (j/n)? ");
            if (Console.ReadLine() == "j")
                Process.Start(dialog.Url);
        }

        static void patchArticles(ContextUOW unitOfWork)
        {
            var patches = new ArticleKey.Patch[]
            {
                new ArticleKey.Patch()
                {
                    External_Key = "PAT#4711",
                    External_RowVersion = "abd",
                    Available = new List<TimePeriod>()
                    {
                        new TimePeriod(1,20,100),
                        new TimePeriod(20,30,100),
                    }
                }
            };
            var job = unitOfWork.Articles.CreatePatches(patches, "PAT", "available", true);
            Console.WriteLine("Patchupdate gestartet: " + job.Name+", "+job.JobID);
            Console.ReadLine();
        }

        static void createAvailabilities(ContextUOW unitOfWork)
        {
            // Erstes Paket für das Update
            var availabilities1 = new Availability[]
            {
                new Availability()
                {
                    ID  = 1,
                    ArticleID = 2,
                    ArticleKeyID = 3,
                    From = DateTime.Now,
                    To = DateTime.Now.AddMonths(1),
                    StockQuantity = 100
                }
            };
            var job = unitOfWork.Articles.CreateAvailabilities(
                availabilities1, // Verfügbarkeiten
                true,            // Komplettupdate (vorher löschen)
                false            // Update ist vollständig?
            );
            Console.WriteLine("Patchupdate gestartet: " + job.Name + ", " + job.JobID);

            // Zweites Paket
            var availabilities2 = new Availability[]
            {
                new Availability()
                {
                    ID  = 1,
                    ArticleID = 2,
                    ArticleKeyID = 3,
                    From = DateTime.Now,
                    To = DateTime.Now.AddMonths(1),
                    StockQuantity = 100
                }
            };
            unitOfWork.Articles.CreateAvailabilities(
                job.JobID,
                availabilities1, // Verfügbarkeiten
                true,            // Komplettupdate (vorher löschen)
                true            // Update ist vollständig?
            );
            Console.ReadLine();
        }

        static void getArticleByExternal_Key(ContextUOW unitOfWork)
        {
            Console.WriteLine("Alle Entitäten haben ein Feld External_Key in das die eigene ID");
            Console.WriteLine("der Warenwirtschaft hinterlegt werden kann.");
            Console.WriteLine("Auf Basis dieses External_Keys kann dann zugegriffen werden.");
            Console.WriteLine();
            Console.Write("External_Key: ");
            var external_key = Console.ReadLine();

            Console.Clear();
            // Nur die ArticleID abfragen damit die Abfrage schneller geht
            var article = unitOfWork.Articles.Get(external_key, new string[]{"ArticleID"});
            if (article == null)
                Console.WriteLine("Kein Artikel gefunden!");
            else
            {
                // danach kann mit der ArticleID weitergearbeitet werden
                getArticle(unitOfWork, new Article.Summary() { ArticleID = article.ArticleID });
            }
            
        }

        static void clearCache(ContextUOW unitOfWork)
        {
            unitOfWork.Cache.Clear();

            Console.WriteLine("Folgende Caches wurden gelöscht:");
            Console.WriteLine(" - OutputCache");
            Console.WriteLine(" - Session Cache");
            Console.WriteLine(" - Search Cache");
            Console.WriteLine(" - DB Cache");
        }

        static void getArticle(ContextUOW unitOfWork, Article.Summary summary)
        {
            Console.WriteLine("Felder die belegt werden sollen können auch angegeben werden.");
            Console.WriteLine("Dadurch braucht der Server nicht alle Felder belegen und kann schneller antworten.");
            Console.WriteLine("<Enter> für Alle Felder, ansonsten z.B. Name,Name2,Keys");
            Console.WriteLine();
            Console.Write("Auswahl: ");
            var properties = Console.ReadLine();

            Console.Clear();
            var article = string.IsNullOrEmpty(properties)
                ? unitOfWork.Articles.Get(summary.ArticleID)
                : unitOfWork.Articles.Get(summary.ArticleID, properties.Split(',').ToArray());

            Console.WriteLine("Name:" + article.Name);
            Console.WriteLine("Name 2:" + article.Name2);

            Console.WriteLine("VARIANTEN");
            if (article.Keys != null)
            {
                foreach (var key in article.Keys)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Artikelnummer: " + key.Value);
                    Console.WriteLine("Info: " + key.Info);
                    Console.WriteLine("EAN: " + key.EAN);
                    foreach (var price in key.Prices)
                    {
                        Console.WriteLine("Preis " + (price.Quantity ?? 1), price.Price);
                    }
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Bitte wählen Sie eine Funktion:");
            Console.WriteLine("(1) - Aktualisieren");
            Console.WriteLine("(2) - Aktualisieren (Englisch)");
            Console.WriteLine("(3) - Löschen");
            Console.WriteLine("(4) - Löschen (permanent)");
            Console.WriteLine("(5) - External_Key setzen für z.B. Verlinkung zur Warenwirtschaft");
            Console.WriteLine("(6) - Dialog aufrufen");
            Console.WriteLine();
            Console.Write("Auswahl: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    updateArticle(unitOfWork, article);
                    break;
                case "2":
                    Console.Clear();
                    updateArticle_enUS(unitOfWork, article);
                    break;
                case "3":
                    Console.Clear();
                    deleteArticle(unitOfWork, article, false);
                    break;
                case "4":
                    Console.Clear();
                    deleteArticle(unitOfWork, article, true);
                    break;
                case "5":
                    Console.Clear();
                    setExternal_Key(unitOfWork, article);
                    break;
                case "6":
                    Console.Clear();
                    startArticleDialog(unitOfWork, article);
                    break;
            }
        }

        static void getVoucher(ContextUOW unitOfWork, Voucher.Summary summary)
        {
            Console.Clear();
            var voucher = unitOfWork.Vouchers.Get(summary.VoucherID);
            Console.WriteLine("ID:" + voucher.VoucherID);
            Console.WriteLine("Preis:" + voucher.Price);
            Console.WriteLine("Guthaben:" + voucher.Remaining);

            Console.WriteLine("Zahlungen:");
            foreach(var payment in voucher.Payments)
            {
                Console.WriteLine("* Preis: " + payment.Price);
                Console.WriteLine("* Info: " + payment.Info);
                Console.WriteLine("* Zahlart: " + payment.PaymentMethod != null ? payment.PaymentMethod.ID.ToString() : "--");
                Console.WriteLine("* Gutschein: " + payment.VoucherCode != null ? payment.VoucherCode.Voucher.ID.ToString() : "--");
            }
            

            Console.WriteLine("");
            Console.ReadLine();
        }

        static void getArticles(ContextUOW unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                var articles = unitOfWork.Articles.FindAll(null, pageIndex, 10, null).Items; // GET api/orders/all

                Console.WriteLine("Seite: " + (pageIndex + 1));
                Console.WriteLine("(+) - Nächste Seite");
                Console.WriteLine("(-) - Vorherige Seite");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var articleSummary in articles)
                {
                    Console.WriteLine("("+i + ") - " + articleSummary.Name + (!string.IsNullOrEmpty(articleSummary.External_Key) ? " (External_Key = " + articleSummary.External_Key + ")" : ""));
                    i++;
                }
                Console.WriteLine();
                Console.Write("Auswahl: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "+":
                        pageIndex++;
                        Console.Clear();
                        break;
                    case "-":
                        pageIndex--;
                        Console.Clear();
                        break;
                    default:
                        if (!string.IsNullOrEmpty(selection))
                        {
                            Console.Clear();
                            getArticle(unitOfWork, articles.ElementAt(Convert.ToInt16(selection)));
                        }
                        break;

                }

            } while (selection == "+" || selection == "-");
                
        }

        static void getVouchers(ContextUOW unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                var vouchers = unitOfWork.Vouchers.FindAll(null, pageIndex, 10, null).Items; // GET api/vouchers/all

                Console.WriteLine("Seite: " + (pageIndex + 1));
                Console.WriteLine("(+) - Nächste Seite");
                Console.WriteLine("(-) - Vorherige Seite");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var voucherSummary in vouchers)
                {
                    Console.WriteLine("(" + i + ") - " + voucherSummary.Name + (!string.IsNullOrEmpty(voucherSummary.External_Key) ? " (External_Key = " + voucherSummary.External_Key + ")" : ""));
                    i++;
                }
                Console.WriteLine();
                Console.Write("Auswahl: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "+":
                        pageIndex++;
                        Console.Clear();
                        break;
                    case "-":
                        pageIndex--;
                        Console.Clear();
                        break;
                    default:
                        if (!string.IsNullOrEmpty(selection))
                        {
                            Console.Clear();
                            getVoucher(unitOfWork, vouchers.ElementAt(Convert.ToInt16(selection)));
                        }
                        break;

                }

            } while (selection == "+" || selection == "-");

        }

        static void validate(ContextUOW unitOfWork)
        {
            Console.WriteLine();
            Console.Write("Benutzername: ");
            var user = Console.ReadLine();
            Console.Write("Passwort: ");
            var password = Console.ReadLine();

            var token = unitOfWork.Account.Validate(user, password); // POST api/account/validate?user={benutzer}&password={passwort}
            Console.Write("Token: " + token);
        }

        static void Main(string[] args)
        {

            var member = new Member();
            

            using (var unitOfWork = new ContextUOW("Test", "<token>", "<endpunkt>"))
            {
                unitOfWork.OnExecuteRequest = (s) =>
                {
                    Console.WriteLine("Daten werden abgefragt..."+s);
                };

                Console.WriteLine("Verbunden mit: "+unitOfWork.Endpoint);
                Console.WriteLine("");

                Console.WriteLine("Bitte wählen Sie eine Funktion:");
                Console.WriteLine("(1) - Authorisieren");
                Console.WriteLine("(2) - Artikel auflisten");
                Console.WriteLine("(3) - Bestellungen auflisten");
                Console.WriteLine("(4) - Artikel anlegen");
                Console.WriteLine("(5) - Artikel per External_Key abfragen");
                Console.WriteLine("(6) - Cache löschen (OutputCache, EF Cache u.s.w.)");
                Console.WriteLine("(7) - Filialen auflisten");
                Console.WriteLine("(8) - Kunden auflisten");
                Console.WriteLine("(9) - Auftragsverwaltung aufrufen");
                Console.WriteLine("(10) - Verfügbarkeiten");
                Console.WriteLine("(11) - Bestellung anlegen");
                Console.WriteLine("(12) - Gutscheine auflisten");
                Console.WriteLine("(13) - Verfügbarkeiten");
                Console.WriteLine("(14) - Positionsupdates");
                Console.WriteLine("");
                Console.Write("Auswahl: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            validate(unitOfWork);
                            break;
                        case "2":
                            Console.Clear();
                            getArticles(unitOfWork);
                            break;
                        case "3":
                            Console.Clear();
                            getOrders(unitOfWork);
                            break;
                        case "4":
                            Console.Clear();
                            createArticle(unitOfWork);
                            break;
                        case "5":
                            Console.Clear();
                            getArticleByExternal_Key(unitOfWork);
                            break;
                        case "6":
                            Console.Clear();
                            clearCache(unitOfWork);
                            break;
                        case "7":
                            Console.Clear();
                            getChainStores(unitOfWork);
                            break;
                        case "8":
                            Console.Clear();
                            getMembers(unitOfWork);
                            break;
                        case "9":
                            Console.Clear();
                            startOrdersDialog(unitOfWork);
                            break;
                        case "10":
                            Console.Clear();
                            patchArticles(unitOfWork);
                            break;
                        case "11":
                            Console.Clear();
                            createOrder(unitOfWork);
                            break;
                        case "12":
                            Console.Clear();
                            getVouchers(unitOfWork);
                            break;
                        case "13":
                            Console.Clear();
                            createAvailabilities(unitOfWork);
                            break;
                        case "14":
                            Console.Clear();
                            getOrdersForStatusupdate(unitOfWork);
                            break;
                        default:
                            Console.WriteLine("Auswahl nicht unterstützt");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fehler: " + e.Message);
                }

                Console.WriteLine("");
                Console.WriteLine("Drücken Sie eine beliebige Taste zum Beenden");
                Console.ReadLine();
            }
            
        }
    }
}
