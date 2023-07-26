using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Web;


namespace DataManager
{
    public class NumberConverWords
    {

        public static string changeNumericToWords(double numb)
        {
            string num = numb.ToString();
            return changeToWords(num, false);
        }

        public static string changeCurrencyToWords(string numb)
        {
            return changeToWords(numb, true);
        }

        public static string changeNumericToWords(string numb)
        {
            return changeToWords(numb, false);
        }

        public static string changeCurrencyToWords(double numb)
        {
            return changeToWords(numb.ToString(), true);
        }

        private static string changeToWords(string numb, bool isCurrency)
        {
            string val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            string endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        //andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/Rupees
                        andStr = "";
                        endStr = (isCurrency) ? ("Rupees " + endStr) : ("");
                        //pointStr = translateRupees(points);
                        pointStr = "";
                    }
                }
                val = string.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch
            {
                ;
            }
            return val;
        }

        private static string translateWholeNumber(string number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(number));


                if (dblAmt > 0)
                {
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    int pos = 0;
                    string place = "";
                    string Hundreds = number.Substring(0, 1);
                    if (Hundreds != "0")
                    {
                        switch (numDigits)
                        {
                            case 1:
                                word = ones(number);
                                isDone = true;
                                break;
                            case 2:
                                word = tens(number);
                                isDone = true;
                                break;
                            case 3:
                                pos = (numDigits % 3) + 1;
                                place = " Hundred ";
                                break;
                            case 4:
                            case 5:
                                pos = (numDigits % 4) + 1;
                                place = " Thousand ";
                                break;
                            case 6:
                            case 7:
                                pos = (numDigits % 6) + 1;
                                place = " Lakh ";
                                break;
                            case 8:
                            case 9:
                            case 10:
                                pos = (numDigits % 10) + 1;
                                place = " Crore ";
                                break;

                            default:
                                isDone = true;
                                break;
                        }
                    }
                    else
                    {
                        place = "";
                        pos = 1;
                    }
                    if (!isDone)
                    {
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));

                        if (beginsZero) word = " and " + word.Trim();
                    }

                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                ;
            }
            return word.Trim();
        }

        private static string tens(string digit)
        {
            int digt = Convert.ToInt32(digit);
            string name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Forty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static string ones(string digit)
        {
            int digt = Convert.ToInt32(digit);
            string name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static string translateRupees(string Rupees)
        {
            string cts = "", digit = "", engOne = "";
            for (int i = 0; i < Rupees.Length; i++)
            {
                digit = Rupees[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }
    }
}
