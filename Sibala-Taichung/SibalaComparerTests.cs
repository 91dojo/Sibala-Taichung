using NSubstitute;
using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture]
    public class SibalaComparerTests
    {
        [Test]
        public void ComparerNoPointAndNoPoint_Should_Return_Zero()
        {
            var x = Substitute.For<ISibala>();
            var y = Substitute.For<ISibala>();
            x.OutputType.Returns(EnumOutputType.NoPoint);
            y.OutputType.Returns(EnumOutputType.NoPoint);
            Assert.AreEqual(0, SibalaComparer.Compare(x, y));
        }

        [Test]
        public void ComparerNPointsAndNoPoint_Should_Return_One()
        {
            var x = Substitute.For<ISibala>();
            var y = Substitute.For<ISibala>();
            x.OutputType.Returns(EnumOutputType.NPoints);
            y.OutputType.Returns(EnumOutputType.NoPoint);
            Assert.AreEqual(1, SibalaComparer.Compare(x, y));
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