using SurfThisUp.Areas.Identity.Data;
using SurfThisUp.Models.Shared;

namespace SurfThisUp.Models.Social
{
    public class SocialPost
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "";
        public string Content { get; set; } = string.Empty;
        public List<ResourcePath> Resources { get; set; } = new List<ResourcePath>();
        public SurfThisUpUser User { get; set; }
        public Location? Location { get; set; } = null;
        public DateTime Created { get; set; } = DateTime.Now;
        public List<Tag>? Tags { get; set; } = new();
        public List<PostComment>? PostComments { get; set; }
    }
}
