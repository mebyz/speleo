FROM microsoft/dotnet:2.0.0-runtime-jessie
WORKDIR /Speleo
COPY . /Speleo


EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "Speleo.dll"]