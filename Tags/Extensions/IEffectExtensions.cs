using System.Collections.Generic;
using System.Linq;
using Tags.Effectors;

namespace Tags.Extensions
{
    public static class IEffectExtensions
    {
        public static float GetTotalWeighting(this IEnumerable<TagWeight> applicableTags)
        {
            return applicableTags.Sum(x => x.Weight);
        }

        public static IEnumerable<TagWeight> FindApplicableTags<T1,T2>(this ITagLinkEffect<T1,T2> linkEffect, ITagged sourceObject, ITagged destinationObject)
        {
            return linkEffect.TagLinks.Where(x => sourceObject.Tags.Contains(x.SourceTag) && destinationObject.Tags.Contains(x.DestinationTag));
        }
        
        public static IEnumerable<TagWeight> FindApplicableTags<T1,T2>(this ITagWeightEffect<T1,T2> weightEffect, ITagged taggedObject)
        {
            return weightEffect.TagWeights.Where(x => taggedObject.Tags.Contains(x.SourceTag));
        }

    }
}