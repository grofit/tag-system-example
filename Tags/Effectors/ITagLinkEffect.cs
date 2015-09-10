using System.Collections.Generic;

namespace Tags.Effectors
{
    public interface ITagLinkEffect<Tin, Tout>
    {
        IEnumerable<TagLink> TagLinks { get; }

        Tout RunEffect(Tin context);
    }
}