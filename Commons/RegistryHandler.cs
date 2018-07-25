using System;
using Microsoft.Win32;

namespace Commons
{
    /// <summary>
    /// Registry helper methods for HKEY_CURRENT_USER registry base key
    /// </summary>
    public static class RegistryHandler
    {
        public static bool CheckSubkeyExists( string subKeyName )
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyName);

            if (key == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Create subkey under HKEY_CURRENT_USER
        /// </summary>
        /// <param name="subKeyName"></param>
        public static void CreateSubKey( string subKeyName )
        {
            bool subkeyExists = CheckSubkeyExists(subKeyName);

            if (subkeyExists != true)
            {
                try
                {
                    Registry.CurrentUser.CreateSubKey(subKeyName);
                }
                catch (Exception e)
                {
                    LoggingHelper.WriteExceptionToLog(e);
                }
            }                
        }

        public static string CheckRegistryCache( string subKeyName, string cacheItemName, bool isItemEncrypted )
        {
            try
            {
                using (RegistryKey cacheKey = Registry.CurrentUser.OpenSubKey(subKeyName))
                {
                    if (cacheKey.GetValue(cacheItemName) != null && isItemEncrypted == false)
                        return cacheKey.GetValue(cacheItemName).ToString();

                    if (cacheKey.GetValue(cacheItemName) != null && isItemEncrypted == true)
                    {
                        Crypto credManage = new Crypto();
                        return credManage.DecryptString(cacheKey.GetValue(cacheItemName).ToString(), Crypto.VECTOR);
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

        public static void WriteRegistryCache( string subKeyName, string cacheItemName, string cacheItemValue, bool isItemEncrypted )
        {
            try
            {
                using (RegistryKey cacheKey = Registry.CurrentUser.OpenSubKey(subKeyName, true))
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
                            cacheKey.SetValue(cacheItemName, credManage.EncryptString(cacheItemValue, Crypto.VECTOR));
                        }
                        else
                            cacheKey.SetValue(cacheItemName, credManage.EncryptString(cacheItemValue, Crypto.VECTOR));
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.WriteExceptionToLog(e);
            }            
        }

        public static void DeleteRegistryItem( string subKeyName, string cacheItemName )
        {
            try
            {
                using (RegistryKey cacheKey = Registry.CurrentUser.OpenSubKey(subKeyName, true))
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

        public static bool RenameSubKey( string subKeyName, string newSubKeyName )
        {
            bool newSubkeyExists = CheckSubkeyExists(newSubKeyName);
            bool oldSubkeyExists = CheckSubkeyExists(subKeyName);

            if (newSubkeyExists || !oldSubkeyExists) // return false if the new subkey already exists or old one does not
                return false;

            bool keyCopied = CopyKey(subKeyName, newSubKeyName);

            if (keyCopied)
            {
                Registry.CurrentUser.DeleteSubKeyTree(subKeyName);
                return true;
            }
            else
                return false;
        }

        public static bool CopyKey( string keyNameToCopy, string newKeyName )
        {
            RegistryKey destinationKey = Registry.CurrentUser.CreateSubKey(newKeyName);
            RegistryKey sourceKey = Registry.CurrentUser.OpenSubKey(keyNameToCopy);

            if (sourceKey == null)
                return false;

            RecurseCopyKey(sourceKey, destinationKey);
            return true;
        }

        private static void RecurseCopyKey( RegistryKey sourceKey, RegistryKey destinationKey )
        {
            foreach (string valueName in sourceKey.GetValueNames())
            {
                object objValue = sourceKey.GetValue(valueName);
                RegistryValueKind valKind = sourceKey.GetValueKind(valueName);
                destinationKey.SetValue(valueName, objValue, valKind);
            }

            foreach (string sourceSubKeyName in sourceKey.GetSubKeyNames())
            {
                RegistryKey sourceSubKey = sourceKey.OpenSubKey(sourceSubKeyName);
                RegistryKey destSubKey = destinationKey.CreateSubKey(sourceSubKeyName);
                RecurseCopyKey(sourceSubKey, destSubKey);
            }
        }        
    }    
}
