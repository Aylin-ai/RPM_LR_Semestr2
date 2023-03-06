using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models
{
    public class TableRepos
    {
        SQLiteConnection db;
        public TableRepos(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();
            db.CreateTable<Book>();
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Table<User>().ToList();
        }
        public IEnumerable<Book> GetBooks()
        {
            return db.Table<Book>().ToList();
        }

        public User GetUser(int id)
        {
            return db.Get<User>(id);
        }
        public Book GetBook(int id)
        {
            return db.Get<Book>(id);
        }

        public int DeleteUser(int id)
        {
            return db.Delete<User>(id);
        }
        public int DeleteBook(int id)
        {
            return db.Delete<Book>(id);
        }

        public int DeleteUsers()
        {
            return db.DeleteAll<User>();
        }
        public int DeleteBooks()
        {
            return db.DeleteAll<Book>();
        }

        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                db.Update(user);
                return user.Id;
            }
            else
            {
                return db.Insert(user);
            }
        }
        public int SaveBook(Book book)
        {
            if (book.Id != 0)
            {
                db.Update(book);
                return book.Id;
            }
            else
            {
                return db.Insert(book);
            }
        }

        public int GetCount(int id)
        {
            if (id == 0)
            {
                return db.Table<User>().ToList().Count;
            }
            else if (id == 1)
            {
                return db.Table<Book>().ToList().Count;

            }
            else
            {
                return -1;
            }
        }
    }
}
