using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBusiness;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace MyDVLD.Global_Classes
{
  public static  class ClsGlobal
    {
        public static ClsUser CurrentUser;

        public static bool RememberUserNameAndPassWord(string UserName ,string PassWord)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + "\\data.txt";

                if(UserName == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                string DataToSave = UserName + "#//#" + PassWord;

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine(DataToSave);
                    return true;
                }

            }catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
      
        public static bool GetStoredCredential(ref string  UserName , ref string Password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + "\\data.txt";

                if(File.Exists(FilePath))
                {
                    using (StreamReader  reader = new StreamReader(FilePath))
                    {
                        string Line;

                        while( (Line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(Line);

                            string[] Result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            UserName = Result[0];
                            Password = Result[1];

                        }
                        return true;
                    }
                }else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
   
    
         public static string ComputeHash(string input)
        {

            using (SHA256 sha256 = SHA256.Create())
            {


                byte[] hashbyte = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                return BitConverter.ToString(hashbyte).Replace("-", "").ToLower();
            }
        }
    }
}
