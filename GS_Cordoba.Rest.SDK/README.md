
# Content Database
## REST API


# Overview

With the Green Solutions REST API, data of the Content Database system can be accessed.

As an innovative software company, we have specialized 100% in the horticultural industry. With our cloud-based omni-channel solution, all relevant online and offline channels such as web shop, website, signage, newsletters, apps, social media, print media, etc. can be managed centrally from one system. In addition, the customer can access the huge Green Solutions database for all channels - with thousands of photos, videos, editorial reports, plant and product data.

## Contents

**[Authorization](#Authorization)**

**[Search Plants](#Search-Plants)**

**[Query Plant](#QueryPlant)**

**[Search Pictures](#Search-Pictures)**

**[Download Picture](#Download-Picture)**

**[Data structures](#Data-structures)**

> [Plant](#Plant)

> [PlantPicture](#PlantPicture)

> [Item](#Item)


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

```
curl --location 'https://app.green-solutions.net/api/search?search=acer&Type=Plant' \
--header 'token: <token>'
```

Please refer to **[Item](#Item)** for the result

# Query Plant

This example shows how to query a specific plant

```csharp
var plant = unitOfWork.Plants.Get(item.ID).Result;
Console.WriteLine("Name: " + plant.Name);
Console.WriteLine("Name 2: " + plant.Name2);
```

```
curl --location 'https://app.green-solutions.net/api/plants/298' \
--header 'token: <token>'
```

Please refer to **[Plant](#Plant)** for the result

# Search Pictures

This example shows how to search a specific picture

```csharp
var args = new GS.Cordoba.Rest.SDK.Models.SearchArgs();
args.Types = new string[] { typeof(PlantPicture).Name };
var pictures = unitOfWork.Search.Search("acer", 1, 10, null, args).Result.Items;
```

```
curl --location 'https://app.green-solutions.net/api/search?search=acer&Type=PlantPicture' \
--header 'token: <token>'
```

Please refer to **[Item](#Item)** for the result

# Query Picture

This example shows how to query a specific Picture

```csharp
var picture = unitOfWork.PlantPictrues.Get(item.ID).Result;
Console.WriteLine("Name: " + picture.NameBotanic);
```

```
curl --location 'https://app.green-solutions.net/api/plantpictures/1325992' \
--header 'token: <token>'
```

Please refer to **[PlantPicture](#PlantPicture)** for the result

# Download Picture

For safety reasons please ask for details

# Data structures

## Plant

```json
{
    "NameTranslation": "Ahorn",
    "Opener": "",
    "Groups": [
        {
            "ID": 22,
            "RowVersion": "#0#0#0#0#17#63#115#57"
        }
    ],
    "Usages": [
        {
            "ID": 4,
            "RowVersion": "#0#0#0#0#17#63#115#219"
        }
    ],
    "Tastes": [],
    "Shapes": [],
    "Features": [],
    "Tasks": [],
    "Colors": [],
    "LittleWater": null,
    "MediumWater": null,
    "MuchWater": null,
    "GrowthHeightFrom": null,
    "GrowthHeightTo": null,
    "GrowthWidthFrom": null,
    "GrowthWidthTo": null,
    "GrowthAnnualFrom": null,
    "GrowthAnnualTo": null,
    "GrowthAnnualWidthFrom": null,
    "GrowthAnnualWidthTo": null,
    "GrowthSpeedType": null,
    "FlowerSmell": null,
    "LocationBright": null,
    "LocationSunny": true,
    "LocationHalfShadowed": true,
    "LocationShadowed": false,
    "Toxically": null,
    "Eatable": null,
    "LifeTimeAnnual": null,
    "LifeTimeBinual": null,
    "LifeTimePerennial": null,
    "Grower": null,
    "Brand": null,
    "DifficultyType": null,
    "CareEffort": null,
    "HardinessType": 2,
    "RizomBarrierRequired": null,
    "FoliageAlwaysGreenType": 0,
    "SoilDiaphanous": null,
    "SoilHumous": null,
    "SoilChalkFree": null,
    "SoilCalcareous": null,
    "SoilLoose": null,
    "SoilNutrientRich": null,
    "SoilSandy": null,
    "SoilSour": null,
    "SoilSourWeak": null,
    "SoilClayey": null,
    "SoilDry": null,
    "SoilUndemanded": null,
    "PruningType": null,
    "Filling": null,
    "BloomingTimePeriod": null,
    "BloomingTimePeriod2": null,
    "FruitCone": null,
    "FruitBerries": null,
    "FruitCore": null,
    "FruitStone": null,
    "FruitAromatic": null,
    "FruitOrnamental": null,
    "ArticleID": 298,
    "Name": "Acer",
    "Name2": "",
    "ShortDescription": "",
    "Description": "Acer ist eine umfangreiche Gattung, deren verschiedene Arten sich fast über die ganze nördlich gemäßigte Breite erstrecken. Die Mehrheit der Arten stammt aus Asien. Der Ahorn fällt besonders durch seine frühe Blüte auf. Während andere Bäume noch keine Blätter tragen, findet man an den Ästen des Ahorns schon Blätter...\r\nMan findet für jeden Boden, jede Lage, jeden Farbgeschmack und jede Gartengröße einen passenden Ahorn!",
    "Priority": null,
    "Notes": null,
    "Inactive": false,
    "Type": "Plant",
    "Categories": [],
    "ArticleGroups": [],
    "Photos": [
        {
            "PhotoID": 7847,
            "Priority": 10,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 425291,
                "Url": "https://app-stage.green-solutions.net/Files/Get/6858",
                "Name": "GS425291.jpg",
                "ID": 6858,
                "RowVersion": "#0#0#0#0#12#84#93#27"
            },
            "Guid": "777452d2-5730-44ed-bb15-7ab92ed2eb89",
            "CreatedOn": "2016-04-20T12:13:50.797",
            "RowVersion": "#0#0#0#0#12#84#93#127",
            "External_DM_ID": 552982,
            "Deleted": false
        },
        {
            "PhotoID": 7848,
            "Priority": 20,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 425292,
                "Url": "https://app-stage.green-solutions.net/Files/Get/6859",
                "Name": "GS425292.jpg",
                "ID": 6859,
                "RowVersion": "#0#0#0#0#12#84#93#210"
            },
            "Guid": "29a270d3-6fbc-4632-869b-d6ad0eb6cd0a",
            "CreatedOn": "2016-04-20T12:13:52.123",
            "RowVersion": "#0#0#0#0#12#84#93#218",
            "External_DM_ID": 552983,
            "Deleted": false
        },
        {
            "PhotoID": 7849,
            "Priority": 30,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 425293,
                "Url": "https://app-stage.green-solutions.net/Files/Get/6860",
                "Name": "GS425293.jpg",
                "ID": 6860,
                "RowVersion": "#0#0#0#0#12#84#94#34"
            },
            "Guid": "bc87cca0-90cd-48fd-a6fa-95cef8dc780a",
            "CreatedOn": "2016-04-20T12:13:54.343",
            "RowVersion": "#0#0#0#0#12#84#94#39",
            "External_DM_ID": 552984,
            "Deleted": false
        },
        {
            "PhotoID": 225175,
            "Priority": 40,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 410500,
                "Url": "https://app-stage.green-solutions.net/Files/Get/117694",
                "Name": "GS410500.jpg",
                "ID": 117694,
                "RowVersion": "#0#0#0#0#12#84#94#43"
            },
            "Guid": "39aba085-49f6-4f25-98bf-efcca50d1268",
            "CreatedOn": "2016-05-17T22:01:57.55",
            "RowVersion": "#0#0#0#0#12#84#94#47",
            "External_DM_ID": 600219,
            "Deleted": false
        },
        {
            "PhotoID": 225176,
            "Priority": 50,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 410499,
                "Url": "https://app-stage.green-solutions.net/Files/Get/117688",
                "Name": "GS410499.jpg",
                "ID": 117688,
                "RowVersion": "#0#0#0#0#12#84#94#119"
            },
            "Guid": "4f3fb2ee-9e36-4bc5-ac5c-c8cf55ef0464",
            "CreatedOn": "2016-05-17T22:01:58.347",
            "RowVersion": "#0#0#0#0#12#84#94#129",
            "External_DM_ID": 600220,
            "Deleted": false
        },
        {
            "PhotoID": 1826172,
            "Priority": 60,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 590745,
                "Url": "https://app-stage.green-solutions.net/Files/Get/774497",
                "Name": "GS590745.jpg",
                "ID": 774497,
                "RowVersion": "#0#0#0#0#12#84#95#124"
            },
            "Guid": "6d0b6d10-f5d8-48d6-af81-1849c286644a",
            "CreatedOn": "2018-10-23T22:01:46.53",
            "RowVersion": "#0#0#0#0#15#17#38#187",
            "External_DM_ID": 819556,
            "Deleted": false
        },
        {
            "PhotoID": 2321943,
            "Priority": 70,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 613769,
                "Url": "https://app-stage.green-solutions.net/Files/Get/914761",
                "Name": "GS613769.jpg",
                "ID": 914761,
                "RowVersion": "#0#0#0#0#12#84#95#180"
            },
            "Guid": "a2b5c2c0-8620-467e-8251-b44b9fe735ed",
            "CreatedOn": "2019-04-09T22:04:43.997",
            "RowVersion": "#0#0#0#0#15#17#38#189",
            "External_DM_ID": 851154,
            "Deleted": false
        },
        {
            "PhotoID": 4718480,
            "Priority": 80,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 745460,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1352135",
                "Name": "GS745460.jpg",
                "ID": 1352135,
                "RowVersion": "#0#0#0#0#13#18#170#181"
            },
            "Guid": "3f5c0412-edf7-427c-923a-59f3c85f7940",
            "CreatedOn": "2022-09-20T23:03:04.01",
            "RowVersion": "#0#0#0#0#15#17#38#196",
            "External_DM_ID": 929346,
            "Deleted": false
        },
        {
            "PhotoID": 4718481,
            "Priority": 90,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 733775,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1325992",
                "Name": "GS733775.jpg",
                "ID": 1325992,
                "RowVersion": "#0#0#0#0#13#18#170#200"
            },
            "Guid": "a674f637-bf12-4280-867e-b6d7577ee843",
            "CreatedOn": "2022-09-20T23:03:04.26",
            "RowVersion": "#0#0#0#0#15#17#38#197",
            "External_DM_ID": 929367,
            "Deleted": false
        },
        {
            "PhotoID": 1943231,
            "Priority": 100,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 503335,
                "Url": "https://app-stage.green-solutions.net/Files/Get/316451",
                "Name": "GS503335.jpg",
                "ID": 316451,
                "RowVersion": "#0#0#0#0#12#84#95#158"
            },
            "Guid": "db53fabb-8550-47f9-9a59-33ecc2f0fb21",
            "CreatedOn": "2018-12-11T22:59:40.473",
            "RowVersion": "#0#0#0#0#15#17#38#188",
            "External_DM_ID": 828393,
            "Deleted": false
        },
        {
            "PhotoID": 654673,
            "Priority": 110,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 514490,
                "Url": "https://app-stage.green-solutions.net/Files/Get/383247",
                "Name": "GS514490.jpg",
                "ID": 383247,
                "RowVersion": "#0#0#0#0#12#84#95#6"
            },
            "Guid": "037a286b-fd53-4bf3-baec-e71ecfeed1c2",
            "CreatedOn": "2017-06-03T15:04:03.83",
            "RowVersion": "#0#0#0#0#15#17#38#185",
            "External_DM_ID": 693559,
            "Deleted": false
        },
        {
            "PhotoID": 291786,
            "Priority": 120,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 410523,
                "Url": "https://app-stage.green-solutions.net/Files/Get/117787",
                "Name": "GS410523.jpg",
                "ID": 117787,
                "RowVersion": "#0#0#0#0#9#249#152#190"
            },
            "Guid": "f12fc619-69f1-41fc-bd5e-849d7714a202",
            "CreatedOn": "2016-08-18T22:01:03.587",
            "RowVersion": "#0#0#0#0#15#17#38#184",
            "External_DM_ID": 619604,
            "Deleted": false
        },
        {
            "PhotoID": 3502027,
            "Priority": 130,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 666474,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1096873",
                "Name": "GS666474.jpg",
                "ID": 1096873,
                "RowVersion": "#0#0#0#0#12#84#96#176"
            },
            "Guid": "603d5f6e-d61d-41c3-a583-bcccff004da3",
            "CreatedOn": "2020-11-14T00:01:39.507",
            "RowVersion": "#0#0#0#0#15#17#38#195",
            "External_DM_ID": 918894,
            "Deleted": false
        },
        {
            "PhotoID": 3502026,
            "Priority": 140,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 666473,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1096868",
                "Name": "GS666473.jpg",
                "ID": 1096868,
                "RowVersion": "#0#0#0#0#12#84#96#165"
            },
            "Guid": "cd32cbd5-0add-4d38-8622-7e1d7a5195e7",
            "CreatedOn": "2020-11-14T00:01:38.273",
            "RowVersion": "#0#0#0#0#15#17#38#194",
            "External_DM_ID": 918893,
            "Deleted": false
        },
        {
            "PhotoID": 3502025,
            "Priority": 150,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 666383,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1096909",
                "Name": "GS666383.jpg",
                "ID": 1096909,
                "RowVersion": "#0#0#0#0#12#84#96#110"
            },
            "Guid": "75100086-0f7d-4a4e-916c-b443cf9fd2b2",
            "CreatedOn": "2020-11-14T00:01:36.977",
            "RowVersion": "#0#0#0#0#15#17#38#193",
            "External_DM_ID": 918892,
            "Deleted": false
        },
        {
            "PhotoID": 3502024,
            "Priority": 160,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 666382,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1096906",
                "Name": "GS666382.jpg",
                "ID": 1096906,
                "RowVersion": "#0#0#0#0#12#84#96#100"
            },
            "Guid": "8a9d1faa-b5a2-435e-9ba0-527b903f44a4",
            "CreatedOn": "2020-11-14T00:01:35.853",
            "RowVersion": "#0#0#0#0#15#17#38#192",
            "External_DM_ID": 918891,
            "Deleted": false
        },
        {
            "PhotoID": 3502023,
            "Priority": 170,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 666381,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1096902",
                "Name": "GS666381.jpg",
                "ID": 1096902,
                "RowVersion": "#0#0#0#0#12#84#95#253"
            },
            "Guid": "f3ea747d-c40d-4844-8e31-a9a9b10e56a1",
            "CreatedOn": "2020-11-14T00:01:34.71",
            "RowVersion": "#0#0#0#0#15#17#38#191",
            "External_DM_ID": 918890,
            "Deleted": false
        },
        {
            "PhotoID": 3502022,
            "Priority": 180,
            "Picture": {
                "Type": 3,
                "External_DM_ID": 666380,
                "Url": "https://app-stage.green-solutions.net/Files/Get/1096897",
                "Name": "GS666380.jpg",
                "ID": 1096897,
                "RowVersion": "#0#0#0#0#12#84#95#187"
            },
            "Guid": "aaeabb97-3d13-46fb-a47a-d659391ffd37",
            "CreatedOn": "2020-11-14T00:01:33.337",
            "RowVersion": "#0#0#0#0#15#17#38#190",
            "External_DM_ID": 918889,
            "Deleted": false
        }
    ],
    "Texts": [
        {
            "ArticleTextID": 1553369,
            "Type": 29,
            "Style": 0,
            "Title": "Boden",
            "Value": "Normaler Boden",
            "Position": 50,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#27#45#43",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 1553372,
            "Type": 0,
            "Style": 0,
            "Title": "Standort",
            "Value": "Sonnig - halbschattig",
            "Position": 40,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#27#45#46",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 1553374,
            "Type": 34,
            "Style": 0,
            "Title": "Verwendungen",
            "Value": "Solitär",
            "Position": 75,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#27#45#48",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 1887358,
            "Type": 54,
            "Style": 0,
            "Title": "Pflege",
            "Value": "Schnitt- und Sägewunden sowie Astbrüche sollten schnellstmöglich mit einem Wundeverschlussmittel versorgt werden, um das Eindringen von Krankheitserregern in die Pflanze zu verhindern.",
            "Position": 90,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#32#150#6",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 2463577,
            "Type": 79,
            "Style": 0,
            "Title": "Pflanzzeit",
            "Value": "Containerpflanzen können, außer bei gefrorenem Boden und bei Sommerhitze (über 30°C ), ganzjährig gepflanzt werden.",
            "Position": 85,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#39#184#181",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 2463579,
            "Type": 31,
            "Style": 0,
            "Title": "Beschreibung",
            "Value": "Der Ahorn (Acer) ist eine Gartenpflanze.",
            "Position": 0,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#39#184#182",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 2511705,
            "Type": 0,
            "Style": 1,
            "Title": "Standort",
            "Value": "Sonnig - halbschattig",
            "Position": 35,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#42#1#126",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 2511706,
            "Type": 29,
            "Style": 1,
            "Title": "Boden",
            "Value": "Normaler Boden",
            "Position": 40,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#42#1#127",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 2511707,
            "Type": 34,
            "Style": 1,
            "Title": "Verwendungen",
            "Value": "Solitär",
            "Position": 75,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#42#1#128",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 583463,
            "Type": 31,
            "Style": 3,
            "Title": "Beschreibung",
            "Value": "Der Ahorn (Acer) eine Gartenpflanze, die, je nach Sorte, Blüten in verschiedenen Farben hervorbringt.",
            "Position": 5,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#0#12#186#106",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 583465,
            "Type": 34,
            "Style": 3,
            "Title": "Verwendung",
            "Value": "Solitär",
            "Position": 80,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#12#84#100#204",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 583466,
            "Type": 54,
            "Style": 3,
            "Title": "Pflege",
            "Value": "Schnitt- und Sägewunden sowie Astbrüche sollten schnellstmöglich mit einem Wundeverschlussmittel versorgt werden, um das Eindringen von Krankheitserregern in die Pflanze zu verhindern.",
            "Position": 105,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#12#84#100#205",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 1511199,
            "Type": 0,
            "Style": 3,
            "Title": "Standort",
            "Value": "Bevorzugter Standort in sonniger bis halbschattiger Lage.",
            "Position": 65,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#12#84#100#206",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 2463575,
            "Type": 29,
            "Style": 3,
            "Title": "Boden",
            "Value": "Normaler Boden.",
            "Position": 75,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#12#84#100#207",
            "External_DM_ID": null,
            "Deleted": false
        },
        {
            "ArticleTextID": 2463576,
            "Type": 79,
            "Style": 3,
            "Title": "Pflanzzeit",
            "Value": "Containerpflanzen können, außer bei gefrorenem Boden und bei Sommerhitze (über 30°C ), ganzjährig gepflanzt werden.",
            "Position": 130,
            "Guid": "00000000-0000-0000-0000-000000000000",
            "CreatedOn": "0001-01-01T00:00:00",
            "RowVersion": "#0#0#0#0#12#84#100#208",
            "External_DM_ID": null,
            "Deleted": false
        }
    ],
    "Keys": [],
    "Tags": [
        {
            "ID": 13,
            "RowVersion": "#0#0#0#0#1#97#8#14"
        },
        {
            "ID": 64,
            "RowVersion": "#0#0#0#0#1#97#8#65"
        }
    ],
    "Fields": [],
    "Available": [],
    "Countries": [],
    "Attachments": [],
    "Owner": {
        "ID": 13,
        "RowVersion": "#0#0#0#0#19#148#60#49"
    },
    "OwnerName": "Firma Green Solutions",
    "Guid": "15ae95f6-844b-42f3-bdd1-dc8fe5c11914",
    "CreatedOn": "2016-04-20T12:13:55.52",
    "RowVersion": "#0#0#0#0#15#17#38#183",
    "External_DM_ID": 137,
    "Deleted": false
}
```

## PlantPicture

```json
{
    "FileID": 1325992,
    "Name": "GS733775.jpg",
    "Url": "https://cordoba.blob.core.windows.net/files/02f787dc-7fcf-4f45-a698-4ab5b9e461b2/GSSL3711.jpg",
    "ContentType": "image/jpeg",
    "Number": "733775",
    "ExtNumbers": "",
    "BotanicName": "Acer",
    "NameTranslation": "Ahorn",
    "TitleEx": "",
    "HeightFrom": null,
    "HeightTo": null,
    "PotSize": null,
    "Size": 17882782,
    "Width": 4197,
    "Height": 6295,
    "DpiX": 300,
    "DpiY": 300,
    "Colors": [],
    "Plants": [],
    "ShapeType": null,
    "Tags": [
        {
            "ID": 13,
            "RowVersion": "#0#0#0#0#1#97#8#14"
        },
        {
            "ID": 37,
            "RowVersion": "#0#0#0#0#18#199#147#165"
        },
        {
            "ID": 43,
            "RowVersion": "#0#0#0#0#18#199#135#138"
        },
        {
            "ID": 64,
            "RowVersion": "#0#0#0#0#1#97#8#65"
        }
    ],
    "Type": 3,
    "Url200x200ProportionalBiggest": "https://cordoba.blob.core.windows.net/files/02f787dc-7fcf-4f45-a698-4ab5b9e461b2/_raw_thumb_w200_h200_sProportionalBiggest.jpg",
    "Url600x600ProportionalBiggest": "https://cordoba.blob.core.windows.net/files/02f787dc-7fcf-4f45-a698-4ab5b9e461b2/_raw_thumb_w600_h600_sProportionalBiggest.jpg",
    "Url1200x1200ProportionalBiggest": "https://cordoba.blob.core.windows.net/files/02f787dc-7fcf-4f45-a698-4ab5b9e461b2/_raw_thumb_w1200_h1200_sProportionalBiggest.jpg",
    "Guid": "02f787dc-7fcf-4f45-a698-4ab5b9e461b2",
    "CreatedOn": "2022-04-26T01:08:42.233",
    "RowVersion": "#0#0#0#0#13#18#170#200",
    "External_DM_ID": 733775,
    "Deleted": false
}
```

## Item

```json
{
    "ID": 298,
    "FileID": 6858,
    "NamePrimary": "Acer",
    "NameSecondary": "Ahorn",
    "OwnerName": "Firma Green Solutions",
    "Description": null,
    "Number": null,
    "DurationSeconds": 0,
    "CreatedOn": "2016-04-20T14:13:55+02:00",
    "ApprovedOn": "0001-01-01T00:00:00",
    "TagIds": [
        13,
        64
    ],
    "Type": "Plant",
    "ReportType": null,
    "EntityKey": "entity.Articles.ArticleID.298",
    "Cache": null,
    "ImageWidth": null,
    "ImageHeight": null,
    "PlantPictureStatus": null,
    "Orientation": null,
    "PictureType": null,
    "Guid": "15ae95f6-844b-42f3-bdd1-dc8fe5c11914",
    "RowVersion": null,
    "External_DM_ID": null,
    "Deleted": false
}
```
