namespace Sibala_Taichung
{
    internal class NoPointsHandler : IDiceHandler
    {
        private Sibala _sibala;

        public NoPointsHandler(Sibala sibala)
        {
            _sibala = sibala;
        }

        public void SetResult()
        {
            _sibala.OutputType = EnumOutputType.NoPoint;
            _sibala.Output = "No Points";
        }
    }
}