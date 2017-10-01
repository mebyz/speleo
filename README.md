# speleo 
### author : mebyz (e.botros@lekiosk.com)
## A language-agnostic probabilistic approach to the "text fragmentation" problem using SymSpell and dotnet core 2.0

###PREREQUISTES
- dotnet core 2.x installed
- VSCode

=== RUN

``dotnet restore``

``cd src/Speleo``

``dotnet build``

``dotnet run``

> then go to http://localhost:5000/

=== TRY

/api/v1/correct?text=toitureendommagée => "toiture endommagée"

/api/v1/correct?text=voitureelectrique => "voiture electrique"

/api/v1/correct?text=poivrevert => "poivre vert"
 

=== PUBLISH

``donet publish``

then publish content of the ``src/Speleo/bin/Debug/netcoreapp2.0/publish/`` folder to ``speleo_builds`` repository

=> reminder : only deploy TAGS in production. do NOT deploy branches.

=== RUN LOCAL DOCKER

``donet publish``

``cd src/Speleo/bin/Debug/netcoreapp2.0/publish``

``docker-compose build``

``docker-compose up``

> then go to http://localhost:5000/