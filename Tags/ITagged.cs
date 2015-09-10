using System.Collections.Generic;

namespace Tags
{
    public interface ITagged
    {
        List<string> Tags { get; }
    }
}