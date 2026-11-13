using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Utils
{
    internal class Rule
    {
        public static bool isPasswordCheck(string pass)
        {
            //8자리 이상
            if (pass != null && pass.Length < 8)
            {
                return false;
            }
            //숫자1이상, 영문1이상, 특수문자1이상
            Regex regexPass = new Regex(@"^(?=.*?[a-zA-Z])(?=.*?[0-9]).{8,}$", RegexOptions.IgnorePatternWhitespace);
            return regexPass.IsMatch(pass);
        }

        public static bool isEmailCheck(string email)
        {
            Regex regexEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regexEmail.IsMatch(email);
        }


    }
}
