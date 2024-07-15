using EfCoreExamples.Db;
using EfCoreExamples.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreExamples.EfCoreExamples;

public class EfCoreExample
{
    private readonly AppDbContext _appDbContext;

    public EfCoreExample(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Run()
    {

    }

    private void Read()
    {
        var lst = _appDbContext.Blogs.ToList();
        foreach (BlogDto blog in lst)
        {
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
        }
    }

    private void Edit(int id)
    {
        var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item == null)
        {
            Console.WriteLine("No data not found");
            return;
        }
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }

    private void Create(string blogTitle, string blogAuthor, string blogContent)
    {
        var item = new BlogDto
        {
            BlogAuthor = blogAuthor,
            BlogContent = blogContent,
            BlogTitle = blogTitle,
        };
        _appDbContext.Blogs.Add(item);
        int result = _appDbContext.SaveChanges();
        var message = result > 0 ? "Success" : "Fail";
        Console.WriteLine(message);
    }

    private void Update(int id, string blogTitle, string blogAuthor, string blogContent)
    {
        var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item == null)
        {
            Console.WriteLine("No data not found");
            return;
        }

        item.BlogTitle = blogTitle;
        item.BlogAuthor = blogAuthor;
        item.BlogContent = blogContent;

        int result = _appDbContext.SaveChanges();
        var message = result > 0 ? "Success" : "Fail";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item == null)
        {
            Console.WriteLine("No data not found");
            return;
        }
        _appDbContext.Remove(item);
        int result = _appDbContext.SaveChanges();
        var message = result > 0 ? "Success" : "Fail";
        Console.WriteLine(message);
    }
}