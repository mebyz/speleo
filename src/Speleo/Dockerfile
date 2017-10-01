FROM microsoft/dotnet:2.0.0-runtime-jessie
WORKDIR /Speleo
COPY . /Speleo
RUN mkdir -p /Speleo/src/Speleo/
COPY fr.txt /Speleo/src/Speleo/fr.txt
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "Speleo.dll"]