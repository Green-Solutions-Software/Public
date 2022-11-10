
# Plant Database
## REST API


# Overview

With the Green Solutions REST API, data of the Plant Data system can be accessed.

As an innovative software company, we have specialized 100% in the horticultural industry. With our cloud-based omni-channel solution, all relevant online and offline channels such as web shop, website, signage, newsletters, apps, social media, print media, etc. can be managed centrally from one system. In addition, the customer can access the huge Green Solutions database for all channels - with thousands of photos, videos, editorial reports, plant and product data.

## Contents

**[Authorization](#Authorization)**

**[Search Plants](#Search-Plants)**

**[Query Plant](#QueryPlant)**

**[Search Pictures](#Search-Pictures)**

**[Download Picture](#Download-Picture)**

# Authorization

This example shows how a connection to the middleware is defined via a vendor, a token and the endpoint.

```csharp
var var unitOfWork = new ContextUOW("<vendor>", "<token>", "<endpoint>");
// GET api/account/info
var token = unitOfWork.Account.Info(); 
```

# Search Plants

This example shows how to search a specific plant

```csharp
var args = new GS.Cordoba.Rest.SDK.Models.SearchArgs();
args.Types = new string[] { typeof(Plant).Name };
var plants = unitOfWork.Search.Search("acer", 1, 10, null, args).Result.Items;
```

# Query Plant

This example shows how to query a specific plant

```csharp
var plant = unitOfWork.Plants.Get(item.ID).Result;
Console.WriteLine("Name: " + plant.Name);
Console.WriteLine("Name 2: " + plant.Name2);
```

# Search Pictures

This example shows how to search a specific picture

```csharp
var args = new GS.Cordoba.Rest.SDK.Models.SearchArgs();
args.Types = new string[] { typeof(PlantPicture).Name };
var pictures = unitOfWork.Search.Search("acer", 1, 10, null, args).Result.Items;
```

# Download Picture

For safety reasons please ask for details
