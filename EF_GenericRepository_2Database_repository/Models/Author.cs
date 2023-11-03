using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_GenericRepository_2Database_repository.Models
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age {  get; set; }
        public List<Book> Books { get; set; }

    }
}
