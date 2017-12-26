using System;
using NSubstitute;
using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture]
    public class SibalaComparerTests
    {
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.NoPoint, 0)]
        [TestCase(EnumOutputType.NPoints, EnumOutputType.NoPoint, 1)]
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.NPoints, -1)]
        [TestCase(EnumOutputType.SameColor, EnumOutputType.NoPoint, 1)]
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.SameColor, -1)]
        public void Compare_ByType(EnumOutputType xOutputType, EnumOutputType yOutputType, int expected)
        {
            var x = Substitute.For<ISibala>();
            var y = Substitute.For<ISibala>();
            x.OutputType.Returns(xOutputType);
            y.OutputType.Returns(yOutputType);
            Assert.AreEqual(expected, SibalaComparer.Compare(x, y));
        }
    }

    public class SibalaComparer
    {
        public static int Compare(ISibala x, ISibala y)
        {
            if (x.OutputType == y.OutputType)
                return 0;
            if (x.OutputType > y.OutputType)
                return 1;
            return -1;
        }
    }

    public interface ISibala
    {
        EnumOutputType OutputType { get; }
    }
}