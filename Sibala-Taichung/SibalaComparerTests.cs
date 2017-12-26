using System;
using NSubstitute;
using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture]
    public class SibalaComparerTests
    {
        private ISibala _firstRoll;

        private ISibala _secondRoll;

        [SetUp]
        public void Setup()
        {
            _firstRoll = Substitute.For<ISibala>();
            _secondRoll = Substitute.For<ISibala>();
        }

        [TestCase(EnumOutputType.NoPoint, EnumOutputType.NoPoint, 0)]
        [TestCase(EnumOutputType.NPoints, EnumOutputType.NoPoint, 1)]
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.NPoints, -1)]
        [TestCase(EnumOutputType.SameColor, EnumOutputType.NoPoint, 1)]
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.SameColor, -1)]
        public void Compare_ByType(EnumOutputType xOutputType, EnumOutputType yOutputType, int expected)
        {
            _firstRoll.OutputType.Returns(xOutputType);
            _secondRoll.OutputType.Returns(yOutputType);
            Assert.AreEqual(expected, SibalaComparer.Compare(_firstRoll, _secondRoll));
        }

        [Test]
        public void Compare_SameColor()
        {
            var expected = 1;
            _firstRoll.OutputType.Returns(EnumOutputType.SameColor);
            _secondRoll.OutputType.Returns(EnumOutputType.SameColor);
            _firstRoll.Point.Returns(1);
            _secondRoll.Point.Returns(4);
            Assert.AreEqual(expected, SibalaComparer.Compare(_firstRoll, _secondRoll));

        }
    }

    public class SibalaComparer
    {
        public static int Compare(ISibala x, ISibala y)
        {
            if (x.OutputType == y.OutputType)
            {
                if (x.Point == 1)
                {
                    return 1;
                }
                return 0;

            }
            if (x.OutputType > y.OutputType)
                return 1;
            return -1;
        }
    }

    public interface ISibala
    {
        EnumOutputType OutputType { get; }
        int Point { get; set; }
    }
}