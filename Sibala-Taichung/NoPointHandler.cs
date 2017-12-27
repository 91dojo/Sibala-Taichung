namespace Sibala_Taichung
{
    internal class NoPointHandler : IDiceHandler
    {
        private Sibala _sibala;

        public NoPointHandler(Sibala sibala)
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