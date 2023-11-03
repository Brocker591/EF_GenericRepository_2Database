using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_GenericRepository_2Database_repository.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Publication { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
