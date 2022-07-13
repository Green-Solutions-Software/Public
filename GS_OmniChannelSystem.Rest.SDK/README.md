
# Omni Channel System (OCS)
## REST API


## Contents

**[Installation](#Installation)**

**[Overview](#Overview)**

**[Hints](#Hints)**

**[Functionality](#Functionality)**

**[Error handling](#Error-handling)**

**[Requirements](#Requirements)**

**[Server](#Server)**

**[Interrogate](#Interrogate)**

**[Postman](#Postman)**

**[Authorization](#Authorization)**

> [Log in](#Log-in)

**[Currencies](#Currencies)**

**[Countries](#Countries)**

**[Categories](#Categories)**

**[Reports](#Reports)**

**[Loyalty cards](#Loyalty-cards)**

> [Request new loyalty cards](#Request-new-loyalty-cards)

> [Validate new debit cards](#validate-new-debit-cards)

> [Current sales](#Current-sales)

**[Videos](#Videos)**

**[Chainstores](#Chainstores)**

**[Customers](#Customers)**

**[Article](#Article)**

> [Extended facility](#Extended-facility)

> [Transactions](#Transactions)

> [Variants](#Variants)

> [Edit dialog](#Dialog-edit)

> [Edit variant dialog](#Dialog-variant-edit)

> [Create QR - Code Linktarget](#Create-QR---Code-Linktarget)

**[Price lists](#Price-lists)**

> [Price lists - Entries](#price-list-entries)

**[Orders](#orders)**

> [All orders](#All-orders)

> [Update status](#Update-status)

> [Ship dialog](#Dialog-ship)

> [Confirm dialog](#Dialog-confirm)

> [Complete dialog](#Dialog-complete)

> [Cancel dialog](#Dialog-cancel)

> [Order management dialog](#dialog-order-management)

**[Invoices](#Invoices)**

**[Documents](#Documents)**

> [Delivery note order](#Delivery-note-order)

> [Delivery note partial order](#Delivery-note-partial-order)

**[Shipping orders](#shipping-orders)**

> [Query shipment label](#query-shipment-label)

**[Files](#Files)**

> [Upload files](#Upload-files)

> [Upload images](#Upload-images)

**[Voucher](#Voucher)**

> [Create Voucher](#Create-voucher)

> [Find coupon](#Coupon-find)

> [Reserve payment](#Payment-reserve)

> [Execute payment](#Payment-execute)

> [Cancel payment](#Payment-cancel)

> [Generate new codes](#Generate-new-codes)

> [Purchase a voucher at the POS](#Voucher-buy-at-pos)

> [Pay with a voucher at the POS](#Pay-by-voucher-at-pos)

> [Cancel voucher at the POS](#Cancel-by-voucher-am-pos)

> [Barcodes](#Barcodes)


**[Messages](#Messages)**
> [Retreive messages for an order](#Retreive-messages-for-an-order)

> [Workflows](#Workflows)

> [Find workflow for an order](#find-workflow-for-an-order)

> [Execute a workflow](#Execute-a-workflow)

> [Create a message](#Create-a-message)

**[Shopping carts](#Shopping-carts)**

**[Jobs](#Jobs)**

**[Container](#Container)**

**[Annual planning](#Annual-planning)**

**[Pictograms](#Pictograms)**

**[Search](#Search)**

**[Linked content for articles](#Linked-content-for-articles)**

**[Linked content for report](#Linked-content-for-report)**

**[Linked content for video](#Linked-content-for-video)**

**[Add External](#Add-External)**

> [Search external](#Search-external)

> [Search for an item](#Search-for-an-item)

> [Import plants](#Import-plant)

> [Import videos](#Import-videos)

> [Import reports](#Import-reports)

> [Import images](#Import-images)

> [Import plant photos](#Import-plant-photos)

**[Cache](#cache)**

> [Clear all caches](#Clear-all-caches)

> [Clear database cache](#Clear-database-cache)

> [Clean up caches](#Caches-clean-up)

**[Data structures](#Data-structures)**

> [Order](#Order)

> [Invoice](#Invoice)

> [ShipmentOrder](#Shipmentorder)

> [Article](#Article)

> [Job](#Job)

> [Payments](#Payment)

> [EntityReference](#Entityreference)

> [Vouchers](#Voucher)

> [Voucher code](#Vouchercode)

> [FoundVoucher](#Foundvoucher)

> [OrderStatusType](#Orderstatustype)

> [MessageType](#MessageType)

> [TransactionStatus](#Transactionstatus)

> [BasketType](#Baskettype)

> [MessageType](#Messagetype)

> [MessageDirection](#Messagedirection)

> [Documentation](#Documentation)

> [Item status](#Item-status)

> [Files](#File)

> [Transaction](#Transaction)

> [OrderStatus](#Orderstatus)

> [loyalty card](#Loyaltycard)

> [Result](#Result)

> [Dialog](#Dialog)

> [Upload](#Upload)

> [Messages](#Message)

> [Pricelist](#Pricelist)

> [PricelistItem](#Pricelistitem)

> [Account info](#Accountinfo)

**[Dialogs](#dialogs)**

> [To ship](#Toship)

> [Order management](#Order-management)

> [Edit article](#Edit-article)

> [Confirm order](#Confirm-order)

> [Cancel-order](#Cancel-order)

> [Complete order](#Complete-order)

**[Examples API](#Examples-API)**

> [Example application](#Example-application)

> [Request token for authentication](#Token-request-for-authentication)

> [To write an article](#To-write-an-article)

> [Query orders](#Orders-query)

# Installation

Simply install the SDK via nuget with the following command

``` powershell
Install-Package GS.PflanzenCMS.Rest.SDK -Version 1.0.0
```

# Overview

The omni channel system can be accessed via a rest api / web service.

# Hints

A session is valid indefinitely.

# Functionality

The API calls are made as a REST request, authenticated with an access token.

# Error handling

If a call fails, a json object with the error information is returned.

# Requirements

You need a user account for the omni channel system with corresponding rights to access the api.

# Server

The requests can be performed via the following URL:

https://{domain}/api/

# Interrogate

There are 6 types of requests common to all entities:

| **URL** | **method** | **Description** |
| --- | --- | --- |
| api/{entities}| GET| Query list of entities|
| api/{entities}/{id}| GET| query entity|
| api/{entities}/?ext={external\_key}| GET| Query entity based on External\_key|
| api/{entities}/{id}| PUT| update entity|
| api/{entities}| PUT| Update/create multiple entities when transferring an array|
| api/{entities}/{id}| DELETE| delete entity|
| api/{entities}| POST OFFICE| Create a new entity|

All functions expect 3 host headers:

| **headers** | **Description** |
| --- | --- |
| **tokens** | Authorization|
| **language** | language(e.g. de-DE) |
| **version** | 1.0(default) |
| **vendor** | Any name|

All functions that return lists have the following parameters:

| **Parameter** | **Description** |
| --- | --- |
| **pageIndex** | Current page|
| **pageSize** | Number of entries per page|
| **Search** | search string|
| **orderBy** | Sorting(string) |
| **filter** | filter criteria (field\|value,field2\|value) |

> **Query/update selected fields only**

When GET and PUT to an entity(Queries/Updates) a parameter "properties"

api/articles/4687?properties=Name,Name2,Photos,Keys,Keys.Info,Keys.Value,Keys.EAN,Keys.Photos

# Postman

A good tool to test the interface before implementation can be found here:

[https://www.getpostman.com/](https://www.getpostman.com/)

This allows you to try out all queries without having implemented the interface.

# Authorization

The authorization only has to be carried out once by the developer. The resulting token can then be used permanently for access without the username/password having to be transmitted again:

| **Function** | **Parameter** | **Description** |
| --- | --- | --- |
| api/account/validate|user| User name| |
| |password| password|

A token is returned as a return, which must be given in all subsequent queries.

# Log in

This method must be used to log in as a user via the app. This then provides not only a token but also information about the logged-in user.

| **Function** | **Parameter** | **Description** |
| --- | --- | --- |
| api/account/login|user| User name| |
| |password| password|

As a return, an AccountInfo is returned with all information about the logged-in user (Please refer **[Account info](#accountinfo)**).

# Currencies

| url| api/currencies|
| --- | --- |

# Countries

| url| api/countries|
| --- | --- |

# Categories

| url| api/categories|
| --- | --- |

# Reports

| url| api/reports|
| --- | --- |

# Loyalty cards

| url| api/debitcards|
| --- | --- |

## Transfer existing loyalty card owners

Transfers all existing loyalty card owners with rudimentary personal information. This information will only be used to recognize existing loyalty card owners during the loyalty card verification process.

**-> Beschreibung der Attribute, die gesetzt werden können**


**Function: GET** /api/debitcards?orderby=ValidatedOn

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **orderby** |string| Sorting| Lists the customer cards that have not yet been assigned|


## Request new loyalty cards

Returns a list with new loyalty cards. These cards had been manually registrered by the  future loyalty card owner.

Please refer **[Loyalty card](#loyaltycard)**

**Function: GET** /api/debitcards?orderby=ValidatedOn

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **orderby** |string| Sorting| Lists the customer cards that have not yet been assigned|

## Request modified personal data of loyalty card owners

Returns a list of members that have changed their personal data. With this function changes on personal data of the loyalty card owner can be hold synchronously with the external system.

**Function: POST** /api/debitcards/validate/{id}

| **Parameter** | **Type** | **Description** |
| --- | --- | --- |
| **i.e** |long| Customer card ID|
| **valid** |boolean| Valid or not|
| **errors** |string| If not valid, the reason can be given here. This text is then displayed to the customer when he tries to buy with the card. Otherwise please enter empty|
| **turnover** |doubles| Current turnover on the customer card|

## Update modified personal data of loyalty card owners

With this function the personal data of the loyalty card owners that have changed their personal data offline e.g. at the POS can be synchronized.

**Function: POST** /api/debitcards/validate/{id}

| **Parameter** | **Type** | **Description** |
| --- | --- | --- |
| **i.e** |long| Customer card ID|
| **valid** |boolean| Valid or not|
| **errors** |string| If not valid, the reason can be given here. This text is then displayed to the customer when he tries to buy with the card. Otherwise please enter empty|
| **turnover** |doubles| Current turnover on the customer card|

## Request verified loyalty cards

Returns a list with verfied loyalty cards. These cards had been manually verfied by the   loyalty card owner.

**Function: POST** /api/debitcards/validate/{id}

| **Parameter** | **Type** | **Description** |
| --- | --- | --- |
| **i.e** |long| Customer card ID|
| **valid** |boolean| Valid or not|
| **errors** |string| If not valid, the reason can be given here. This text is then displayed to the customer when he tries to buy with the card. Otherwise please enter empty|
| **turnover** |doubles| Current turnover on the customer card|


## Transfer stationary purchases

Transfers all stationary purchases of the loyalty card owner. 

**-> Beschreibung der Attribute, die gesetzt werden können**


**Function: GET** /api/debitcards?orderby=ValidatedOn

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **orderby** |string| Sorting| Lists the customer cards that have not yet been assigned|

## Update loyalty card bonus and turn over

With this function the bonus and turn ober of the loyalty card can be updated.

**Function: POST** /api/debitcards/validate/{id}

| **Parameter** | **Type** | **Description** |
| --- | --- | --- |
| **i.e** |long| Customer card ID|
| **valid** |boolean| Valid or not|
| **errors** |string| If not valid, the reason can be given here. This text is then displayed to the customer when he tries to buy with the card. Otherwise please enter empty|
| **turnover** |doubles| Current turnover on the customer card|

## Transfer bonus vouchers

Transfers all bonus vouchers the the loyalty card owners. This voucher can be redeemed online or offline.

**-> Beschreibung der Attribute, die gesetzt werden können**


**Function: GET** /api/debitcards?orderby=ValidatedOn

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **orderby** |string| Sorting| Lists the customer cards that have not yet been assigned|



# Videos

| url| api/videos|
| --- | --- |

# Chainstores

| url| api/chainstores|
| --- | --- |

# Customers

| url| api/members|
| --- | --- |

# Article

| url| api/articles|
| --- | --- |

## Extended facility

With this function, an article can be created and automatically enriched with data from the Green Solutions database.

**Function: POST** api/articles/create

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **importExternal** |boolean| Add external data?| |
| **compareNameSecondary** |boolean| compare name 2?| |

## Transactions

With this function, stocks and prices can be updated for larger quantities of items

**Function: POST** api/articles/transaction

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **BODY** |ArticleTransactionArgs[]| An array with multiple transactions| Please refer **[transactions](#transactions)** |


## Create QR - Code Linktarget

Create a new linktarget for a QR Code

**Function: POST** api/articles/create/linktarget

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| extkey |**string**| Article Number ||
| info |**string**| Article Name (e.g. Acer Palmatum) | The name is needed for the mapping to the right data|

## Variants

| url| api/articlekeys|
| --- | --- |

## Edit dialog

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/articles/dialog/{id}|ID| **long** | ID of the item to be edited|

As a return, the dialog is returned (please refer **[dialog](#dialog)** and **[Edit article](#Edit-article)** )

## Edit variant dialog

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/articles/dialog/key/{id}|ID| **long** | ID of the variant to be processed|

As a return, the dialog is returned (please refer **[dialog](#dialog)**)

# Price lists

Price lists / listings with customer-specific prices(please refer **[pricelist](#pricelist)**)

| url| api/pricelists|
| --- | --- |

# Price List Entries

The entries correspond to the articles in the price list(please refer **[PricelistItem](#pricelistitem)**).
The keys of the variants of the articles with the individual prices

| url| api/pricelistitems|
| --- | --- |
| filter| pricelistid|

# Orders

| **url** | **api/orders** |
| --- | --- |
| filter| ownermemberid|

## All orders


> This function is only allowed by users within the main account of the shop! Otherwise, a corresponding error is raised.

| **url** | **api/orders/all** |
| --- | --- |

**Filters**

| Filter | Type | Description |
| --- | --- | --- |
| status | **[OrderStatusType](#OrderStatusType)**| Filters by the given Order Status|
| channelid| **long**| ID of the Channel|


## Update Status

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/orders/transactions/status/{ID}|ID| **long** | ID of the order| |
|BODY| **status message** | please refer **[OrderStatus](#orderstatus)** |

As a return, the order will be returned (please refer **[order](#order)** )

## Ship dialog

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/orders/transactions/dialog/delivered/{id}|ID| **long** | ID of the transaction of the order(must be sent) |

As a return, the dialog is returned (please refer **[dialog](#dialog)** and**[To ship](##to ship)** )

## Confirm dialog

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/orders/dialog/confirm/{id}|ID| **long** | ID of the order|

As a return, the dialog is returned (please refer **[dialog](#dialog)** and **[confirm order](#confirm-order)**)

## Complete dialog

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/orders/dialog/finish/{id}|ID| **long** | ID of the order|

As a return, the dialog is returned (please refer **[dialog](#dialog) and **[complete order](#order-complete)** )

## Cancel dialog

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/orders/dialog/cancel/{id}|ID| **long** | ID of the order|

As a return, the dialog is returned (please refer **[dialog](#dialog) and**[cancel order](#cancel-order)** )

## Order management dialog

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/orders/dialog| | | |

As a return, the dialog is returned (please refer **[dialog](#dialog) and **[order management](#order-management)** )

## All orders


> This function is only allowed by users within the main account of the shop! Otherwise, a corresponding error is raised.


| url| api/orders/all|
| --- | --- |

# Invoices

| **url** | **api/invoices** |
| --- | --- |


# Documents

## Delivery note order

Delivers the delivery note for an order.

Please note that you will only receive the items that have been confirmed, so this function may only be called up after the order has been confirmed.

| **Function(GET)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/documents/order/{orderid}/{type}|orderid| **long** | ID of the order|
| |type| **string** | DeliverySlip|
| | output| | DOCX, PDF|

## Delivery note partial order

Delivers the delivery note for a partial order.

Please note that you will only receive the items that have been confirmed, so this function may only be called up after the order has been confirmed.

| **Function(GET)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/documents/order/{orderid}/{type}/{transactionid}|orderid| **long** | ID of the order| |
|type| **string** | DeliverySlip| |
|transactionid| **long** | ID of the partial order| |
|output|**string**| DOCX, PDF|

# Shipping orders

Contains a list of all shipping orders in the system. Each shipping order can contain several items(broadcasts)

| url| api/shipment orders|
| --- | --- |

please refer **[ShipmentOrder](#shipmentorder)**

## Query package label

The parcel label can be queried with this function. To do this, pass one of the ShipmentOrderID of the shipping order(please refer **[ShipmentOrder](#shipmentorder)** )

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/shipmentorders/items/label/{id}|ID| **long** | Shipment ID|

The pdf is returned as a return

# Files

| url| api/datafiles|
| --- | --- |

## Upload files

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/datafiles/upload|BODY| **Upload** | please refer **[Upload](#upload)** |

The file is returned as a return(please refer **[File](#file)** )

## Upload images

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/pictures/upload|BODY| **Upload** | please refer **[Upload](#upload)** |

The file is returned as a return(please refer **[Files](#file)** )

# Voucher

| url| api/vouchers| |
| --- | --- | --- |

## Create voucher

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/vouchers/create|Surname| **string** | Name for the new voucher| |
|amount| **double** | amount| |
|name| **string** | currency(e.g. EUR) | |
|info| **string** | An information that is visibly stored with the voucher| |
|deleted| **boolean** | Create deleted|

The voucher will be returned as a return(please refer **[vouchers](#voucher)** ).

## Find voucher

| **Function(GET)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/vouchers/find|keyValue| **string** | Coupon Code(without space) |

Return: voucher code(please refer **[FoundVoucher](#foundvoucher)** )

## Reserve payment

Reserve a payment for a voucher. During the time, the revenue is considered consumed until the time expires and cannot be used elsewhere.

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/vouchers/reserve|voucherID| **long** | Voucher ID| |
|voucherCodeID| **long** | Voucher Code ID| |
|amount| **double** | Amount to be reserved| |
|name| **string** | currency(e.g. EUR) | |
|info| **string** | An information that is visible when paying| |
|minutes| **internal** | Number of minutes for which the payment should be reserved|

As a return, the created payment is returned (please refer **[payments](#payment)** ).

## Execute payment

After a payment has been reserved, the payment can then be made(during the time of reservation)

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/vouchers/pay|paymentid| **long** | Payment ID(please refer **[payments](#payment)** ) |

The voucher will be returned as a return(please refer **[vouchers](#voucher)** ).

## Cancel payment

Cancel a payment for a voucher

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/vouchers/cancel|voucherID| **long** | Voucher ID| |
|voucherCodeID| **long** | Voucher Code ID| |
|amount| **double** | Amount to be reserved| |
|name| **string** | currency(e.g. EUR) | |
|info| **string** | An information that is visible when paying| |

As a return, the created payment is returned (please refer **[payments](#payment)** ).

## Generate new codes

Generates new codes without creating them in the database(for your own printed vouchers)

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/vouchers/generate/codes|count| **internal** | number of codes| |

Returns: A list of voucher codes(please refer **[voucher code](#voucher code)**)

## Purchase a voucher at the POS

The customer buys a voucher offline and this is then sent by **[Create Voucher](#create voucher)** created online.

## Pay with a voucher at the POS

The customer buys offline and pays with an online voucher. First the voucher is searched for(**[find coupon](#coupon-find)**).
If none is found, the voucher is not a valid online voucher. If one is found, the
desired payment can be reserved (**[Reserve payment](#Reserve-payment)**). If the balance is no longer sufficient, a
appropriate error returned. After completing the payment then the payment
accomplished (**[Execute payment](#Execute-payment)**). The voucher is now available online

## Cancel voucher at the POS

The customer cancels a product offline that was paid for with a voucher. Now this payment is also canceled online(**[Cancel payment](#cancel-payment)**).

## Barcodes

The following barcode types are currently available for printing:
- code 128
- EAN 13

# Messages

Data is exchanged between the web shop and the supplier via messages.
Each message can have one of the **[MessageType](#messagetype)** have defined types. Outgoing or incoming messages can be generated(please refer **[MessageDirection](#messagedirection)**).
For an outgoing message, please set the "receiver" and for incoming messages the "sender".

> Please note that some messages are intended as an answer to an incoming message and therefore have to be linked with each other via "Parent".

| url| api/messages| |
| --- | --- | --- |

please refer **[messages](#message)**

## Retreive messages for an order

Retreives all messages for an order

| **Function(GET)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/messages/order/{id}|id| **long** | ID of the Order|

please refer **[messages](#message)**

## Create a message

> Please note that this is not the recommended way. Use **[Workflows](#workflows)** instead.



| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/messages/create|BODY| **[messages](#message)** | Message to be created|

The following fields must be set in the message:
|**Surname** |**Type** |**value** |**Description** |
| --- | --- | --- | --- |
|Direction|**short** | | Outgoing or incoming |
|Type|**short** | |(please refer **[MessageType](#messagetype)**) |
|Keys|**string** | | key for reference |
|transmitter|**[EntityReference](#entityreference)**| | Sender |
|receivers|**[EntityReference](#entityreference)**| | Receiver |
|Parent|**[EntityReference](#entityreference)**| | Parent Message |
|SenderConfirm|**boolean** | | Send confirmation by mail after dispatch |

The created message is returned as a return (please refer **[messages](#message)**). This is then sent to the recipient with the next job that processes the messages.

**Attention:** The recommended way to create new messages is to use our Workflow API which takes care of several conditions

## Workflows

You can retreive a workflow for a defined message. This workflow defines "replys" you could submit

| **Function(GET)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/messages/{id}/workflow|id| **long** | ID of the message you want to reply|

Returns an Array of **[Workflow](#workflow)** to choose from

## Find workflow for an order

To send a specific message you first need to find a fitting workflow

| **Function(GET)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/messages/order/{id}/workflow|id| **long** | ID of the Order you want to reply to|
||type| **[MessageType](#MessageType)** | Type of message you want to submit |

Returns an **[Workflow](#workflow)**

## Execute a workflow

This method creates the Reply message depending on a Workflow

| **Function(POST)** | **Parameter** | **Type** | **Description** |
| --- | --- | --- | --- |
| api/messages/{id}/workflow/execute|id| **long** | ID of the message you want to reply|
||BODY| **[Workflow](#workflow)** | the Workflow to execute|

Returns an **[Messsage](#Messsage)** with the newly created Reply Message

# Shopping carts

| url| api/baskets| |
| --- | --- | --- |

## Filter

| Surname| Type| value| description|
| --- | --- | --- | --- |
| type| **BasketType** | | please refer **[BasketType](#baskettype)** |
| memberid| **long** | | MemberID to filter by|
| my| **boolean** | true/false| Own records only|

## Sorting
| Surname|description|
| --- | --- |
| BasketID| Sort by ID|


# Jobs

| url| api/jobs|
| --- | --- |

# Container

| url| api/containers| |
| --- | --- | --- |
| key| api/containers/key/{key}| Find container with key|
| items| API/containers/items/{id}| All entries of a container(including paging) |

# Annual planning

| url| api/timelines| |
| --- | --- | --- |
| key| api/timelines/key/{key}| Search planning with key|
| items| api/timelines/items/{id}| All entries of a plan(including paging) |
| Current| api/timelines/current/{id}| All current entries of a plan(including paging) |

# Pictograms

**Function:** api/pictos/{id}

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **i.e** | long| Article ID| Article for which the pictogram is to be queried|
| **width** | internal| Broad| px|
| **height** | internal| Height| px|

**Return:**

A list of all valid pictograms for the selected item

**Definition:**

| **Field** | **Type** | **Description** |
| --- | --- | --- |
| Surname| string| Pictogram name(shown in bold below/next to the pictogram)e.g. "Location|
| text| string| Text of the pictogram(displayed below/next to the name)e.g. "Sunny|
| key| string| Unique Key|
| url| string| URL for the graphic|
| PictoID| long| primary key|

# Search

**Function:** api/search

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **search** |string| search term| |
| **orderBy** |string| Title, Title2| |
| **type** |string| Article, report, video| Can also be specified multiple times, e.g. Types=Article|
| **BloomingTimeFrom** |internal| heyday of| months|
| **BloomingTimeTo** |internal| heyday to| months|
| **WidthFrom** |double| width of| cm|
| **WidthTo** |double| width to| cm|
| **HeightTo** |double| Height of| cm|
| **HeightFrom** |double| height up to| cm|
| **WeightFrom** |double| weight of| kg|
| **WeightTo** |double| weight up| kg|
| **GrowthFrom** |double| growth of| cm|
| **GrowthTo** |double| increase up to| cm|
| **FeatureIds** |long[]| features| ID#39;s of the characteristics(see Admin/Features) |

# Linked content for articles

**Function:** api/cross/articles{id}

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **i.e** |long| Article ID| |
| **search** |string| search term| |
| **orderBy** |string| Title, Title2| |
| **type** |string| Article, report, video| Can also be specified multiple times, e.g. Types=Article|

# Linked content for reports

**Function:** api/cross/reports/{id}

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **i.e** |long| ID of the report| |
| **search** |string| search term| |
| **orderBy** |string| Title, Title2| |
| **type** |string| Article, report, video| Can also be specified multiple times, e.g. Types=Article|

# Linked content for videos

**Function:** api/cross/videos/{id}

| **Parameter** | **Type** | **Description** | **Remark** |
| --- | --- | --- | --- |
| **i.e** |long| ID of the video| |
| **search** |string| search term| |
| **orderBy** |string| Title, Title2| |
| **type** |string| Article, report, video| Can also be specified multiple times, e.g. Types=Article|

# Add External

This function can be used to search for content from the Green Solutions database and import it into the local CMS database. See Add External

## Search external

**Function:** api/external/search

|pageIndex| Current page|
| --- | --- |
|pageSize| Number of entries per page|
|search| search string|
|orderBy| Sorting(string) |

**Return:**

A list of all external search results

## Search for an article

**Function:** api/external/search/article

|Surname| Article name(e.g. Acer Palmatum Bloodgood) |
| --- | --- |

**Return:**
The most suitable item

## Import plants

**Function:** api/external/import/plants/{id}

|i.e| External ID of the plant to be imported|
| --- | --- |
|to|ID of the article to be imported into(optional)|

## Import videos

**Function:** api/external/import/videos/{id}

|i.e| External ID of the video to be imported|
| --- | --- |

## Import reports

**Function:** api/external/import/reports/{id}

|i.e| External ID of the report to be imported|
| --- | --- |

## Import images

**Function:** api/external/import/pictures/{id}

|i.e| External ID of the image to be imported|
| --- | --- |

## Import plant photos

**Function:** api/external/import/plantpictures/{id}

|i.e| External ID of the plant photo to be imported|
| --- | --- |

# Cache

To improve performance, the system works with some caches that must be deleted if necessary. Currently there are the following caches:

- Database
- session
- search index
- sitemaps

As soon as cached content has been changed in the database, the corresponding cache should be deleted so that the change is immediately visible.

## Clear all caches

**Function:** POST api/cache/clear

## Clear database cache

**Function:** POST api/cache/clear/efcache

## Clean up caches

**Function:** POST api/cache/purge

# Data structures

## Order

```json
{
  "OrderID": 174,
  "Voucher": null,
  "VoucherCode": null,
  "InvoiceAddress": {
    "ContactAddressID": 6,
    "Type": 1,
    "Address": {
      "AddressID": 7,
      "Street": "Bahnhofstraße",
      "HouseNumber": "62b",
      "Zip": "26835",
      "City": "Hesel",
      "Postbox": null,
      "Country": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#58#151"
      },
      "Type": 1,
      "Longitude": null,
      "Latitude": null,
      "External_Key": null,
      "External_COR_ID": null
    },
    "Contact": {
      "ContactID": 23,
      "Picture": null,
      "Apellation": 1,
      "FirstName": "Kevin",
      "LastName": "Klaassen",
      "Phone": "1325513154712",
      "Mobile": null,
      "Fax": null,
      "Position": null,
      "Homepage": null,
      "EMail": "jhaghjs@bjkafgs.de",
      "Company": null,
      "Company2": null,
      "Language": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#44#148"
      },
      "External_Key": null,
      "External_COR_ID": null
    },
    "Member": {
      "ID": 0,
      "RowVersion": "#0#0#0#0#0#2#66#134"
    },
    "External_Key": null,
    "External_COR_ID": null
  },
  "ShippingAddress": {
    "ContactAddressID": 9,
    "Type": 2,
    "Address": {
      "AddressID": 10,
      "Street": "gdsshgdshd",
      "HouseNumber": "235253",
      "Zip": "23789",
      "City": "hsdshdshd",
      "Postbox": "23236263",
      "Country": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#58#151"
      },
      "Type": 2,
      "Longitude": null,
      "Latitude": null,
      "External_Key": null,
      "External_COR_ID": null
    },
    "Contact": {
      "ContactID": 26,
      "Picture": null,
      "Apellation": 0,
      "FirstName": "asgagsgas",
      "LastName": "asgagsga",
      "Phone": "23524362643",
      "Mobile": null,
      "Fax": null,
      "Position": null,
      "Homepage": null,
      "EMail": "gaf@bkjfas.de",
      "Company": "gasgas",
      "Company2": null,
      "Language": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#44#148"
      },
      "External_Key": null,
      "External_COR_ID": null
    },
    "Member": {
      "ID": 0,
      "RowVersion": "#0#0#0#0#0#2#66#134"
    },
    "External_Key": null,
    "External_COR_ID": null
  },
  "Status": 1,
  "TotalCostsArticles": 27.799999999999997,
  "TotalTaxCosts1": 1.24,
  "TaxRate1": {
    "ID": 0,
    "RowVersion": "#0#0#0#0#0#0#230#203"
  },
  "TotalTaxCosts2": 1.42,
  "TaxRate2": {
    "ID": 0,
    "RowVersion": "#0#0#0#0#0#1#231#2"
  },
  "TotalCosts": 44.789999999999992,
  "TaxRateDeliver": {
    "ID": 0,
    "RowVersion": "#0#0#0#0#0#0#230#203"
  },
  "TotalTaxCostsDeliver": 1.11,
  "TotalCostsDeliver": 16.99,
  "TotalDiscount": 0,
  "ApprovedBy": {
    "ID": 0,
    "RowVersion": "#0#0#0#0#0#2#58#153"
  },
  "ApprovedOn": "2017-01-30T15:56:59.677",
  "Notes": null,
  "File": null,
  "Currency": {
    "ID": 0,
    "RowVersion": "#0#0#0#0#0#0#77#11"
  },
  "Items": [{
      "OrderItemID": 199,
      "ArticleGroups": null,
      "Date": "2017-01-30T15:56:59.533",
      "DeliveryDate": "2017-02-06T15:56:59.583",
      "Info": "Rhododendron 'Abendsonne'",
      "Info2": "Rhododendron 'Abendsonne'",
      "Photo": null,
      "ArticleKey": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#39#45"
      },
      "Vouchers": [{
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#230#203"
      }]
      "Article": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#39#91"
      },
      "Notes": null,
      "Type": 0,
      "Price": 18.9,
      "Stock": false,
      "DropShip": false,
      "Currency": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#77#11"
      },
      "Quantity": 1,
      "Rated": null,
      "RatedBy": null,
      "Position": 0,
      "TotalPrice": 18.9,
      "TotalCosts": 18.9,
      "TaxRate": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#230#203"
      },
      "Glyph": null,
      "TransactionType": 0,
      "External_Key": null,
      "External_COR_ID": null
    },
    {
      "OrderItemID": 200,
      "ArticleGroups": null,
      "Date": "2017-01-30T15:56:59.583",
      "DeliveryDate": "2017-02-06T15:56:59.63",
      "Info": "Frux Rhododendron- & Moorbeeterde",
      "Info2": "",
      "Photo": null,
      "ArticleKey": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#15#80"
      },
      "Article": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#223#163"
      },
      "Notes": null,
      "Type": 0,
      "Price": 8.9,
      "Stock": false,
      "DropShip": false,
      "Currency": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#77#11"
      },
      "Quantity": 1,
      "Rated": null,
      "RatedBy": null,
      "Position": 1,
      "TotalPrice": 8.9,
      "TotalCosts": 8.9,
      "TaxRate": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#1#231#2"
      },
      "Glyph": null,
      "TransactionType": 0,
      "External_Key": null,
      "External_COR_ID": null
    },
    {
      "OrderItemID": 201,
      "ArticleGroups": null,
      "Date": "2017-01-30T15:56:59.63",
      "DeliveryDate": "2017-02-06T15:56:59.677",
      "Info": "Floragard Rhodohum",
      "Info2": "",
      "Photo": null,
      "ArticleKey": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#15#76"
      },
      "Article": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#19#103"
      },
      "Notes": null,
      "Type": 0,
      "Price": 14.95,
      "Stock": false,
      "DropShip": false,
      "Currency": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#77#11"
      },
      "Quantity": 3,
      "Rated": null,
      "RatedBy": null,
      "Position": 2,
      "TotalPrice": 44.849999999999994,
      "TotalCosts": 44.849999999999994,
      "TaxRate": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#1#231#2"
      },
      "Glyph": null,
      "TransactionType": 0,
      "External_Key": null,
      "External_COR_ID": null
    }
  ],
  "Transactions": [{
    "OrderTransactionID": 90,
    "DeliveredTrackAndTraceID": null,
    "DeliveredTrackAndTraceURL": null,
    "Status": 0,
    "StatusOn": null,
    "Type": 0,
    "ShippingAddress": {
      "ContactAddressID": 9,
      "Type": 2,
      "Address": {
        "AddressID": 10,
        "Street": "gdsshgdshd",
        "HouseNumber": "235253",
        "Zip": "23789",
        "City": "hsdshdshd",
        "Postbox": "23236263",
        "Country": {
          "ID": 0,
          "RowVersion": "#0#0#0#0#0#2#58#151"
        },
        "Type": 2,
        "Longitude": null,
        "Latitude": null,
        "External_Key": null,
        "External_COR_ID": null
      },
      "Contact": {
        "ContactID": 26,
        "Picture": null,
        "Apellation": 0,
        "FirstName": "asgagsgas",
        "LastName": "asgagsga",
        "Phone": "23524362643",
        "Mobile": null,
        "Fax": null,
        "Position": null,
        "Homepage": null,
        "EMail": "gaf@bkjfas.de",
        "Company": "gasgas",
        "Company2": null,
        "Language": {
          "ID": 0,
          "RowVersion": "#0#0#0#0#0#2#44#148"
        },
        "External_Key": null,
        "External_COR_ID": null
      },
      "Member": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#66#134"
      },
      "External_Key": null,
      "External_COR_ID": null
    },
    "ShippingMethod": {
      "ContactAddressID": 0,
      "Type": 0,
      "Address": null,
      "Contact": null,
      "Member": null,
      "External_Key": null,
      "External_COR_ID": null
    },
    "External_Key": null,
    "External_COR_ID": null
  }],
  "ShippingMethod": {
    "ID": 0,
    "RowVersion": "#0#0#0#0#0#0#202#162"
  },
  "External_Key": null,
  "External_COR_ID": null
}
```

## Invoice

```json
{
    "InvoiceID": 1,
    "Number": "2020-101",
    "TaxPlus": false,
    "Date": "2020-03-24T00:00:00",
    "Type": 0,
    "AutomaticallyCreated": false,
    "Text": "Einkauf vom 24.03.2020",
    "Notes": null,
    "CancelationNote": null,
    "Description": null,
    "DeliveryDate": "2020-03-24T00:00:00",
    "Language": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#56#241#21",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": 1
    },
    "Currency": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#11#203#34",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": null
    },
    "State": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#13#50#17",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": null
    },
    "Member": {
        "ID": 2,
        "RowVersion": "#0#0#0#0#0#42#198#71",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": null
    },
    "DebitCard": null,
    "Address": {
        "ID": 2,
        "RowVersion": "#0#0#0#0#0#11#190#161",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": null
    },
    "Sequence": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#25#167#164",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": null
    },
    "SequenceItem": {
        "ID": 2,
        "RowVersion": "#0#0#0#0#0#25#167#145",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": null
    },
    "Positions": [
        {
            "InvoicePositionID": 1,
            "Quantity": 1,
            "Price": 5.0,
            "Currency": {
                "ID": 1,
                "RowVersion": "#0#0#0#0#0#11#203#34",
                "External_Key": null,
                "External_RowVersion": null,
                "External_COR_ID": null
            },
            "TotalPrice": 5.0,
            "TaxCosts": 0.8,
            "TaxRate": {
                "Percent": 19.0,
                "ID": 1,
                "RowVersion": "#0#0#0#0#0#57#28#97",
                "External_Key": "Helsinki#1",
                "External_RowVersion": "#0#0#0#0#0#0#10#230",
                "External_COR_ID": null
            },
            "TaxIncluded": true,
            "Text": "AKTIV-ERDE Bio-Erde",
            "Text2": null,
            "BeginDate": null,
            "EndDate": null,
            "OrderItem": {
                "ID": 3,
                "RowVersion": "#0#0#0#0#0#13#60#36",
                "External_Key": null,
                "External_RowVersion": null,
                "External_COR_ID": null
            },
            "BookAccount": null,
            "State": null,
            "ArticleKey": null,
            "Article": null,
            "External_Key": null,
            "External_RowVersion": null,
            "External_COR_ID": null,
            "External_DM_ID": null,
            "External_COR_Owner": null,
            "RowVersion": "#0#0#0#0#0#13#49#224",
            "Deleted": false
        }
    ],
    "States": [
        {
            "InvoiceStateID": 1,
            "State": 0,
            "PaymentDate": "2020-04-03T07:05:39.89",
            "DueDate": "2020-04-03T07:05:39.89",
            "Document": null,
            "External_Key": null,
            "External_RowVersion": null,
            "External_COR_ID": null,
            "External_DM_ID": null,
            "External_COR_Owner": null,
            "RowVersion": "#0#0#0#0#0#13#50#17",
            "Deleted": false
        }
    ],
    "Payments": [
        {
            "PaymentID": 25,
            "ReservedUntil": null,
            "Info": "Banküberweisung vom 07.08.2020",
            "Price": -99.99,
            "Currency": {
                "ID": 1,
                "RowVersion": "#0#0#0#0#0#11#203#34",
                "External_Key": null,
                "External_RowVersion": null,
                "External_COR_ID": null
            },
            "VoucherCode": null,
            "PaymentMethod": {
                "ID": 3,
                "RowVersion": "#0#0#0#0#0#61#135#153",
                "External_Key": "Helsinki#3",
                "External_RowVersion": "#0#0#0#0#0#3#116#216",
                "External_COR_ID": null
            },
            "External_Key": "DE33700800850002222222#240409241",
            "External_RowVersion": null,
            "External_COR_ID": null,
            "External_DM_ID": null,
            "External_COR_Owner": null,
            "RowVersion": "#0#0#0#0#0#26#144#113",
            "Deleted": true
        },
        {
            "PaymentID": 26,
            "ReservedUntil": null,
            "Info": "Banküberweisung vom 07.08.2020",
            "Price": 5.0,
            "Currency": {
                "ID": 1,
                "RowVersion": "#0#0#0#0#0#11#203#34",
                "External_Key": null,
                "External_RowVersion": null,
                "External_COR_ID": null
            },
            "VoucherCode": null,
            "PaymentMethod": {
                "ID": 3,
                "RowVersion": "#0#0#0#0#0#61#135#153",
                "External_Key": "Helsinki#3",
                "External_RowVersion": "#0#0#0#0#0#3#116#216",
                "External_COR_ID": null
            },
            "External_Key": "DE33700800850002222222#240409241",
            "External_RowVersion": null,
            "External_COR_ID": null,
            "External_DM_ID": null,
            "External_COR_Owner": null,
            "RowVersion": "#0#0#0#0#0#26#144#123",
            "Deleted": true
        },
        {
            "PaymentID": 27,
            "ReservedUntil": null,
            "Info": "Banküberweisung vom 21.07.2020",
            "Price": 5.0,
            "Currency": {
                "ID": 1,
                "RowVersion": "#0#0#0#0#0#11#203#34",
                "External_Key": null,
                "External_RowVersion": null,
                "External_COR_ID": null
            },
            "VoucherCode": null,
            "PaymentMethod": {
                "ID": 3,
                "RowVersion": "#0#0#0#0#0#61#135#153",
                "External_Key": "Helsinki#3",
                "External_RowVersion": "#0#0#0#0#0#3#116#216",
                "External_COR_ID": null
            },
            "External_Key": "DE33700800850002222222#240409223",
            "External_RowVersion": null,
            "External_COR_ID": null,
            "External_DM_ID": null,
            "External_COR_Owner": null,
            "RowVersion": "#0#0#0#0#0#26#144#130",
            "Deleted": true
        },
        {
            "PaymentID": 28,
            "ReservedUntil": null,
            "Info": "Banküberweisung vom 21.07.2020",
            "Price": 5.0,
            "Currency": {
                "ID": 1,
                "RowVersion": "#0#0#0#0#0#11#203#34",
                "External_Key": null,
                "External_RowVersion": null,
                "External_COR_ID": null
            },
            "VoucherCode": null,
            "PaymentMethod": {
                "ID": 3,
                "RowVersion": "#0#0#0#0#0#61#135#153",
                "External_Key": "Helsinki#3",
                "External_RowVersion": "#0#0#0#0#0#3#116#216",
                "External_COR_ID": null
            },
            "External_Key": "DE33700800850002222222#240409223",
            "External_RowVersion": null,
            "External_COR_ID": null,
            "External_DM_ID": null,
            "External_COR_Owner": null,
            "RowVersion": "#0#0#0#0#0#26#144#132",
            "Deleted": false
        }
    ],
    "Orders": [],
    "PaydOn": "2020-03-24T08:05:02.467",
    "DubiosOn": null,
    "PaymentMethod": {
        "ID": 3,
        "RowVersion": "#0#0#0#0#0#61#135#153",
        "External_Key": "Helsinki#3",
        "External_RowVersion": "#0#0#0#0#0#3#116#216",
        "External_COR_ID": null
    },
    "TotalPriceNet": 4.2016806722689077,
    "TotalPriceGros": 5.0,
    "TotalPaid": 5.0,
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null,
    "External_DM_ID": null,
    "External_COR_Owner": null,
    "RowVersion": "#0#0#0#0#0#26#144#131",
    "Deleted": false
}
```

## ShipmentOrder
```json
{
  "ShipmentOrderID": 18,
  "Name": "Versand für 2018-241",
  "Items": [{
    "ShipmentOrderItemID": 16,
    "Number": "222201010028682105",
    "Transaction": {
      "ID": 145,
      "RowVersion": "#0#0#0#0#0#9#45#2",
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null
    },
    "ShipmentOrder": {
      "ID": 18,
      "RowVersion": "#0#0#0#0#0#9#45#3",
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null
    },
    "WeightInKg": 10,
    "LengthInCM": null,
    "WidthInCM": null,
    "HeightInCM": null,
    "Data": "{}",
    "TakenOn": "2018-04-23T08:52:48.913",
    "CancelledOn": null,
    "HasShipmentLabel": true,
    "HasReturnLabel": false,
    "HasExportLabel": false,
    "HasCodeLabel": false,
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null,
    "External_DM_ID": null,
    "External_COR_Owner": null,
    "RowVersion": "#0#0#0#0#0#9#44#253",
    "Deleted": false
  }],
  "PaymentMethod": null,
  "ShippingMethod": {
    "ID": 3,
    "RowVersion": "#0#0#0#0#0#9#44#222",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Member": {
    "ID": 1,
    "RowVersion": "#0#0#0#0#0#9#45#9",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "AddressFrom": {
    "ContactAddressID": 73,
    "Type": 2,
    "Address": {
      "AddressID": 78,
      "Street": "Bahnhofstraße",
      "HouseNumber": "1",
      "Zip": "26129",
      "City": "Musterhausen",
      "Postbox": null,
      "Country": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#6#134#52",
        "External_Key": null,
        "External_RowVersion": "#0#0#0#0#0#0#7#211",
        "External_COR_ID": null
      },
      "Type": 2,
      "Longitude": null,
      "Latitude": null,
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null,
      "External_DM_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#9#44#125",
      "Deleted": false
    },
    "Contact": {
      "ContactID": 216,
      "Picture": null,
      "Apellation": 1,
      "FirstName": "Max",
      "LastName": "Mustermann",
      "Phone": "0123456789",
      "Mobile": null,
      "Fax": null,
      "Position": null,
      "Homepage": null,
      "EMail": "tt@tt.de",
      "Company": null,
      "DisplayText": null,
      "Language": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#6#100#222",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": 1
      },
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null,
      "External_DM_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#9#44#126",
      "Deleted": false
    },
    "Member": {
      "ID": 1,
      "RowVersion": "#0#0#0#0#0#9#45#9",
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null
    },
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null,
    "External_DM_ID": null,
    "External_COR_Owner": null,
    "RowVersion": "#0#0#0#0#0#9#44#127",
    "Deleted": false
  },
  "AddressTo": {
    "ContactAddressID": 9,
    "Type": 2,
    "Address": {
      "AddressID": 10,
      "Street": "gdsshgdshd",
      "HouseNumber": "235253",
      "Zip": "23789",
      "City": "hsdshdshd",
      "Postbox": "23236263",
      "Country": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#6#134#52",
        "External_Key": null,
        "External_RowVersion": "#0#0#0#0#0#0#7#211",
        "External_COR_ID": null
      },
      "Type": 2,
      "Longitude": null,
      "Latitude": null,
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null,
      "External_DM_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#2#35#228",
      "Deleted": false
    },
    "Contact": {
      "ContactID": 26,
      "Picture": null,
      "Apellation": 0,
      "FirstName": "asgagsgas",
      "LastName": "asgagsga",
      "Phone": "23524362643",
      "Mobile": null,
      "Fax": null,
      "Position": null,
      "Homepage": null,
      "EMail": "gaf@bkjfas.de",
      "Company": "gasgas",
      "DisplayText": null,
      "Language": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#6#100#222",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": 1
      },
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null,
      "External_DM_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#0#76#25",
      "Deleted": false
    },
    "Member": {
      "ID": 1,
      "RowVersion": "#0#0#0#0#0#9#45#9",
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null
    },
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null,
    "External_DM_ID": null,
    "External_COR_Owner": null,
    "RowVersion": "#0#0#0#0#0#2#35#231",
    "Deleted": false
  },
  "Order": {
    "ID": 241,
    "RowVersion": "#0#0#0#0#0#9#45#1",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Transaction": {
    "ID": 145,
    "RowVersion": "#0#0#0#0#0#9#45#2",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Date": "2018-04-24T00:00:00",
  "TakenOn": "2018-04-23T08:52:48.913",
  "CancelledOn": null,
  "Data": "{\"Product\":0}",
  "External_Key": null,
  "External_RowVersion": null,
  "External_COR_ID": null,
  "External_DM_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#9#45#3",
  "Deleted": false
}
```

## Article
```json
{
  "ArticleID": 1375,
  "Name": "Abies koreana 'Veredelung'",
  "Name2": "Koreatanne 'Veredelung'",
  "Description": "Zierliche Tanne für kleine Gärten, zeigt sehr früh\nzierende Zapfen, hart.\n",
  "ShortDescription": null,
  "Photos": [],
  "ArticleGroups": [],
  "Categories": [{
    "ID": 0,
    "RowVersion": "#0#0#0#0#0#2#15#209"
  }],
  "Countries": [],
  "Available": [],
  "Keys": [{
    "ArticleKeyID": 1291,
    "Info": "Sol C 20  125- 150",
    "Value": "98820121",
    "Decimals": 0,
    "PackingUnit": 0,
    "PackingSize": null,
    "PackingUnitType": 0,
    "PackingForm": null,
    "DeliverSize": null,
    "DeliverUnitType": null,
    "DeliverType": null,
    "StockQuantity": 1,
    "EAN": "4011266062981",
    "Country": {
      "ID": 0,
      "RowVersion": "#0#0#0#0#0#2#58#151"
    },
    "TaxRate": {
      "ID": 0,
      "RowVersion": "#0#0#0#0#0#0#230#203"
    },
    "AvailableForShippingText": null,
    "AvailableForShippingDeliverTime": null,
    "AvailableForRadiusDeliveryText": null,
    "AvailableForClickAndCollectText": null,
    "GrowthFrom": null,
    "GrowthTo": null,
    "WeightFrom": null,
    "WeightTo": null,
    "WidthFrom": null,
    "WidthTo": null,
    "HeightFrom": null,
    "HeightTo": null,
    "DeliverHeightFrom": null,
    "DeliverHeightTo": null,
    "LengthFrom": null,
    "LengthTo": null,
    "DepthFrom": null,
    "DepthTo": null,
    "PotSize": null,
    "PotSizeL": null,
    "FillAmountFrom": null,
    "FillAmountTo": null,
    "DiameterFrom": null,
    "DiameterTo": null,
    "LoadingCapacityFrom": null,
    "LoadingCapacityTo": null,
    "BloomingTimeFrom": null,
    "BloomingTimeTo": null,
    "BloomingTimePeriod": null,
    "BloomingTimePeriod2": null,
    "Size": null,
    "Quality": null,
    "Features": [],
    "Tasks": [],
    "Grower": null,
    "Brand": null,
    "BotanicName": null,
    "NameTranslation": null,
    "Photos": [],
    "Prices": [{
      "ArticleKeyPriceID": 1712,
      "Quantity": 0,
      "Price": 189.5,
      "PriceUnitAmount": null,
      "ValueUnitType": null,
      "PriceOld": null,
      "PriceNet": false,
      "TaxIncluded": true,
      "Currency": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#0#77#11"
      },
      "External_Key": null,
      "External_COR_ID": null
    }],
    "Attachments": [],
    "Available": [],
    "CustomFields": [{
      "CustomFieldID": 1061,
      "Field": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#34#20"
      },
      "StringValue": "P",
      "IntValue": null,
      "DateValue": null,
      "FloatValue": null,
      "BoolValue": null,
      "External_Key": null,
      "External_COR_ID": null
    }],
    "Inactive": false,
    "AvailableForShipping": true,
    "AvailableForRadiusDelivery": false,
    "AvailableForClickAndCollect": false,
    "AvailableForMarketPlaces": false,
    "External_Key": "98820121",
    "External_COR_ID": null
  }],
  "Texts": [{
      "ArticleTextID": 14006,
      "Position": 0,
      "Type": 31,
      "Title": null,
      "Value": "Zierliche Tanne für kleine Gärten, zeigt sehr früh\nzierende Zapfen, hart.\n",
      "External_Key": null,
      "External_COR_ID": null
    },
    {
      "ArticleTextID": 14007,
      "Position": 0,
      "Type": 87,
      "Title": null,
      "Value": "Nadelbaum mit attraktivem Zapfenschmuck\n",
      "External_Key": null,
      "External_COR_ID": null
    },
    {
      "ArticleTextID": 14008,
      "Position": 0,
      "Type": 88,
      "Title": null,
      "Value": "Standort (Boden): kalkverträglich, lehmig, nährstoffreich; Standort (Licht): vollsonnig bis leicht schattig; Winterhärte: frosthart; Besonderheiten (Pflegetipp): Schnitt unüblich\n",
      "External_Key": null,
      "External_COR_ID": null
    },
    {
      "ArticleTextID": 14009,
      "Position": 0,
      "Type": 65,
      "Title": null,
      "Value": "Blütezeit (Geruch): April bis Mai@Blütenfarbe: purpur@Blattfarbe, -phase: dunkelgrün, immergrün@Blattform: Nadeln bis 2 cm@Zapfen/Frucht: Zapfen blau-violett, später braun, eiförmig, aufrecht, bis 7 cm, sehr dekorativ@Wuchshöhe: über 5 m@Habitus: Nadelbaum@Standort (Boden): kalkverträglich, lehmig, nährstoffreich@Standort (Licht): vollsonnig bis leicht schattig@Verwendung Teil 1: Hausgarten, Steingarten, Einzelstellung, zusammen mit Rhododendron und Stauden@Rinde: im Alter rau@Winterhärte: frosthart\n",
      "External_Key": null,
      "External_COR_ID": null
    }
  ],
  "Tasks": [],
  "Ratings": [],
  "Tags": [],
  "Features": [],
  "CustomFields": [{
      "CustomFieldID": 1059,
      "Field": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#34#19"
      },
      "StringValue": null,
      "IntValue": 24180,
      "DateValue": null,
      "FloatValue": null,
      "BoolValue": null,
      "External_Key": null,
      "External_COR_ID": null
    },
    {
      "CustomFieldID": 1060,
      "Field": {
        "ID": 0,
        "RowVersion": "#0#0#0#0#0#2#34#20"
      },
      "StringValue": "P",
      "IntValue": null,
      "DateValue": null,
      "FloatValue": null,
      "BoolValue": null,
      "External_Key": null,
      "External_COR_ID": null
    }
  ],
  "RatingCount": null,
  "Teaser": null,
  "Inactive": false,
  "GrowthFrom": null,
  "GrowthTo": null,
  "WeightFrom": null,
  "WeightTo": null,
  "WidthFrom": null,
  "WidthTo": null,
  "HeightFrom": null,
  "HeightTo": null,
  "DeliverHeightFrom": null,
  "DeliverHeightTo": null,
  "LengthFrom": null,
  "LengthTo": null,
  "DepthFrom": null,
  "DepthTo": null,
  "PotSize": null,
  "PotSizeL": null,
  "FillAmountFrom": null,
  "FillAmountTo": null,
  "DiameterFrom": null,
  "DiameterTo": null,
  "LoadingCapacityFrom": null,
  "LoadingCapacityTo": null,
  "BloomingTimeFrom": null,
  "BloomingTimeTo": null,
  "BloomingTimePeriod": null,
  "BloomingTimePeriod2": null,
  "Size": null,
  "Quality": null,
  "Grower": null,
  "Brand": null,
  "BotanicName": null,
  "NameTranslation": null,
  "External_Key": "98820121",
  "External_COR_ID": null
}
```


## Job

```json
{
  "JobID": 5,
  "Name": "Sortimentsaktualisierung",
  "Percent": 100,
  "Status": "2 aktualisiert",
  "Started": "2016-05-11T14:26:12.407",
  "Finished": "2016-05-11T14:26:15.05",
  "Alive": null,
  "Aborted": null,
  "Succeeded": true,
  "External_Key": null,
  "External_COR_ID": null
}
```

## Workflow

```json
{
    "Text": "Goods shipped",
    "Title": null,
    "Action": "reply",
    "Type": 16,
    "Refund": false,
    "Replacement": false,
    "Positions": null
}
```

## Payment

```json
{
  "PaymentID": 1,
  "ReservedUntil": null,
  "Info": null,
  "Price": 10,
  "Currency": {
    "ID": 1,
    "RowVersion": "#0#0#0#0#0#3#93#115",
    "External_Key": null
  },
  "VoucherCode": null,
  "External_Key": null,
  "External_COR_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#5#130#114",
  "Deleted": true
}
```

## EntityReference

```json
{
    "ID": 1, // ID des Datensatz
    "RowVersion": "#0#0#0#0#0#3#93#115", // Timestamp
    "External_Key": null // Externer Schlüssel
}
```

## Voucher

```json
{
  "VoucherID": 28,
  "Name": "Auftrag 2017-184, Firma Blumen Cordes",
  "ValidFrom": null,
  "ValidTo": "2019-08-10T00:00:00",
  "KeyValue": null,
  "Type": 1,
  "OrderItem": {
    "ID": 213,
    "RowVersion": "#0#0#0#0#0#5#126#37",
    "External_Key": null
  },
  "Price": 50,
  "Remaining": 0.00999999999999801,
  "Info": null,
  "Currency": {
    "ID": 1,
    "RowVersion": "#0#0#0#0#0#3#93#115",
    "External_Key": null
  },
  "Codes": [{
    "VoucherCodeID": 1781,
    "UsedOn": null,
    "KeyValue": "4039T4GJ6M3MP6JK",
    "EAN": "800000000204",
    "Voucher": {
      "ID": 28,
      "RowVersion": "#0#0#0#0#0#5#132#3",
      "External_Key": null
    },
    "External_Key": null,
    "External_COR_ID": null,
    "External_COR_Owner": null,
    "RowVersion": "#0#0#0#0#0#5#126#34",
    "Deleted": false
  }],
  "Payments": [{
      "PaymentID": 1,
      "ReservedUntil": null,
      "Info": null,
      "Price": 10,
      "Currency": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#3#93#115",
        "External_Key": null
      },
      "VoucherCode": null,
      "External_Key": null,
      "External_COR_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#5#130#114",
      "Deleted": true
    },
    {
      "PaymentID": 12,
      "ReservedUntil": null,
      "Info": null,
      "Price": 39.99,
      "Currency": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#3#93#115",
        "External_Key": null
      },
      "VoucherCode": {
        "VoucherCodeID": 1781,
        "UsedOn": null,
        "KeyValue": "4039T4GJ6M3MP6JK",
        "EAN": "800000000204",
        "Voucher": {
          "ID": 28,
          "RowVersion": "#0#0#0#0#0#5#132#3",
          "External_Key": null
        },
        "External_Key": null,
        "External_COR_ID": null,
        "External_COR_Owner": null,
        "RowVersion": "#0#0#0#0#0#5#126#34",
        "Deleted": false
      },
      "External_Key": null,
      "External_COR_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#5#131#195",
      "Deleted": true
    },
    {
      "PaymentID": 18,
      "ReservedUntil": null,
      "Info": null,
      "Price": 44.99,
      "Currency": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#3#93#115",
        "External_Key": null
      },
      "VoucherCode": {
        "VoucherCodeID": 1781,
        "UsedOn": null,
        "KeyValue": "4039T4GJ6M3MP6JK",
        "EAN": "800000000204",
        "Voucher": {
          "ID": 28,
          "RowVersion": "#0#0#0#0#0#5#132#3",
          "External_Key": null
        },
        "External_Key": null,
        "External_COR_ID": null,
        "External_COR_Owner": null,
        "RowVersion": "#0#0#0#0#0#5#126#34",
        "Deleted": false
      },
      "External_Key": null,
      "External_COR_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#5#131#218",
      "Deleted": true
    },
    {
      "PaymentID": 19,
      "ReservedUntil": null,
      "Info": "Test",
      "Price": 49.99,
      "Currency": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#3#93#115",
        "External_Key": null
      },
      "VoucherCode": {
        "VoucherCodeID": 1781,
        "UsedOn": null,
        "KeyValue": "4039T4GJ6M3MP6JK",
        "EAN": "800000000204",
        "Voucher": {
          "ID": 28,
          "RowVersion": "#0#0#0#0#0#5#132#3",
          "External_Key": null
        },
        "External_Key": null,
        "External_COR_ID": null,
        "External_COR_Owner": null,
        "RowVersion": "#0#0#0#0#0#5#126#34",
        "Deleted": false
      },
      "External_Key": null,
      "External_COR_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#5#132#12",
      "Deleted": false
    }
  ],
  "External_Key": null,
  "External_COR_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#5#132#3",
  "Deleted": false
}
```

## Voucher Code

```json
{
  "VoucherCodeID": 1781,
  "UsedOn": null,
  "KeyValue": "4039T4GJ6M3MP6JK",
  "EAN": "800000000204",
  "Voucher": {
    "ID": 28,
    "RowVersion": "#0#0#0#0#0#5#132#3",
    "External_Key": null
  },
  "External_Key": null,
  "External_RowVersion": null,
  "External_COR_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#5#126#34",
  "Deleted": false
}
```

## FoundVoucher
```json
{
    "VoucherID": 28,
    "VoucherCodeID": 1781,
    "UsedOn": null,
    "KeyValue": "4039T4GJ6M3MP6JK",
    "EAN": "800000000204",
    "Currency":{  
       "ID":0,
       "RowVersion":"#0#0#0#0#0#0#77#11"
    },
    "Remaining": 0.00999999999999801
}

```

## MessageType
```csharp
public enum MessageType
{
    CancellationRequested, // Anfrage Stornierung
    ReturnRequested, // Anfrage Rückgabe/Reklamation
    Order, // Bestellung
    ProcessBegun, // Bestellung Empfangsbestätigung (5)
    DeliveryArranged, // Ware versendet / Ware an Spedition übergeben (24)
    DeliveryCompleted, // Lieferung durchgeführt (21)
    DeliveryRefusedByRecipient, // Annahme der Lieferung verweigert (325)
    ReceiptOfGoodParticiallyAcknowledged, // Lieferung unvollständig (73)
    DeliveryScheduled, // Bestätigung des Liefertermins (209)
    DeliveryUnsuccessfullAttempt, // Kunde nicht angetroffen (210)
    DeliveryChangeSchedule, // Änderung des Liefertermins (212)
    Damaged, // Ware beschädigt (218)
    DeliveryPendingAwaitingSpecificDateTimes,  // Kunde nicht erreicht (216)
    NotDeliverable, // Terminavisierung nicht möglich 243
    CollectionPickUpAwaited, // Abholauftrag erhalten (64)
    CollectionDateTimeAcknowledged, // Bestätigung des Abholtermins (13)
    CollectionPickUpCompleted, // Retourenlieferung ist eingegangen (82)
    ReturnsInspectionPassed, // Retouren-Prüfung bestanden (80)
    ReturnsInspectionFailed, // Retouren-Prüfung nicht bestanden (81)
    CancellationRequestConfirmed, // Stornoanfrage des Kunden bestätigt (275)
    CancellationIsNoLongerPossible, // Storno nicht mehr möglich (71)
    CancellationBeportedBySupplier, // Storno vom Lieferanten gemeldet (56)
    EMail, // E-Mail Nachricht
    RequestAccepted, // Anfrage akzeptiert
    RequestRejected, // Anfrage abgelehnt
    UpdateStatus, // Status aktualisieren
    ReturnViaEMail, // Retoure (per E-Mail erhalten)
    InventoryReport, // Bestandsmeldung
    Invoice, // Rechnung
    CancellationViaEmail // Storno (per E-Mail erhalten)
}

```
## OrderStatusType

```csharp
public enum OrderStatusType : short
{
	NotEdited, // Noch nicht bearbeitet
	Confirmed, // Bestätigt
	Canceled, // Storniert
	Ready // Erledigt
}

```

## TransactionStatus

```csharp
public enum TransactionStatus : short
{
	NotDelivered, // Noch nicht bearbeitet
	Delivered, // Ausgeliefert
	Ready // Steht Bereit
}
```

## BasketType

```csharp
public enum BasketType: short {
  Checkout, // Warenkorb
  WatchList, // Merkliste
  RequestList, // Preisanfrage
  ImageDeliveryList, // Bildermappe
  Projects, // Projekt
  DirectOrderForm // Direktbestellschein
}
```

## MessageType

```csharp
public enum MessageType {
  CancellationRequested, //Anfrage Stornierung
  ReturnRequested, // Anfrage Retoure
  Order, // Bestellung
  ProcessBegun, // Bestellung Empfangsbestätigung (5)
  DeliveryArranged, // Ware versendet / Ware an Spedition übergeben (24)
  DeliveryCompleted, // Lieferung durchgeführt (21)
  DeliveryRefusedByRecipient, // Annahme der Lieferung verweigert (325)
  ReceiptOfGoodParticiallyAcknowledged, // Lieferung unvollständig (73)
  DeliveryScheduled, // Bestätigung des Liefertermins (209)
  DeliveryUnsuccessfullAttempt, // Kunde nicht angetroffen (210)
  DeliveryChangeSchedule, // Änderung des Liefertermins (212)
  Damaged, // Ware beschädigt (218)
  DeliveryPendingAwaitingSpecificDateTimes, // Kunde nicht erreicht (216)
  NotDeliverable, // Terminavisierung nicht möglich 243
  CollectionPickUpAwaited, // Abholauftrag erhalten (64)
  CollectionDateTimeAcknowledged, // Bestätigung des Abholtermins (13)
  CollectionPickUpCompleted, // Retourenlieferung ist eingegangen (82)
  ReturnsInspectionPassed, // Retouren-Prüfung bestanden (80)
  ReturnsInspectionFailed, // Retouren-Prüfung nicht bestanden (81)
  CancellationRequestConfirmed, // Stornoanfrage des Kunden bestätigt (275)
  CancellationIsNoLongerPossible, // Storno nicht mehr möglich (71)
  CancellationBeportedBySupplier, // Storno vom Lieferanten gemeldet (56)
  EMail, // E-Mail Nachricht
  RequestAccepted, // Anfrage akzeptiert
  RequestRejected, // Anfrage abgelehnt
  UpdateStatus, // Status aktualisieren
  ReturnViaEMail, // Retoure (per E-Mail erhalten)
  InventoryReport, // Bestandsmeldung
  Invoice, // Rechnung
  CancellationViaEmail // Storno (per E-Mail erhalten)
}

```

## MessageDirection

```csharp
public enum MessageDirection {
  Inbound, // Eingehend
  Outbound // Ausgehend
}
```


## Documentation
```json
{
  "DocumentationID": 28,
  "Thumbnail": null,
  "DataFile": {  
  "ID": 10,
  "RowVersion": "#0#0#0#0#0#0#77#11"
},
"Language": null,
"Title": null,
"Type": "Invoice"
}
```

## Item status

```json
{
    "External_Key":"abcdef",
    "Confirmed": true,
    "QuantityConfirmed": null, // oder die Anzahl bei Teillieferungen
}

```

## File
```json
{
  "FileID": 8965,
  "Revision": 2,
  "Name": "testAnhang.pdf",
  "Type": "file/pdf",
  "Guid": "c4b4b19a-ce6d-4729-923f-c6ab922a70c8",
  "Url": "http://localhost:61235/Files?id=8965",
  "SmallUrl": "http://localhost:61235/Files?id=8965&width=200&height=200",
  "MediumUrl": "http://localhost:61235/Files?id=8965&width=600&height=600",
  "LargeUrl": "http://localhost:61235/Files?id=8965&width=1200&height=1200",
  "Size": 373790,
  "Title": null,
  "SearchKeywords": null,
  "Storename": "testAnhang.pdf",
  "StoreName200x200ProportionalBiggest": null,
  "StoreName600x600ProportionalBiggest": null,
  "StoreName1200x1200ProportionalBiggest": null,
  "FrameCount": null,
  "StoreNameFrames": null,
  "StoreNameFramesMedium": null,
  "External_Key": "testAnhang.pdf",
  "External_RowVersion": "5769b59763194354b0096cb7c6eb8e46",
  "External_COR_ID": null,
  "External_DM_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#6#10#88",
  "Deleted": false
}
```

## Transaction
```json
{
    "External_Key": "4711",
    "StockQuantity": 100,
    "Prices": [
       {  
          "Quantity":null,
          "Price":5.9,
          "PriceOld":6.5,
       }
    ]
}

```

## OrderStatus
 ```json
{

"OrderStatus" : 1, 

"OrderTransactionID" : 10, // ID der Abwicklung

"Status": 1,

"StatusOn": "2018-04-03T14:30:05.037", // Wann wurde z.B. ausgeliefert

"TrackAndTraceID" : null, // Tracking ID

"TrackAndTraceURL" : null, // Tracking URL

"Documentations" : null, // Array von Dokumentationten 34.11

"InvoiceURI" : null, // Rechnung als DataURI

"InvoiceFilename" : null, // Dateiname Rechnung

"InvoiceMimeType" : null, // Mimetype Rechnung

"Articles" : null, // Array von ArtikelStatus 34.12

}
```

## LoyaltyCard
```json
{
  "DebitCardID": 1,
  "KeyValue": "test",
  "Valid": true,
  "ValidatedOn": "2018-11-15T13:16:28.7",
  "ValidatedBy": {
    "ID": 1,
    "RowVersion": "#0#0#0#0#0#11#103#56",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Member": {
    "ID": 70,
    "RowVersion": "#0#0#0#0#0#9#35#145",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Turnover": 55,
  "Currency": {
    "ID": 1,
    "RowVersion": "#0#0#0#0#0#6#99#130",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": 4
  },
  "Orders": [{
    "ID": 269,
    "RowVersion": "#0#0#0#0#0#12#59#49",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  }],
  "Payments": [{
    "PaymentID": 155,
    "ReservedUntil": null,
    "Info": "Test",
    "Price": 15,
    "Currency": {
      "ID": 1,
      "RowVersion": "#0#0#0#0#0#6#99#130",
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": 4
    },
    "VoucherCode": null,
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null,
    "External_DM_ID": null,
    "External_COR_Owner": null,
    "RowVersion": "#0#0#0#0#0#12#59#50",
    "Deleted": false
  }],
  "Results": [],
  "External_Key": null,
  "External_RowVersion": null,
  "External_COR_ID": null,
  "External_DM_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#12#62#22",
  "Deleted": false
}
```

## Result
```json
{
    "ResultID": 43576,
    "Text": "Kundenkarte nicht korrekt",
    "ResultType": "ResultError", // ResultError oder ResultInfo
}

```

## Dialog

```json
{
  "Url": "http://localhost:61235/Plugin/OrderTransactions/Delivered/145",
  "Title": "Auftrag versenden",
  "Width": 600,
  "Height": 400
}
```


## Upload
```json
{
    "Filename" : "Test.png",
    "Data" : "iVBORwjsjhb67gjh…5ErkJggg==", // Dateiinhalt als Data URI https://de.wikipedia.org/wiki/Data-URL
    "Type" : "image/png", // Mime Type (z.B. application/pdf)
    "Deleted" : "false",
    "Rotation": 0 // Nur bei api/pictures/upload, Rotation im Uhrzeigersinn (1=90 Grad, 2=180 Grad usw.)
}

```

## Message
```json
{
  "MessageID": 145,
  "Key": null, // Schlüssel der Nachricht
  "Number": "2022-145", // Nummer (wird vom System vergeben)
  "Guid": "674116e3-815b-439d-a44e-ee46c13f6bef",
  "Type": 21, // Siehe MessageType
  "Direction": 1, // Siehe MessageDirection
  "ProcessedOn": "2022-03-14T15:19:48.817",
  "DoneOn": null,
  "SenderConfirm": false,
  "SenderConfirmedOn": null,
  "HasReadBy": null,
  "Succeeded": null,
  "HasReadOn": null,
  "AcknowledgedOn": "2022-03-14T15:19:53.77",
  "CreatedOn": "2022-03-14T15:19:09.93",
  "DoneBy": null,
  "Editor": null,
  "Subject": "Storno vom Lieferanten gemeldet (56)", // Betreff der Nachricht
  "Body": null, // Inhalt (falls E-Mail)
  "Html": null, // Html - Inhalt (falls E-Mail)
  // Externe Daten (z.B. EDI)
  "External_Data": "UNA:+.? '\nUNB+UNOC:3+{Message.Sender.GLN}:14+{Message.Receiver.GLN}:14+220314:1619+{Message.Number}+++++EANCOM+0'\r\nUNH+{Message.Number}+OSTRPT:D:01B:UN:EAN008'\r\nBGM+348+{Message.Number}+9'\r\nDTM+137:20220314:102'\r\nNAD+SU+{Message.Sender.SupplierNumber}::92'\r\nDOC+227+21357682'\r\nDTM+137:20220314:102'\r\nLIN+1++4251628174130:SRV'\r\nPIA+1+29013960:IN'\r\nRFF+ON:1033161696'\r\nDTM+171:20220314:102'\r\nRFF+ABO:1'\r\nSTS+1+56'\r\nDTM+334:20220314:102'\r\nQTY+46:1:PCE'\r\nUNT+15+{Message.Number}'\r\nUNZ+1+{Message.Number}'",
  "External_Data2": null,
  "External_CMS_Number": "21357682", // Externe Bestellnummer
  "External_CMS_ID": null,
  "External_CMS_CAPS": null,
  "ExternalID": null,
  "Refund": false,
  "Replacement": false,
  "SupplierNumber": null,
  "GLN": "4024506000001",
  "Channel": null,
  // Verknüpfte Bestellung
  "Order": {
    "ID": 898,
    "RowVersion": "#0#0#0#0#0#12#71#131",
    "External_Key": "Bauhaus#$1033161696",
    "External_RowVersion": "9491c979cb9d11d9878021cd2dee133a",
    "External_COR_ID": null
  },
  // Vorherige Nachricht auf die geantwortet wird
  "Parent": {
    "Guid": "4b4d48c3-fe9f-421c-8f65-accaf272730c",
    "ID": 143,
    "RowVersion": "#0#0#0#0#0#12#71#80",
    "External_Key": "Bauhaus#404",
    "External_RowVersion": "#0#0#0#0#0#3#18#211",
    "External_COR_ID": null
  },
  // Sender
  "Sender": {
    "ID": 1,
    "RowVersion": "#0#0#0#0#0#12#83#161",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "SendedBy": null,
  // Empfänger
  "Receiver": {
    "ID": 5,
    "RowVersion": "#0#0#0#0#0#12#84#94",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Children": [],
  "Positions": [],
  "Results": [],
  "External_Key": null,
  "External_RowVersion": null,
  "External_COR_ID": null,
  "External_DM_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#12#71#157",
  "Deleted": false
}
```

## MessagePosition
```json
{
  "MessagePosition": 145,
  "External_Key": null,
  "External_RowVersion": null,
  "External_COR_ID": null,
  "External_DM_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#12#71#157",
  "Deleted": false
}
```

# PriceList

```json
{
  "PricelistID": 2,
  "Name": "Großkunden",
  "ShortName": null,
  "Description": null,
  "Key": null,
  "Color": "#000000",
  "Priority": null,
  "Public": false,
  "Items": [],
  "CustomerGroups": [],
  "Members": [],
  "External_Key": null,
  "External_RowVersion": null,
  "External_COR_ID": null,
  "External_DM_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#11#195#46",
  "Deleted": false
}
```


# AccountInfo

```json
{
    "MemberID": 1,
    "LanguageID": 0,
    "UserID": 1,
    "Member": "Gartencenter Mustermann", // Kunde
    "User": "Herr Max Mustermann", // Benutzer
    "Login": "admin", // Benutzername
    "Token": "8xn+HVHclg5wfcbqGq9zmgw2EYr5Lswv36Qg1KZlqnU/tPZxX6QplT2+cSNTEX2O4R5BYEUEagHu+15wJPteTQ==", // Zugriffstoken
    "Error": null,
    "Version": "2.0.0.228",
    "PublishDate": "28.02.2022 14:10",
    "Info": null,
    "AutomaticPassword": false,
    // Rollen    
    "Roles": [
        "admin",
        "superuser",
        "user",
        "website.admin",
        "social.media",
        "website.user",
        "webshop.admin",
        "webshop.user",
        "member",
        "module.api"
    ],
    // Rechte
    "Rights": [
        "users.update",
        "users.create",
        "users.delete"        
    ],
    "PricelistIDs": null,
    // Logo
    "Logo": {
        "Url": "https://gartencentermustermann.gswebapps.net/files?id=179",
        "Name": "GartencenterMustermann_Logo_mit-Schatten_20-03-20.png",
        "Revision": 4,
        "CreatedOn": "2020-03-20T10:23:04.123",
        "ID": 179,
        "RowVersion": "#0#0#0#0#0#26#152#41",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": null
    }
}
```

# PricelistItem

```json
{
  "PricelistItemID": 13,
  "Article": {
    "ID": 1365,
    "RowVersion": "#0#0#0#0#0#6#81#143",
    "External_Key": "SANA018230",
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Pricelist": {
    "ID": 2,
    "RowVersion": "#0#0#0#0#0#11#195#46",
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null
  },
  "Keys": [{
    "PricelistKeyID": 13,
    "ArticleKey": {
      "ID": 1271,
      "RowVersion": "#0#0#0#0#0#4#8#5",
      "External_Key": "001826721076602",
      "External_RowVersion": null,
      "External_COR_ID": null
    },
    "CustomerEAN": null,
    "CustomerArticleNumber": null,
    "CustomerPrice": 15.0,
    "Individual": false,
    "Top": false,
    "Currency": {
      "ID": 1,
      "RowVersion": "#0#0#0#0#0#6#99#130",
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": 4
    },
    "Teaser": null,
    "Notes": null,
    "External_Data": null,
    "Prices": [{
      "PricelistPriceID": 13,
      "Quantity": null,
      "Price": 10.0,
      "PriceOld": null,
      "PriceNet": false,
      "TaxIncluded": false,
      "Currency": {
        "ID": 1,
        "RowVersion": "#0#0#0#0#0#6#99#130",
        "External_Key": null,
        "External_RowVersion": null,
        "External_COR_ID": 4
      },
      "Type": 0,
      "External_Key": null,
      "External_RowVersion": null,
      "External_COR_ID": null,
      "External_DM_ID": null,
      "External_COR_Owner": null,
      "RowVersion": "#0#0#0#0#0#2#54#179",
      "Deleted": false
    }],
    "External_Key": null,
    "External_RowVersion": null,
    "External_COR_ID": null,
    "External_DM_ID": null,
    "External_COR_Owner": null,
    "RowVersion": "#0#0#0#0#0#2#54#180",
    "Deleted": false
  }],
  "External_Key": null,
  "External_RowVersion": null,
  "External_COR_ID": null,
  "External_DM_ID": null,
  "External_COR_Owner": null,
  "RowVersion": "#0#0#0#0#0#2#54#177",
  "Deleted": false
}
```

# Dialogs

Selected dialog can be called externally(please refer[dialog](#dialog) ).

Please then open a browser window in the specified size and with the title. Then navigate in the window to the transferred url!

## To ship

![To ship](images/send.png)

## Order management

![order management](images/order management.png)

## Edit article

![Edit article](images/article-edit.png)

## Confirm order

![confirm order](images/order-confirm.png)

## Cancel order

![cancel order](images/cancel-order.png)

## Complete order

![complete order](images/order-complete.png)

# Examples API

## Sample application

A sample application for the API developed in C# .NET can be found here:

[sample application](../GS_PflanzenCMS.net.Rest.Sample)

## Request token for authentication

```csharp
var unitOfWork = new Api.Client.ContextUOW(null, "");
var token = unitOfWork.Account.Validate("Benutzer", "Passwort"); // POST api/account/validate?user={benutzer}&password={passwort}
```
The token can now be used in all subsequent posts as a header "token

## Update article
```csharp
var unitOfWork = new Api.Client.ContextUOW(null, "");

var article = new Article();

article.Name = "Acer Palmatum Bloodgood";
article.Name2 = "Fächerahorn Bloodgood";
article.Description = "Dies ist eine lange Beschreibung";
article.ShortDescription = "Dies ist eine kurze Beschreibung";

// Warengruppe setzen (evtl. Hierachie beachten)
var articleGroup = unitOfWork.ArticleGroups.FindAll("Pflanzen", 0, 100, null).Items.First(); // GET api/articlegroups
article.ArticleGroups.Add(new EntityReference() {
  ID = articleGroup.ArticleGroupID
});

// Kategorie setzen (evtl. Hierachie beachten)
var category = unitOfWork.Categories.FindAll("Zubehör", 0, 100, null).Items.First(); // GET api/categories
article.Categories.Add(new EntityReference() {
  ID = category.CategoryID
});

// Texte hinzufügen
var text = new ArticleText();
article.Texts.Add(text);
text.Type = Types.TextType.BulletPoints;
text.Title = "Kaufargumente";
text.Value = "	* frosthart * duftend * wintergrün * Kübel geeignet";

// Verfügbarkeiten
var timePeriod = new TimePeriod();
article.Available.Add(timePeriod);
timePeriod.FromCW = 10; // Kalendarwoche (von)
timePeriod.ToCW = 20; // Kalendarwoche (bis)

// Varianten (Artikelnummern) hinzufügen
var articleKey = new ArticleKey();
article.Keys.Add(articleKey);

articleKey.Value = "47811"; // Artikelnummer
articleKey.Info = "C/  50 - 60";
articleKey.AvailableForClickAndCollect = true; // Click & Collect
articleKey.AvailableForRadiusDelivery = true; // Liefern
articleKey.AvailableForShipping = true; // Versenden
articleKey.PackingSize = 20; // VE
articleKey.StockQuantity = 10; // Bestand

// Steuersatz
var taxRate = unitOfWork.Countries.Get("DE").TaxRates.Single(m => m.Percent == 19); // GET api/countries
articleKey.TaxRate = new EntityReference() {
  ID = taxRate.TaxRateID
};

// Preise
var currency = unitOfWork.Currencies.Get("EUR"); // GET api/currencies

var articleKeyPrice = new ArticleKeyPrice();
articleKey.Prices.Add(articleKeyPrice);
articleKeyPrice.Price = 17; // Preis
articleKeyPrice.PriceOld = 25; // Streichpreis
articleKeyPrice.PriceUnitAmount = 10; // pro 10
articleKeyPrice.ValueUnitType = Types.PriceUnitType.Liter; // Liter
articleKeyPrice.Quantity = 1; // Ab Stückzahl
articleKeyPrice.Currency = new EntityReference() {
  ID = currency.CurrencyID
};
articleKeyPrice.TaxIncluded = true; // Mwst. inkl?
articleKeyPrice.PriceNet = true; // Netto - Preis (keine Rabatte)

unitOfWork.Articles.Create(article); // POST api/articles/create?importExternal=true 
// PUT api/articles/{id} zum updaten
```

## Query orders

```csharp
var unitOfWork = new Api.Client.ContextUOW(null, "");
var orders = unitOfWork.Orders.FindAll(null, 0, 100, "OrderID desc").Items; // GET api/orders/all

foreach(var orderSummary in orders) {
  var order = unitOfWork.Orders.Get(orderSummary.OrderID); // GET api/orders/{id}

  Console.WriteLine("Ordernumber:" + order.OrderID);
  Console.WriteLine("Date:" + order.CreatedOn.ToShortDateString());

  var owner = unitOfWork.Members.Get(order.Owner.ID); // GET api/members/{id}
  Console.WriteLine("Customer:" + owner.MainContact.Company);

  Console.WriteLine("Invoiceaddress:" + order.InvoiceAddress.Contact.Company + " " + order.InvoiceAddress.Address.Street + " " + order.InvoiceAddress.Address.HouseNumber);
  Console.WriteLine("Shippingaddress:" + order.ShippingAddress.Contact.Company + " " + order.ShippingAddress.Address.Street + " " + order.ShippingAddress.Address.HouseNumber);

  var paymentMethod = unitOfWork.PaymentMethods.Get(order.PaymentMethod.ID); // GET api/paymentmethods/{id}
  Console.WriteLine("Payment method:" + paymentMethod.Name);

  var shippingMethod = unitOfWork.ShippingMethods.Get(order.ShippingMethod.ID); // GET api/shippingmethods/{id}
  Console.WriteLine("Shipping method:" + shippingMethod.Name);

  // Positionen
  foreach(var position in order.Items) {
    var article = unitOfWork.Articles.Get(position.Article.ID); // GET api/articles/{id}
    var articleKey = article.Keys.SingleOrDefault(m => m.ArticleKeyID == position.ArticleKey.ID);

    Console.WriteLine("Article:" + article.Name + " / " + article.Name2);
    Console.WriteLine("Articlenumber:" + articleKey.Value);
    Console.WriteLine("Transaction:" + position.TransactionType); // CLick&Collect, Versenden u.s.w.
    Console.WriteLine("Quantity:" + position.Quantity);
    Console.WriteLine("Price:" + position.Price);
    Console.WriteLine("Totalprice:" + position.TotalCosts);
    Console.WriteLine("Confirmed:" + (position.IsConfirmed == true ? "Ja" : "Nein"));
  }

}
```
