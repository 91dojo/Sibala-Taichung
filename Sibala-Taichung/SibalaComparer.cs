using System;
using System.Collections.Generic;

namespace Sibala_Taichung
{
    public partial class SibalaComparer : IComparer<ISibala>
    {
        private static Dictionary<int, int> _samecolorlookup = new Dictionary<int, int>
        {
            {1, 6},
            {4, 5},
            {6, 4},
            {5, 3},
            {3, 2},
            {2, 1}
        };

        public int Compare(ISibala x, ISibala y)
        {
            return IsSameType(x, y) ? CompareWhenSameType(x, y) : CompareWhenDifferentType(x, y);
        }

        private static int CompareWhenSameType(ISibala x, ISibala y)
        {
            var comparers = new Dictionary<EnumOutputType, Func<ISibala, ISibala, int>>()
            {
                {EnumOutputType.SameColor, CompareWhenSameColor},
                {EnumOutputType.NPoints, CompareWhenNormalPoint},
                {EnumOutputType.NoPoint, CompareWhenNoPoint},
            };
            return comparers[x.OutputType].Invoke(x, y);
        }

        private static int CompareWhenDifferentType(ISibala x, ISibala y)
        {
            return x.OutputType - y.OutputType;
        }

        private static int CompareWhenNoPoint(ISibala x, ISibala y)
        {
            return 0;
        }

        private static int CompareWhenNormalPoint(ISibala x, ISibala y)
        {
            if (x.Point == y.Point)
            {
                return x.MaxPoint - y.MaxPoint;
            }
            return x.Point - y.Point;
        }

        private static int CompareWhenSameColor(ISibala x, ISibala y)
        {
            return _samecolorlookup[x.Point] - _samecolorlookup[y.Point];
        }

        private static bool IsSameType(ISibala x, ISibala y)
        {
            return x.OutputType == y.OutputType;
        }
    }
}