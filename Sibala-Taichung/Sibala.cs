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
            var maxCountofGroup = Dice.GroupBy(x => x).Max(x => x.Count());
            switch (maxCountofGroup)
            {
                case 1:
                case 3:
                    GenerateNoPoint();
                    break;
                case 2:
                    GenerateNormalPoint();
                    break;
                case 4:
                    GenerateSamePoint();
                    break;
            }
        }

        private void GenerateNoPoint()
        {
            OutputType = EnumOutputType.NoPoint;
            Output = "No Points";
        }

        private void GenerateSamePoint()
        {
            OutputType = EnumOutputType.SameColor;
            Output = "Same Color";
            Point = Dice.First();
            MaxPoint = Dice.First();
        }

        private void GenerateNormalPoint()
        {
            var pairPoint = Dice.GroupBy(x => x).Where(x => x.Count() == 2).Min(x => x.Key);
            Point = Dice.Where(x => x != pairPoint).Sum();
            MaxPoint = Dice.Where(x => x != pairPoint).Max();
            OutputType = EnumOutputType.NPoints;
            Output = Point + " Points";
            if (Point == 3)
            {
                Output = "BG";
            }
            if (Point == 12)
            {
                Output = "Sibala";
            }
        }
    }
}