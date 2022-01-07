namespace SurfThisUp.Models.Shared
{
    public class ResourcePath
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = "";
    }
}
