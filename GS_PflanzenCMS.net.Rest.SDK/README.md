
# Schnittstelle Webservice
## Omni Channel System (OCS)

Datum: 16.03.2022

## Inhaltsverzeichnis

**[Übersicht](#übersicht)**

**[Hinweise](#hinweise)**

**[Funktionsweise](#funktionsweise)**

**[Fehlerbehandlung](#fehlerbehandlung)**

**[Voraussetzungen](#voraussetzungen)**

**[Server](#Server)**

**[Abfragen](#abfragen)**

**[Postman](#postman)**

**[Authorisierung](#_Toc8988929)**

**[Währungen](#_Toc8988930)**

**[Länder (inkl. MwSt. Sätze)](#_Toc8988931)**

**[Kategorien](#_Toc8988932)**

**[Berichte](#_Toc8988933)**

> [Kundenkarten](#_Toc8988934)

> [Neue Kundenkarten abfragen](#_Toc8988935)

> [Neue Kundenkarten validieren](#_Toc8988936)

> [Aktueller Umsatz](#_Toc8988937)

**[Webshop Bestellungen](#_Toc8988938)**

**[Auftragsdaten](#_Toc8988939)**

**[Videos](#_Toc8988940)**

**[Filialen](#_Toc8988941)**

**[Kunden](#_Toc8988942)**

**[Artikel](#_Toc8988943)**

> [Erweiterte Anlage](#_Toc8988944)

> [Transaktionen](#_Toc8988945)

> [Varianten](#_Toc8988946)

> [Dialog „Bearbeiten&quot;](#_Toc8988947)

**[Bestellungen](#_Toc8988948)**

> [Alle Shop Bestellungen](#_Toc8988949)

> [Status anpassen](#_Toc8988950)

> [Dialog „Versenden&quot;](#_Toc8988951)

> [Dialog „Bestätigen&quot;](#_Toc8988952)

> [Dialog „Erledigen&quot;](#_Toc8988953)

> [Dialog „Stornieren&quot;](#_Toc8988954)

> [Dialog „Auftragsverwaltung&quot;](#_Toc8988955)

**[Dokumente](#_Toc8988956)**

> [Lieferschein Bestellung](#_Toc8988957)

> [Lieferschein Teilbestellung](#_Toc8988958)

**[Versandaufträge](#_Toc8988959)**

> [Packetaufkleber abfragen](#_Toc8988960)

**[Dateien](#_Toc8988961)**

> [Dateien Hochladen](#_Toc8988962)

> [Bilder hochladen](#_Toc8988963)

**[Gutscheine](#_Toc8988964)**

> [Gutschein erstellen](#_Toc8988965)

> [Gutschein finden](#_Toc8988966)

> [Zahlung reservieren](#_Toc8988967)

> [Zahlung durchführen](#_Toc8988968)

**[Aufträge (asynchrone Jobs)](#_Toc8988969)**

**[Container](#_Toc8988970)**

**[Jahresplanungen](#_Toc8988971)**

**[Piktogramme](#_Toc8988972)**

**[Suche](#_Toc8988973)**

**[Verknüpfte Inhalte für Artikel](#_Toc8988974)**

**[Verknüpfte Inhalte für Bericht](#_Toc8988975)**

**[Verknüpfte Inhalte für Video](#_Toc8988976)**

**[Extern hinzufügen](#_Toc8988977)**

> [Suchen](#_Toc8988978)

> [Nach einem Artikel suchen](#_Toc8988979)

> [Pflanzen importieren](#_Toc8988980)

> [Videos importieren](#_Toc8988981)

> [Berichte importieren](#_Toc8988982)

> [Bilder importieren](#_Toc8988983)

> [Pflanzenfotos importieren](#_Toc8988984)

**[Zwischenspeicher (Cache)](#_Toc8988985)**

> [Alle caches löschen](#_Toc8988986)

> [Datenbank- Cache löschen](#_Toc8988987)

> [Caches aufräumen](#_Toc8988988)

**[Datenstrukturen](#_Toc8988989)**

> [Bestellungen](#_Toc8988990)

> [Versandaufträge](#_Toc8988991)

> [Artikel](#_Toc8988992)

> [Aufträge (asynchrone Jobs)](#_Toc8988993)

> [Zahlung](#_Toc8988994)

> [Gutschein](#_Toc8988995)

> [Gutschein - Code](#_Toc8988996)

> [Gefundener Gutschein](#_Toc8988997)

> [Auftragsstatus](#_Toc8988998)

> [Abwicklungsstatus](#_Toc8988999)

> [Dokumentation](#_Toc8989000)

> [Artikelstatus](#_Toc8989001)

> [Datei](#_Toc8989002)

> [Transaktion](#_Toc8989003)

> [Statusmeldung](#_Toc8989004)

> [Kundenkarte](#_Toc8989005)

> [Result](#_Toc8989006)

> [Dialog](#_Toc8989007)

> [Upload](#_Toc8989008)

**[Dialoge](#_Toc8989009)**

> [Versenden](#_Toc8989010)

> [Auftragsverwaltung](#_Toc8989011)

> [Artikel bearbeiten](#_Toc8989012)

> [Bestellung bestätigen](#_Toc8989013)

> [Bestellung stornieren](#_Toc8989014)

> [Bestellung erledigen](#_Toc8989015)

**[Beispiele + API](#_Toc8989016)**

> [Beispiel Applikation + C# .Net API](#_Toc8989017)

> [Token abfragen zur Authentifizierung](#_Toc8989018)

> [Artikel anlegen](#_Toc8989019)

> [Bestellungen abfragen](#_Toc8989020)

# Übersicht

Mit dem Webservice können kann das System ausgelesen werden

# Hinweise

Eine Sitzung ist unbegrenzt gültig.

# Funktionsweise

Die API-Aufrufe werden als REST-Request durchgeführt, authentifiziert mit einem Zugriffstoken.

# Fehlerbehandlung

Im Fehlerfall eines Aufrufes wird ein Json Objekt mit den Fehlerinformationen zurückgegeben

# Voraussetzungen

Man benötigt ein Benutzerkonto auf dem CMS System mit ausreichender Berechtigung.

# Server

Die Anfragen werden über die folgende URL aufgerufen:

http://{domain}/api/

# Abfragen

Es gibt 6 Arten von Anfragen die für alle Entitäten gleich sind:

| **URL** | **Methode** | **Beschreibung** |
| --- | --- | --- |
| api/{entities} | GET | Liste von Entitäten abfragen |
| api/{entities}/{id} | GET | Entität abfragen |
| api/{entities}/?ext={external\_key} | GET | Entität auf Basis des External\_key abfragen |
| api/{entities}/{id} | PUT | Entität updaten |
| api/{entities} | PUT | Mehrere Entitäten updaten/anlegen wenn ein Array übertragen wird |
| api/{entities}/{id} | DELETE | Entität löschen |
| api/{entities} | POST | Eine neue Entität anlegen |

Alle Funktionen erwarten 3 Hostheader:

| **Header** | **Beschreibung** |
| --- | --- |
| **token** | Authorisierung |
| **language** | Sprache (z.B. de-DE) |
| **version** | 1.0 (default) |
| **vendor** | Beliebiger Name |

Alle Funktionen die Listen zurückgeben haben folgende Parameter:

| **Parameter** | **Beschreibung** |
| --- | --- |
| _ **pageIndex** _ | Aktuelle Seite |
| _ **pageSize** _ | Anzahl Einträge pro Seite |
| _ **Search** _ | Suchstring |
| _ **orderBy** _ | Sortierung (string) |
| _ **filter** _ | Filterkriterien |

**WICHTIG: Nur ausgewählte Felder abfragen/aktualisieren**

Bei dem GET und PUT zu einer Entität (Abfragen/Updaten) kann noch ein Parameter „properties&quot; mitgegeben werden um zu definieren welche Felder aus dem Model überhaupt verwendet/gefüllt werden sollen. Für z.B. Artikel sähe sowas wie folgt aus:

api/articles/4687?properties=Name,Name2,Photos,Keys,Keys.Info,Keys.Value,Keys.EAN,Keys.Photos

# Postman

Ein gutes Tool um die Schnittstelle zu testen vor der Implementation finden Sie hier:

[https://www.getpostman.com/](https://www.getpostman.com/)

Damit können Sie alles Abfragen ausprobieren ohne die Schnittstelle implementiert zu haben.

# Authorisierung

Die Authorisierung muss nur 1-mal durchgeführt werden vom Entwickler. Der daraus entstehende Token kann dann dauerhaft für den Zugriff verwendet werden ohne dass das Benutzername/Passwort erneut übertragen werden muss:

| **Funktion** | **Paramete** | **Beschreibung** |
| --- | --- | --- |
| api/account/validate | _user_ | Benutzername |
|
 | _password_ | Passwort |

Als Rückgabe wird ein Token zurückgegeben der bei allen folgenden Abfragen mitgegeben werden muss.

# Währungen

| Url | api/currencies |
| --- | --- |

# Länder (inkl. MwSt. Sätze)

| Url | api/countries |
| --- | --- |

# Kategorien

| Url | api/categories |
| --- | --- |

# Berichte

| Url | api/reports |
| --- | --- |

#


# Kundenkarten

| Url | api/debitcards |
| --- | --- |

## Neue Kundenkarten abfragen

Listet neue Kundenkarten ohne Validierung an den Anfang der Liste. Sie können dann pageweise immer weitergehen bis ein Datensatz erscheint der bereits validiert wurde.

**Siehe**  **34.16**

**Funktion: GET** /api/debitcards?orderby=ValidatedOn

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| **orderby** | _string_ | Sortierung | Listet die noch nicht zugeordneten Kundenkarten nach oben |

## Neue Kundenkarten validieren

Neue Kundenkarten müssen von der WaWi einmalig validiert werden das diese auch von dem eingeloggten Benutzer verwendet werden dürfen. Hierzu laden Sie sich bitte den Kunden, der der Karte zugeordnet ist und vergleichen z.B. Adressdaten

**Funktion: POST** /api/debitcards/validate/{id}

| **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- |
| **id** | _long_ | ID der Kundenkarte |
| **valid** | _Bool_ | Gültig oder nicht |
| **Error** | _string_ | Falls nicht gültig kann hier der Grund angegeben werden. Dieser Text wird dann dem Kunden angezeigt, wenn er versucht mit der Karte zu kaufen. Ansonsten bitte leer mitgeben |
| **Turnover** | _Double_ | Aktueller Umsatz auf der Kundenkarte |

## Aktueller Umsatz

In festen Intervallen müssen der aktuelle Umsatz sowie die einzelnen Auftragsdaten übertragen werden.

Setzen Sie hierfür das Turnover Feld auf den aktuell gebuchten Umsatz.

## Webshop Bestellungen

Webshop Aufträge haben nun eine Verknüpfung „DebitCard&quot; zu der Kundenkarte, der sie zugeordnet werden sollen.

## Auftragsdaten

Die Aufträge können als api/orders mit dem Status „Ready&quot; im System angelegt und dann über das DebitCard Feld mit der Kundenkarte verknüpft werden. Bitte verwenden Sie bei der Transaction den Type Cashdesc (4) damit das System weiß, das der Auftrag über die Kasse gelaufen ist.

**Wichtig:** Bitte achten Sie darauf uns nur Bestellungen zu übermitteln die Sie nicht von uns bekommen haben!

# Videos

| Url | api/videos |
| --- | --- |

# Filialen

| Url | api/chainstores |
| --- | --- |

# Kunden

| Url | api/members |
| --- | --- |

# Artikel

| Url | api/articles |
| --- | --- |

## Erweiterte Anlage

Mit dieser Funktion kann ein Artikel angelegt und direkt mit einem Green – Solutions Artikel um Informationen angereichert werden

**Funktion: POST** api/articles/create

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| _ **importExternal** _ | _bool_ | Externe Daten hinzufügen? |
 |
| _ **compareNameSecondary** _ | _bool_ | Name 2 vergleichen? |
 |

## Transaktionen

Mit dieser Funktion können bei größeren Mengen von Artikeln die Bestände und die Preise aktualisiert werden

**Funktion: POST** api/articles/ transaction

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| _ **BODY** _ | _ArticleTransactionArgs[]_ | Ein Array mit mehreren Transaktionen | Siehe **34.14** |

## Varianten

| Url | api/articlekeys |
| --- | --- |

## Dialog „Bearbeiten&quot;

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/articles/dialog/{id} | _ID_ | **long** | ID des Artikels der bearbeitet werden soll |

Als Rückgabe wird der Dialog zurückgegeben (siehe **34.18** und **35.3** )

# Bestellungen

| **Url** | **api/orders** |
| --- | --- |
| Filter | ownermemberid |

## Alle Shop Bestellungen

| Url | api/orders/all |
| --- | --- |

**Hinweis:** Diese Funktion ist nur zulässig von Benutzern innerhalb des Hauptaccount des Shops! Andernfalls wird ein entsprechender Fehler ausgelöst.

## Status anpassen

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/orders/transactions/status/{ID} | _ID_ | **long** | ID der Bestellung |
|
 | _BODY_ | **Statusmeldung** | Siehe **34.15** |

Als Rückgabe wird die Bestellung zurückgegeben (siehe **34.6** )

## Dialog „Versenden&quot;

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/orders/transactions/dialog/delivered/{id} | _ID_ | **long** | ID der Transaction der Bestellung (muss versenden sein) |

Als Rückgabe wird der Dialog zurückgegeben (siehe **34.18** und **35.1** )

## Dialog „Bestätigen&quot;

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/orders/dialog/confirm/{id} | _ID_ | **long** | ID der Bestellung |

Als Rückgabe wird der Dialog zurückgegeben (siehe **34.18** und **35.4** )

## Dialog „Erledigen&quot;

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/orders/dialog/finish/{id} | _ID_ | **long** | ID der Bestellung |

Als Rückgabe wird der Dialog zurückgegeben (siehe **34.18** und **35.6** )

## Dialog „Stornieren&quot;

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/orders/dialog/cancel/{id} | _ID_ | **long** | ID der Bestellung |

Als Rückgabe wird der Dialog zurückgegeben (siehe **34.18** und **35.5** )

## Dialog „Auftragsverwaltung&quot;

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/orders/dialog |
 |
 |
 |

Als Rückgabe wird der Dialog zurückgegeben (siehe **34.18** und **35.2** )

# Dokumente

## Lieferschein Bestellung

Liefert den Lieferschein zu einer Bestellung.

Bitte beachten Sie das sie nur die Positionen bekommen die bestätigt sind daher darf diese Funktion nur nach erfolgter Auftragsbestätigung aufgerufen werden.

| **Funktion(GET)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/documents/order/{orderid}/{type} | _orderid_ | **long** | ID der Bestellung |
|
 | _type_ | **string** | DeliverySlip |
|
 | output |
 | DOCX, PDF |

## Lieferschein Teilbestellung

Liefert den Lieferschein zu einer Teilbestellung.

Bitte beachten Sie das sie nur die Positionen bekommen die bestätigt sind daher darf diese Funktion nur nach erfolgter Auftragsbestätigung aufgerufen werden.

| **Funktion(GET)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/documents/order/{orderid}/{type}/{transactionid} | _orderid_ | **long** | ID der Bestellung |
|
 | _type_ | **string** | DeliverySlip |
|
 | _Transactionid_ | **long** | ID der Teilbestellung |
|
 | _Output_ |
 | DOCX, PDF |

# Versandaufträge

Enthält eine Liste aller Versandaufträge im System. Jeder Versandauftrag kann mehrere Items enthalten (Sendungen)

| Url | api/shipmentorders |
| --- | --- |

Siehe 34.2

## Packetaufkleber abfragen

Mit dieser Funktion kann der Paketschein abgefragt werden. Übergeben Sie dafür eine der ShipmentOrderID des Versandauftrags (siehe **20** )

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/shipmentorders/items/label/{id} | _ID_ | **long** | ID der Sendung |

Als Rückgabe wird die Pdf zurückgegeben

# Dateien

| Url | api/datafiles |
| --- | --- |

## Dateien Hochladen

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/datafiles/upload | _BODY_ | **Upload** | Siehe 34.19 |

Als Rückgabe wird die Datei zurückgegeben (siehe **34.13** )

## Bilder hochladen

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/pictures/upload | _BODY_ | **Upload** | Siehe 34.19 |

Als Rückgabe wird die Datei zurückgegeben (siehe **34.13** )

# Gutscheine

| Url | api/vouchers |
 |
| --- | --- | --- |

## Gutschein erstellen

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/vouchers/create | _name_ | **string** | Name für den neuen Gutschein |
|
 | _amount_ | **double** | Betrag |
|
 | _currencyName_ | **string** | Währung (z.B. EUR) |
|
 | _info_ | **string** | Eine Info die beim Gutschein sichtbar hinterlegt wird |
|
 | _deleted_ | **bool** | Gelöscht anlegen |

Als Rückgabe wird der Gutschein zurückgegeben (siehe **34.6** ).

## Gutschein finden

| **Funktion(GET)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/vouchers/find | _keyValue_ | **string** | Gutscheincode (ohne Leerzeichen) |

Rückgabe: Gutschein –Code (siehe **34.8** )

## Zahlung reservieren

Eine Zahlung für einen Gutschein reservieren. Während der Zeit gilt der Umsatz als verbraucht bis die Zeit abläuft und kann nicht an anderer Stelle verbraucht werden.

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/vouchers/reserve | _voucherID_ | **long** | Gutschein ID |
|
 | _voucherCodeID_ | **long** | Gutschein Code ID |
|
 | _amount_ | **double** | Betrag der reserviert werden soll |
|
 | _currencyName_ | **string** | Währung (z.B. EUR) |
|
 | _info_ | **string** | Eine Info die bei der Zahlung sichtbar hinterlegt wird |
|
 | _minutes_ | **int** | Anzahl der Minuten für die die Zahlung reserviert werden soll |

Als Rückgabe wird die erstellte Zahlung zurückgegeben (siehe **34.5** ).

## Zahlung durchführen

Nachdem eine Zahlung reserviert worden ist kann die Zahlung dann durchgeführt werden (während der Zeit der Reservierung)

| **Funktion(POST)** | **Parameter** | **Typ** | **Beschreibung** |
| --- | --- | --- | --- |
| api/vouchers/pay | _paymentid_ | l **ong** | ID der Zahlung (siehe **23.3** ) |

Als Rückgabe wird der Gutschein zurückgegeben (siehe **34.6** ).

# Aufträge (asynchrone Jobs)

| Url | api/jobs |
| --- | --- |

# Container

| Url | api/containers |
 |
| --- | --- | --- |
| Schlüssel | api/containers/key/{key} | Container mit Schlüssel suchen |
| Items | Api/containers/items/{id} | Alle Einträge eines Containers (inkl. Paging) |

# Jahresplanungen

| Url | api/timelines |
 |
| --- | --- | --- |
| Schlüssel | api/timelines/key/{key} | Planung mit Schlüssel suchen |
| Items | api/timelines/items/{id} | Alle Einträge einer Planung (inkl. Paging) |
| Current | api/timelines/current/{id} | Alle aktuellen Einträge einer Planung (inkl. Paging) |

# Piktogramme

**Funktion:** api/pictos/{id}

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| _ **id** _ | long | Artikel ID | Artikel für den das Piktogramm abgefragt werden soll |
| _ **width** _ | int | Breite | px |
| _ **height** _ | int | Höhe | px |

**Rückgabe:**

Eine Liste aller gültigen Piktogramme für den gewählten Artikel

**Definition:**

| **Feld** | **Typ** | **Beschreibung** |
| --- | --- | --- |
| Name | string | Name des Piktogramms (darzustellen in fett unter/neben dem Piktogramm)z.B. „Standort&quot; |
| Text | string | Text des Piktogramms (darzustellen unter/neben dem Namen)z.B. „Sonnig&quot; |
| Key | string | Eindeutiger Schlüssel |
| Url | string | URL für die Grafik |
| PictoID | long | Primärschlüssel |

# Suche

**Funktion:** api/search

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| _ **search** _ | _string_ | Suchbegriff |
 |
| _ **orderBy** _ | _string_ | Title, Title2 |
 |
| _ **Types** _ | _string_ | Article, Report, Video | Kann auch mehrfach angegeben werden z.B. Types=Article&amp;Types=Video |
| _ **BloomingTimeFrom** _ | _int_ | Blütezeit von | Monate |
| _ **BloomingTimeTo** _ | _int_ | Blütezeit bis | Monate |
| _ **WidthFrom** _ | _double_ | Breite von | cm |
| _ **WidthTo** _ | _double_ | Breite bis | cm |
| _ **HeightTo** _ | _double_ | Höhe von | cm |
| _ **HeightFrom** _ | _double_ | Höhe bis | cm |
| _ **WeightFrom** _ | _double_ | Gewicht von | kg |
| _ **WeightTo** _ | _double_ | Gewicht bis | kg |
| _ **GrowthFrom** _ | _double_ | Zuwachs von | cm |
| _ **GrowthTo** _ | _double_ | Zuwachs bis | cm |
| _ **FeatureIds** _ | _long[]_ | Merkmale | ID&#39;s der Merkmale (siehe Admin/Features) |

# Verknüpfte Inhalte für Artikel

**Funktion:** api/cross/articles{id}

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| _ **id** _ | _long_ | ID des Artikel |
 |
| _ **search** _ | _string_ | Suchbegriff |
 |
| _ **orderBy** _ | _string_ | Title, Title2 |
 |
| _ **Types** _ | _string_ | Article, Report, Video | Kann auch mehrfach angegeben werden z.B. Types=Article&amp;Types=Video |

# Verknüpfte Inhalte für Bericht

**Funktion:** api/cross/reports/{id}

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| _ **id** _ | _long_ | ID des Berichts |
 |
| _ **search** _ | _string_ | Suchbegriff |
 |
| _ **orderBy** _ | _string_ | Title, Title2 |
 |
| _ **Types** _ | _string_ | Article, Report, Video | Kann auch mehrfach angegeben werden z.B. Types=Article&amp;Types=Video |

# Verknüpfte Inhalte für Video

**Funktion:** api/cross/videos/{id}

| **Parameter** | **Typ** | **Beschreibung** | **Bemerkung** |
| --- | --- | --- | --- |
| _ **id** _ | _long_ | ID des Video |
 |
| _ **search** _ | _string_ | Suchbegriff |
 |
| _ **orderBy** _ | _string_ | Title, Title2 |
 |
| _ **Types** _ | _string_ | Article, Report, Video | Kann auch mehrfach angegeben werden z.B. Types=Article&amp;Types=Video |

# Extern hinzufügen

Über diese Funktion können Inhalte aus der Green-Solutions Datenbank gesucht und in die lokale CMS Datenbank importiert werden. Siehe „Extern Hinzufügen&quot; im CMS Backend!

## Suchen

**Funktion:** api/external/search

| _pageIndex_ | Aktuelle Seite |
| --- | --- |
| _pageSize_ | Anzahl Einträge pro Seite |
| _search_ | Suchstring |
| _orderBy_ | Sortierung (string) |

**Rückgabe:**

Eine Liste aller externen Suchergebnisse

## Nach einem Artikel suchen

**Funktion:** api/external/search/article

| _name_ | Name des Artikels (z.B. Acer Palmatum Bloodgood) |
| --- | --- |

**Rückgabe:**
Den am besten passenden Artikel

## Pflanzen importieren

**Funktion:** api/external/import/plants/{id}

| _id_ | Externe ID der Pflanze die importiert werden soll |
| --- | --- |
| _to_ | _ID des Artikels in den importiert werden soll (optional)_ |

## Videos importieren

**Funktion:** api/external/import/videos/{id}

| _id_ | Externe ID des Videos das importiert werden soll |
| --- | --- |

## Berichte importieren

**Funktion:** api/external/import/reports/{id}

| _id_ | Externe ID des Berichts der importiert werden soll |
| --- | --- |

## Bilder importieren

**Funktion:** api/external/import/pictures/{id}

| _id_ | Externe ID des Bildes das importiert werden soll |
| --- | --- |

## Pflanzenfotos importieren

**Funktion:** api/external/import/plantpictures/{id}

| _id_ | Externe ID des Pflanzenfotos das importiert werden soll |
| --- | --- |

# Zwischenspeicher (Cache)

Zur Verbesserung der Performance arbeitet das System mit einigen Caches die bei Bedarf gelöscht werden müssen. Momentan gibt es die folgenden Caches:

- Datenbank
- Sessions
- Suchindex
- Sitemaps

Sobald gecachte Inhalte in der Datenbank verändert wurden sollte der korrespondierende Cache gelöscht werden damit die Änderung direkt sichtbar wird.

## Alle caches löschen

**Funktion:** POSTapi/cache/clear

## Datenbank- Cache löschen

**Funktion:** POSTapi/cache/clear/efcache

## Caches aufräumen

**Funktion:** POSTapi/cache/purge

# Datenstrukturen

## Bestellungen

{

&quot;OrderID&quot;:174,

&quot;Voucher&quot;:null,

&quot;VoucherCode&quot;:null,

&quot;InvoiceAddress&quot;:{

&quot;ContactAddressID&quot;:6,

&quot;Type&quot;:1,

&quot;Address&quot;:{

&quot;AddressID&quot;:7,

&quot;Street&quot;:&quot;Bahnhofstraße&quot;,

&quot;HouseNumber&quot;:&quot;62b&quot;,

&quot;Zip&quot;:&quot;26835&quot;,

&quot;City&quot;:&quot;Hesel&quot;,

&quot;Postbox&quot;:null,

&quot;Country&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#58#151&quot;

},

&quot;Type&quot;:1,

&quot;Longitude&quot;:null,

&quot;Latitude&quot;:null,

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;Contact&quot;:{

&quot;ContactID&quot;:23,

&quot;Picture&quot;:null,

&quot;Apellation&quot;:1,

&quot;FirstName&quot;:&quot;Kevin&quot;,

&quot;LastName&quot;:&quot;Klaassen&quot;,

&quot;Phone&quot;:&quot;1325513154712&quot;,

&quot;Mobile&quot;:null,

&quot;Fax&quot;:null,

&quot;Position&quot;:null,

&quot;Homepage&quot;:null,

&quot;EMail&quot;:&quot;jhaghjs@bjkafgs.de&quot;,

&quot;Company&quot;:null,

&quot;Company2&quot;:null,

&quot;Language&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#44#148&quot;

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;Member&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#66#134&quot;

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;ShippingAddress&quot;:{

&quot;ContactAddressID&quot;:9,

&quot;Type&quot;:2,

&quot;Address&quot;:{

&quot;AddressID&quot;:10,

&quot;Street&quot;:&quot;gdsshgdshd&quot;,

&quot;HouseNumber&quot;:&quot;235253&quot;,

&quot;Zip&quot;:&quot;23789&quot;,

&quot;City&quot;:&quot;hsdshdshd&quot;,

&quot;Postbox&quot;:&quot;23236263&quot;,

&quot;Country&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#58#151&quot;

},

&quot;Type&quot;:2,

&quot;Longitude&quot;:null,

&quot;Latitude&quot;:null,

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;Contact&quot;:{

&quot;ContactID&quot;:26,

&quot;Picture&quot;:null,

&quot;Apellation&quot;:0,

&quot;FirstName&quot;:&quot;asgagsgas&quot;,

&quot;LastName&quot;:&quot;asgagsga&quot;,

&quot;Phone&quot;:&quot;23524362643&quot;,

&quot;Mobile&quot;:null,

&quot;Fax&quot;:null,

&quot;Position&quot;:null,

&quot;Homepage&quot;:null,

&quot;EMail&quot;:&quot;gaf@bkjfas.de&quot;,

&quot;Company&quot;:&quot;gasgas&quot;,

&quot;Company2&quot;:null,

&quot;Language&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#44#148&quot;

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;Member&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#66#134&quot;

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;Status&quot;:1,

&quot;TotalCostsArticles&quot;:27.799999999999997,

&quot;TotalTaxCosts1&quot;:1.24,

&quot;TaxRate1&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#230#203&quot;

},

&quot;TotalTaxCosts2&quot;:1.42,

&quot;TaxRate2&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#1#231#2&quot;

},

&quot;TotalCosts&quot;:44.789999999999992,

&quot;TaxRateDeliver&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#230#203&quot;

},

&quot;TotalTaxCostsDeliver&quot;:1.11,

&quot;TotalCostsDeliver&quot;:16.99,

&quot;TotalDiscount&quot;:0,

&quot;ApprovedBy&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#58#153&quot;

},

&quot;ApprovedOn&quot;:&quot;2017-01-30T15:56:59.677&quot;,

&quot;Notes&quot;:null,

&quot;File&quot;:null,

&quot;Currency&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#77#11&quot;

},

&quot;Items&quot;:[

{

&quot;OrderItemID&quot;:199,

&quot;ArticleGroups&quot;:null,

&quot;Date&quot;:&quot;2017-01-30T15:56:59.533&quot;,

&quot;DeliveryDate&quot;:&quot;2017-02-06T15:56:59.583&quot;,

&quot;Info&quot;:&quot;Rhododendron &#39;Abendsonne&#39;&quot;,

&quot;Info2&quot;:&quot;Rhododendron &#39;Abendsonne&#39;&quot;,

&quot;Photo&quot;:null,

&quot;ArticleKey&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#39#45&quot;

},

&quot;Vouchers&quot;:[{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#230#203&quot;

}]

&quot;Article&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#39#91&quot;

},

&quot;Notes&quot;:null,

&quot;Type&quot;:0,

&quot;Price&quot;:18.9,

&quot;Stock&quot;:false,

&quot;DropShip&quot;:false,

&quot;Currency&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#77#11&quot;

},

&quot;Quantity&quot;:1,

&quot;Rated&quot;:null,

&quot;RatedBy&quot;:null,

&quot;Position&quot;:0,

&quot;TotalPrice&quot;:18.9,

&quot;TotalCosts&quot;:18.9,

&quot;TaxRate&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#230#203&quot;

},

&quot;Glyph&quot;:null,

&quot;TransactionType&quot;:0,

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

{

&quot;OrderItemID&quot;:200,

&quot;ArticleGroups&quot;:null,

&quot;Date&quot;:&quot;2017-01-30T15:56:59.583&quot;,

&quot;DeliveryDate&quot;:&quot;2017-02-06T15:56:59.63&quot;,

&quot;Info&quot;:&quot;Frux Rhododendron- &amp; Moorbeeterde&quot;,

&quot;Info2&quot;:&quot;&quot;,

&quot;Photo&quot;:null,

&quot;ArticleKey&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#15#80&quot;

},

&quot;Article&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#223#163&quot;

},

&quot;Notes&quot;:null,

&quot;Type&quot;:0,

&quot;Price&quot;:8.9,

&quot;Stock&quot;:false,

&quot;DropShip&quot;:false,

&quot;Currency&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#77#11&quot;

},

&quot;Quantity&quot;:1,

&quot;Rated&quot;:null,

&quot;RatedBy&quot;:null,

&quot;Position&quot;:1,

&quot;TotalPrice&quot;:8.9,

&quot;TotalCosts&quot;:8.9,

&quot;TaxRate&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#1#231#2&quot;

},

&quot;Glyph&quot;:null,

&quot;TransactionType&quot;:0,

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

{

&quot;OrderItemID&quot;:201,

&quot;ArticleGroups&quot;:null,

&quot;Date&quot;:&quot;2017-01-30T15:56:59.63&quot;,

&quot;DeliveryDate&quot;:&quot;2017-02-06T15:56:59.677&quot;,

&quot;Info&quot;:&quot;Floragard Rhodohum&quot;,

&quot;Info2&quot;:&quot;&quot;,

&quot;Photo&quot;:null,

&quot;ArticleKey&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#15#76&quot;

},

&quot;Article&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#19#103&quot;

},

&quot;Notes&quot;:null,

&quot;Type&quot;:0,

&quot;Price&quot;:14.95,

&quot;Stock&quot;:false,

&quot;DropShip&quot;:false,

&quot;Currency&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#77#11&quot;

},

&quot;Quantity&quot;:3,

&quot;Rated&quot;:null,

&quot;RatedBy&quot;:null,

&quot;Position&quot;:2,

&quot;TotalPrice&quot;:44.849999999999994,

&quot;TotalCosts&quot;:44.849999999999994,

&quot;TaxRate&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#1#231#2&quot;

},

&quot;Glyph&quot;:null,

&quot;TransactionType&quot;:0,

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

}

],

&quot;Transactions&quot;:[

{

&quot;OrderTransactionID&quot;:90,

&quot;DeliveredTrackAndTraceID&quot;:null,

&quot;DeliveredTrackAndTraceURL&quot;:null,

&quot;Status&quot;:0,

&quot;StatusOn&quot;:null,

&quot;Type&quot;:0,

&quot;ShippingAddress&quot;:{

&quot;ContactAddressID&quot;:9,

&quot;Type&quot;:2,

&quot;Address&quot;:{

&quot;AddressID&quot;:10,

&quot;Street&quot;:&quot;gdsshgdshd&quot;,

&quot;HouseNumber&quot;:&quot;235253&quot;,

&quot;Zip&quot;:&quot;23789&quot;,

&quot;City&quot;:&quot;hsdshdshd&quot;,

&quot;Postbox&quot;:&quot;23236263&quot;,

&quot;Country&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#58#151&quot;

},

&quot;Type&quot;:2,

&quot;Longitude&quot;:null,

&quot;Latitude&quot;:null,

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;Contact&quot;:{

&quot;ContactID&quot;:26,

&quot;Picture&quot;:null,

&quot;Apellation&quot;:0,

&quot;FirstName&quot;:&quot;asgagsgas&quot;,

&quot;LastName&quot;:&quot;asgagsga&quot;,

&quot;Phone&quot;:&quot;23524362643&quot;,

&quot;Mobile&quot;:null,

&quot;Fax&quot;:null,

&quot;Position&quot;:null,

&quot;Homepage&quot;:null,

&quot;EMail&quot;:&quot;gaf@bkjfas.de&quot;,

&quot;Company&quot;:&quot;gasgas&quot;,

&quot;Company2&quot;:null,

&quot;Language&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#44#148&quot;

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;Member&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#2#66#134&quot;

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;ShippingMethod&quot;:{

&quot;ContactAddressID&quot;:0,

&quot;Type&quot;:0,

&quot;Address&quot;:null,

&quot;Contact&quot;:null,

&quot;Member&quot;:null,

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

}

],

&quot;ShippingMethod&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#202#162&quot;

},

&quot;External\_Key&quot;:null,

&quot;External\_COR\_ID&quot;:null

}

## Versandaufträge

{

&quot;ShipmentOrderID&quot;: 18,

&quot;Name&quot;: &quot;Versand für 2018-241&quot;,

&quot;Items&quot;: [

{

&quot;ShipmentOrderItemID&quot;: 16,

&quot;Number&quot;: &quot;222201010028682105&quot;,

&quot;Transaction&quot;: {

&quot;ID&quot;: 145,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#2&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;ShipmentOrder&quot;: {

&quot;ID&quot;: 18,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#3&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;WeightInKg&quot;: 10,

&quot;LengthInCM&quot;: null,

&quot;WidthInCM&quot;: null,

&quot;HeightInCM&quot;: null,

&quot;Data&quot;: &quot;{}&quot;,

&quot;TakenOn&quot;: &quot;2018-04-23T08:52:48.913&quot;,

&quot;CancelledOn&quot;: null,

&quot;HasShipmentLabel&quot;: true,

&quot;HasReturnLabel&quot;: false,

&quot;HasExportLabel&quot;: false,

&quot;HasCodeLabel&quot;: false,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#44#253&quot;,

&quot;Deleted&quot;: false

}

],

&quot;PaymentMethod&quot;: null,

&quot;ShippingMethod&quot;: {

&quot;ID&quot;: 3,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#44#222&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;Member&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#9&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;AddressFrom&quot;: {

&quot;ContactAddressID&quot;: 73,

&quot;Type&quot;: 2,

&quot;Address&quot;: {

&quot;AddressID&quot;: 78,

&quot;Street&quot;: &quot;Bahnhofstraße&quot;,

&quot;HouseNumber&quot;: &quot;1&quot;,

&quot;Zip&quot;: &quot;26129&quot;,

&quot;City&quot;: &quot;Musterhausen&quot;,

&quot;Postbox&quot;: null,

&quot;Country&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#6#134#52&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: &quot;#0#0#0#0#0#0#7#211&quot;,

&quot;External\_COR\_ID&quot;: null

},

&quot;Type&quot;: 2,

&quot;Longitude&quot;: null,

&quot;Latitude&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#44#125&quot;,

&quot;Deleted&quot;: false

},

&quot;Contact&quot;: {

&quot;ContactID&quot;: 216,

&quot;Picture&quot;: null,

&quot;Apellation&quot;: 1,

&quot;FirstName&quot;: &quot;Max&quot;,

&quot;LastName&quot;: &quot;Mustermann&quot;,

&quot;Phone&quot;: &quot;0123456789&quot;,

&quot;Mobile&quot;: null,

&quot;Fax&quot;: null,

&quot;Position&quot;: null,

&quot;Homepage&quot;: null,

&quot;EMail&quot;: &quot;tt@tt.de&quot;,

&quot;Company&quot;: null,

&quot;DisplayText&quot;: null,

&quot;Language&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#6#100#222&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: 1

},

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#44#126&quot;,

&quot;Deleted&quot;: false

},

&quot;Member&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#9&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#44#127&quot;,

&quot;Deleted&quot;: false

},

&quot;AddressTo&quot;: {

&quot;ContactAddressID&quot;: 9,

&quot;Type&quot;: 2,

&quot;Address&quot;: {

&quot;AddressID&quot;: 10,

&quot;Street&quot;: &quot;gdsshgdshd&quot;,

&quot;HouseNumber&quot;: &quot;235253&quot;,

&quot;Zip&quot;: &quot;23789&quot;,

&quot;City&quot;: &quot;hsdshdshd&quot;,

&quot;Postbox&quot;: &quot;23236263&quot;,

&quot;Country&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#6#134#52&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: &quot;#0#0#0#0#0#0#7#211&quot;,

&quot;External\_COR\_ID&quot;: null

},

&quot;Type&quot;: 2,

&quot;Longitude&quot;: null,

&quot;Latitude&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#2#35#228&quot;,

&quot;Deleted&quot;: false

},

&quot;Contact&quot;: {

&quot;ContactID&quot;: 26,

&quot;Picture&quot;: null,

&quot;Apellation&quot;: 0,

&quot;FirstName&quot;: &quot;asgagsgas&quot;,

&quot;LastName&quot;: &quot;asgagsga&quot;,

&quot;Phone&quot;: &quot;23524362643&quot;,

&quot;Mobile&quot;: null,

&quot;Fax&quot;: null,

&quot;Position&quot;: null,

&quot;Homepage&quot;: null,

&quot;EMail&quot;: &quot;gaf@bkjfas.de&quot;,

&quot;Company&quot;: &quot;gasgas&quot;,

&quot;DisplayText&quot;: null,

&quot;Language&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#6#100#222&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: 1

},

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#0#76#25&quot;,

&quot;Deleted&quot;: false

},

&quot;Member&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#9&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#2#35#231&quot;,

&quot;Deleted&quot;: false

},

&quot;Order&quot;: {

&quot;ID&quot;: 241,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#1&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;Transaction&quot;: {

&quot;ID&quot;: 145,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#2&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;Date&quot;: &quot;2018-04-24T00:00:00&quot;,

&quot;TakenOn&quot;: &quot;2018-04-23T08:52:48.913&quot;,

&quot;CancelledOn&quot;: null,

&quot;Data&quot;: &quot;{\&quot;Product\&quot;:0}&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#45#3&quot;,

&quot;Deleted&quot;: false

}

## Artikel

{

&quot;ArticleID&quot;: 1375,

&quot;Name&quot;: &quot;Abies koreana &#39;Veredelung&#39;&quot;,

&quot;Name2&quot;: &quot;Koreatanne &#39;Veredelung&#39;&quot;,

&quot;Description&quot;: &quot;Zierliche Tanne für kleine Gärten, zeigt sehr früh\nzierende Zapfen, hart.\n&quot;,

&quot;ShortDescription&quot;: null,

&quot;Photos&quot;: [],

&quot;ArticleGroups&quot;: [],

&quot;Categories&quot;: [

{

&quot;ID&quot;: 0,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#2#15#209&quot;

}

],

&quot;Countries&quot;: [],

&quot;Available&quot;: [],

&quot;Keys&quot;: [

{

&quot;ArticleKeyID&quot;: 1291,

&quot;Info&quot;: &quot;Sol C 20 125- 150&quot;,

&quot;Value&quot;: &quot;98820121&quot;,

&quot;Decimals&quot;: 0,

&quot;PackingUnit&quot;: 0,

&quot;PackingSize&quot;: null,

&quot;PackingUnitType&quot;: 0,

&quot;PackingForm&quot;: null,

&quot;DeliverSize&quot;: null,

&quot;DeliverUnitType&quot;: null,

&quot;DeliverType&quot;: null,

&quot;StockQuantity&quot;: 1,

&quot;EAN&quot;: &quot;4011266062981&quot;,

&quot;Country&quot;: {

&quot;ID&quot;: 0,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#2#58#151&quot;

},

&quot;TaxRate&quot;: {

&quot;ID&quot;: 0,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#0#230#203&quot;

},

&quot;AvailableForShippingText&quot;: null,

&quot;AvailableForShippingDeliverTime&quot;: null,

&quot;AvailableForRadiusDeliveryText&quot;: null,

&quot;AvailableForClickAndCollectText&quot;: null,

&quot;GrowthFrom&quot;: null,

&quot;GrowthTo&quot;: null,

&quot;WeightFrom&quot;: null,

&quot;WeightTo&quot;: null,

&quot;WidthFrom&quot;: null,

&quot;WidthTo&quot;: null,

&quot;HeightFrom&quot;: null,

&quot;HeightTo&quot;: null,

&quot;DeliverHeightFrom&quot;: null,

&quot;DeliverHeightTo&quot;: null,

&quot;LengthFrom&quot;: null,

&quot;LengthTo&quot;: null,

&quot;DepthFrom&quot;: null,

&quot;DepthTo&quot;: null,

&quot;PotSize&quot;: null,

&quot;PotSizeL&quot;: null,

&quot;FillAmountFrom&quot;: null,

&quot;FillAmountTo&quot;: null,

&quot;DiameterFrom&quot;: null,

&quot;DiameterTo&quot;: null,

&quot;LoadingCapacityFrom&quot;: null,

&quot;LoadingCapacityTo&quot;: null,

&quot;BloomingTimeFrom&quot;: null,

&quot;BloomingTimeTo&quot;: null,

&quot;BloomingTimePeriod&quot;: null,

&quot;BloomingTimePeriod2&quot;: null,

&quot;Size&quot;: null,

&quot;Quality&quot;: null,

&quot;Features&quot;: [],

&quot;Tasks&quot;: [],

&quot;Grower&quot;: null,

&quot;Brand&quot;: null,

&quot;BotanicName&quot;: null,

&quot;NameTranslation&quot;: null,

&quot;Photos&quot;: [],

&quot;Prices&quot;: [

{

&quot;ArticleKeyPriceID&quot;: 1712,

&quot;Quantity&quot;: 0,

&quot;Price&quot;: 189.5,

&quot;PriceUnitAmount&quot;: null,

&quot;ValueUnitType&quot;: null,

&quot;PriceOld&quot;: null,

&quot;PriceNet&quot;: false,

&quot;TaxIncluded&quot;: true,

&quot;Currency&quot;: {

&quot;ID&quot;: 0,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#0#77#11&quot;

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

}

],

&quot;Attachments&quot;: [],

&quot;Available&quot;: [],

&quot;CustomFields&quot;: [

{

&quot;CustomFieldID&quot;: 1061,

&quot;Field&quot;: {

&quot;ID&quot;: 0,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#2#34#20&quot;

},

&quot;StringValue&quot;: &quot;P&quot;,

&quot;IntValue&quot;: null,

&quot;DateValue&quot;: null,

&quot;FloatValue&quot;: null,

&quot;BoolValue&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

}

],

&quot;Inactive&quot;: false,

&quot;AvailableForShipping&quot;: true,

&quot;AvailableForRadiusDelivery&quot;: false,

&quot;AvailableForClickAndCollect&quot;: false,

&quot;AvailableForMarketPlaces&quot;: false,

&quot;External\_Key&quot;: &quot;98820121&quot;,

&quot;External\_COR\_ID&quot;: null

}

],

&quot;Texts&quot;: [

{

&quot;ArticleTextID&quot;: 14006,

&quot;Position&quot;: 0,

&quot;Type&quot;: 31,

&quot;Title&quot;: null,

&quot;Value&quot;: &quot;Zierliche Tanne für kleine Gärten, zeigt sehr früh\nzierende Zapfen, hart.\n&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

{

&quot;ArticleTextID&quot;: 14007,

&quot;Position&quot;: 0,

&quot;Type&quot;: 87,

&quot;Title&quot;: null,

&quot;Value&quot;: &quot;Nadelbaum mit attraktivem Zapfenschmuck\n&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

{

&quot;ArticleTextID&quot;: 14008,

&quot;Position&quot;: 0,

&quot;Type&quot;: 88,

&quot;Title&quot;: null,

&quot;Value&quot;: &quot;Standort (Boden): kalkverträglich, lehmig, nährstoffreich; Standort (Licht): vollsonnig bis leicht schattig; Winterhärte: frosthart; Besonderheiten (Pflegetipp): Schnitt unüblich\n&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

{

&quot;ArticleTextID&quot;: 14009,

&quot;Position&quot;: 0,

&quot;Type&quot;: 65,

&quot;Title&quot;: null,

&quot;Value&quot;: &quot;Blütezeit (Geruch): April bis Mai@Blütenfarbe: purpur@Blattfarbe, -phase: dunkelgrün, immergrün@Blattform: Nadeln bis 2 cm@Zapfen/Frucht: Zapfen blau-violett, später braun, eiförmig, aufrecht, bis 7 cm, sehr dekorativ@Wuchshöhe: über 5 m@Habitus: Nadelbaum@Standort (Boden): kalkverträglich, lehmig, nährstoffreich@Standort (Licht): vollsonnig bis leicht schattig@Verwendung Teil 1: Hausgarten, Steingarten, Einzelstellung, zusammen mit Rhododendron und Stauden@Rinde: im Alter rau@Winterhärte: frosthart\n&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

}

],

&quot;Tasks&quot;: [],

&quot;Ratings&quot;: [],

&quot;Tags&quot;: [],

&quot;Features&quot;: [],

&quot;CustomFields&quot;: [

{

&quot;CustomFieldID&quot;: 1059,

&quot;Field&quot;: {

&quot;ID&quot;: 0,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#2#34#19&quot;

},

&quot;StringValue&quot;: null,

&quot;IntValue&quot;: 24180,

&quot;DateValue&quot;: null,

&quot;FloatValue&quot;: null,

&quot;BoolValue&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

{

&quot;CustomFieldID&quot;: 1060,

&quot;Field&quot;: {

&quot;ID&quot;: 0,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#2#34#20&quot;

},

&quot;StringValue&quot;: &quot;P&quot;,

&quot;IntValue&quot;: null,

&quot;DateValue&quot;: null,

&quot;FloatValue&quot;: null,

&quot;BoolValue&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

}

],

&quot;RatingCount&quot;: null,

&quot;Teaser&quot;: null,

&quot;Inactive&quot;: false,

&quot;GrowthFrom&quot;: null,

&quot;GrowthTo&quot;: null,

&quot;WeightFrom&quot;: null,

&quot;WeightTo&quot;: null,

&quot;WidthFrom&quot;: null,

&quot;WidthTo&quot;: null,

&quot;HeightFrom&quot;: null,

&quot;HeightTo&quot;: null,

&quot;DeliverHeightFrom&quot;: null,

&quot;DeliverHeightTo&quot;: null,

&quot;LengthFrom&quot;: null,

&quot;LengthTo&quot;: null,

&quot;DepthFrom&quot;: null,

&quot;DepthTo&quot;: null,

&quot;PotSize&quot;: null,

&quot;PotSizeL&quot;: null,

&quot;FillAmountFrom&quot;: null,

&quot;FillAmountTo&quot;: null,

&quot;DiameterFrom&quot;: null,

&quot;DiameterTo&quot;: null,

&quot;LoadingCapacityFrom&quot;: null,

&quot;LoadingCapacityTo&quot;: null,

&quot;BloomingTimeFrom&quot;: null,

&quot;BloomingTimeTo&quot;: null,

&quot;BloomingTimePeriod&quot;: null,

&quot;BloomingTimePeriod2&quot;: null,

&quot;Size&quot;: null,

&quot;Quality&quot;: null,

&quot;Grower&quot;: null,

&quot;Brand&quot;: null,

&quot;BotanicName&quot;: null,

&quot;NameTranslation&quot;: null,

&quot;External\_Key&quot;: &quot;98820121&quot;,

&quot;External\_COR\_ID&quot;: null

}

## 34.4Aufträge (asynchrone Jobs)

{

&quot;JobID&quot;: 5,

&quot;Name&quot;: &quot;Sortimentsaktualisierung&quot;,

&quot;Percent&quot;: 100,

&quot;Status&quot;: &quot;2 aktualisiert&quot;,

&quot;Started&quot;: &quot;2016-05-11T14:26:12.407&quot;,

&quot;Finished&quot;: &quot;2016-05-11T14:26:15.05&quot;,

&quot;Alive&quot;: null,

&quot;Aborted&quot;: null,

&quot;Succeeded&quot;: true,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null

}

## Zahlung

{

&quot;PaymentID&quot;: 1,

&quot;ReservedUntil&quot;: null,

&quot;Info&quot;: null,

&quot;Price&quot;: 10,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#3#93#115&quot;,

&quot;External\_Key&quot;: null

},

&quot;VoucherCode&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#130#114&quot;,

&quot;Deleted&quot;: true

}

## Gutschein

{

&quot;VoucherID&quot;: 28,

&quot;Name&quot;: &quot;Auftrag 2017-184, Firma Blumen Cordes&quot;,

&quot;ValidFrom&quot;: null,

&quot;ValidTo&quot;: &quot;2019-08-10T00:00:00&quot;,

&quot;KeyValue&quot;: null,

&quot;Type&quot;: 1,

&quot;OrderItem&quot;: {

&quot;ID&quot;: 213,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#126#37&quot;,

&quot;External\_Key&quot;: null

},

&quot;Price&quot;: 50,

&quot;Remaining&quot;: 0.00999999999999801,

&quot;Info&quot;: null,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#3#93#115&quot;,

&quot;External\_Key&quot;: null

},

&quot;Codes&quot;: [

{

&quot;VoucherCodeID&quot;: 1781,

&quot;UsedOn&quot;: null,

&quot;KeyValue&quot;: &quot;4039T4GJ6M3MP6JK&quot;,

&quot;EAN&quot;: &quot;800000000204&quot;,

&quot;Voucher&quot;: {

&quot;ID&quot;: 28,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#132#3&quot;,

&quot;External\_Key&quot;: null

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#126#34&quot;,

&quot;Deleted&quot;: false

}

],

&quot;Payments&quot;: [

{

&quot;PaymentID&quot;: 1,

&quot;ReservedUntil&quot;: null,

&quot;Info&quot;: null,

&quot;Price&quot;: 10,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#3#93#115&quot;,

&quot;External\_Key&quot;: null

},

&quot;VoucherCode&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#130#114&quot;,

&quot;Deleted&quot;: true

},

{

&quot;PaymentID&quot;: 12,

&quot;ReservedUntil&quot;: null,

&quot;Info&quot;: null,

&quot;Price&quot;: 39.99,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#3#93#115&quot;,

&quot;External\_Key&quot;: null

},

&quot;VoucherCode&quot;: {

&quot;VoucherCodeID&quot;: 1781,

&quot;UsedOn&quot;: null,

&quot;KeyValue&quot;: &quot;4039T4GJ6M3MP6JK&quot;,

&quot;EAN&quot;: &quot;800000000204&quot;,

&quot;Voucher&quot;: {

&quot;ID&quot;: 28,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#132#3&quot;,

&quot;External\_Key&quot;: null

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#126#34&quot;,

&quot;Deleted&quot;: false

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#131#195&quot;,

&quot;Deleted&quot;: true

},

{

&quot;PaymentID&quot;: 18,

&quot;ReservedUntil&quot;: null,

&quot;Info&quot;: null,

&quot;Price&quot;: 44.99,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#3#93#115&quot;,

&quot;External\_Key&quot;: null

},

&quot;VoucherCode&quot;: {

&quot;VoucherCodeID&quot;: 1781,

&quot;UsedOn&quot;: null,

&quot;KeyValue&quot;: &quot;4039T4GJ6M3MP6JK&quot;,

&quot;EAN&quot;: &quot;800000000204&quot;,

&quot;Voucher&quot;: {

&quot;ID&quot;: 28,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#132#3&quot;,

&quot;External\_Key&quot;: null

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#126#34&quot;,

&quot;Deleted&quot;: false

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#131#218&quot;,

&quot;Deleted&quot;: true

},

{

&quot;PaymentID&quot;: 19,

&quot;ReservedUntil&quot;: null,

&quot;Info&quot;: &quot;Test&quot;,

&quot;Price&quot;: 49.99,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#3#93#115&quot;,

&quot;External\_Key&quot;: null

},

&quot;VoucherCode&quot;: {

&quot;VoucherCodeID&quot;: 1781,

&quot;UsedOn&quot;: null,

&quot;KeyValue&quot;: &quot;4039T4GJ6M3MP6JK&quot;,

&quot;EAN&quot;: &quot;800000000204&quot;,

&quot;Voucher&quot;: {

&quot;ID&quot;: 28,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#132#3&quot;,

&quot;External\_Key&quot;: null

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#126#34&quot;,

&quot;Deleted&quot;: false

},

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#132#12&quot;,

&quot;Deleted&quot;: false

}

],

&quot;External\_Key&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#132#3&quot;,

&quot;Deleted&quot;: false

}

## Gutschein - Code

{

&quot;VoucherCodeID&quot;: 1781,

&quot;UsedOn&quot;: null,

&quot;KeyValue&quot;: &quot;4039T4GJ6M3MP6JK&quot;,

&quot;EAN&quot;: &quot;800000000204&quot;,

&quot;Voucher&quot;: {

&quot;ID&quot;: 28,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#132#3&quot;,

&quot;External\_Key&quot;: null

},

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#5#126#34&quot;,

&quot;Deleted&quot;: false

}

## Gefundener Gutschein

{

&quot;VoucherID&quot;: 28,

&quot;VoucherCodeID&quot;: 1781,

&quot;UsedOn&quot;: null,

&quot;KeyValue&quot;: &quot;4039T4GJ6M3MP6JK&quot;,

&quot;EAN&quot;: &quot;800000000204&quot;,

&quot;Currency&quot;:{

&quot;ID&quot;:0,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#77#11&quot;

},

&quot;Remaining&quot;: 0.00999999999999801

}

## Auftragsstatus

public enum OrderStatusType : short

{

NotEdited, // Noch nicht bearbeitet

Confirmed, // Bestätigt

Canceled, // Storniert

Ready // Erledigt

}

## Abwicklungsstatus

public enum TransactionStatus : short

{

NotDelivered, // Noch nicht bearbeitet

Delivered, // Ausgeliefert

Ready // Steht Bereit

}

## Dokumentation

{

&quot;DocumentationID&quot;: 28,

&quot;Thumbnail&quot;: null,

&quot;DataFile&quot;: &quot;:{

&quot;ID&quot;:10,

&quot;RowVersion&quot;:&quot;#0#0#0#0#0#0#77#11&quot;

},

&quot;Language&quot;: null,

&quot;Title&quot;: null,

&quot;Type&quot;:&quot;Invoice&quot;

}

## Artikelstatus

{

&quot;External\_Key&quot;:&quot;abcdef&quot;

&quot;Confirmed&quot;: true,

&quot;QuantityConfirmed&quot;: null, // oder die Anzahl bei Teillieferungen

}

## Datei

{

&quot;FileID&quot;: 8965,

&quot;Revision&quot;: 2,

&quot;Name&quot;: &quot;testAnhang.pdf&quot;,

&quot;Type&quot;: &quot;file/pdf&quot;,

&quot;Guid&quot;: &quot;c4b4b19a-ce6d-4729-923f-c6ab922a70c8&quot;,

&quot;Url&quot;: &quot;http://localhost:61235/Files?id=8965&quot;,

&quot;SmallUrl&quot;: &quot;http://localhost:61235/Files?id=8965&amp;width=200&amp;height=200&quot;,

&quot;MediumUrl&quot;: &quot;http://localhost:61235/Files?id=8965&amp;width=600&amp;height=600&quot;,

&quot;LargeUrl&quot;: &quot;http://localhost:61235/Files?id=8965&amp;width=1200&amp;height=1200&quot;,

&quot;Size&quot;: 373790,

&quot;Title&quot;: null,

&quot;SearchKeywords&quot;: null,

&quot;Storename&quot;: &quot;testAnhang.pdf&quot;,

&quot;StoreName200x200ProportionalBiggest&quot;: null,

&quot;StoreName600x600ProportionalBiggest&quot;: null,

&quot;StoreName1200x1200ProportionalBiggest&quot;: null,

&quot;FrameCount&quot;: null,

&quot;StoreNameFrames&quot;: null,

&quot;StoreNameFramesMedium&quot;: null,

&quot;External\_Key&quot;: &quot;testAnhang.pdf&quot;,

&quot;External\_RowVersion&quot;: &quot;5769b59763194354b0096cb7c6eb8e46&quot;,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#6#10#88&quot;,

&quot;Deleted&quot;: false

}

## Transaktion

{

&quot;External\_Key&quot;: &quot;4711&quot;,

&quot;StockQuantity&quot;: 100,

&quot;Prices&quot;: &quot;:[

{

&quot;Quantity&quot;:null,

&quot;Price&quot;:5.9,

&quot;PriceOld&quot;:6.5,

}

]

}

## Statusmeldung
 ```csharp
{

"OrderStatus" : 1, // Siehe 34.9

"OrderTransactionID" : 10, // ID der Abwicklung

"Status": 1, // Siehe 34.10

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

{

&quot;OrderStatus&quot; : 1, // Siehe 34.9

&quot;OrderTransactionID&quot; : 10, // ID der Abwicklung

&quot;Status&quot;: 1, // Siehe 34.10

&quot;StatusOn&quot;: &quot;2018-04-03T14:30:05.037&quot;, // Wann wurde z.B. ausgeliefert

&quot;TrackAndTraceID&quot; : null, // Tracking ID

&quot;TrackAndTraceURL&quot; : null, // Tracking URL

&quot;Documentations&quot; : null, // Array von Dokumentationten **34.11**

&quot;InvoiceURI&quot; : null, // Rechnung als DataURI

&quot;InvoiceFilename&quot; : null, // Dateiname Rechnung

&quot;InvoiceMimeType&quot; : null, // Mimetype Rechnung

&quot;Articles&quot; : null, // Array von ArtikelStatus **34.12**

}

## Kundenkarte

{

&quot;DebitCardID&quot;: 1,

&quot;KeyValue&quot;: &quot;test&quot;,

&quot;Valid&quot;: true,

&quot;ValidatedOn&quot;: &quot;2018-11-15T13:16:28.7&quot;,

&quot;ValidatedBy&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#11#103#56&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;Member&quot;: {

&quot;ID&quot;: 70,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#9#35#145&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

},

&quot;Turnover&quot;: 55,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#6#99#130&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: 4

},

&quot;Orders&quot;: [

{

&quot;ID&quot;: 269,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#12#59#49&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null

}

],

&quot;Payments&quot;: [

{

&quot;PaymentID&quot;: 155,

&quot;ReservedUntil&quot;: null,

&quot;Info&quot;: &quot;Test&quot;,

&quot;Price&quot;: 15,

&quot;Currency&quot;: {

&quot;ID&quot;: 1,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#6#99#130&quot;,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: 4

},

&quot;VoucherCode&quot;: null,

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#12#59#50&quot;,

&quot;Deleted&quot;: false

}

],

&quot;Results&quot;: [],

&quot;External\_Key&quot;: null,

&quot;External\_RowVersion&quot;: null,

&quot;External\_COR\_ID&quot;: null,

&quot;External\_DM\_ID&quot;: null,

&quot;External\_COR\_Owner&quot;: null,

&quot;RowVersion&quot;: &quot;#0#0#0#0#0#12#62#22&quot;,

&quot;Deleted&quot;: false

}

## Result

{

&quot;ResultID&quot;: 43576,

&quot;Text&quot;: &quot;Kundenkarte nicht korrekt&quot;,

&quot;ResultType&quot;: &quot;ResultError&quot;, // ResultError oder ResultInfo

}

## Dialog

{

&quot;Url&quot;: &quot;http://localhost:61235/Plugin/OrderTransactions/Delivered/145&quot;,

&quot;Title&quot;: &quot;Auftrag versenden&quot;,

&quot;Width&quot;: 600,

&quot;Height&quot;: 400

}

## Upload

{

&quot;Filename&quot; : &quot;Test.png&quot;,

&quot;Data&quot; : &quot;iVBORwjsjhb67gjh…5ErkJggg==&quot;, // Dateiinhalt als Data URI https://de.wikipedia.org/wiki/Data-URL

&quot;Type&quot; : &quot;image/png&quot;, // Mime Type (z.B. application/pdf)

&quot;Deleted&quot; : &quot;false&quot;,

&quot;Rotation&quot;: 0 // Nur bei api/pictures/upload, Rotation im Uhrzeigersinn (1=90 Grad, 2=180 Grad usw.)

}

# Dialoge

Ausgesuchte Dialog können extern „aufgerufen werden&quot;. Dazu bekommen Sie von den entsprechenden API Funktionen einen Dialog (siehe **34.18** ).

Bitte öffnen Sie daraufhin ein Browser – Fenster in der angegebenen Größe und mit dem Titel. Danach navigieren Sie in dem Fenster zu der übergebenen Url!

## Versenden

![](RackMultipart20220316-4-1b19uaa_html_6033246c2359d7e7.png)

## Auftragsverwaltung

![](RackMultipart20220316-4-1b19uaa_html_8aa30f124fe80c06.png)

## Artikel bearbeiten

![](RackMultipart20220316-4-1b19uaa_html_c4730d08f1e2b93e.png)

## Bestellung bestätigen

![](RackMultipart20220316-4-1b19uaa_html_3d9d355a6c018a5d.png)

## Bestellung stornieren

![](RackMultipart20220316-4-1b19uaa_html_c1a373ffd988a0a4.png)

## Bestellung erledigen

![](RackMultipart20220316-4-1b19uaa_html_2a65965b4aff3ab9.png)

# Beispiele + API

## Beispiel Applikation + C# .Net API

Eine Beispiel Applikation sowieso eine API für C# .Net auf denen die nachfolgenden Beispiele basieren finden Sie hier:

[http://greensolutions.blob.core.windows.net/uploads/Samples/REST%20API.zip](http://greensolutions.blob.core.windows.net/uploads/Samples/REST%20API.zip)

## Token abfragen zur Authentifizierung

var unitOfWork = new Api.Client.ContextUOW(null, &quot;&quot;);

var token = unitOfWork.Account.Validate(&quot;Benutzer&quot;, &quot;Passwort&quot;); // POST api/account/validate?user={benutzer}&amp;password={passwort}

Das Token kann nun bei allen folgenden Posts als Header „token&quot; mitgesendet werden!

## Artikel anlegen

var unitOfWork = new Api.Client.ContextUOW(null,&quot;&quot;);

var article = new Article();

article.Name = &quot;Acer Palmatum Bloodgood&quot;;

article.Name2 = &quot;Fächerahorn Bloodgood&quot;;

article.Description = &quot;Dies ist eine lange Beschreibung&quot;;

article.ShortDescription = &quot;Dies ist eine kurze Beschreibung&quot;;

// Warengruppe setzen (evtl. Hierachie beachten)

var articleGroup = unitOfWork.ArticleGroups.FindAll(&quot;Pflanzen&quot;, 0, 100, null).Items.First(); // GET api/articlegroups

article.ArticleGroups.Add(new EntityReference() { ID = articleGroup.ArticleGroupID });

// Kategorie setzen (evtl. Hierachie beachten)

var category = unitOfWork.Categories.FindAll(&quot;Zubehör&quot;, 0, 100, null).Items.First(); // GET api/categories

article.Categories.Add(new EntityReference() { ID = category.CategoryID });

// Texte hinzufügen

var text = new ArticleText();

article.Texts.Add(text);

text.Type = Types.TextType.BulletPoints;

text.Title = &quot;Kaufargumente&quot;;

text.Value = &quot; \* frosthart \* duftend \* wintergrün \* Kübel geeignet&quot;;

// Verfügbarkeiten

var timePeriod = new TimePeriod();

article.Available.Add(timePeriod);

timePeriod.FromCW = 10; // Kalendarwoche (von)

timePeriod.ToCW = 20; // Kalendarwoche (bis)

// Varianten (Artikelnummern) hinzufügen

var articleKey = new ArticleKey();

article.Keys.Add(articleKey);

articleKey.Value = &quot;47811&quot;; // Artikelnummer

articleKey.Info = &quot;C/ 50 - 60&quot;;

articleKey.AvailableForClickAndCollect = true; // Click &amp; Collect

articleKey.AvailableForRadiusDelivery = true; // Liefern

articleKey.AvailableForShipping = true; // Versenden

articleKey.PackingSize = 20; // VE

articleKey.StockQuantity = 10; // Bestand

// Steuersatz

var taxRate = unitOfWork.Countries.Get(&quot;DE&quot;).TaxRates.Single(m =\&gt; m.Percent == 19); // GET api/countries

articleKey.TaxRate = new EntityReference() { ID = taxRate.TaxRateID };

// Preise

var currency = unitOfWork.Currencies.Get(&quot;EUR&quot;); // GET api/currencies

var articleKeyPrice = new ArticleKeyPrice();

articleKey.Prices.Add(articleKeyPrice);

articleKeyPrice.Price = 17; // Preis

articleKeyPrice.PriceOld = 25; // Streichpreis

articleKeyPrice.PriceUnitAmount = 10; // pro 10

articleKeyPrice.ValueUnitType = Types.PriceUnitType.Liter; // Liter

articleKeyPrice.Quantity = 1; // Ab Stückzahl

articleKeyPrice.Currency = new EntityReference() { ID = currency.CurrencyID };

articleKeyPrice.TaxIncluded = true; // Mwst. inkl?

articleKeyPrice.PriceNet = true; // Netto - Preis (keine Rabatte)

unitOfWork.Articles.Create(article); // POST api/articles/create?importExternal=true

// PUT api/articles/{id} zum updaten

## Bestellungen abfragen

var unitOfWork = new Api.Client.ContextUOW(null, &quot;&quot;);

var orders = unitOfWork.Orders.FindAll(null, 0, 100, &quot;OrderID desc&quot;).Items; // GET api/orders/all

foreach(var orderSummary in orders)

{

var order = unitOfWork.Orders.Get(orderSummary.OrderID); // GET api/orders/{id}

Console.WriteLine(&quot;Auftragsnummer:&quot; + order.OrderID);

Console.WriteLine(&quot;Datum:&quot; + order.CreatedOn.ToShortDateString());

var owner = unitOfWork.Members.Get(order.Owner.ID); // GET api/members/{id}

Console.WriteLine(&quot;Kunde:&quot; + owner.MainContact.Company);

Console.WriteLine(&quot;Rechnungsadresse:&quot; + order.InvoiceAddress.Contact.Company+&quot; &quot;+order.InvoiceAddress.Address.Street+&quot; &quot;+order.InvoiceAddress.Address.HouseNumber);

Console.WriteLine(&quot;Lieferadresse:&quot; + order.ShippingAddress.Contact.Company + &quot; &quot; + order.ShippingAddress.Address.Street + &quot; &quot; + order.ShippingAddress.Address.HouseNumber);

var paymentMethod = unitOfWork.PaymentMethods.Get(order.PaymentMethod.ID); // GET api/paymentmethods/{id}

Console.WriteLine(&quot;Bezahlart:&quot; + paymentMethod.Name);

var shippingMethod = unitOfWork.ShippingMethods.Get(order.ShippingMethod.ID); // GET api/shippingmethods/{id}

Console.WriteLine(&quot;Versandart:&quot; + shippingMethod.Name);

// Positionen

foreach (var position in order.Items)

{

var article = unitOfWork.Articles.Get(position.Article.ID); // GET api/articles/{id}

var articleKey = article.Keys.SingleOrDefault(m=\&gt;m.ArticleKeyID == position.ArticleKey.ID);

Console.WriteLine(&quot;Artikel:&quot; + article.Name+&quot; / &quot;+article.Name2);

Console.WriteLine(&quot;Artikelnummer:&quot; + articleKey.Value);

Console.WriteLine(&quot;Abwicklung:&quot; + position.TransactionType); // CLick&amp;Collect, Versenden u.s.w.

Console.WriteLine(&quot;Menge:&quot; + position.Quantity);

Console.WriteLine(&quot;Einzelpreis:&quot; + position.Price);

Console.WriteLine(&quot;Gesamtpreis:&quot; + position.TotalCosts);

Console.WriteLine(&quot;Bestätigt:&quot; + (position.IsConfirmed==true ? &quot;Ja&quot; : &quot;Nein&quot;) );

}

}
