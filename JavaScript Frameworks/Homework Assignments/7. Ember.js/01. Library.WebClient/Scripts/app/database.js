var database = (function () {

    var books = [{
        id: 1,
        category: 'Databases',
        title: 'SQL in a Nutshell: A Desktop Quick Reference',
        author: 'Kevin Kline',
        publicationDate: new Date('12-2-2008'),
        isbn: '978-0596518844',
        webSite: 'http://www.amazon.com/SQL-Nutshell-In-OReilly/dp/0596518846/ref=sr_1_1?ie=UTF8&qid=1379586721&sr=8-1&keywords=SQL+in+a+Nutshell%3A+A+Desktop+Quick+Reference+Kevin+Kline&selectObb=rent',
        description: 'SQL in a Nutshell applies the classic O\'Reilly "Nutshell" format to Structured Query Language (SQL), the elegant descriptive language that\'s used to create and manipulate stores of data. This book explains the purpose and proper syntax of hundreds of SQL statements, as defined in four major SQL implementations, and details each entry with explanatory text and illustrative examples. Perhaps best of all, authors Kevin and Daniel Kline feature MySQL in their coverage, and give it billing that\'s equal to that of Oracle, Microsoft SQL Server, and PostgreSQL. Their inclusion of open-source MySQL, which in most situations carries no license fee, is recognition of its growing popularity and suitability for serious database applications; also, it improves this book\'s appeal to Unix and Linux developers.'
    }, {
        id: 2,
        category: 'Web Development',
        title: 'Professional ASP.NET MVC 5',
        author: 'Jon Galloway',
        publicationDate: new Date('1-21-2014'),
        isbn: '978-1118794753',
        webSite: 'http://www.amazon.com/Professional-ASP-NET-MVC-Jon-Galloway/dp/1118794753/ref=sr_1_2?ie=UTF8&qid=1379586852&sr=8-2&keywords=Professional+ASP.NET+MVC+5+Jon+Galloway',
        description: 'MVC 5 is the newest update to the popular Microsoft technology that enables you to build dynamic, data-driven websites. Like previous versions, this guide shows you step-by-step techniques on using MVC to best advantage, with plenty of practical tutorials to illustrate the concepts. It covers controllers, views, and models; forms and HTML helpers; data annotation and validation; membership, authorization, and security; plus the new Single Page applications.'
    }];

    return {
        books: books
    };

})();