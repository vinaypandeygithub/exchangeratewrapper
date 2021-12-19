## What is the application for

The application is a wrapper on https://exchangerate.host/#/#docs which exposes endpoint **GetExchangeRateMovement** and accepts more than one date as input then in response gives details such as below:-

• The maximum exchange rate during the period

• The minimum exchange rate during the period

• The average exchange rate during the period


## Application Architecture

Application is written with principles of Clean/Onion architecture. More detail on Clean architecture can be found at https://sharingwhiledoing.blogspot.com/2021/11/application-architecture.html.
Route based versioning has been considered in the architecture to let the development team maintain more than 1 version of the API.

## Out of scope

No unit testing has been done, but ease of unit testing has been considered hence Clean architecture has been used. XUnit & Moq can be used to perform unit testing.

## Technology Stack

| **Component** | **Feature/Remark** |
| --- | --- |
| ASP.Net Core| ASP.NET Core is a free and open-source web framework and successor to ASP.NET, developed by Microsoft. It is a modular framework that runs on both the full .NET Framework, on Windows, and the cross-platform .NET. However ASP.NET Core version 3 works only on .NET Core dropping support of the .NET Framework |
| Swagger | Simplify API development for users, teams, and enterprises with our open source and professional toolset |


### Sample request with more than 50 dates

```{
  "datesToAnalyse": [
    "2021-01-01",
"2021-01-02",
"2021-01-03",
"2021-01-04",
"2021-01-05",
"2021-01-06",
"2021-01-07",
"2021-01-08",
"2021-01-09",
"2021-01-10",
"2021-01-11",
"2021-01-12",
"2021-01-13",
"2021-01-14",
"2021-01-15",
"2021-01-16",
"2021-01-17",
"2021-01-18",
"2021-01-19",
"2021-01-20",
"2021-01-21",
"2021-01-22",
"2021-01-23",
"2021-01-24",
"2021-01-25",
"2021-01-26",
"2021-01-27",
"2021-01-28",
"2021-01-29",
"2021-01-30",
"2021-01-31",
"2021-02-01",
"2021-02-02",
"2021-02-03",
"2021-02-04",
"2021-02-05",
"2021-02-06",
"2021-02-07",
"2021-02-08",
"2021-02-09",
"2021-02-10",
"2021-02-11",
"2021-02-12",
"2021-02-13",
"2021-02-14",
"2021-02-15",
"2021-02-16",
"2021-02-17",
"2021-02-18",
"2021-02-19",
"2021-02-20",
"2021-02-21",
"2021-02-22",
"2021-02-23",
"2021-02-24",
"2021-02-25",
"2021-02-26",
"2021-02-27",
"2021-02-28"

  ],
  "sourceCurrency": "GBP",
  "targetCurrency": "USD"
}
```

### Response
```
{
  "maximumReachedOnDate": "2021-01-01T00:00:00",
  "minumumReachedOnDate": "2021-02-19T00:00:00",
  "maximumReached": 1.323114,
  "minimumReached": 1.381467,
  "averageRate": 1.3530947796610162
}
```

#### Response time

Due to caching implemented in repository layer, subequent call takes 2-3 ms compared to 1100-1200 ms

## NFR&#39;s Catered

1. Application has been developed using microservices architecture hence can be scaled at runtime and deployed as per need.
2. Caching reduces processing time drastically.

## Known Issues

Application uses InMemory cache hence when load balanced may not always perform due to cache access restricted to application domain. Redis can be used as cache to help overcome this situation.

## How to Run In Visual Studio

Open VS 2019, open ToDo.sln and click run from tool bar or click F5, you will be shown Swagger UI.
Input parameters as per test case and verify the result, more detail can be found at https://idratherbewriting.com/learnapidoc/pubapis_swagger.html
