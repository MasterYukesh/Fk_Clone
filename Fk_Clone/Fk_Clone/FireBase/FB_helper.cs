using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Fk_Clone.Model;

namespace Fk_Clone.FireBase
{
   public class FB_helper
    {
        public static FirebaseClient fbc = new FirebaseClient("https://fkclone-aed80-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public static async Task<List<Users>> getallusers()
        {
            try
            {
               var userlist = ( await fbc.Child("users").OnceAsync<Users>()).Select(item => new Users()
               {
                   firstname = item.Object.firstname,
                   lastname = item.Object.lastname,
                   password = item.Object.password,
                   email = item.Object.email,
                   mobile = item.Object.mobile
               }).ToList();
               return userlist;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error : {e}");
                return null;
            }
        }
        public static async Task<Users> getuser_num(string num)
        {
            try
            {
                var user = (await getallusers()).Where(a => a.mobile == num).FirstOrDefault();
                return user;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error : {e}");
                return null;
            }         
        }
        public static async Task<Users> getuser_mail(string mail)
        {
            try
            {
                var user = (await getallusers()).Where(a => a.email == mail).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error : {e}");
                return null;
            }
        }
        public static async Task<bool> adduser(string num ,string fn ,string ln,string mail ,string pass)
        {
            try
            {
                await fbc.Child("users").PostAsync(new Users()
                {
                    email = mail,
                    password = pass,
                    firstname = fn,
                    lastname = ln,
                    mobile = num
                });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error : {e}");
                return false;
            }
        }        
        public static async Task<bool> deluser(string num)
        {
            try
            {
                var del = (await fbc.Child("users").OnceAsync<Users>()).Where(a => a.Object.mobile == num).FirstOrDefault();
                await fbc.Child("users").Child(del.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error : {e}");
                return false;
            }
        }
        public static async Task<bool> updateuser(string num, string fn, string ln, string mail, string pass)
        {
            try
            {
                var update = (await fbc.Child("users").OnceAsync<Users>()).Where(b => b.Object.mobile == num).FirstOrDefault();
                await fbc.Child("users").Child(update.Key).PutAsync(new Users()
                {
                    firstname = fn,
                    lastname = ln,
                    password = pass,
                    mobile = num,
                    email = mail
                });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error : {e}");
                return false;
            }
        }
    }
}
