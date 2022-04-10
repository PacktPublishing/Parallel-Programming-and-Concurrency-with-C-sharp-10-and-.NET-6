using System.ServiceModel.Syndication;
using System.Threading.Tasks.Dataflow;

namespace OutputBlogCategories
{
    public static class FeedCategoryTransformer
    {
        public static async Task GetCategoriesForFeed(string url)
        {
            // Downloads the requested blog posts.
            var downloadFeed = new TransformBlock<string, IEnumerable<SyndicationItem>>(url =>
            {
                Console.WriteLine("Fetching feed from '{0}'...", url);
                return RssFeedService.GetFeedItems(url);
            });

            // Aggregates the categories from all the posts.
            var createCategoryList = new TransformBlock<IEnumerable<SyndicationItem>, List<SyndicationCategory>>(items =>
            {
                Console.WriteLine("Getting category list...");
                var result = new List<SyndicationCategory>();

                foreach (var item in items)
                {
                    result.AddRange(item.Categories);
                }

                return result;
            });

            // Removes duplicates.
            var deDupList = new TransformBlock<List<SyndicationCategory>, List<SyndicationCategory>>(categories =>
            {
                Console.WriteLine("De-duplicating category list...");
                var categoryComparer = new CategoryComparer();
                return categories.Distinct(categoryComparer).ToList();
            });

            // Gets the category names from the list of category objects.
            var createCategoryString = new TransformManyBlock<List<SyndicationCategory>, string>(categories =>
            {
                Console.WriteLine("Extracting category names...");
                return categories.Select(c => c.Name);
            });

            // Prints the upper-cased unique categories to the console.
            var printCategoryInCaps = new ActionBlock<string>(categoryName =>
            {
                Console.WriteLine($"Found CATEGORY {categoryName.ToUpper()}");
            });

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            downloadFeed.LinkTo(createCategoryList, linkOptions);
            createCategoryList.LinkTo(deDupList, linkOptions);
            deDupList.LinkTo(createCategoryString, linkOptions);
            createCategoryString.LinkTo(printCategoryInCaps, linkOptions);

            await downloadFeed.SendAsync(url);
            downloadFeed.Complete();
            await printCategoryInCaps.Completion;
        }
    }
}
