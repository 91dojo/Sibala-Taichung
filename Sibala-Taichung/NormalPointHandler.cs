using System.Collections.Generic;
using System.Linq;

namespace Sibala_Taichung
{
    internal class NormalPointHandler : IDiceHandler
    {
        private Sibala _sibala;

        private readonly Dictionary<int, string> _specialOutput = new Dictionary<int, string>()
        {
            {3, "BG"},
            {12, "Sibala"},
        };

        public NormalPointHandler(Sibala sibala)
        {
            _sibala = sibala;
        }

        public void SetResult()
        {
            var points = GetPointDices();
            _sibala.Point = points.Sum();
            _sibala.MaxPoint = points.Max();
            _sibala.OutputType = EnumOutputType.NPoints;
            _sibala.Output = GetOutput();
        }

        private string GetOutput()
        {
            return IsSpecialOutput(_specialOutput)
                ? _specialOutput[_sibala.Point]
                : _sibala.Point + " Points";
        }

        private bool IsSpecialOutput(Dictionary<int, string> specialOutput)
        {
            return specialOutput.ContainsKey(_sibala.Point);
        }

        private IEnumerable<int> GetPointDices()
        {
            var pairPoint = _sibala.Dice.GroupBy(x => x).Where(x => x.Count() == 2).Min(x => x.Key);
            var points = _sibala.Dice.Where(x => x != pairPoint);
            return points;
        }
    }
}