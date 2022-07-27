using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAPI.Helper
{

    public class Track
    {
        private readonly Random _random = new Random();
        public string Trackid()
        {
            var idBuilder = new StringBuilder();



            // 9-Digits between 1000 and 9999  
            idBuilder.Append(RandomNumber(100000000, 999999999));

            // 2-Letters upper case  
            idBuilder.Append(RandomString(2));
            return idBuilder.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }


        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);



            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString().ToUpper();
        }
    }
}
