using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Cezium.SmartHome.Api.Models.Configuration
{
    public class Item
    {
        public string Name {get; set;}
        public ItemConfiguration Configuration {get; set;}
    }

    public class ItemConfiguration
    {
        public bool ShowOnDashboard { get; set; }
        public bool ShowInDashboardTab { get; set; }
        public string DashboardTabName { get; set; }
    }

    public class Configuration
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }

    public class ConfigurationService
    {
        private string _path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Configuration\configuration.json");

        private void CreateDefaultConfigurationFile()
        {
            if (!File.Exists(_path))
            {
                List<Configuration> Configurations = new List<Configuration>() { 
                    new Configuration()
                    {
                        Name = "default",
                        Items = new List<Item>(){}
                    }
                };

                string json = JsonConvert.SerializeObject(Configurations);

                using (StreamWriter writer = File.CreateText(_path))
                {
                    writer.Write(json);
                }
            }
        }

        public Configuration Read()
        {
            CreateDefaultConfigurationFile();

            string content = File.ReadAllText(_path, Encoding.UTF8);

            return JsonConvert.DeserializeObject<List<Configuration>>(content).FirstOrDefault();
        }

        public List<string> Write(Configuration configuration)
        {
            List<string> response = new List<string>();

            response.Add("source config:");
            response.Add(JsonConvert.SerializeObject(configuration));

            try
            {

                //Configuration configuration = JsonConvert.DeserializeObject<Configuration>(configurationJson);


                CreateDefaultConfigurationFile();

                string content = File.ReadAllText(_path, Encoding.UTF8);

                List<Configuration> configurations = JsonConvert.DeserializeObject<List<Configuration>>(content);

                var currentConfiguration = configurations.FirstOrDefault(c => c.Name == configuration.Name);
                if (currentConfiguration != null)
                {
                    configurations.FirstOrDefault(c => c.Name == configuration.Name).Items = configuration.Items;
                }
                else
                {
                    configurations.Add(configuration);
                }

                string json = JsonConvert.SerializeObject(configurations);

                using (StreamWriter writer = File.CreateText(_path))
                {
                    writer.Write(json);
                }
            }
            catch (Exception ex)
            {
            }

            return response;
        }
    }
}