#Take dotnet sdk as base image
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal as build
#Create a work directory for GroceryTracker app
WORKDIR /groc
#Copy source code to work directory
COPY src/ /groc/
#Generate Publish files
RUN dotnet publish Grocery.Tracker.ConsoleUI/Grocery.Tracker.ConsoleUI.csproj -c Release -o /groc/publish
#Run GroceryTracker app
ENTRYPOINT ["dotnet", "/groc/publish/Grocery.Tracker.ConsoleUI.dll"]
