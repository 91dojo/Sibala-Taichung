using System.Collections.Generic;
using System.Linq;

namespace Sibala_Taichung
{
    internal class Sibala
    {
        public string Output { get; set; }

        public EnumOutputType OutputType { get; set; }

        public int Point { get; set; }

        public int MaxPoint { get; set; }

        private List<int> Dice = new List<int>();

        public Sibala(int dice1, int dice2, int dice3, int dice4)
        {
            Dice = new List<int> { dice1, dice2, dice3, dice4 };
            Initialize();
        }

        private void Initialize()
        {
            if (IsNoPoint())
            {
                OutputType = EnumOutputType.NoPoint;
                Output = "No Points";
            }
            else if (IsSameColor())
            {
                OutputType = EnumOutputType.SameColor;
                Output = "Same Color";
                Point = Dice.First();
                MaxPoint = Dice.First();
            }
            else if (IsNormalPoint())
            {
                if (Dice.Distinct().Count() == 2)
                {
                    MaxPoint = Dice.GroupBy(x => x).Where(x => x.Count() == 2).Max(x => x.Key);
                    Point = MaxPoint * 2;
                }
                else
                {
                    MaxPoint = Dice.GroupBy(x => x).Where(x => x.Count() == 1).Max(x => x.Key);
                    Point = Dice.GroupBy(x => x).Where(x => x.Count() == 1).Sum(x => x.Key);
                }
                OutputType = EnumOutputType.NPoints;
                Output = Point + " Points";
            }
        }

        private bool IsNoPoint()
        {
            return Dice.GroupBy(x => x).Count() == Dice.Count;
        }

        private bool IsNormalPoint()
        {
            return Dice.Distinct().Count() == 3 || Dice.Distinct().Count() == 2;
        }

        private bool IsSameColor()
        {
            return Dice.Distinct().Count() == 1;
        }
    }
}