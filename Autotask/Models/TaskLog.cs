using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask.Models
{
    public class TaskLog : IDbModel
    {
        public TaskLog()
        {
            Id = Guid.NewGuid();
            CreatedTime = DateTime.Now;
        }

        public Guid Id { get; set; }

        public Guid TaskId { get; set; }

        public string TaskName { get; set; }

        public bool IsSuccessful { get; set; }

        public string Remark { get; set; }
        
        public DateTime CreatedTime { get; set; }
    }
}
