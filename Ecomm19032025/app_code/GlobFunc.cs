using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecomm19032025
{
    public class GlobFunc
    {
        public static string GetRandStr(int len)
        {
            string st = "abcdefghijklmnopqrstuvwxyz0123456789";
            string RetVal = "";
            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                RetVal +=st[rnd.Next(st.Length)];
            }
            return RetVal;
        }




    }
}