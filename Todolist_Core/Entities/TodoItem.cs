using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist_Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    }
}
