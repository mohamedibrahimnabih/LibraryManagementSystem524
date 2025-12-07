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
                Console.WriteLine("4. Display Books");
                Console.WriteLine("5. Search Book By Name");
                Console.WriteLine("6. Search Book By Prices");
                Console.WriteLine("7. Show Quantity in Each Category");
                Console.WriteLine("8. Show User Name, Book Name");
                Console.WriteLine("9. .....");

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

                                db.Books.Update(new Book()
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
                        {
                            Console.WriteLine("Enter Book Id To Edit It: ");
                            int bookId = Convert.ToInt32(Console.ReadLine());

                            var book = db.Books.AsNoTracking().SingleOrDefault(b => b.Id == bookId);

                            if(book is null)
                                Console.WriteLine("Book Not Founded");
                            else
                            {
                                db.Books.Remove(book);
                                db.SaveChanges();

                                Console.WriteLine("Delete Book Successfully");
                            }
                        }
                        break;
                    case "4":

                        {
                            Console.WriteLine("Enter Page Number");
                            int page = Convert.ToInt32(Console.ReadLine());

                            //var books = db.Books
                            //    .Skip((page - 1) * 10)
                            //    .Take(10)
                            //    .OrderBy(e => e.Name)
                            //    .ThenByDescending(e => e.Rate)
                            //    .Join(db.Books, b => b.CategoryId, c => c.Id, (b, c) => new
                            //    {
                            //        b.Id,
                            //        BrandName = b.Name,
                            //        b.Author,
                            //        CategoryName = c.Name
                            //    });

                            var books = db.Books
                                .Include(e => e.Category)
                                .Skip((page - 1) * 10)
                                .Take(10)
                                .OrderBy(e => e.Name)
                                .ThenByDescending(e => e.Rate)
                                .Select(e => new
                                {
                                    e.Id,
                                    BrandName = e.Name,
                                    e.Author,
                                    CategoryName = e.Category.Name
                                });

                            //var books = db.Books
                            //    .Skip((page - 1) * 10)
                            //    .Take(10)
                            //    .OrderBy(e => e.Name)
                            //    .ThenByDescending(e => e.Rate)
                            //    .ToList();

                            foreach (var item in books)
                            {
                                Console.WriteLine($"Id: {item.Id}, Brand Name: {item.BrandName}, Author: {item.Author}, Category Name: {item.CategoryName}");
                            }
                        }

                        break;
                    case "5":

                        {
                            var books = db.Books.AsQueryable();

                            /* YOUR CODE HERE */
                            // STEP 1: filter By Name
                            // STEP 2: Order By Name, then by rate
                            // STEP 3: Select id, name, author only

                            foreach (var item in newBooks)
                            {
                                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Author: {item.Author}");
                            }
                        }

                        break;
                    case "6":

                        {
                            var books = db.Books.AsQueryable();

                            /* YOUR CODE HERE */
                            // STEP 1: filter By min price, max price
                            // STEP 2: Order By prices, rate
                            // STEP 3: Select id, name, price only

                            foreach (var item in newBooks)
                            {
                                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Author: {item.Price}");
                            }
                        }

                        break;
                    case "7":
                        {

                            var groups = db.Books.GroupBy(e => e.CategoryId).Select(g => new
                            {
                                g.Key,
                                Sum = g.Sum(e => e.Quantity)
                            });

                            foreach(var item in groups)
                            {
                                Console.WriteLine($"Key: {item.Key}, Sum: {item.Sum}");
                            }

                        }
                        break;
                    case "8":
                        {
                            var userBooks = db.UserBooks.AsQueryable();

                            ////////////////

                            foreach (var item in userBooks)
                            {
                                Console.WriteLine($"User Name: {item.User.Name}, Book Name: {item.Book.Name}");
                            }
                        }
                        break;
                    default:
                        break;
                }

            } while (true);
        }

        
    }
}
