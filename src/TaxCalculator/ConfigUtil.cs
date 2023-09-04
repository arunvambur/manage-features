namespace TaxCalculator
{
    public static class Enviornments
    {
        public static string Dev = "dev";
        public static string Stg = "stg";
        public static string Prd = "prd";

    }

    public static class Region
    {
        public static string IN = "in";
        public static string US = "us";
    }

    public static class ConfigUtil
    {
        public static string ENVIRONMENT = "ENVIRONMENT";
        public static string REGION = "REGION";

        //directory
        public static string ConfigDirectory = "config";

        public static string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable);
        }

        public static string GetEnvironment()
        {
            return GetEnvironmentVariable(ENVIRONMENT);
        }

        public static string GetRegion()
        {
            return GetEnvironmentVariable(REGION);
        }

        public static bool IsDevEnviornment()
        {
            return GetEnvironment() == Enviornments.Dev;
        }

        public static string GetConfigurationFile()
        {
            string filePath = string.Format($"{Directory.GetCurrentDirectory()}\\{ConfigDirectory}\\{GetRegion()}\\appsettings.{GetEnvironment()}.json");
            return filePath;
        }


    }
}
