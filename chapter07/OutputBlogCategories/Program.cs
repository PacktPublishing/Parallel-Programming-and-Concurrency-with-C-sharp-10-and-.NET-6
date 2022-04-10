using OutputBlogCategories;

Console.WriteLine("Hello, World!");

await FeedCategoryTransformer.GetCategoriesForFeed("https://blogs.windows.com/feed");
Console.ReadLine();