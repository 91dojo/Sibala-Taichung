using System.Collections.Generic;
using System.Linq;

namespace Sibala_Taichung
{
    internal class NormalPointHanlder : IDiceHandler
    {
        private Sibala _sibala;

        private readonly Dictionary<int, string> _specialOutput = new Dictionary<int, string>()
        {
            {3, "BG"},
            {12, "Sibala"},
        };

        public NormalPointHanlder(Sibala sibala)
        {
            _sibala = sibala;
        }

        public void SetResult()
        {
            var pointDices = GetPointDices();
            _sibala.Point = pointDices.Sum();
            _sibala.MaxPoint = pointDices.Max();
            _sibala.OutputType = EnumOutputType.NPoints;
            _sibala.Output = GetOutput();
        }

        private string GetOutput()
        {
            return IsSpecialOutput()
                ? _specialOutput[_sibala.Point]
                : _sibala.Point + " Points";
        }

        private bool IsSpecialOutput()
        {
            return _specialOutput.ContainsKey(_sibala.Point);
        }

        private IEnumerable<int> GetPointDices()
        {
            var pairPoint = _sibala.Dice.GroupBy(x => x).Where(x => x.Count() == 2).Min(x => x.Key);
            return _sibala.Dice.Where(x => x != pairPoint);
        }
    }
}