using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pusula.Helper
{
    public static class General
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateToken()
        { 
            string secret = RandomString(30);
            string token = new JwtBuilder()
           .WithAlgorithm(new HMACSHA256Algorithm())
           .WithSecret(secret)
           .Encode();
           return token;
        }

        //•	3 kiraz: 50 altın
        //•	2 kiraz 1 elma: 40 altın
        //•	3 elma: 20 altın
        //•	2 elma 1 muz: 10 altın
        //•	3 muz: 15 altın
        //•	2 muz: 5 altın
        //•	3 limon: 3 altın

        public static int prize(string arr)
        {
            int resultPrize = 0;
            int kiraz = Regex.Matches(arr, "kiraz").Count;
            int elma = Regex.Matches(arr, "elma").Count;
            int limon = Regex.Matches(arr, "limon").Count;
            int muz = Regex.Matches(arr, "muz").Count;
            int pass = Regex.Matches(arr, "pass").Count;

            if (kiraz == 3)
            {
                resultPrize = 50;
            }

            if (kiraz== 2 && elma == 1)
            {
                resultPrize = 40;
            }

            if (elma == 3)
            {
                resultPrize = 20;
            }

            if (elma == 2 && muz == 1)
            {
                resultPrize = 10;
            }

            if (muz == 3)
            {
                resultPrize = 15;
            }

            if (muz == 2)
            {
                resultPrize = 5;
            }

            if (limon == 3)
            {
                resultPrize = 3;
            }

            return resultPrize;
        }

    }
}
