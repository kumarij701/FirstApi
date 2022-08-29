using System;
using System.Collections.Generic;

namespace FirstAPI.Models
{
    public partial class UserStory
    {
        public int UserStoryId { get; set; }
        public string UserStoryName { get; set; } = null!;
        public string StoryOwner { get; set; } = null!;
        public int StoryPoints { get; set; }
        public string StoryDescription { get; set; } = null!;
    }
}
