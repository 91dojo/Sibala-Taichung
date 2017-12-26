namespace Sibala_Taichung
{
    public interface ISibala
    {
        EnumOutputType OutputType { get; }

        int Point { get; set; }
        int MaxPoint { get; set; }
    }
}