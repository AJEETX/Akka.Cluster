using System;
using System.Collections.Generic;
using System.Text;

namespace Message
{
    public class Pnr
    {
        public string Locator { get; private set; }

        public Pnr(string locator)
        {
            Locator = locator;
        }
    }
}