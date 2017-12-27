using System.Linq;

namespace Sibala_Taichung
{
    internal class SameColorHandler : IDiceHandler
    {
        private Sibala _sibala;

        public SameColorHandler(Sibala sibala)
        {
            _sibala = sibala;
        }

        public void SetResult()
        {
            _sibala.OutputType = EnumOutputType.SameColor;
            _sibala.Output = "Same Color";
            _sibala.Point = _sibala.Dice.First();
            _sibala.MaxPoint = _sibala.Dice.First();
        }
    }
}