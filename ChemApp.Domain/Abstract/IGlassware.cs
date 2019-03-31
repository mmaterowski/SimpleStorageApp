namespace ChemApp.Domain.Abstract
{
    public interface IGlassware : IBaseEntity
    {
        string Name { get; set; }
        decimal Price { get; set; }
        float Volume { get; set; }
        int Quality { get; set; }
        string Condition { get; set; }
        bool IsClean { get; set; }
    }
}