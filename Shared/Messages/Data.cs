using System;
using System.Collections.Generic;
using System.Text;

namespace Message
{
    public static class Data
    {
        public static List<Office> CreateOfficeList
        {
            get
            {
                return new List<Office> {
                new Office("SYDqb2100", "40"),
                new Office("SYDqb2100", "41"),
                new Office("SYDqb2100", "42"),
                new Office("SYDqb2100", "43")
                };
            }
        }

        public static IEnumerable<string> Pnrs
        {
            get
            {
                return new List<string> { "abcde1", "abcde2", "abcde3", "abcde4", "abcde5" };
            }
        }
    }
}