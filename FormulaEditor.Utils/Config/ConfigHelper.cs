using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace FormulaEditor.Utils.Config
{
    public static class ConfigHelper
    {
        public static void UpdateAppConfig(string newKey, string newValue)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }

            // Open App.Config of executable      
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // You need to remove the old settings object before you can replace it      
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            // Add an Application Setting.      
            config.AppSettings.Settings.Add(newKey, newValue);
            // Save the changes in App.config file.      
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.      
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetAppConfig(string strKey)
        {
            try
            {
                string file = System.Windows.Forms.Application.ExecutablePath;
                Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                foreach (string key in config.AppSettings.Settings.AllKeys)
                {
                    if (key == strKey)
                    {
                        return config.AppSettings.Settings[strKey].Value.ToString();
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
