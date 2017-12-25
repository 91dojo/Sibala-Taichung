using NSubstitute;
using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture]
    public class SibalaComparerTests
    {
        [Test]
        public void ComparerCorrect()
        {
            var x = Substitute.For<ISibala>();
            var y = Substitute.For<ISibala>();
            x.GetOutputType().Returns(EnumOutputType.NoPoint);
            y.GetOutputType().Returns(EnumOutputType.NoPoint);
            Assert.AreEqual(0, SibalaComparer.Compare(x, y));
        }
    }

    public class SibalaComparer
    {
        public static int Compare(ISibala x, ISibala y)
        {
            if(x.GetOutputType() == y.GetOutputType())
                return 0;
            return -1;
        }
    }

    public interface ISibala
    {
        EnumOutputType GetOutputType();
    }
}