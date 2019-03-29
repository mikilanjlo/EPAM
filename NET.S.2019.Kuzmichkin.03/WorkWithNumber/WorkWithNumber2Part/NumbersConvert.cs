using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithNumber2Part
{
    public static class NumbersConvert
    {
        private static int  length = 63;
        private static int order = 1023;
        private static int bias = 52;
        public static string ToBit(this double number)
        {
            string strNumber = "";
            int intNumber = (int)number;
            double fraction = number % intNumber;
            if (number < 0.0d)
                strNumber += "1";
            else
                strNumber += "0";
            number = Math.Abs(number);
            if (number > 1)
            {
                int pow2 = 0;
                while (Math.Pow(2, pow2) < number)
                    pow2++;
                strNumber += ToBit(order + pow2 - 1);
                //strNumber += ToBit((int)(Math.Pow(2, bias) * ((number - Math.Pow(2, pow2 - 1)) / Math.Pow(2, pow2 - 1))));
                fraction = ((number - Math.Pow(2, pow2 - 1)) / Math.Pow(2, pow2 - 1));
                
            }
            else
            {
                for (int i = 0; i < length - bias;i++)
                    strNumber += "0";
                fraction = number;
            }
            while (strNumber.Length < length + 1)
            {
                fraction = fraction * 2;
                strNumber += (int)fraction;
                fraction = fraction - (int)fraction;
                //strNumber += "0";
            }
            if (strNumber.Length > length)
                strNumber.Substring(0, strNumber.Length - (strNumber.Length - length) - 1);
            if(number != 0)
                strNumber = SmallNumber(strNumber);
            return strNumber;
        }

        private static string SmallNumber(string number)
        {
            for(int i = length - bias + 1; i<number.Length; i++)
                if( number[i] != '0') 
                    return number;
            return number.Substring(0, number.Length - 1) + "1";
        }

        private static string ToBit(int number)
        {
            number = Math.Abs(number);
            string strNumber = "";
            while(number >= 1)
            {
                int tmp = number % 2;
                number /= 2;
                strNumber = "" + tmp + strNumber;
            }
            //strNumber = "" + number + strNumber;
            return strNumber;
        }

        public static string ToBit(this double number,bool exception)
        {
            if (!exception)
                return number.ToBit();
            var bitArray = new System.Collections.BitArray(BitConverter.GetBytes(number));
            StringBuilder res = new StringBuilder(64);

            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                if (bitArray[i] == false)
                    res.Append('0');
                else
                    res.Append('1');
            }

            return res.ToString();
        }
    }
}
