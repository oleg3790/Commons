using System;
using Microsoft.Win32;

namespace Commons
{
    public static class RegistryHandler
    {        
        public static void CreateSubKey()
        {
            string[] subKeys = Registry.CurrentUser.GetSubKeyNames();
            bool subKeyPresent = false;

            foreach (string x in subKeys)
            {
                if (x == "SupportTools")
                    subKeyPresent = true;
            }

            if (subKeyPresent != true)
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey("SupportTools");
                }
                catch (Exception e)
                {
                    LoggingHelper.WriteExceptionToLog(e);
                }
            }                
        }

        public static string CheckRegistryCache(string cacheItemName, bool isItemEncrypted)
        {
            try
            {
                using (RegistryKey cacheKey = Registry.CurrentUser.OpenSubKey("SupportTools"))
                {
                    if (cacheKey.GetValue(cacheItemName) != null && isItemEncrypted == false)
                        return cacheKey.GetValue(cacheItemName).ToString();

                    if (cacheKey.GetValue(cacheItemName) != null && isItemEncrypted == true)
                    {
                        Crypto credManage = new Crypto();
                        return credManage.DecryptString(cacheKey.GetValue(cacheItemName).ToString(), credManage.vector);
                    }
                    else
                        return null;
                }
            }            
            catch (Exception e)
            {
                LoggingHelper.WriteExceptionToLog(e);
                return null;
            }
        }

        public static void WriteRegistryCache(string cacheItemName, string cacheItemValue, bool isItemEncrypted)
        {
            try
            {
                using (RegistryKey cacheKey = Registry.CurrentUser.OpenSubKey("SupportTools", true))
                {
                    if (isItemEncrypted == false)
                    {
                        if (cacheKey.GetValue(cacheItemName) != null)
                        {
                            cacheKey.DeleteValue(cacheItemName);
                            cacheKey.SetValue(cacheItemName, cacheItemValue);
                        }
                        else
                            cacheKey.SetValue(cacheItemName, cacheItemValue);
                    }                        
                    if (isItemEncrypted == true)
                    {
                        Crypto credManage = new Crypto();
                        if (cacheKey.GetValue(cacheItemName) != null)
                        {
                            cacheKey.DeleteValue(cacheItemName);
                            cacheKey.SetValue(cacheItemName, credManage.EncryptString(cacheItemValue, credManage.vector));
                        }
                        else
                            cacheKey.SetValue(cacheItemName, credManage.EncryptString(cacheItemValue, credManage.vector));
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.WriteExceptionToLog(e);
            }            
        }

        public static void DeleteRegistryItem(string cacheItemName)
        {
            try
            {
                using (RegistryKey cacheKey = Registry.CurrentUser.OpenSubKey("SupportTools", true))
                {
                    if (cacheKey.GetValue(cacheItemName) != null)
                        cacheKey.DeleteValue(cacheItemName);
                }
            }
            catch (Exception e)
            {
                LoggingHelper.WriteExceptionToLog(e);
            }
        }
    }    
}
