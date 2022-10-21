# Parallel Programming and Concurrency with C#10 and .NET6 

<a href="https://www.packtpub.com/product/parallel-programming-and-concurrency-with-c-10-and-net6/9781803243672?utm_source=github&utm_medium=repository&utm_campaign="><img src="https://static.packt-cdn.com/products/9781803243672/cover/smaller" alt="Parallel Programming and Concurrency with C#10 and .NET6 " height="256px" align="right"></a>

This is the code repository for [Parallel Programming and Concurrency with C#10 and .NET6 ](https://www.packtpub.com/product/parallel-programming-and-concurrency-with-c-10-and-net6/9781803243672?utm_source=github&utm_medium=repository&utm_campaign=), published by Packt.

**A modern approach to building faster, more responsive, and asynchronous .NET applications using C#**

## What is this book about?
Whether you are developing for desktop, mobile, web, or the cloud, performance and responsiveness are key to the success of any application. This book will help every type of C# developer to scale their application to its users’ needs and avoid the pitfalls often encountered with multi-threaded development.

This book covers the following exciting features:

* Prevent deadlocks and race conditions with managed threading
* Update Windows app UIs without causing exceptions
* Explore best practices for introducing asynchronous constructs to existing code
* Avoid pitfalls when introducing parallelism to your code
* Implement the producer-consumer pattern with Dataflow blocks
* Enforce data sorting when processing data in parallel and safely merge data from multiple sources
* Use concurrent collections that help synchronize data across threads
* Debug an everyday parallel app with the Parallel Stacks and Parallel Tasks windows

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1803243678) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>

## Instructions and Navigations
All of the code is organized into folders. For example, Chapter02.

The code will look like the following:
```
public async Task PerformCalculations()
{
    _runningTotal = 3;
    await MultiplyValue().ContinueWith(async (Task) => {
    await AddValue();
});
Console.WriteLine($Running total is {_runningTotal});
}
```

**Following is what you need for this book:**
This book is for beginner to intermediate-level .NET developers who want to employ the latest parallel and concurrency features in .NET when building their applications. Readers should have a solid understanding of the C# language and any version of the .NET Framework or .NET Core.

With the following software and hardware list you can run all code files present in the book (Chapter 1-12).
### Software and Hardware List
| Chapter | Software required | OS required |
| -------- | ------------------------------------ | ----------------------------------- |
| 1 | Visual studio 2022 | Windows 10/11 |
| 1 | Visual studio code | Windows, Mac OS X, and Linux (Any) |
| 1 | .NET 6 | Windows, Mac OS X, and Linux (Any) |


We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://packt.link/Z4GcQ).

### Related products
* Enterprise Application Development with C# 10 and .NET 6 - Second Edition  [[Packt]](https://www.packtpub.com/product/enterprise-application-development-with-c-10-and-net-6/9781803232973?utm_source=github&utm_medium=repository&utm_campaign=) [[Amazon]](https://www.amazon.com/dp/1803232978)

* High-Performance Programming in C# and .NET  [[Packt]](https://www.packtpub.com/product/high-performance-programming-in-c-and-net/9781800564718?utm_source=github&utm_medium=repository&utm_campaign=) [[Amazon]](https://www.amazon.com/dp/1800564716)


## Get to Know the Author
**Alvin Ashcraft**
iis a software engineer and developer community champion with over 25 years of experience in software development. Working primarily with Microsoft Windows, web, and cloud technologies, his career has focused primarily on the healthcare industry. He has been awarded as a Microsoft MVP 11 times, most recently as a Windows Dev MVP.
Alvin works in the Philadelphia area for Allscripts, a global healthcare software company, as a principal software engineer. He is also a board member of the TechBash Foundation, where he helps organize the annual TechBash developer conference. He has previously worked for companies such as Oracle, Genzeon, CSC, and ITG Pathfinders.
Originally from the Allentown, PA area, Alvin currently resides in West Grove, PA with his wife and three daughters.





### Download a free PDF

 <i>If you have already purchased a print or Kindle version of this book, you can get a DRM-free PDF version at no cost.<br>Simply click on the link to claim your free PDF.</i>
<p align="center"> <a href="https://packt.link/free-ebook/9781803243672">https://packt.link/free-ebook/9781803243672 </a> </p>