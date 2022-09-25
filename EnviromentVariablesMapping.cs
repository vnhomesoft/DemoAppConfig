namespace DemoAppConfig;
internal static class EnviromentVariablesMapping {
    //private const string APP_SETTTING_FILE = "appsettings";
    private static readonly Dictionary<string, string> map = new()
    {
        {"DB_CONNECTION", "ConnectionStrings__Default"},
        // TODO: define more env. variables here  
    };

    /// <summary>
    /// Mapping external enviroment setting to override configuration
    /// </summary>
    public static void OverrideDefaultSettings(WebApplicationBuilder builder){
      foreach(var kv in map){
        OverrideIfEnvExist(kv.Key, kv.Value);
      }
    }

    // // Custom method to load configuration from json for different environments
    // private static void UseDefaultConfiguration(WebApplicationBuilder builder){
    //   var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    //   var appSettingFile = $"{APP_SETTTING_FILE}.json";
    //   if(!string.IsNullOrWhiteSpace(env)){
    //     appSettingFile = $"{APP_SETTTING_FILE}.{env}.json";
    //   }

    //   if(System.IO.File.Exists(appSettingFile)){
    //     IConfigurationRoot config = new ConfigurationBuilder()
    //       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //       .AddJsonFile(appSettingFile, true)
    //       .AddEnvironmentVariables()
    //       .Build();
    //     builder.WebHost.UseConfiguration(config);
    //   }
    // }

    /// <summary>
    /// Override default setting from json file by environemnt variables.
    /// </summary>
    /// <param name="outKey">External variable name</param>
    /// <param name="inKey">(Internal) variable name that map with Json key</param>
    private static void OverrideIfEnvExist(string outKey, string inKey){
        var envVar = Environment.GetEnvironmentVariable(outKey);
        //Console.WriteLine($"Env: {outKey} = {envVar}");
        if(!string.IsNullOrEmpty(envVar)){
            Environment.SetEnvironmentVariable(inKey, envVar);
        }
    }
}