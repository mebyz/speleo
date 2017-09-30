FROM microsoft/aspnetcore-build:2.0
ARG source=.
WORKDIR /Spello
COPY $source /Spello
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]


EXPOSE 9000/tcp
ENV ASPNETCORE_URLS http://*:9000

ENTRYPOINT ["dotnet", "run"]


