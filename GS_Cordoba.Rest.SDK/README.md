
# Cordoba
## REST API


# Overview

With the Green Solutions REST API, data of the Cordoba plant system can be accessed.

As an innovative software company, we have specialized 100% in the horticultural industry. With our cloud-based omni-channel solution, all relevant online and offline channels such as web shop, website, signage, newsletters, apps, social media, print media, etc. can be managed centrally from one system. In addition, the customer can access the huge Green Solutions database for all channels - with thousands of photos, videos, editorial reports, plant and product data.

## Contents

**[Search](#Search)**
**[Query Plant](#QueryPlant)**

# Authorization

This example shows how a connection to the middleware is defined via a vendor, a token and the endpoint.

```csharp
var var unitOfWork = new ContextUOW("<vendor>", "<token>", "<endpoint>");
// GET api/account/info
var token = unitOfWork.Account.Info(); 
```
