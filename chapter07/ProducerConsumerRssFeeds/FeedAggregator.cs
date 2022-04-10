using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ProducerConsumerRssFeeds
{
    public class FeedAggregator
    {
        public async Task<IEnumerable<BlogPost>> GetAllMicrosoftBlogPosts()
        {
            var posts = new ConcurrentBag<BlogPost>();

            // Create queue of source posts
            BufferBlock<SyndicationItem> itemQueue = new(new DataflowBlockOptions { BoundedCapacity = 10 });

            // Create and link consumers
            var consumerOptions = new ExecutionDataflowBlockOptions { BoundedCapacity = 1 };
            var consumerA = new ActionBlock<SyndicationItem>((i) => ConsumeFeedItem(i, posts), consumerOptions);
            var consumerB = new ActionBlock<SyndicationItem>((i) => ConsumeFeedItem(i, posts), consumerOptions);
            var consumerC = new ActionBlock<SyndicationItem>((i) => ConsumeFeedItem(i, posts), consumerOptions);
            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true, };
            itemQueue.LinkTo(consumerA, linkOptions);
            itemQueue.LinkTo(consumerB, linkOptions);
            itemQueue.LinkTo(consumerC, linkOptions);

            // Start producers
            Task producers = QueueAllFeeds(itemQueue);

            // Wait for producers and consumers to complete
            await Task.WhenAll(producers, consumerA.Completion,
                consumerB.Completion, consumerC.Completion);

            return posts;
        }

        private async Task QueueAllFeeds(BufferBlock<SyndicationItem> itemQueue)
        {
            Task feedTask1 = ProduceFeedItems(itemQueue, "https://devblogs.microsoft.com/dotnet/feed/");
            Task feedTask2 = ProduceFeedItems(itemQueue, "https://blogs.windows.com/feed");
            Task feedTask3 = ProduceFeedItems(itemQueue, "https://www.microsoft.com/microsoft-365/blog/feed/");
            await Task.WhenAll(feedTask1, feedTask2, feedTask3);
            itemQueue.Complete();
        }

        private async Task ProduceFeedItems(BufferBlock<SyndicationItem> itemQueue, string feedUrl)
        {
            IEnumerable<SyndicationItem> items = RssFeedService.GetFeedItems(feedUrl);
            foreach (SyndicationItem item in items)
            {
                await itemQueue.SendAsync(item);
            }
        }

        private void ConsumeFeedItem(SyndicationItem nextItem, ConcurrentBag<BlogPost> posts)
        {
            if (nextItem != null && nextItem.Summary != null)
            {
                BlogPost newPost = new();
                newPost.PostContent = nextItem.Summary.Text.ToString();
                newPost.PostDate = nextItem.PublishDate.ToLocalTime().ToString("g");
                if (nextItem.Categories != null)
                {
                    newPost.Categories = string.Join(",", nextItem.Categories.Select(c => c.Name));
                }
                posts.Add(newPost);
            }
        }
    }
}