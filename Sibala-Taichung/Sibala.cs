using System.Collections.Generic;
using System.Linq;

namespace Sibala_Taichung
{
    internal class Sibala
    {
        public string Output { get; set; }

        public EnumOutputType OutputType { get; set; }

        public int Point { get; set; }
        
        private List<int> Dice = new List<int>();

        public Sibala(int dice1, int dice2, int dice3, int dice4)
        {
            Dice = new List<int> {dice1, dice2, dice3, dice4};
            Initialize();
        }

        private void Initialize()
        {
            if (IsNoPoint())
            {
                OutputType = EnumOutputType.NoPoint;
                Output = "No Points";
            }
            else if(IsSameColor())
            {
                OutputType = EnumOutputType.SameColor;
                Point = Dice.First();
                Output = "Same Color";
            }
            else if (IsNormalPoint())
            {
                Point = Dice.GroupBy(x => x).Where(x => x.Count() == 1).Sum(x => x.Key);
                Output = Point + " Points";
                OutputType = EnumOutputType.NPoints;
            }
        }

        private bool IsNoPoint()
        {
            return Dice.GroupBy(x => x).Count() == Dice.Count;
        }

        private bool IsNormalPoint()
        {
            return Dice.Distinct().Count() == 3;
        }

        private bool IsSameColor()
        {
            return Dice.Distinct().Count() == 1;
        }
    }
}