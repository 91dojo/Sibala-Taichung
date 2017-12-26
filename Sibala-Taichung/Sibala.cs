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

        public List<int> Dice = new List<int>();

        public Sibala(int dice1, int dice2, int dice3, int dice4)
        {
            Dice = new List<int> { dice1, dice2, dice3, dice4 };
            Initialize();
        }

        private void Initialize()
        {
            GetDiceHandler().SetResult();
        }

        private IDiceHandler GetDiceHandler()
        {
            var handlerLookup = new Dictionary<int, IDiceHandler>
            {
                {1, new NoPointsHandler(this)},
                {2, new NormalPointHandler(this)},
                {3, new NoPointsHandler(this)},
                {4, new SameColorHandler(this)},
            };
            return handlerLookup[Dice.GroupBy(x => x).Max(x => x.Count())];
        }
    }

    internal interface IDiceHandler
    {
        void SetResult();
    }
}