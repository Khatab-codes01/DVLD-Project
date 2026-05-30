using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using Microsoft.Win32;


namespace DVLD.Classes
{
    internal static  class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            //try
            //{
            //    //this will get the current project directory folder.
            //    string currentDirectory = System.IO.Directory.GetCurrentDirectory();


            //    // Define the path to the text file where you want to save the data
            //    string filePath = currentDirectory + "\\data.txt";

            //    //incase the username is empty, delete the file
            //    if (Username=="" && File.Exists(filePath)) 
            //    { 
            //         File.Delete(filePath);
            //        return true;

            //    }

            //    // concatonate username and passwrod withe seperator.
            //    string dataToSave = Username + "#//#"+Password ;

            //    // Create a StreamWriter to write to the file
            //    using (StreamWriter writer = new StreamWriter(filePath))
            //    {
            //        // Write the data to the file
            //        writer.WriteLine(dataToSave);

            //      return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //   MessageBox.Show ($"An error occurred: {ex.Message}");
            //    return false;
            //}


            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";
            //string username = "user123";  // اسم المستخدم الذي ترغب في تخزينه
            //string password = "mySecurePassword123";  // كلمة المرور التي ترغب في تخزينها

            try
            {
                // تخزين اسم المستخدم وكلمة المرور في السجل
                Registry.SetValue(keyPath, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);

                Console.WriteLine("Username and password successfully written to the Registry.");
                return true;
            }
            catch (Exception ex)
            {


                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;


            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";


            try
            {

                // Read the Username and Password from the Registry
                Username = (string)Registry.GetValue(keyPath, "Username", null);
                Password = (string)Registry.GetValue(keyPath, "Password", null);

                // Check if values were found
                if (Username != null && Password != null)
                {

                    return true;

                }
                else
                {

                    return false;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                  return false;

            }















        }
    }
}
