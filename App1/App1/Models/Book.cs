using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    [Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Read { get; set; }

        public Book(string name, string desc, string read)
        {
            Name = name;
            Description = desc;
            Read = read;
        }
        public Book() { }
    }
}
