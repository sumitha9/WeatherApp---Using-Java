using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace TodoXamarinForms
{
    public class TodoItem : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public string ZipCode { get; set; }

         public string City { get; set; }

        public string Unit { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        
        public bool IsCompleted { get; set; }

        public DateTime Timestamp { get; set; }
    }
}