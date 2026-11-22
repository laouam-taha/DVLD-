using DVLD_Buisness;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Global_Classe
{
    internal static class clsGlobal
    {
        public static clsUsers CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            const string RegistrySubKey = @"Software\DVLD Project";
            try
            {
                
                if (string.IsNullOrEmpty(Username))
                {
                    Registry.CurrentUser.DeleteSubKey(RegistrySubKey, false);
                    return true;
                }

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistrySubKey))
                {
                    key.SetValue("Username", Username, RegistryValueKind.String);
                    key.SetValue("Password", Password, RegistryValueKind.String);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

       

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            const string RegistrySubKey = @"Software\DVLD Project";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistrySubKey))
                {
                    if (key == null)
                        return false;

                    string storedUsername = key.GetValue("Username") as string;
                    string storedPassword = key.GetValue("Password") as string;

                    if (string.IsNullOrEmpty(storedUsername) || storedPassword == null)
                        return false;

                    Username = storedUsername;
                    Password = storedPassword;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
