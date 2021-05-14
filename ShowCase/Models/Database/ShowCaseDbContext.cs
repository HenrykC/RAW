using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShowCase.Models.Database
{
    public class ShowCaseDbContext : DbContext
    {
        public ShowCaseDbContext(DbContextOptions<ShowCaseDbContext> options) : base(options)
        {
        }

        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Example>()
                .HasData(new Example()
                {
                    Id = 1,

                    Name = "Use Post 4 Everything",

                    WorstPractice = "<b>POST</b> /api/v2/CreateOrder<br>" +
                                    "<b>POST</b> /api/v2/GetOrder?id = 12345<br>" +
                                    "<b>POST</b> /api/v2/GetOrders<br>" +
                                    "<b>POST</b> /api/v2/DeleteOrder?id=12345<br>",

                    BestPractice = "<b>POST</b> /api/v2/orders<br>" +
                                    "<b>GET</b> /api/v2/orders<br>" +
                                    "<b>GET</b> /api/v2/orders/12345<br>" +
                                    "<b>DELETE</b> /api/v2/orders/12345<br>",


                });

            modelBuilder.Entity<Example>()
                 .HasData(new Example()
                 {
                     Id = 2,

                     Name = "Update with post",

                     WorstPractice = "Update a post -><br>" +
                                     "<b>POST</b> /api/v2/posts/12345",


                     BestPractice = "Update a post -><br>" +
                                     "<b>PUT</b> /api/v2/posts/12345<br>" +
                                     "<b>PATCH </b> /api/v2/posts/12345",
                 });

            modelBuilder.Entity<Example>()
                 .HasData(new Example()
                 {
                     Id = 3,

                     Name = "Let’s use PUT",

                     WorstPractice = "Request -><br>" +
                                     "<b>PUT</b> /api/v2/posts/12345<br><br>" +
                                     "Response Status -><br>" +
                                     "<b>404</b> Not Found",


                     BestPractice = "Request -><br>" +
                                     "<b>PUT</b> /api/v2/posts/12345<br><br>" +
                                     "Response Status -><br>" +
                                     "<b>201</b> Created",

                     Description = "Post 12345 does not exist."

                 });

            modelBuilder.Entity<Example>()
                .HasData(new Example()
                {
                    Id = 4,

                    Name = "The PUT request should return 201",

                    WorstPractice = "Request -><br>" +
                                    "<b>PUT</b> /api/v2/posts/12345<br><br>" +
                                    "Response Status -><br>" +
                                    "<b>200</b> OK",

                    BestPractice = "Request -><br>" +
                                    "<b>PUT</b> /api/v2/posts/12345<br><br>" +
                                    "Response Status -><br>" +
                                    "<b>201</b> Created",

                    Description = "Post 12345 does not exist."

                });

            modelBuilder.Entity<Example>()
                .HasData(new Example()
                {
                    Id = 5,

                    Name = "Everything is “OK”",

                    WorstPractice = "Request -><br>" +
                                    "<b>POST</b> /api/v2/posts" +
                                    "Response Status -><br>" +
                                    "<b>200</b> OK",

                    BestPractice = "Request -><br>" +
                                    "<b>POST</b> /api/v2/posts" +
                                    "Response Status -><br>" +
                                    "<b>201</b> Created"

                });

            modelBuilder.Entity<Example>()
               .HasData(new Example()
               {
                   Id = 6,

                   Name = "Everything is “OK”",

                   WorstPractice = "Request -><br>" +
                                   "<b>DELETE</b> /api/v2/posts/12345" +
                                   "Response Status -><br>" +
                                   "<b>200</b> OK<br><br>" +
                                   "Response Body -><br>" +
                                   "<b>NULL</b>",

                   BestPractice = "Request -><br>" +
                                   "<b>DELETE</b> /api/v2/posts/12345" +
                                   "Response Status -><br>" +
                                   "<b>204</b> No Content<br><br>" +
                                   "Response Body -><br>" +
                                   "<b>NULL</b>",
               });

            modelBuilder.Entity<Example>()
              .HasData(new Example()
              {
                  Id = 7,

                  Name = "Server: “400 Bad Request”<br> Client: “Thanks for nothing”",

                  WorstPractice = "Request -><br>" +
                                  "<b>POST</b> /api/v2/posts/12345" +
                                  "Response Status -><br>" +
                                  "<b>400</b> Bad Request<br><br>" +
                                  "Response Body -><br>" +
                                  "<b>NULL</b>",

                  BestPractice = "Request -><br>" +
                                  "<b>POST</b> /api/v2/posts/12345" +
                                  "Response Status -><br>" +
                                  "<b>400</b> Bad Request<br><br>" +
                                  "Response Body -><br>" +
                                  "<b>Content-Type</b> JSON<br>" +
                                  "{<br>" +
                                  "  “code”: “ERR0001”,<br>" +
                                  "  “message”: “Your cart is empty.”<br>" +
                                  "}",
              });

            modelBuilder.Entity<Example>()
                           .HasData(new Example()
                           {
                               Id = 8,

                               Name = "Server: “400 Bad Request”<br> Client: “But this is a GET request”",

                               WorstPractice = "Request -><br>" +
                                    "<b>GET</b> /api/v2/ExampleExtension/12345<br><br>" +
                                    "Response Status -><br>" +
                                    "<b>400</b> Bad Request",

                               BestPractice = "Request -><br>" +
                                    "<b>GET</b> /api/v2/ExampleExtension/12345<br><br>" +
                                    "Response Status -><br>" +
                                    "<b>503</b> Service Unavailable",

                               Description = "Note: Do not return a 4XX<br>"+
                                             "error status if the error comes<br>"+
                                             "from the server — it is highly<br>"+
                                             "confusing and will drive your<br>"+
                                             "users completely insane!"
                           });

        }
    }
}
