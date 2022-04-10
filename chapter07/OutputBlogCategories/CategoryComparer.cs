using System.Diagnostics.CodeAnalysis;
using System.ServiceModel.Syndication;

namespace OutputBlogCategories
{
    public class CategoryComparer : IEqualityComparer<SyndicationCategory>
    {
        public bool Equals(SyndicationCategory? x, SyndicationCategory? y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }

            //Comparing category names
            return x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] SyndicationCategory obj)
        {
            if (obj == null)
            {
                return 0;
            }
            // return the Name hashcode
            return obj.Name == null ? 0 : obj.Name.GetHashCode();
        }
    }
}