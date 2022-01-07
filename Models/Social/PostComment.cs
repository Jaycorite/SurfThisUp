using SurfThisUp.Areas.Identity.Data;

namespace SurfThisUp.Models.Social
{
    public class PostComment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;
        public SurfThisUpUser User { get; set; }
    }
}
