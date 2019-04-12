/******************************************
 * KP Restoration VMS                     *
 * Created 12/12/18 by Kyle Price         *
 * Globals.cs - contains global variables *
 *  used throughout the system            *
 * ***************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KPRestoration
{
    class Globals
    {
        /*  Global variables
         *  **************************************/
        public static string programTitle = "KP Restoration VMS";
        public static double programVersion = 1.0;
        public static int adminLevel = 3;
        public const string dbHost = "rmserver";
        public static Color errorColor = Color.FromArgb(197, 0, 0);

        /*  Encryption function using SHA1 
         *      Used for user passwords
         *  **************************************/
        public static string Encrypt(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /*  Ping function used to verify MySQL server
         *      is online
         *  **************************************/
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }


        /*  Formats string to currency
         *  **************************************/
        public static string FormatCurrency(string s)
        {
            String.Format("{0:C}", @s);
            return s;
        }


        /*  Formats string to a phone number 
         *  Format: 000-000-0000
         *  **************************************/
        public static string FormatPhoneNumber(string s)
        {
            Regex ex = new Regex(@"[^\d]");
            s = ex.Replace(s, "");                              // Remove everything except numbers
            s = Convert.ToInt64(s).ToString("###-###-####");    // Convert to integer and then to given string format
            return s;
        }


        /*  Checks for phone number format
         *  **************************************/
        public static bool IsPhoneNumber(string s)
        {
            return Regex.Match(s, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").Success;
        }


        /*  Checks for currency format
         *  **************************************/
        public static bool IsCurrency(string s)
        {
            bool validInput = false;

            Regex dollarSign = new Regex(@"^\$");
            Regex numeric = new Regex(@"^\d{1,5}");
            Regex currency = new Regex(@"\d{1,5}\.\d{2}");

            if (numeric.IsMatch(s) || currency.IsMatch(s))
                validInput = true;
            // \d{1,5} matches at least one digit and no more than 5

            /*
            if (numeric.IsMatch(s)) 
            {
                s = s = ".00";  // Add cents
                validInput = true;
            }
            
            else if (currency.IsMatch(s))
            {
                validInput = true;
            }

            if (validInput == true)
            {
                if (!dollarSign.IsMatch(s)) // Add dollar sign
                    s = "$" + s;
            }
            */
            return validInput;
        }
    }
}
