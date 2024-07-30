namespace FineArtDbApp
{
    public class Painting
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Painter { get; set; } = string.Empty;
        public int YearWriting { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Technique { get; set; } = string.Empty;
        public Painting() { }
    }
}
