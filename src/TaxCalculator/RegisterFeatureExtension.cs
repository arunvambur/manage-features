using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaxCalculator
{
    public static class RegisterFeatureExtension
    {
        public static void RegisterFeature(this IServiceCollection services, string path, string pattern, Type featureType, string region)
        {
            string fileName = pattern.Replace("*", region);

            string fullPath = $"{Path.GetDirectoryName(typeof(RegisterFeatureExtension).Assembly.Location)}\\{path}\\{fileName}";

            var assembly = Assembly.LoadFrom(fullPath);

            //register service types
            var implemntationType = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(featureType)).SingleOrDefault();
            if (implemntationType != null)
            {
                services.AddTransient(featureType, implemntationType);
                
            }

        }
    }
}
