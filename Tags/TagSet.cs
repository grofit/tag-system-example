using System.Collections.Generic;

namespace Tags
{
    public class TagSet : ITagged
    {
        public List<string> Tags { get; }

        public TagSet(List<string> tags)
        {
            Tags = tags;
        }
    }
}
