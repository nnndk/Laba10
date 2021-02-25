using System;
using System.Collections;
using System.Text;

namespace Laba10
{
    class SortByPrice : IComparer
    {
        public int Compare(object x, object y)
        {
            Item item1 = (Item)x;
            Item item2 = (Item)y;

            //return string.Compare(item1.Name, item2.Name);
            if (item1.Price > item2.Price)
                return 1;
            else if (item1.Price == item2.Price)
                return 0;
            else
                return -1;
        }
    }
}
