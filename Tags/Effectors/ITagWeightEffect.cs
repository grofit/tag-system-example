using System.Collections.Generic;
using System.Globalization;

namespace Tags.Effectors
{
    public interface ITagWeightEffect<Tin, Tout>
    {
        IEnumerable<TagWeight> TagWeights { get; }

        Tout RunEffect(Tin context);
    }
}
