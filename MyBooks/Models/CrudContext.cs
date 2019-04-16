using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace MyBooks.Models
{
    public class CrudContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Country> Countries { get; set; }

        public CrudContext(string _connectionString)
        {
            this.ConnectionString = _connectionString;
        }

        public MySqlConnection getConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            using(MySqlConnection conn = getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("View_all_books", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book()
                        {
                            BookId = Convert.ToInt32(reader["book_id"]),
                            BookName = reader["book_name"].ToString(),
                            BookAuthor = reader["author_name"].ToString(),
                            BookGenre = reader["genre_name"].ToString(),
                            BookPagesNum = Convert.ToInt32(reader["book_pages_num"]),
                            BookStatus = reader["book_status_name"].ToString()
                        }
                        );
                    }
                }
            }

            return books;
        }
    }
}
