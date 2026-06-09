# download the whole dotnet sdk to build our app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# copy all the files into the working dir
COPY . ./
#install packeges and build the app
RUN dotnet restore
RUN dotnet publish -c Release -o out

# install the smaller runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# copy the build dir from the bulky sdk into the light image
COPY --from=build /app/out .

# defines the startup commands
ENTRYPOINT ["dotnet", "AnimeNewsletter.dll"]