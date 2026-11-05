
using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
                age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayRole()
    {
        Console.WriteLine("I am a person.");
    }
}

class Student : Person
{
    public Student(string name, int age)
        : base(name, age)
    {
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Student");
        Console.WriteLine("I can borrow books from the library.");
    }
}

class Librarian : Person
{
    public Librarian(string name, int age)
        : base(name, age)
    {
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Librarian");
        Console.WriteLine("I manage the library and its books.");
    }
}


abstract class LibraryItem
{
    public string Title { get; set; }
    public int ItemId { get; set; }

    public LibraryItem(string title, int itemId)
    {
        Title = title;
        ItemId = itemId;
    }

    public abstract void GetDetails();
}

// Book inherits from LibraryItem
class Book : LibraryItem
{
    public string Author { get; set; }

    public Book(string title, int itemId, string author)
        : base(title, itemId)
    {
        Author = author;
    }

    public override void GetDetails()
    {
        Console.WriteLine($"Book ID: {ItemId}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
    }
}

class Magazine : LibraryItem
{
    public int IssueNumber { get; set; }

    public Magazine(string title, int itemId, int issueNumber)
        : base(title, itemId)
    {
        IssueNumber = issueNumber;
    }

    public override void GetDetails()
    {
        Console.WriteLine($"Magazine ID: {ItemId}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Issue Number: {IssueNumber}");
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added successfully!");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\nLibrary Books:");

        foreach (Book book in books)
        {
            book.GetDetails();
            Console.WriteLine("----------------");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        

        Student student = new Student("Ahmed", 20);
        Librarian librarian = new Librarian("Mona", 35);

        Console.WriteLine(" People Information ");

        student.DisplayRole();
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Age: {student.Age}");

        Console.WriteLine();

        librarian.DisplayRole();
        Console.WriteLine($"Name: {librarian.Name}");
        Console.WriteLine($"Age: {librarian.Age}");

       

        Console.WriteLine("\n Library Items ");

        LibraryItem book1 = new Book("C# Programming", 101, "John Smith");
        LibraryItem magazine1 = new Magazine("Tech World", 201, 15);

        book1.GetDetails();

        Console.WriteLine();

        magazine1.GetDetails();

       

        Console.WriteLine("\n Library Management ");

        Library library = new Library();

        library.AddBook(new Book("OOP with C#", 102, "Ahmed Ali"));
        library.AddBook(new Book("Learn Programming", 103, "Sara Mohamed"));

        library.DisplayBooks();
    }
}

