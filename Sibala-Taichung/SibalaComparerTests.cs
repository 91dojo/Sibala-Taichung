using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture]
    public class SibalaComparerTests
    {
        [Test]
        public void TestMethod1()
        {
            //ISibala x;
            //ISibala y;
            //Assert.AreEqual(0, SibalaComparer.Compare(x, y));
        }
    }

    public class SibalaComparer
    {
        public static int Compare(ISibala x, ISibala y)
        {
            return 0;
        }
    }

    public interface ISibala
    {

    }
}