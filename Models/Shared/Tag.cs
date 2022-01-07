namespace SurfThisUp.Models.Shared
{
    public class Tag
    {
        public int Id { get; set; } = 0;
        public string TagText { get; set; } = string.Empty;
        public Category TagType { get; set; } = new();

    }
}
