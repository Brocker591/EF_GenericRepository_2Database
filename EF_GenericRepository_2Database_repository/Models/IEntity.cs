using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_GenericRepository_2Database_repository.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
