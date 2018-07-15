// <copyright file="OfficePnrList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Message
{
    using System.Collections.Generic;

    public class OfficePnrList
    {
        public int Counter { get; set; }

        public Office Office { get; private set; }

        public IEnumerable<string> Pnrs { get; set; }

        public OfficePnrList(Office office, IEnumerable<string> pnrs)
        {
            Office = office;
            Pnrs = pnrs;
        }
    }
}