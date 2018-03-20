# speleo 
### A language-agnostic probabilistic approach to the "text fragmentation" problem using SymSpell and dotnet core 2.0

###### author : mebyz - e.botros@lekiosk.com



## PREREQUISTES
- dotnet core 2.x installed
- VSCode


## RUN

``dotnet restore``

``cd src/Speleo``

``dotnet build``

``dotnet run``

> then go to http://localhost:5000/


## PUBLISH

``donet publish``

then publish content of ``src/Speleo/bin/Debug/netcoreapp2.0/publish/`` 

to ``speleo_builds`` repository

**reminder : only deploy TAGS in production. do NOT deploy branches.**


## RUN LOCAL DOCKER

`donet publish`

`cd src/Speleo/bin/Debug/netcoreapp2.0/publish`

`docker-compose build`

`docker-compose up`

> then go to http://localhost:5000/


## TRY

`/api/v1/correct?language=fr&editDistanceMax=0&enableCompoundCheck=true&text=toitureendommagée`

produces => "toiture endommagée"

`/api/v1/correct?language=fr&editDistanceMax=0&enableCompoundCheck=true&text=voitureelectrique`

produces => "voiture electrique"

`/api/v1/correct?language=fr&editDistanceMax=0&enableCompoundCheck=true&text=poivrevert`

produces => "poivre vert"

## sample use of the english dictionary:

*input : "whereis th elove hehad dated forImuch of thepast who couqdn'tread in sixthgrade and ins pired him"*

`/api/v1/correct?language=en&text=whereis%20th%20elove%20hehad%20dated%20forImuch%20of%20thepast%20who%20couqdn%27tread%20in%20sixthgrade%20and%20ins%20pired%20him&editDistanceMax=2&enableCompoundCheck=true`

produces => "where is the love he had dated for much of the past who couldn't read in sixth grade and inspired him"
