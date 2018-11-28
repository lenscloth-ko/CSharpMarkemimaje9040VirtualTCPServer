using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //60 => 00000060 / 3c / 00111100
            //0 => 00000000 / 0 / 00000000
            //CheckSum: 00111100 XOR 00000000
            //0 => 00000000 / 0 / 00000000
            //CheckSum: 00000000 XOR 00000000
            //60 => 00000060 / 3c / 00111100
            //CheckSum: 00000000 XOR 00111100

            string X = "00010101";
            string Y = "01010110";

            //Console.WriteLine(00010101 ^ 01010110);

            //Console.WriteLine(0 ^ 0);
            //Console.WriteLine(0 ^ 1);
            //Console.WriteLine(1 ^ 0);
            //Console.WriteLine(1 ^ 1);

            Console.WriteLine("CCC = " + CalCheckSumHex(X, Y));

        }

        public static string CalCheckSumHex(string X, string Y)
        {
            if (X.Length != 8 || Y.Length != 8)
            {
                return "ERR";
            }

            string _result = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                //Console.WriteLine(X[i] + " XOR " + Y[i] + " = " + (int.Parse(X[i].ToString()) ^ int.Parse(Y[i].ToString())) );
                _result += (int.Parse(X[i].ToString()) ^ int.Parse(Y[i].ToString())).ToString();
            }

            //Console.WriteLine("2진수 : " + _result);
            int decimal10 = Convert.ToInt32(_result, 2);

            //Console.WriteLine("10진수 : + " + decimal10);
            // 10진수 숫자를 16진수 문자열 (영문대문자)  
            // (X4: Hexa 4자리, 영문은 대문자로)
            string hexDecimal = decimal10.ToString("X");
            //Console.WriteLine("hexDecimal = " + hexDecimal);

            //// 위의 ToString과 동일한 표현
            //string strHex3 = string.Format("{0:X4}", decimal10);
            //Console.WriteLine("16진수 : + " + strHex3);

            return hexDecimal;
        }

    }
}
