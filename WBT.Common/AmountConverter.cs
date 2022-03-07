using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.Common
{
    public class AmountConverter
    {
        #region " Constructor "

        public AmountConverter(long amount, ConvertStyle style)
        {
            m_amount = amount;
            m_style = style;
        }

        #endregion

        #region " Public Methods"

        public string Convert()
        {

            string convertedString = string.Empty;

            switch (this.Style)
            {

                case ConvertStyle.English:
                    convertedString = this.EnglishStyle();

                    break;
                case ConvertStyle.Asian:
                    convertedString = this.AsianStyle();

                    break;
            }

            return convertedString;
        }

        #endregion

        #region " Private Methods"


        #region " English Style "


        private string EnglishStyle()
        {
            if (Amount == 0)
                return "Zero";
            //Unique and exceptional case
            //Overflow exception will occur when 18+ digits are passed as
            //Long can handle upto 18 digits but the routine below can convert upto 24 digits


            string amountString = Amount.ToString();
            string result = string.Empty;
            string tempResult = string.Empty;
            int i = 3;
            string newAmount = amountString;
            int workedStringLength = 0;

            bool concatHigherDigitString = false;

            do
            {
                concatHigherDigitString = false;
                if (i > 3)
                    concatHigherDigitString = true;
                //to suffix the Thousand/Million/Billion type of Word


                //work with 3 right most digits at a time
                if (newAmount.Length >= 4)
                {
                    newAmount = amountString.Substring(amountString.Length - i, 3);
                }


                //do the conversion and affist the Thousand/Million/Billion type of word at the end when needed
                if (concatHigherDigitString && System.Convert.ToInt32(newAmount) != 0)
                {
                    result = ThreeDigitsConverter(System.Convert.ToInt32(newAmount)) + " " + HigherDigitEnglishStringArray[i / 3 + 1] + " " + result;
                }
                else
                {
                    result = ThreeDigitsConverter(System.Convert.ToInt32(newAmount));
                }


                workedStringLength += newAmount.Length;
                newAmount = amountString.Substring(0, amountString.Length - workedStringLength);
                i += 3;
            } while (!(amountString.Length <= workedStringLength));

            return RemoveSpaces(result);

        }


        private string ThreeDigitsConverter(int amount)
        {
            string amountString = amount.ToString();

            //convert numbers to array of each digit
            int[] amountArray = new int[amountString.Length];
            for (int i = amountArray.Length; i >= 1; i += -1)
            {
                amountArray[i - 1] = System.Convert.ToInt32(amountString.Substring(i - 1, 1));
            }

            int j = 0;
            int digit = 0;
            string result = string.Empty;
            string separator = string.Empty;
            string higherDigitEnglishString = string.Empty;
            string codeIndex = string.Empty;


            for (int i = amountArray.Length; i >= 1; i += -1)
            {
                j = amountArray.Length - i;
                digit = amountArray[j];

                codeIndex = EnglishCodeArray[i - 1];
                higherDigitEnglishString = HigherDigitEnglishStringArray[System.Convert.ToInt32(codeIndex.Substring(0, 1)) - 1];


                //Number [1 9]
                if (codeIndex == "1")
                {
                    result = result + separator + SingleDigitStringArray[digit];

                    //Number in tenth place and skip if digit is 0
                }
                else if (codeIndex.Length == 2 & digit != 0)
                {

                    //Number [Eleven, Twelve,...., Nineteen]
                    if (digit == 1)
                    {
                        int suffixDigit = amountArray[j + 1];
                        result = result + separator + TenthDigitStringArray[suffixDigit] + " " + higherDigitEnglishString;
                        i -= 1;
                        //Skip the next round as we already looked at it

                        //Number [tenth] and [20+]  
                    }
                    else
                    {
                        result = result + separator + DoubleDigitsStringArray[digit] + " " + higherDigitEnglishString;
                    }

                    //Standard Number like 100, 1000, 1000000 and skip if digit is 0
                }
                else if (digit != 0)
                {
                    result = result + separator + SingleDigitStringArray[digit] + " " + higherDigitEnglishString;
                }

                separator = " ";
            }

            return result;
        }

        #endregion

        #region " Asian Style "

        private string AsianStyle()
        {
            string amountString = Amount.ToString();

            if (Amount == 0)
                return "Zero";
            //Unique and exceptional case
            if (amountString.Length > 13)
                return "That's too long...";

            int[] amountArray = new int[amountString.Length];
            for (int i = amountArray.Length; i >= 1; i += -1)
            {
                amountArray[i - 1] = System.Convert.ToInt32(amountString.Substring(i - 1, 1));
            }


            int j = 0;
            int digit = 0;
            string result = "";
            string separator = "";
            string higherDigitAsianString = "";
            string codeIndex = "";


            for (int i = amountArray.Length; i >= 1; i += -1)
            {
                j = amountArray.Length - i;
                digit = amountArray[j];

                codeIndex = AsianCodeArray[i - 1];
                higherDigitAsianString = HigherDigitAsianStringArray[System.Convert.ToInt32(codeIndex.Substring(0, 1)) - 1];


                //Number [1, 9]
                if (codeIndex == "1")
                {
                    result = result + separator + SingleDigitStringArray[digit];

                    //Number in tenth place and skip if digit is 0
                }
                else if (codeIndex.Length == 2 & digit != 0)
                {
                    int suffixDigit = amountArray[j + 1];

                    //Number [Eleven, Twelve,...., Nineteen]
                    if (digit == 1)
                    {
                        result = result + separator + TenthDigitStringArray[suffixDigit] + " " + higherDigitAsianString;
                        i -= 1;
                        //Skip the next round as we already looked at it

                        //Number [tenth] and [20+]  
                    }
                    else
                    {
                        //Numbers like [20 30 40...90]
                        if (suffixDigit == 0)
                        {
                            result = result + separator + DoubleDigitsStringArray[digit] + " " + higherDigitAsianString;
                        }
                        else
                        {
                            result = result + separator + DoubleDigitsStringArray[digit];
                        }

                    }

                    //Standard Number like 100, 1000, 1000000 and skip if digit is 0
                }
                else if (digit != 0)
                {
                    result = result + separator + SingleDigitStringArray[digit] + " " + higherDigitAsianString;
                }

                separator = " ";
            }



            return RemoveSpaces(result);
        }

        #endregion


        private string RemoveSpaces(string word)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("  ");
            return regEx.Replace(word, " ").Trim();
        }

        #endregion

        #region " Property"

        public long Amount
        {
            get { return m_amount; }
        }

        public ConvertStyle Style
        {
            get { return m_style; }
        }
        #endregion

        #region " Fields"

        private long m_amount;

        private ConvertStyle m_style;
        private string[] SingleDigitStringArray = {
            "",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten"
        };
        private string[] DoubleDigitsStringArray = {
            "",
            "Ten",
            "Twenty",
            "Thirty",
            "Forty",
            "Fifty",
            "Sixty",
            "Seventy",
            "Eighty",
            "Ninety"
        };
        private string[] TenthDigitStringArray = {
            "Ten",
            "Eleven",
            "Tweleve",
            "Thirteen",
            "Fourteen",
            "Fifteen",
            "Sixteen",
            "Seventeen",
            "Eighteen",
            "Nineteen"

        };
        private string[] HigherDigitEnglishStringArray = {
            "",
            "",
            "Hundred",
            "Thousand",
            "Million",
            "Billion",
            "Trillion",
            "Quadrillion",
            "Quintillion"
        };
        private string[] HigherDigitAsianStringArray = {
            "",
            "",
            "Hundred",
            "Thousand",
            "Lakh",
            "Karod",
            "Arab",
            "Kharab"

        };
        private string[] EnglishCodeArray = {
            "1",
            "22",
            "3"
        };
        private string[] AsianCodeArray = {
            "1",
            "22",
            "3",
            "4",
            "42",
            "5",
            "52",
            "6",
            "62",
            "7",
            "72",
            "8",
            "82"

        };
        #endregion

        #region " Enums"

        public enum ConvertStyle
        {
            Asian,
            English
        }

        #endregion
    }
}
