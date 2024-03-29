
using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Classes;
using GS.OmniChannelSystem.Rest.SDK.Client;
using GS.OmniChannelSystem.Rest.SDK.Extensions;
using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.PflanzenCMS.Rest.SDK.Args;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static GS.PflanzenCMS.Rest.SDK.Classes.QRCode;

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

        static void createMember_Import(ContextUOW unitOfWork)
        {
            var articles = new List<Article>();
            var categories = new List<Category>();
            var countries = new List<Country>();
            var articleGroups = new List<ArticleGroup>();
            var currencies = new List<Currency>();
            var pictures = new List<Picture>();
            var roles = new List<Role>();
            var customerGroups = new List<CustomerGroup>();
            var members = new List<Member>();

            // Prices
            var currency = new Currency();
            currency.Name = "Euro";
            currency.NameShort = "EUR";
            currency.Sign = "€";
            currency.External_Key = "EUR";
            currencies.Add(currency);

            var role = new Role();
            role.Key = "member";
            role.Name = "Kunde";
            roles.Add(role);

            var customerGroup = new CustomerGroup();
            customerGroup.Key = "standard";
            customerGroup.Name = "Standard";
            customerGroups.Add(customerGroup);

            User user = new User();
            Member member = new Member();
            member.External_Key = "abc";
            member.Currency = new EntityReference() { External_Key = currency.External_Key };

            member.MainContact = new Contact();
            member.MainContact.Apellation = Apellation.Mr;
            member.MainContact.FirstName = "Jon";
            member.MainContact.LastName = "Doe";
            member.MainContact.EMail = "jon@doe.com";
            member.Roles = new List<EntityReference>();
            member.Roles.Add(new EntityReference(role));

            var contact = new Contact();
            contact.Apellation = Apellation.Mr;
            contact.FirstName = "Jon";
            contact.LastName = "Doe";

            var address = new Address();
            address.Street = "Street";
            address.Zip = "26802";

            member.Adresses = new List<Address>();
            member.Adresses.Add(address);

            var contactAddress = new ContactAddress();
            contactAddress.Type = AddressType.Main;
            contactAddress.Contact = contact;
            contactAddress.Address = address;
            member.ContactAddresses = new List<ContactAddress>();
            member.ContactAddresses.Add(contactAddress);

            user.Contact = member.MainContact;
            user.EMail = "jondoe@test.de!";
            user.Login = user.EMail;
            user.Password = "password";
            user.AutomaticPassword = true;
            user.Roles = new List<EntityReference>();
            user.Roles.Add(new EntityReference(role));

            member.CustomerGroup = new EntityReference(customerGroup);
            members.Add(member);

            var import = new Import();
            import.Articles = articles.ToArray();
            import.Categories = categories.ToArray();
            import.Countries = countries.ToArray();
            import.ArticleGroups = articleGroups.ToArray();
            import.Currencies = currencies.ToArray();
            import.Pictures = pictures.ToArray();
            import.Roles = roles.ToArray();
            import.Members = members.ToArray();
            import.CustomerGroups = customerGroups.ToArray();

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(import);
            Console.WriteLine("Json: ");
            Console.WriteLine(json);


        }

        static void createArticle(ContextUOW unitOfWork)
        {
            var article = new Article();

            article.Name = "Acer Palmatum Bloodgood";
            article.Name2 = "Fächerahorn Bloodgood";
            article.Description = "Dies ist eine lange Beschreibung";
            article.ShortDescription = "Dies ist eine kurze Beschreibung";

            // Set ArticleGroup
            var articleGroup = unitOfWork.ArticleGroups.FindAll("Pflanzen", 0, 100, null).Items.First(); // GET api/articlegroups
            article.ArticleGroups = new List<EntityReference>();
            article.ArticleGroups.Add(new EntityReference() { ID = articleGroup.ArticleGroupID });

            // Set Category
            var category = unitOfWork.Categories.FindAll("Zubehör", 0, 100, null).Items.First(); // GET api/categories
            article.Categories = new List<EntityReference>();
            article.Categories.Add(new EntityReference() { ID = category.CategoryID });

            // Add Texts
            var text = new ArticleText();
            article.Texts = new List<ArticleText>();
            article.Texts.Add(text);
            text.Type = TextType.BulletPoints;
            text.Title = "Kaufargumente";
            text.Value = "	* frosthart * duftend * wintergrün * Kübel geeignet";

            // Availabilities
            var timePeriod = new TimePeriod();
            article.Available = new List<TimePeriod>();
            article.Available.Add(timePeriod);
            timePeriod.FromCW = 10; // Calendarweek (from)
            timePeriod.ToCW = 20; // Calendarweek (to)
            timePeriod.StockQuantity = 100; // Stock Quantity

            // Add variants (Articlenumbers)
            var articleKey = new ArticleKey();
            article.Keys = new List<ArticleKey>();
            article.Keys.Add(articleKey);

            articleKey.Value = "47811"; // Articlenumber
            articleKey.Info = "C/  50 - 60";
            articleKey.AvailableForClickAndCollect = true; // Click & Collect
            articleKey.AvailableForRadiusDelivery = true; // Send
            articleKey.AvailableForShipping = true; // Deliver
            articleKey.PackingSize = 20; // Payking Unit
            articleKey.StockQuantity = 10; // Stock Quantity
            articleKey.Available.Add(timePeriod);

            // Tax
            var countries = unitOfWork.Countries.FindAll(null, 0, 100, null);
            var germanySummary = countries.Items.Single(m => m.ISO == "DE");
            var germany = unitOfWork.Countries.Get(germanySummary.CountryID);

            var taxRate = germany.TaxRates.Single(m => m.Percent == 19); // GET api/countries
            articleKey.TaxRate = new EntityReference() { ID = taxRate.TaxRateID };


            // Prices
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

            // Channel Articlenumber
            var channel = unitOfWork.Channels.Get(1);
            var articleKeyChannel = new ArticleKeyChannel();
            articleKeyChannel.Channel = new EntityReference(channel.ChannelID);
            articleKeyChannel.Number = "abc";
            articleKey.Channels.Add(articleKeyChannel);

            var summary = unitOfWork.Articles.Create(article, true);  // POST api/articles/create
            Console.WriteLine("Article was created. ID = " + summary.ArticleID);

        }

        static void createArticle_Import(ContextUOW unitOfWork)
        {
            var articles = new List<Article>();
            var categories = new List<Category>();
            var countries = new List<Country>();
            var articleGroups = new List<ArticleGroup>();
            var currencies= new List<Currency>();
            var pictures = new List<Picture>();


            var article = new Article();
            articles.Add(article);

            article.Name = "Acer Palmatum Bloodgood";
            article.Name2 = "Fächerahorn Bloodgood";
            article.Description = "Dies ist eine lange Beschreibung";
            article.ShortDescription = "Dies ist eine kurze Beschreibung";

            // Set ArticleGroup
            var articleGroup = new ArticleGroup();
            articleGroup.Name = "abc";
            articleGroup.External_Key = "abc";
            articleGroups.Add(articleGroup);
            article.ArticleGroups = new List<EntityReference>();
            article.ArticleGroups.Add(new EntityReference() { External_Key = articleGroup.External_Key });

            // Set Category
            var category = new Category();
            category.Name = "Pflanzen";
            category.External_Key = "pflanzen";
            article.Categories = new List<EntityReference>();
            article.Categories.Add(new EntityReference() { External_Key = category.External_Key });
            categories.Add(category);

            // Add Texts
            var text = new ArticleText();
            article.Texts = new List<ArticleText>();
            article.Texts.Add(text);
            text.Type = TextType.BulletPoints;
            text.Title = "Kaufargumente";
            text.Value = "	* frosthart * duftend * wintergrün * Kübel geeignet";

            // Availabilities
            var timePeriod = new TimePeriod();
            article.Available = new List<TimePeriod>();
            article.Available.Add(timePeriod);
            timePeriod.FromCW = 10; // Calendarweek (from)
            timePeriod.ToCW = 20; // Calendarweek (to)
            timePeriod.StockQuantity = 100; // Stock Quantity

            // Add variants (Articlenumbers)
            var articleKey = new ArticleKey();
            article.Keys = new List<ArticleKey>();
            article.Keys.Add(articleKey);

            articleKey.Value = "47811"; // Articlenumber
            articleKey.Info = "C/  50 - 60";
            articleKey.AvailableForClickAndCollect = true; // Click & Collect
            articleKey.AvailableForRadiusDelivery = true; // Send
            articleKey.AvailableForShipping = true; // Deliver
            articleKey.PackingSize = 20; // Payking Unit
            articleKey.StockQuantity = 10; // Stock Quantity

            articleKey.Available = new List<TimePeriod>();
            articleKey.Available.Add(timePeriod);

            // Tax
            var country = new Country();
            country.Name = "Deutschland";
            country.ISO = "DE";
            country.TaxRates = new List<TaxRate>();
            country.TaxRates.Add(new TaxRate() { External_Key = "de19", Percent = 19.0 });
            country.External_Key = "de";
            countries.Add(country);

            articleKey.TaxRate = new EntityReference() { External_Key = "de19" };


            // Prices
            var currency = new Currency();
            currency.Name = "Euro";
            currency.NameShort = "EUR";
            currency.Sign = "€";
            currency.External_Key = "EUR";
            currencies.Add(currency);

            var articleKeyPrice = new ArticleKeyPrice();
            articleKey.Prices = new List<ArticleKeyPrice>();
            articleKey.Prices.Add(articleKeyPrice);
            articleKeyPrice.Price = 17; // Preis
            articleKeyPrice.PriceOld = 25; // Streichpreis
            articleKeyPrice.PriceUnitAmount = 10; // pro 10
            articleKeyPrice.ValueUnitType = PriceUnitType.Liter; // Liter
            articleKeyPrice.Quantity = 1; // Ab Stückzahl
            articleKeyPrice.Currency = new EntityReference() { External_Key = currency.External_Key };
            articleKeyPrice.TaxIncluded = true; // Mwst. inkl?
            articleKeyPrice.PriceNet = true; // Netto - Preis (keine Rabatte)

            var picture = new Picture();
            picture.Name = "aaaaa.png";
            picture.External_Key = "aaaaa.png";
            picture.Url = "ftp://local/import/aaaaa.png";
            pictures.Add(picture);

            articleKey.Photos = new List<ArticleKeyPhoto>();
            articleKey.Photos.Add(new ArticleKeyPhoto()
            {
                Picture = new PictureEntityReference() { External_Key = picture.External_Key }
            });

            var import = new Import();
            import.Articles = articles.ToArray();
            import.Categories = categories.ToArray();
            import.Countries = countries.ToArray();
            import.ArticleGroups = articleGroups.ToArray();
            import.Currencies = currencies.ToArray();
            import.Pictures = pictures.ToArray();

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(import);
            Console.WriteLine("Json: ");
            Console.WriteLine(json);

        }
        static void createDataURI(ContextUOW unitOfWork)
        {
            var file = @"c:\test.xml";
            Console.WriteLine("Reading from "+file);
            var dataUri = new DataUri(System.IO.File.ReadAllBytes(file), "application/xml");
            Console.WriteLine("dataUri: "+dataUri.ToString());

        }


        static void createInvoice(ContextUOW unitOfWork)
        {
            var member = unitOfWork.Members.Get(1);

            var invoice = new Invoice();
            invoice.Member = new EntityReference(member.MemberID);
            invoice.Address = new EntityReference(member.ContactAddresses.First().ContactAddressID);
            invoice.Positions = new List<InvoicePosition>();
            var position = new InvoicePosition();
            position.Text = "Acer Palmatum Bloodgood";
            position.Price = 19.99;
            position.Quantity = 10;
            invoice.SequenceItem = new SequenceItem();
            invoice.SequenceItem.Key = "4711";
            invoice.SequenceItem.Number = "4711";
            var summary = unitOfWork.Invoices.Create(invoice);  // POST api/invoices/create
            Console.WriteLine("Article was created. ID = " + invoice.InvoiceID);

        }

        static void createArticleLinkTarget(ContextUOW unitOfWork)
        {
            // POST articles/create/linktarget
            var linkTarget = unitOfWork.Articles.LinkTarget(
                "233181-test", 
                "Testartikel"
           );  
            Console.WriteLine("LinkTarget was created. ID = " + linkTarget.Url);

        }

        static void createArticleTransaction(ContextUOW unitOfWork)
        {
            var transactions = new List<ArticleTransactionArgs>();
            var transaction = new ArticleTransactionArgs();
            transaction.External_Key = "abc";
            transaction.StockQuantity = 100; // Bestand
            transaction.Prices = new List<ArticleTransactionPrice>();
            transaction.Prices.Add(new ArticleTransactionPrice() { Quantity = 1, Price = 9.99 });
            transactions.Add(transaction);

            unitOfWork.Articles.Transactions(transactions.ToArray());  // POST api/articles/transaction
        }

        static void getDeliverySlip(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();
            var pdf = unitOfWork.Documents.GetForOrder(order.OrderID, transaction.OrderTransactionID, DocumentationType.DeliverySlip);
            Process.Start(pdf);
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

            // Invoiceaddress - Address
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

            // Invoiceaddress - Contact
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

            // Shippingaddress = Invoiceaddress
            // Could be separeted as well like to definition before but for args.ShippingAddress
            args.ShippingAddress = args.InvoiceAddress;
            args.Notes = "Dies ist eine Bemerkung";

            // Payment method
            var paymentMethod = unitOfWork.PaymentMethods.FindAll(null, 0, 1, null).Items.First(); // GET api/paymentmethods
            args.PaymentMethodID = paymentMethod.PaymentMethodID;

            // Shipping method
            var shippingMethod = unitOfWork.ShippingMethods.FindAll(null, 0, 1, null).Items.First(); // GET api/shippingmethods
            args.ShippingMethodID = shippingMethod.ShippingMethodID;

            // Minimum age (for alcohol)
            args.MinimumAge = null; // 18 / 16

            // Currency
            args.Currency = "EUR";

            // Wanted Delivery Date
            args.WantedShippingDate = DateTime.Now;

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
            Console.WriteLine("Order was created. ID = " + summary.OrderID);
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

            // Payment method
            var paymentMethod = unitOfWork.PaymentMethods.FindAll(null, 0, 1, null).Items.First(); // GET api/paymentmethods
            args.PaymentMethodID = paymentMethod.PaymentMethodID;

            // Currency
            args.Currency = "EUR";

            // Customer
            args.OwnerMemberID = 1;

            var items = new List<CreateCashdeskArgs.OrderItem>();
            var item = new CreateCashdeskArgs.OrderItem();
            item.Date = DateTime.Now;
            item.Info = "Acer Palmatum Bloodgood";
            item.ArticleKey = "4711";
            item.Notes = "Notes for the article";
            item.Type = ItemType.ArticleKey;
            item.Currency = "EUR";
            item.Quantity = 1;
            item.Position = 1;
            item.TaxRate = 19.0;
            items.Add(item);

            args.Items = items;
            var summary = unitOfWork.Orders.CreateCashDesk(args);  // POST api/orders/create
            Console.WriteLine("Order was created. ID = " + summary.OrderID);
        }

        static void getOrders(ContextUOW unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                // We query the orders sorted by orderID descending to get the newest first
                // and then the rest
                var orders = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "OrderID desc", new GS.OmniChannelSystem.Rest.SDK.Filters.Orders()).Items; // GET api/orders/all

                Console.WriteLine("Page: " + (pageIndex + 1));
                Console.WriteLine("(+) - Next page");
                Console.WriteLine("(-) - Pev page");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var orderSummary in orders)
                {
                    Console.WriteLine("(" + i + ") - Ordernumber " + orderSummary.OrderID + " from " + orderSummary.CreatedOn.ToShortDateString());

                    i++;
                }

                Console.WriteLine();
                Console.Write("Choice: ");
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
                // We query the orders sorted by orderID descending to get the newest first
                // and then the rest
                var orders = unitOfWork.Orders.FindAllForShop(null, pageIndex, 10, "OrderID desc", new GS.OmniChannelSystem.Rest.SDK.Filters.Orders()).Items; // GET api/orders/all

                Console.WriteLine("Page: " + (pageIndex + 1));
                Console.WriteLine("(+) - Next page");
                Console.WriteLine("(-) - Prev page");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var orderSummary in orders)
                {
                    Console.WriteLine("(" + i + ") - Ordernumber " + orderSummary.OrderID + " from " + orderSummary.CreatedOn.ToShortDateString());

                    i++;
                }

                Console.WriteLine();
                Console.Write("choice: ");
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

                Console.WriteLine("Page: " + (pageIndex + 1));
                Console.WriteLine("(+) - Next page");
                Console.WriteLine("(-) - Prev page");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var chainStoreSummary in chainStores)
                {
                    Console.WriteLine("(" + i + ") - "+chainStoreSummary.Name);

                    i++;
                }

                Console.WriteLine();
                Console.Write("Choice: ");
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
                // We query the Members sorted by MemberID descending to get the newest first
                // and then the rest
                var members = unitOfWork.Members.FindAll(null, pageIndex, 10, "MemberID desc").Items; // GET api/orders/all

                Console.WriteLine("Page: " + (pageIndex + 1));
                Console.WriteLine("(+) - Next page");
                Console.WriteLine("(-) - Prev page");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var memberSummary in members)
                {
                    Console.WriteLine("(" + i + ") - " + memberSummary.MainContact+", "+ memberSummary.MainAddress);

                    i++;
                }

                Console.WriteLine();
                Console.Write("Choice: ");
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

            Console.WriteLine("Ordernumber:" + order.OrderID);
            Console.WriteLine("Date:" + order.CreatedOn.ToShortDateString());

            var owner = unitOfWork.Members.Get(order.Owner.ID); // GET api/members/{id}
            Console.WriteLine("Customer:" + owner.MainContact.Company);

            Console.WriteLine("Invoice address:" + order.InvoiceAddress.Contact.Company + " " + order.InvoiceAddress.Address.Street + " " + order.InvoiceAddress.Address.HouseNumber);
            if (order.ShippingAddress != null)
                Console.WriteLine("Shipping address:" + order.ShippingAddress.Contact.Company + " " + order.ShippingAddress.Address.Street + " " + order.ShippingAddress.Address.HouseNumber);

            if (order.PaymentMethod != null)
            {
                var paymentMethod = unitOfWork.PaymentMethods.Get(order.PaymentMethod.ID); // GET api/paymentmethods/{id}
                Console.WriteLine("Payment method:" + paymentMethod.Name);
            }

            if (order.ShippingMethod != null)
            {
                var shippingMethod = unitOfWork.ShippingMethods.Get(order.ShippingMethod.ID); // GET api/shippingmethods/{id}
                Console.WriteLine("Shipping method:" + shippingMethod.Name);
            }

            // Positions
            foreach (var position in order.Items)
            {
                var article = unitOfWork.Articles.Get(position.Article.ID); // GET api/articles/{id}
                var articleKey = article.Keys.SingleOrDefault(m => m.ArticleKeyID == position.ArticleKey.ID);

                Console.WriteLine("Article:" + article.Name + " / " + article.Name2);
                Console.WriteLine("Articlenumber:" + articleKey.Value);
                Console.WriteLine("Transaction:" + position.TransactionType); // CLick&Collect, Send u.s.w.
                Console.WriteLine("Menge:" + position.Quantity);
                Console.WriteLine("Price:" + position.Price);
                Console.WriteLine("Total price:" + position.TotalCosts);
                Console.WriteLine("Confirmed:" + (position.IsConfirmed == true ? "Ja" : "Nein"));

                // Vouchers bought ?
                if(position.Vouchers!=null && position.Vouchers.Any())
                {
                    foreach (var voucherReference in position.Vouchers)
                    {
                        var voucher = unitOfWork.Vouchers.Get(voucherReference.ID);
                        Console.WriteLine("Voucher: " + voucher.Name);
                        Console.WriteLine("Amount: " + voucher.Price);
                        Console.WriteLine("Balance: " + voucher.Remaining);
                    }
                }
            }

            Console.WriteLine("Payments:");
            foreach (var payment in order.Payments)
            {
                Console.WriteLine("* Price: " + payment.Price);
                Console.WriteLine("* Info: " + payment.Info);
                Console.WriteLine("* Payment method: " + payment.PaymentMethod != null ? payment.PaymentMethod.ID.ToString() : "--");

                // Payd with voucher?
                if (payment.VoucherCode != null)
                {
                    var voucher = unitOfWork.Vouchers.Get(payment.VoucherCode.Voucher.ID);
                    Console.WriteLine("Voucher: " + voucher.Name);
                    Console.WriteLine("Price: " + voucher.Price);
                    Console.WriteLine("Balance: " + voucher.Remaining);
                    Console.WriteLine("* Code: " + payment.VoucherCode != null ? payment.VoucherCode.Voucher.ID.ToString() : "--");
                }
            }

            Console.WriteLine("Please select:");
            Console.WriteLine("(1) - Update");
            Console.WriteLine("(2) - Confirm order");
            Console.WriteLine("(3) - Replacement");
            Console.WriteLine("(4) - Cancel order");
            Console.WriteLine("(5) - Sent order");
            Console.WriteLine("(6) - Order is delayed");
            Console.WriteLine("(7) - Finish order");
            Console.WriteLine("(8) - Refund order");
            Console.WriteLine("(9) - Split order");
            Console.WriteLine("(A) - Update order on position status");
            Console.WriteLine("(M) - Service");
            Console.WriteLine();
            Console.Write("Choice: ");
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
                case "M":
                    Console.Clear();
                    getOrderMessages(unitOfWork, order);
                    break;
            }

        }

        static void executeMessageWorkflow(ContextUOW unitOfWork, Message message, Workflow workflow)
        {
            Console.Clear();
            Console.WriteLine("Text: " + workflow.Text);
            Console.WriteLine("Type: " + workflow.Type.ToString());
            var newMessage = unitOfWork.Messages.ExecuteWorkflow(message.MessageID, workflow);
            Console.WriteLine("Neue Meldung erstellt: " + newMessage.Number);

        }

        static void getMessageWorkflow(ContextUOW unitOfWork, Message message)
        {
            var order = unitOfWork.Messages.Get(message.MessageID); // GET api/orders/{id}
            Console.Clear();
            Console.WriteLine("Number:" + message.Number);
            Console.WriteLine("Subject:" + message.Subject);
            Console.WriteLine("Type:" + message.Type.ToString());

            var workflows = unitOfWork.Messages.GetWorkflow(message.MessageID);

            Console.WriteLine("");
            // Positions
            Console.WriteLine("Please select:");
            int i = 0;
            foreach (var workflow in workflows)
            {
                Console.WriteLine("(" + i + ") - " + workflow.Text);
                Console.WriteLine("     Type:" + workflow.Type.ToString());
                Console.WriteLine("==============================");
                Console.WriteLine("");
                i++;
            }

            Console.WriteLine();
            Console.Write("Choice: ");
            executeMessageWorkflow(unitOfWork, message, workflows.ElementAt(Convert.ToInt16(Console.ReadLine())));
        }

        static void replyOrderMessages(ContextUOW unitOfWork, Order order)
        {
            Console.Clear();
            Console.WriteLine("Ordernumber:" + order.OrderID);
            Console.WriteLine("Date:" + order.CreatedOn.ToShortDateString());
            // Retreive all messages for this order
            var workflow = unitOfWork.Messages.FindOrderWorkflow(order.OrderID, MessageType.ReturnsInspectionFailed);
            // Execute the workflow and create a new reply message
            unitOfWork.Messages.ExecuteWorkflow(workflow.MessageID, workflow);

        }

        static void getOrderMessages(ContextUOW unitOfWork, Order order)
        {
            //var order = unitOfWork.Orders.Get(order.OrderID); // GET api/orders/{id}
            Console.Clear();
            Console.WriteLine("Ordernumber:" + order.OrderID);
            Console.WriteLine("Date:" + order.CreatedOn.ToShortDateString());
            var messages = unitOfWork.Messages.GetForOrder(order.OrderID, null, 0, 10, null);
            // Positions
            Console.WriteLine("");
            Console.WriteLine("Please select:");
            int i = 0;
            foreach (var message in messages.Items)
            {
                Console.WriteLine("("+i+") - "+ message.Number);
                Console.WriteLine("     Subject:" + message.Subject);
                Console.WriteLine("     Type:" + message.Type.ToString());
                Console.WriteLine("==============================");
                Console.WriteLine("");
                i++;
            }

            Console.WriteLine();
            Console.Write("Choice: ");            
            getMessageWorkflow(unitOfWork, messages.Items.ElementAt(Convert.ToInt16(Console.ReadLine())));

        }

        static void updateOrderPositionStatusConfirm(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positions:");            
            var positions = Console.ReadLine();
            Console.WriteLine();

            // Order - Head
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions)
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Order - Positions
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Confirmed;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Order was updated: " + result.Length + " Updates");
        }

        static void updateOrderPositionStatusCancel(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positions:");
            var positions = Console.ReadLine();
            Console.WriteLine();

            // Order - Head
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Order - Positions
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Cancelled;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Order was updated: " + result.Length + " Updates");
        }

        static void updateOrderPositionReduceQuantity(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positions:");
            var positions = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Quantity:");
            var quantity = Console.ReadLine();
            Console.WriteLine();

            // Order - Head
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Order - Positions
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity-Convert.ToInt16(quantity);
                positionTransaction.Status = OrderTransactionStatusType.Cancelled;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Order was updated: " + result.Length + " Updates");
        }

        static void updateOrderPositionStatusDeliver(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positions:");
            var positions = Console.ReadLine();
            Console.WriteLine();

            // Order - Head
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Order-Positions
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn;
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Delivered;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Order was updated: " + result.Length + " Updates");
        }

        static void updateOrderPositionStatusSplit(ContextUOW unitOfWork, Order order)
        {
            Console.Write("Positions:");
            var positions = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Days:");
            var days = Console.ReadLine();
            Console.WriteLine();

            // Order - Head
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            foreach (var position in positions.Split(','))
            {
                var item = order.Items.ElementAt(Convert.ToInt16(position));

                // Order - Positions
                var positionTransaction = new OrderTransactionPosition();
                positionTransaction.OrderItemID = item.OrderItemID;
                positionTransaction.AvailableOn = item.AvailableOn.Value.AddDays(Convert.ToInt16(days));
                positionTransaction.Quantity = item.Quantity;
                positionTransaction.Status = OrderTransactionStatusType.Confirmed;
                orderTransaction.Positions.Add(positionTransaction);
            }

            var result = unitOfWork.Orders.UpdatePositions(order.OrderID, orderTransaction);
            Console.WriteLine("Order was updated: " + result.Length + " Updates");
        }

        static void updateOrderStatus(ContextUOW unitOfWork, Order.Summary summary)
        {
            do
            {
                unitOfWork.Invalidate();
                var order = unitOfWork.Orders.Get(summary.OrderID); // GET api/orders/{id}

                Console.Clear();
                Console.WriteLine("Ordernumber:" + order.OrderID);
                Console.WriteLine("Date:" + order.CreatedOn.ToShortDateString());
                Console.WriteLine("Status: " + order.Status);
                Console.WriteLine("Invoice address:" + order.InvoiceAddress.Contact.Company + " " + order.InvoiceAddress.Address.Street + " " + order.InvoiceAddress.Address.HouseNumber);
                if (order.ShippingAddress != null)
                    Console.WriteLine("Shipping address:" + order.ShippingAddress.Contact.Company + " " + order.ShippingAddress.Address.Street + " " + order.ShippingAddress.Address.HouseNumber);

                order = unitOfWork.Orders.Get(summary.OrderID); // GET api/orders/{id}

                Console.WriteLine();
                StringBuilder sb = new StringBuilder();
                sb.Append("No", 5);
                sb.Append("Article", 30);
                sb.Append("Confirmed", 5);
                sb.Append("Quantity", 8);
                sb.Append("Price", 8);
                sb.Append("Total", 8);
                sb.Append("Intern", 60);
                Console.WriteLine(sb.ToString());

                // Positions
                foreach (var position in order.Items)
                {
                    var transaction = order.Transactions.Single(m => m.OrderTransactionID == position.Transaction.ID);
                    sb.Clear();
                    sb.Append(position.Position.ToString(), 5);
                    sb.Append(position.Info, 30);
                    sb.Append(position.IsConfirmed == true ? "Yes" : position.Confirmed == null ? "??" : "No", 5);
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
                Console.WriteLine("Please select:");
                Console.WriteLine("(0) - Decrease quantity");
                Console.WriteLine("(1) - Split");
                Console.WriteLine("(2) - Confirm");
                Console.WriteLine("(3) - Sent");
                Console.WriteLine("(4) - Cancel");
                Console.WriteLine("(X) - Quit");
                Console.WriteLine();
                Console.Write("Choice: ");
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
            

            Console.WriteLine("Address:" + (chainStore.Contact!=null ? chainStore.Contact.Company : "") + " " + chainStore.Address.Street + " " + chainStore.Address.HouseNumber);
        }

        static void getMember(ContextUOW unitOfWork, Member.Summary summary)
        {
            var member = unitOfWork.Members.Get(summary.MemberID); // GET api/chainstores/{id}

            Console.WriteLine("Company:" + member.MainContact.Company);
            Console.WriteLine("Customer number:" + member.Number);

            Console.WriteLine("Please select:");
            Console.WriteLine("(1) - Update");
            Console.WriteLine();
            Console.Write("Choice: ");
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

            // Permanent delety (Standard ist logical)
            // Is only supported by few entity types like Member or User
            // unitOfWork.Articles.Delete(article.ArticleID, true);

            Console.WriteLine("Article was deleted");
        }

        static void setExternal_Key(ContextUOW unitOfWork, Article article)
        {
            Console.WriteLine("All entities have an External_Key field in which their own primary key, such as the ID of the external");
            Console.WriteLine("software system, can be stored. The entity can then be accessed on the basis of this External_Key.");
            Console.WriteLine();
            Console.Write("External_Key: ");
            article.External_Key = Console.ReadLine();
            var newArticle = unitOfWork.Articles.Update(article.ArticleID, article, new string[] { "External_Key" } /* optional */);
            Console.WriteLine("Article was updated: " + newArticle.External_Key);
        }

        static void updateArticle_enUS(ContextUOW unitOfWork, Article article)
        {
            using (var unitOfWork_enUS = unitOfWork.Clone("en-US"))
            {
                var enUsArticle = unitOfWork_enUS.Articles.Get(article.ArticleID, new string[] { "Name" });

                Console.WriteLine("Name: " + enUsArticle.Name);
                Console.WriteLine();
                Console.Write("New Name: ");
                
                enUsArticle.Name = Console.ReadLine();
                unitOfWork_enUS.Articles.Update(enUsArticle.ArticleID, enUsArticle, new string[] { "Name" } /* optional */);
                Console.WriteLine("Article was updated: " + enUsArticle.Name);
            }
        }

        static void updateArticle(ContextUOW unitOfWork, Article article)
        {
            Console.WriteLine("Name 2: " + article.Name2);
            Console.WriteLine();
            Console.Write("New Name 2: ");
            article.Name2 = Console.ReadLine();
            var newArticle = unitOfWork.Articles.Update(article.ArticleID, article, new string[] { "Name2" } /* optional */);
            Console.WriteLine("Article was updated: " + newArticle.Name2);
        }

        static void updateMember(ContextUOW unitOfWork, Member member)
        {
            Console.WriteLine("Customernumber: " + member.Number);
            Console.WriteLine();
            Console.Write("New  Nummer: ");
            member.Number = Console.ReadLine();
            var newMember = unitOfWork.Members.Update(member.MemberID, member); // PUT api/members
            Console.WriteLine("Customer was updated: " + newMember.Number);
        }

        static void updateOrder(ContextUOW unitOfWork, Order order)
        {
            Console.WriteLine("Note: " + order.Notes);
            Console.WriteLine();
            Console.Write("New Note: ");
            order.Notes = Console.ReadLine();
            var newOrder = unitOfWork.Orders.Update(order.OrderID, order, new string[] { "Notes" } /* optional */);
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void confirmOrder(ContextUOW unitOfWork, Order order)
        {
            Console.WriteLine("Confirm order: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.OrderStatus = OrderStatusType.Confirmed;
            args.StatusOn = DateTime.Now;
            args.Message = "Confirmation message";

            var articles = new List<OrderTransactionArticle>();

            var article = new OrderTransactionArticle();
            article.OrderItemID = order.Items.First().OrderItemID;
            // false = not confirmed
            article.Confirmed = true; 
            // Confirm less quantity?
            // null = no otherwise the quantity to confirm
            article.QuantityConfirmed = null; // St
            articles.Add(article);

            args.Articles = articles.ToArray();
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void updateOrderPositionStatus(ContextUOW unitOfWork)
        {
            Console.WriteLine("Order is updated on positions");
            Console.WriteLine();

            // Order - Head
            var orderTransaction = new OrderTransactionPositions();
            orderTransaction.Positions = new List<OrderTransactionPosition>();

            // Tracking URL
            orderTransaction.TrackAndTraceURL = "http://dpd.com/?code=";
            orderTransaction.TrackAndTraceID = new string[] { "abc", "def"};
            // Invoice
            orderTransaction.InvoiceFilename = "Rechung.pdf";
            orderTransaction.InvoiceMimeType = "application/pdf";
            // Base 64 encoded Data URI with the Pdf
            orderTransaction.InvoiceURI = "data:application/pdf;base64,jhakuzbsahdga676f3jhgbsa5as6g";

            // If you use our OCS for invoices you can link it via a EntityReference
            var invoice = unitOfWork.Invoices.Get(1);
            orderTransaction.InvoiceID = invoice.InvoiceID;

            // Order - Position
            var positionTransaction = new OrderTransactionPosition();
            // Number
            positionTransaction.OrderItemID = 123;
            // Article
            positionTransaction.External_Key = "abcdef";
            // Quantity
            positionTransaction.Quantity = 10;
            // Deliver Date
            positionTransaction.AvailableOn = new DateTime(2020, 12, 24);
            // Delivered
            positionTransaction.Status = OrderTransactionStatusType.Delivered;
            // Confirmed
            positionTransaction.Status = OrderTransactionStatusType.Confirmed;
            // Cancelled
            positionTransaction.Status = OrderTransactionStatusType.Cancelled;
            orderTransaction.Positions.Add(positionTransaction);

            var result = unitOfWork.Orders.UpdatePositions(44, orderTransaction);
            Console.WriteLine("Order was updated: " + result.Length+" updates");
        }

        static void splitOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Split order: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Action = OrderTransactionActionType.Split;
            args.OrderTransactionID = transaction.OrderTransactionID;

            // New Date
            args.EarliestShippingDate = DateTime.Now.AddDays(14);

            var articles = new List<OrderTransactionArticle>();
            var article = new OrderTransactionArticle();
            article.OrderItemID = order.Items.First().OrderItemID;
            articles.Add(article);

            args.Articles = articles.ToArray();
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Order was updated: " + order.OrderID);
        }

        static void cancelOrder(ContextUOW unitOfWork, Order order)
        {
            Console.WriteLine("Cancel order: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.OrderStatus = OrderStatusType.Canceled;
            args.StatusOn = DateTime.Now;
            args.Message = "Cancellation message";

            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void shipOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            // Create shipment label
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


            Console.WriteLine("Sent order: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Status = OrderTransactionStatusType.Delivered;
            args.StatusOn = DateTime.Now;
            args.TrackAndTraceID = new string[] {"123456","789012" };
            args.TrackAndTraceURL = "https://dhl.tracking.de/?piececode=";
            args.OrderTransactionID = transaction.OrderTransactionID;
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void replaceOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Replace order: " + order.OrderID);
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
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void refundOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Refund order: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Action = OrderTransactionActionType.Refund;

            var replacements = new List<OrderTransactionArticle>();

            var replacement = new OrderTransactionArticle();
            replacement.OrderItemID = order.Items.First().OrderItemID;
            replacements.Add(replacement);

            args.Articles = replacements.ToArray();
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void delayOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Delay order: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.Action = OrderTransactionActionType.Delay;
            args.EarliestShippingDate = DateTime.Now.AddDays(7);
            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void finishOrder(ContextUOW unitOfWork, Order order)
        {
            var transaction = order.Transactions.First();

            Console.WriteLine("Finish order: " + order.OrderID);
            Console.WriteLine();
            var args = new OrderTransactionArgs();
            args.OrderStatus = OrderStatusType.Ready;
            args.InvoiceFilename = "Rechung.pdf";
            args.InvoiceMimeType = "application/pdf";
            // Base 64 encoded Data URI with the pdf
            args.InvoiceURI = "data:application/pdf;base64,jhakuzbsahdga676f3jhgbsa5as6g";

            var newOrder = unitOfWork.Orders.UpdateStatus(order.OrderID, args);
            Console.WriteLine("Order was updated: " + order.Notes);
        }

        static void startArticleDialog(ContextUOW unitOfWork, Article article)
        {
            var dialog = unitOfWork.Articles.Dialog(article.ArticleID);
            Console.WriteLine("Title: " + dialog.Title);
            Console.WriteLine("Url: " + dialog.Url);
            Console.WriteLine("Width: " + dialog.Width);
            Console.WriteLine("Height: " + dialog.Height);

            Console.WriteLine();
            Console.Write("Open browser (y/n)? ");
            if (Console.ReadLine() == "y")
                Process.Start(dialog.Url);
        }

        static void startOrdersDialog(ContextUOW unitOfWork)
        {
            var dialog = unitOfWork.Orders.Dialog();
            Console.WriteLine("Title: " + dialog.Title);
            Console.WriteLine("Url: " + dialog.Url);
            Console.WriteLine("Width: " + dialog.Width);
            Console.WriteLine("Height: " + dialog.Height);

            Console.WriteLine();
            Console.Write("Open Broswer (y/n)? ");
            if (Console.ReadLine() == "y")
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
            Console.WriteLine("Start Patchupdate: " + job.Name+", "+job.JobID);
            Console.ReadLine();
        }

        static void createAvailabilities(ContextUOW unitOfWork)
        {
            // First package for the update
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
                availabilities1, // Availabilities
                true,            // Complete (delete first)
                false            // Update is necessary?
            );
            Console.WriteLine("Start Patchupdate: " + job.Name+", "+job.JobID);

            // Second package
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
                availabilities1, // Availabilities
                true,            // Complete (delete first)
                true            // Update is necessary?
            );
            Console.ReadLine();
        }

        static void getArticleByExternal_Key(ContextUOW unitOfWork)
        {
            Console.WriteLine("All entities have an External_Key field in which their own primary key, such as the ID of the external software system,");
            Console.WriteLine("can be stored. The entity can then be accessed on the basis of this External_Key.");
            Console.WriteLine();
            Console.Write("External_Key: ");
            var external_key = Console.ReadLine();

            Console.Clear();
            // Only retreive the ArticleID for a faster result
            var article = unitOfWork.Articles.Get(external_key, new string[]{"ArticleID"});
            if (article == null)
                Console.WriteLine("No article found!");
            else
            {
                // the we can work with the ArticleID
                getArticle(unitOfWork, new Article.Summary() { ArticleID = article.ArticleID });
            }
            
        }

        static void clearCache(ContextUOW unitOfWork)
        {
            unitOfWork.Cache.Clear();

            Console.WriteLine("Following caches were cleared:");
            Console.WriteLine(" - OutputCache");
            Console.WriteLine(" - Session Cache");
            Console.WriteLine(" - Search Cache");
            Console.WriteLine(" - DB Cache");
        }

        static void getArticle(ContextUOW unitOfWork, Article.Summary summary)
        {
            Console.WriteLine("Properties can be defined for the query.");
            Console.WriteLine("This helps to increase the query speed for the server.");
            Console.WriteLine("<Enter> for all properties, otherwise e.g. Name,Name2,Keys");
            Console.WriteLine();
            Console.Write("Choice: ");
            var properties = Console.ReadLine();

            Console.Clear();
            var article = string.IsNullOrEmpty(properties)
                ? unitOfWork.Articles.Get(summary.ArticleID)
                : unitOfWork.Articles.Get(summary.ArticleID, properties.Split(',').ToArray());

            Console.WriteLine("Name:" + article.Name);
            Console.WriteLine("Name 2:" + article.Name2);

            Console.WriteLine("Variants");
            if (article.Keys != null)
            {
                foreach (var key in article.Keys)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Articlenumber: " + key.Value);
                    Console.WriteLine("Info: " + key.Info);
                    Console.WriteLine("EAN: " + key.EAN);
                    foreach (var price in key.Prices)
                    {
                        Console.WriteLine("Price " + (price.Quantity ?? 1), price.Price);
                    }
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Please select:");
            Console.WriteLine("(1) - Update");
            Console.WriteLine("(2) - Update (English)");
            Console.WriteLine("(3) - Delete");
            Console.WriteLine("(4) - Delete (permanent)");
            Console.WriteLine("(5) - Set External_Key e.g. link to external software system");
            Console.WriteLine("(6) - Open dialog");
            Console.WriteLine();
            Console.Write("Choice: ");
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
            Console.WriteLine("Price:" + voucher.Price);
            Console.WriteLine("Balance:" + voucher.Remaining);

            Console.WriteLine("Payments:");
            foreach(var payment in voucher.Payments)
            {
                Console.WriteLine("* Price: " + payment.Price);
                Console.WriteLine("* Info: " + payment.Info);
                Console.WriteLine("* Payment Method: " + payment.PaymentMethod != null ? payment.PaymentMethod.ID.ToString() : "--");
                Console.WriteLine("* Code: " + payment.VoucherCode != null ? payment.VoucherCode.Voucher.ID.ToString() : "--");
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

                Console.WriteLine("Page: " + (pageIndex + 1));
                Console.WriteLine("(+) - Next page");
                Console.WriteLine("(-) - Prev page");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var articleSummary in articles)
                {
                    Console.WriteLine("("+i + ") - " + articleSummary.Name + (!string.IsNullOrEmpty(articleSummary.External_Key) ? " (External_Key = " + articleSummary.External_Key + ")" : ""));
                    i++;
                }
                Console.WriteLine();
                Console.Write("Choice: ");
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

                Console.WriteLine("Page: " + (pageIndex + 1));
                Console.WriteLine("(+) - Next page");
                Console.WriteLine("(-) - Prev page");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var voucherSummary in vouchers)
                {
                    Console.WriteLine("(" + i + ") - " + voucherSummary.Name + (!string.IsNullOrEmpty(voucherSummary.External_Key) ? " (External_Key = " + voucherSummary.External_Key + ")" : ""));
                    i++;
                }
                Console.WriteLine();
                Console.Write("Choice: ");
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
            Console.Write("Username: ");
            var user = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            var token = unitOfWork.Account.Validate(user, password); // POST api/account/validate?user={benutzer}&password={passwort}
            Console.Write("Token: " + token);
        }

        static void payWithVoucher(ContextUOW unitOfWork)
        {
            Console.WriteLine();
            Console.Write("Code: ");
            var code = Console.ReadLine();
            var foundVoucher = unitOfWork.Vouchers.Find(code);
            if (foundVoucher == null)
                throw new Exception("Voucher not found: " + code);

            // Reserve a payment
            var payment = unitOfWork.Vouchers.Reserve(foundVoucher.VoucherID, foundVoucher.VoucherCodeID, 5, "EUR", "Test", 5);

            // Execute the payment
            var voucher = unitOfWork.Vouchers.Pay(payment.PaymentID);

            Console.WriteLine($"Remaining: {voucher.Remaining}");            
        }

        static void createQRCode(ContextUOW unitOfWork)
        {
            var code = CreateQR(new QRInfo()
            {
                MemberNumber = "50",
                Vouchers = new string[]
                {
                    "32"
                },
                NoReceipt = true,
                DebitCardNumber = "50",
                Amount = 11.5
            });
            Console.WriteLine();
            Console.Write("Code: " + code);
        }

        static void Main(string[] args)
        {

            createMember_Import(null);

            using (var unitOfWork = new ContextUOW("Test", "<endpoint>", "<token>"))
            {
                unitOfWork.OnExecuteRequest = (s) =>
                {
                    Console.WriteLine("Query data..."+s);
                };

                Console.WriteLine("Connected to: "+unitOfWork.Endpoint);
                Console.WriteLine("");

                Console.WriteLine("Please select:");
                Console.WriteLine("(1) - authorize");
                Console.WriteLine("(2) - Query articles");
                Console.WriteLine("(3) - Query orders");
                Console.WriteLine("(4) - Create article");
                Console.WriteLine("(5) - Quuery article by External_Key");
                Console.WriteLine("(6) - Clear caches  (OutputCache, EF Cache u.s.w.)");
                Console.WriteLine("(7) - Query chainstores");
                Console.WriteLine("(8) - Query customers");
                Console.WriteLine("(9) - Open Order Management");
                Console.WriteLine("(10) - Availabilities");
                Console.WriteLine("(11) - Create order");
                Console.WriteLine("(12) - Query vouchers");
                Console.WriteLine("(13) - Availabilities");
                Console.WriteLine("(14) - Positionupdates");
                Console.WriteLine("(15) - Create Linktarget");
                Console.WriteLine("(16) - Create QR - Code");
                Console.WriteLine("(17) - Pay with Voucher");
                Console.WriteLine("");
                Console.Write("Choice: ");

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
                        case "15":
                            Console.Clear();
                            createArticleLinkTarget(unitOfWork);
                            break;
                        case "16":
                            Console.Clear();
                            createQRCode(unitOfWork);
                            break;
                        case "17":
                            Console.Clear();
                            payWithVoucher(unitOfWork);
                            break;
                        default:
                            Console.WriteLine("Choice not supported");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

                Console.WriteLine("");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
            
        }
    }
}
