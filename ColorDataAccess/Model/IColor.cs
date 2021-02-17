namespace ColorDataAccess.Model
{
    public interface IColor
    {
        string HexCode { get; set; }
        int Id { get; set; }
        bool IsAvailable { get; set; }
        string Name { get; set; }
    }
}