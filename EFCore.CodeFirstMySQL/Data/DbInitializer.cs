using EFCore.CodeFirstMySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.CodeFirstMySQL.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory, EFCoreDBContext context)
        {
            _scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<EFCoreDBContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<EFCoreDBContext>())
                {
                    context.Database.EnsureCreated();
                    if (!context.Blogs.Any())
                    {
                        var dotnetBlog = new Blog
                        {
                            Url = "http://www.microsoft.com"
                        };
                        var dotnetCoreBlog = new Blog
                        {
                            Url = "http://www.visualstudio.com"
                        };

                        var blogs = new Blog[]
                        {
                            dotnetBlog, dotnetCoreBlog
                        };

                        foreach (var blog in blogs)
                        {
                            context.Blogs.Add(blog);
                        }
                        context.SaveChanges();

                        var posts = new Post[]
                        {
                            new Post {Title="Microsoft", Blog=dotnetBlog, Content="Microsoft Content", PublishedDateTime=DateTime.Now},
                            new Post {Title="Visual Studio", Blog=dotnetCoreBlog, Content="Visual Studio Content", PublishedDateTime=DateTime.Now},
                        };

                        foreach (var post in posts)
                        {
                            context.Posts.Add(post);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
