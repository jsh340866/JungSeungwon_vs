using System.Linq;
using System.Text.RegularExpressions;

namespace WindowsFormsApp2.Utils
{
    internal class ValidationRule
    {
        // 비밀번호 규칙(영문,숫자 포함 8자리 이상)
        public static bool PasswordCheck(string pass)
        {
            //8자리 이상
            if (string.IsNullOrWhiteSpace(pass) || pass.Length < 8)
            {
                return false;
            }
            //숫자1이상, 영문1이상
            Regex regexPass = new Regex(@"^(?=.*?[a-zA-Z])(?=.*?[0-9]).{8,}$", RegexOptions.IgnorePatternWhitespace);
            return regexPass.IsMatch(pass);
        }

        // 이메일 규칙( _@_._)
        public static bool EmailCheck(string email)
        {
            // 이메일 형식 규칙
            Regex regexEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regexEmail.IsMatch(email);

        }

        // 휴대전화 번호 하이폰 규칙 ( 000-0000-0000..)
        public static string PhoneRule(string phone) 
        {
            string digits = new string(phone.Where(char.IsDigit).ToArray());
            if (digits.Length >= 11)
            {
                phone = digits.Insert(7, "-").Insert(3, "-");

            }
            return phone;

        }
    }
}
