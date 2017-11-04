using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemThi
{
    public static class StringHelper
    {
        public static string GetString(String a, int first, int last)
        {
            string ans = "";
            for (int i = first - 1; i < last; i++)
                ans += a[i];
            return ans.Trim();
        }

        public static string StringWithLength(string a, int length)
        {
            string ans = String.Format("{0," + ((a.Length + length) / 2).ToString() + "}", a);
            return ans;
        }

        public static string StringWithLengthLeft(string a, int length)
        {
            string ans = a;

            while (ans.Length < length) ans += ' ';

            return ans;
        }

        public static string StringHr(int length)
        {
            string ans = " ";
            for (int i = 2; i <= length; i++) ans = ans + "-";
            return ans;
        }
    }
}
