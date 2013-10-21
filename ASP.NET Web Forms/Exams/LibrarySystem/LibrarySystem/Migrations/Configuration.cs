using LibrarySystem.Data;
using LibrarySystem.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LibrarySystem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(
                r => r.Name,
                new Category { Name = "Programming" },
                new Category { Name = "Databases" },
                new Category { Name = "Web Development" },
                new Category { Name = "System Administration" },
                new Category { Name = "Data Structures and Algorithms" },
                new Category { Name = "Rocket Science" }
                );

            context.SaveChanges();

            var categoryProgramming = context.Categories.FirstOrDefault(c => c.Name == "Programming");
            var categoryDatabases = context.Categories.FirstOrDefault(c => c.Name == "Databases");
            var categoryWebDevelopment = context.Categories.FirstOrDefault(c => c.Name == "Web Development");
            var categorySystemAdministration = context.Categories.FirstOrDefault(c => c.Name == "System Administration");
            var categoryDataStructuresAndAlgorithms = context.Categories.FirstOrDefault(c => c.Name == "Data Structures and Algorithms");

            context.Books.AddOrUpdate(
                b => b.Title,
                new Book
                {
                    Category = categoryProgramming,
                    Title = "Fundamentals of Computer Programming with C#",
                    Author = "Svetlin Nakov & Co.",
                    Isbn = "978-954-400-773-7",
                    WebSite = "http://www.introprogramming.info/english-intro-csharp-book/",
                    Description = "The free book \"Fundamentals of Computer Programming with C#\" aims to provide novice programmers solid foundation of basic knowledge regardless of the programming language. This book covers the fundamentals of programming that have not changed significantly over the last 10 years. Educational content was developed by an authoritative author team led by Svetlin Nakov and covers topics such as variables conditional statements, loops and arrays, and more complex concepts such as data structures (lists, stacks, queues, trees, hash tables, etc.), and recursion recursive algorithms, object-oriented programming and high-quality code. From the book you will learn how to think as programmers and how to solve efficiently programming problems. You will master the fundamental principles of programming and basic data structures and algorithms, without which you can't become a software engineer."
                },

                new Book
                {
                    Category = categoryProgramming,
                    Title = "Microsoft&reg; XNA&reg; Game Studio 4.0: Learn Programming Now!: How to program for Windows Phone 7, Xbox 360, Zune devices, and more",
                    Author = "Rob Miles",
                    Isbn = "978-0735651579",
                    WebSite = "http://www.amazon.com/Microsoft-XNA-Game-Studio-4-0/dp/0735651574/ref=sr_1_1?ie=UTF8&qid=1379586190&sr=8-1&keywords=rob+miles",
                    Description = "Now you can build your own games for your Xbox 360®, Windows® Phone 7, or Windows-based PC—as you learn the underlying concepts for computer programming. Use this hands-on guide to dive straight into your first project—adding new tools and tricks to your arsenal as you go. No experience required!"
                },

                new Book
                {
                    Category = categoryProgramming,
                    Title = "Beginning JavaScript, 4th Edition",
                    Author = "Paul Wilton, Jeremy McPeak",
                    Isbn = "978-0470525937",
                    WebSite = "http://www.amazon.com/Beginning-JavaScript-Paul-Wilton/dp/0470525932/ref=sr_1_1?ie=UTF8&qid=1379586343&sr=8-1&keywords=Beginning+JavaScript%2C+4th+Edition+Paul+Wilton%2C+Jeremy+McPeak&selectObb=rent",
                    Description = "JavaScript allows you to enhance your web pages and web applications by providing dynamic, personalized, and interactive content. Serving as a great introduction to JavaScript, this book offers all you need to start using JavaScript on your web pages right away. It's fully updated and covers utilizing JavaScript with the latest versions of the Internet Explorer®, Firefox®, and Safari® browsers."
                },

                new Book
                {
                    Category = categoryDatabases,
                    Title = "Database Systems: The Complete Book",
                    Author = "Hector Garcia-Molina, Jeff Ullman, and Jennifer Widom",
                    Isbn = "978-0470525937",
                    WebSite = "http://www.amazon.com/Beginning-JavaScript-Paul-Wilton/dp/0470525932/ref=sr_1_1?ie=UTF8&qid=1379586343&sr=8-1&keywords=Beginning+JavaScript%2C+4th+Edition+Paul+Wilton%2C+Jeremy+McPeak&selectObb=rent",
                    Description = "Database Systems: The Complete Book is ideal for Database Systems and Database Design and Application courses offered at the junior, senior and graduate levels in Computer Science departments. A basic understanding of algebraic expressions and laws, logic, basic data structure, OOP concepts, and programming environments is implied."
                },

                new Book
                {
                    Category = categoryDatabases,
                    Title = "SQL in a Nutshell: A Desktop Quick Reference",
                    Author = "Kevin Kline",
                    Isbn = "978-0596518844",
                    WebSite = "http://www.amazon.com/SQL-Nutshell-In-OReilly/dp/0596518846/ref=sr_1_1?ie=UTF8&qid=1379586721&sr=8-1&keywords=SQL+in+a+Nutshell%3A+A+Desktop+Quick+Reference+Kevin+Kline&selectObb=rent",
                    Description = "SQL in a Nutshell applies the classic O'Reilly \"Nutshell\" format to Structured Query Language (SQL), the elegant descriptive language that's used to create and manipulate stores of data. This book explains the purpose and proper syntax of hundreds of SQL statements, as defined in four major SQL implementations, and details each entry with explanatory text and illustrative examples. Perhaps best of all, authors Kevin and Daniel Kline feature MySQL in their coverage, and give it billing that's equal to that of Oracle, Microsoft SQL Server, and PostgreSQL. Their inclusion of open-source MySQL, which in most situations carries no license fee, is recognition of its growing popularity and suitability for serious database applications; also, it improves this book's appeal to Unix and Linux developers."
                },

                new Book
                {
                    Category = categoryWebDevelopment,
                    Title = "Professional ASP.NET MVC 5",
                    Author = "Jon Galloway",
                    Isbn = "978-1118794753",
                    WebSite = "http://www.amazon.com/Professional-ASP-NET-MVC-Jon-Galloway/dp/1118794753/ref=sr_1_2?ie=UTF8&qid=1379586852&sr=8-2&keywords=Professional+ASP.NET+MVC+5+Jon+Galloway",
                    Description = "MVC 5 is the newest update to the popular Microsoft technology that enables you to build dynamic, data-driven websites. Like previous versions, this guide shows you step-by-step techniques on using MVC to best advantage, with plenty of practical tutorials to illustrate the concepts. It covers controllers, views, and models; forms and HTML helpers; data annotation and validation; membership, authorization, and security; plus the new Single Page applications."
                },

                new Book
                {
                    Category = categoryWebDevelopment,
                    Title = "Beginning ASP.NET 4.5 in C# Coding Skills Kit",
                    Author = "Imar Spaanjaars",
                    Isbn = "978-1118727294",
                    WebSite = "http://www.amazon.com/Beginning-ASP-NET-Coding-InnerWorkings-Software/dp/1118727290/ref=sr_1_1?ie=UTF8&qid=1380657247&sr=8-1&keywords=Beginning+ASP.NET+4.5+in+C%23+Coding+Skills+Kit",
                    Description = "Developers love to read books and learn new skills by solving coding problems, so we’ve brought the best of both worlds together. Presented by Wrox and InnerWorkings, this value-packed book-and-training software kit offers you an effective hands-on learning environment. The bundle consists of Wrox’s book Beginning ASP.NET 4.5 paired with practice-based coding challenges powered by InnerWorkings."
                },

                new Book
                {
                    Category = categoryWebDevelopment,
                    Title = "Beginning HTML and CSS",
                    Author = "Rob Larsen",
                    Isbn = "978-1118340189",
                    WebSite = "http://www.amazon.com/Beginning-HTML-CSS-Rob-Larsen/dp/1118340183/ref=sr_1_1?ie=UTF8&qid=1380657191&sr=8-1&keywords=Beginning+HTML+and+CSS",
                    Description = "If you develop websites, you know that the goal posts keep moving, especially now that your website must work on not only traditional desktops, but also on an ever-changing range of smartphones and tablets. This step-by-step book efficiently guides you through the thicket. Teaching you the very latest best practices and techniques, this practical reference walks you through how to use HTML5 and CSS3 to develop attractive, modern websites for today's multiple devices. From handling text, forms, and video, to implementing powerful JavaScript functionality, this book covers it all."
                },

                new Book
                {
                    Category = categorySystemAdministration,
                    Title = "Advanced Linux Programming",
                    Author = "CodeSourcery LLC",
                    Isbn = "978-0735710436",
                    WebSite = "http://www.amazon.com/Advanced-Linux-Programming-CodeSourcery-LLC/dp/0735710430/ref=sr_1_1?ie=UTF8&qid=1380657129&sr=8-1&keywords=Advanced+Linux+Programming",
                    Description = "Advanced Linux Programming is divided into two parts. The first covers generic UNIX system services, but with a particular eye towards Linux specific information. This portion of the book will be of use even to advanced programmers who have worked with other Linux systems since it will cover Linux specific details and differences. For programmers without UNIX experience, it will be even more valuable. The second section covers material that is entirely Linux specific. These are truly advanced topics, and are the techniques that the gurus use to build great applications. While this book will focus mostly on the Application Programming Interface (API) provided by the Linux kernel and the C library, a preliminary introduction to the development tools available will allow all who purchase the book to make immediate use of Linux."
                },

                new Book
                {
                    Category = categoryDataStructuresAndAlgorithms,
                    Title = "Programming = ++ Algorithms;",
                    Author = "Preslav Nakov and Panayot Dobrikov",
                    Isbn = "954-8905-06-X",
                    WebSite = "http://www.programirane.org/",
                    Description = "Bulgaria’s President Georgi Parvanov presented for the first time the yearly John Atanassoff award given for special achievements in the filed of computer engineering. The first laureate of the prestigious award is Preslav Nakov from the town of Veliko Tarnovo. Parvanov announced the setting up of the award in October. He also said that it will be presented annual to young Bulgarians that showed great achievements in the computers and informative technologies. In the beginning of October Bulgaria’s President Georgi Parvanov led a special ceremony to inaugurate a monument of the modern computer inventor Bulgaria-descended John Atanasoff. John Atanasoff Junior was also present at the ceremony. John Atanasoff, who is son of a Bulgarian immigrant from Bulgaria’s village of Boyadjik in the Yambol Region, built the world’s first electronic digital computer at US Iowa State University during 1937-42 together with his assistant Clifford Berry. Their creation incorporated several major innovations in computing including the use of binary arithmetic, regenerative memory, parallel processing and separation of memory and computing functions."
                },

                new Book
                {
                    Category = categoryDataStructuresAndAlgorithms,
                    Title = "Introduction to Algorithms, 3rd Edition",
                    Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, and Clifford Stein",
                    Isbn = "978-0262033848",
                    WebSite = "http://www.amazon.com/Introduction-Algorithms-Thomas-H-Cormen/dp/0262033844/ref=sr_1_1?ie=UTF8&qid=1380656857&sr=8-1&keywords=introduction+to+algorithms",
                    Description = "Some books on algorithms are rigorous but incomplete; others cover masses of material but lack rigor. Introduction to Algorithms uniquely combines rigor and comprehensiveness. The book covers a broad range of algorithms in depth, yet makes their design and analysis accessible to all levels of readers. Each chapter is relatively self-contained and can be used as a unit of study. The algorithms are described in English and in a pseudocode designed to be readable by anyone who has done a little programming. The explanations have been kept elementary without sacrificing depth of coverage or mathematical rigor.The first edition became a widely used text in universities worldwide as well as the standard reference for professionals. The second edition featured new chapters on the role of algorithms, probabilistic analysis and randomized algorithms, and linear programming. The third edition has been revised and updated throughout. It includes two completely new chapters, on van Emde Boas trees and multithreaded algorithms, substantial additions to the chapter on recurrence (now called \"Divide-and-Conquer\"), and an appendix on matrices. It features improved treatment of dynamic programming and greedy algorithms and a new notion of edge-based flow in the material on flow networks. Many new exercises and problems have been added for this edition. As of the third edition, this textbook is published exclusively by the MIT Press."
                });
        }
    }
}
