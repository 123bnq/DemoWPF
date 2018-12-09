using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBNConverter
{
    public class ISBNConvertLib
    {
        public object CheckISBN(string ISBN)
        {
            int sum = 0;
            if (this.neccessaryToBeISBN(ISBN))
            {
                if (ISBN.Length == 10)
                {
                    sum = 0;
                    for (int i = 0; i < ISBN.Length; i++)
                    {
                        if (ISBN[i] == 'x' || ISBN[i] == 'X')
                        {
                            sum += 10 * (10 - i);
                        }
                        else
                        {
                            sum += (ISBN[i] - '0') * (10 - i);
                        }
                    }
                    return (sum % 11) == 0;
                }
                else if (ISBN.Length == 13)
                {
                    sum = 0;
                    for (int i = 0; i < ISBN.Length; i++)
                    {
                        sum += ((i % 2 * 2) + 1) * (ISBN[i] - '0');
                    }
                    return (sum % 10) == 0;
                }
            }
            else
            {
                return false;
            }
            return null;
        }

        /// <summary>
        /// check the string that could be an ISBN
        /// </summary>
        /// <param name="ISBN">random string</param>
        /// <returns>true - could be an ISBN</returns>
        private bool neccessaryToBeISBN(string ISBN)
        {
            bool isISBN = false;
            // Loop through each character, if the string contains forbidden ISBN character, then the string will be discarded
            for (int i = 0; i < ISBN.Length; i++)
            {
                // ISBN-10 could end with letter X to replace number 10
                if (ISBN.Length == 10 && i == 9 && (ISBN[i] == 'x' || ISBN[i] == 'X'))
                {
                    isISBN = true;
                    break;
                }
                switch (ISBN[i])
                {
                    // Check if all characters are digits
                    case '0':case '1':case '2':case '3':case '4':case '5':case '6':case '7':case '8':case '9':
                        isISBN = true;
                        break;
                    // In case of non-digit, return false
                    default:
                        isISBN = false;
                        break;
                }
                if (!isISBN)
                    return isISBN;
            }
            return isISBN;
        }

        /// <summary>
        /// Convert ISBN-10 into ISBN-13
        /// </summary>
        /// <param name="ISBN10">Given ISBN-10</param>
        /// <returns></returns>
        public string ISBN10to13(string ISBN10)
        {
            int sumISBN13 = 0;
            string ISBN13 = new StringBuilder($"978{ISBN10}").ToString();
            ISBN13 = ISBN13.Remove(ISBN13.Length - 1);

            for (int i = 0; i < ISBN13.Length; i++)
            {
                sumISBN13 += ((i % 2 * 2) + 1) * (ISBN13[i] - '0');
            }
            ISBN13 = new StringBuilder($"{ISBN13}{10 - (sumISBN13 % 10)}").ToString();
            return ISBN13;
        }

        /// <summary>
        /// Convert ISBN-10 into ISBN-13
        /// </summary>
        /// <param name="ISBN13">Given ISBN-13</param>
        /// <returns></returns>
        public string ISBN13to10(string ISBN13)
        {
            int sumISBN10 = 0;
            int remainder = 0;
            int added = 0;
            string ISBN10 = ISBN13.Substring(3);
            ISBN10 = ISBN10.Remove(ISBN10.Length - 1);

            for (int i = 0; i < ISBN10.Length; i++)
            {
                sumISBN10 += (ISBN10[i] - '0') * (10 - i);
            }
            remainder = sumISBN10 % 11;
            added = 11 - remainder;

            // ISBN10 contains a special character ('X') for replacing number 10
            if (added < 10)
            {
                ISBN10 = new StringBuilder($"{ISBN10}{added}").ToString();
            }
            else
            {
                ISBN10 = new StringBuilder($"{ISBN10}X").ToString();
            }
            return ISBN10;
        }
    }
}
