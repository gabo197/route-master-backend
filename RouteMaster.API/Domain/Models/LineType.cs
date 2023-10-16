namespace RouteMaster.API.Domain.Models
{
    public class LineType
    {
        public int LineTypeId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<BusLine> BusLines { get; set; } = null!;
    }
}