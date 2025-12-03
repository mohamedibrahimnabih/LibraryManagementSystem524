using Linq.Models;
using Linq.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Book> books = new();
            ApplicationDbContext db = new();

            do
            {

                Console.WriteLine("\n1. Add New Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. ....");

                Console.WriteLine("Enter Your Selection: ");
                string selection = Console.ReadLine();

                switch(selection)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter Author");
                            string author = Console.ReadLine();

                            Console.WriteLine("Enter Description");
                            string description = Console.ReadLine();

                            Console.WriteLine("Enter Price");
                            decimal price = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Enter Quantity");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter SKU");
                            string sku = Console.ReadLine();

                            Console.WriteLine("Enter Category Id");
                            int categoryId = Convert.ToInt32(Console.ReadLine());

                            db.Books.Add(new()
                            {
                                Name = name,
                                Author = author,
                                Price = price,
                                Description = description,
                                Quantity = quantity,
                                Sku = sku,
                                CategoryId = categoryId,
                            });

                            //db.Books.FromSqlRaw($"INSERT INTO books(name, author, price, description, quantity, sku, categroyId) VALUES ({name}, {author}, {price}, {description}, {quantity}, {sku}, {categoryId})");

                            //db.Books.FromSqlRaw($"", );

                            db.SaveChanges();
                            Console.WriteLine("Add Book Successfully");
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine("Enter Book Id To Edit It: ");
                            int bookId = Convert.ToInt32(Console.ReadLine());

                            //var book = db.Books.First();
                            //var book = db.Books.First(b => b.Id == bookId);
                            //var book = db.Books.First(b => b.Name == "test");
                            //var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                            //var book = db.Books.Single();
                            //var book = db.Books.Single(b => b.Id == bookId);
                            //var book = db.Books.Single(b => b.Name == "test");
                            //var book = db.Books.AsNoTracking().SingleOrDefault(b => b.Id == bookId);

                            var book = db.Books.Find(bookId);

                            if (book is null)
                                Console.WriteLine("Book Not Founded");
                            else
                            {
                                Console.WriteLine("Enter Name");
                                string name = Console.ReadLine();

                                Console.WriteLine("Enter Author");
                                string author = Console.ReadLine();

                                Console.WriteLine("Enter Description");
                                string description = Console.ReadLine();

                                Console.WriteLine("Enter Price");
                                decimal price = Convert.ToDecimal(Console.ReadLine());

                                Console.WriteLine("Enter Quantity");
                                int quantity = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter SKU");
                                string sku = Console.ReadLine();

                                Console.WriteLine("Enter Category Id");
                                int categoryId = Convert.ToInt32(Console.ReadLine());

                                db.Books.Remove(new Book()
                                {
                                    Id = book.Id,
                                    Name = name,
                                    Author = author,
                                    Price = price,
                                    Description = description,
                                    Quantity = quantity,
                                    Sku = sku,
                                    CategoryId = categoryId,
                                });

                                book.Name = name;
                                book.Author = author;
                                book.Price = price;
                                book.Description = description;
                                book.Quantity = quantity;
                                book.Sku = sku;
                                book.CategoryId = categoryId;

                                db.SaveChanges();

                                Console.WriteLine("Update Book Successfully");
                            }
                        }
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }

            } while (true);
        }

        
    }
}
