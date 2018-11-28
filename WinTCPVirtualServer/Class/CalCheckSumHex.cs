using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTCPVirtualServer.Class
{
    public class CalCheckSumHex
    {
        private string _A = string.Empty;
        private string _B = string.Empty;

        public CalCheckSumHex(string A, string B)
        {
            this._A = A;
            this._B = B;
        }

        public string GetCheckSumHexValue
        {
            get { return Cal(); }
        }

        private string Cal()
        {
            string _result = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                _result += (int.Parse(_A[i].ToString()) ^ int.Parse(_B[i].ToString())).ToString();
            }
            int decimal10 = Convert.ToInt32(_result, 2);
            string hexDecimal = decimal10.ToString("X");

            return hexDecimal;
        }

    }
}
