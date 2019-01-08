using Microsoft.Win32;

namespace UseFul.Uteis
{
    public class RegistryUtil
    {
        public static void SetRegistry(string name, string value)
        {
            const string path = @"SOFTWARE\ACSolutions\Welic\";
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(path);

            if (registryKey == null)
            {
                return;
            }

            registryKey.SetValue(name, value);
            registryKey.Close();
        }

        public static string GetRegistryValueByName(string name)
        {
            const string path = @"SOFTWARE\ACSolutions\Welic\";
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(path);

            string value = string.Empty;
            if (registryKey != null)
            {
                object registryValue = registryKey.GetValue(name);
                if (registryValue != null)
                {
                    value = registryKey.GetValue(name).ToString();
                }
                registryKey.Close();
            }
            return value;
        }
    }
}