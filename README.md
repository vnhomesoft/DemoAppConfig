# Projects:
DemoAppConfig:

## Demonstration of multiple enviroment configuration
Run the app with specified environment.
```
dotnet run --environment=Staging
```

## Override setting by environment variables
To override sentting in json file we need to define environment variables to map the json keys.
Ihe naming method seem to be a little ridiculous if you deploy your .NET app together with services in other languages.
So, here we mapping variables in standard naming convention to .NET naming conventions.
Try set environemnt variable `DB_CONNECTION` and run the app to see result.
```
# On Linux
export DB_CONNECTION=sqlite
dotnet run --environment=Staging
```
The connection string is overrided by value from enviroment variable.