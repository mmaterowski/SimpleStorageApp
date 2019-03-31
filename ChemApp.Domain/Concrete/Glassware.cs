using ChemApp.Domain.Abstract;

namespace ChemApp.Domain.Concrete
{
    public class Glassware : BaseEntity, IGlassware
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Volume { get; set; }
        public int Quality { get; set; }
        public string Condition { get; set; }
        public bool IsClean { get; set; }

        override public string ToString()
        {
            return $"{this.Name} ({this.Volume}ml)";
        }
    }
}