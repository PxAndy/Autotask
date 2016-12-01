using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask.Models
{
    public class TaskModel : IDbModel
    {
        public TaskModel()
        {
            Id = Guid.NewGuid();
            ExecutionRangeStart = new TimeSpan(9, 0, 0);
            ExecutionRangeEnd = new TimeSpan(18, 0, 0);
            TaskNodes = new List<ITaskNode>();
        }

        #region 公共属性

        public Guid Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 执行任务的时间区间
        /// </summary>
        public TimeSpan ExecutionRangeStart { get; set; }

        /// <summary>
        /// 执行任务的时间区间
        /// </summary>
        public TimeSpan ExecutionRangeEnd { get; set; }

        public string ExecutionRangeRange
        {
            get
            {
                return string.Format("{0} - {1}", ExecutionRangeStart, ExecutionRangeEnd);
            }
        }

        public bool IsEnabled { get; set; }

        public List<ITaskNode> TaskNodes { get; set; }

        public ITaskNode FirstNode { get { return TaskNodes.HasValue() ? TaskNodes.First() : null; } }

        public ITaskNode LastNode { get { return TaskNodes.HasValue() ? TaskNodes.Last() : null; } }

        #endregion

        #region 公共方法

        public bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null)
        {
            if (TaskNodes.HasValue())
            {
                foreach (var node in TaskNodes)
                {
                    var result = node.Run(browser, onRunning, onRunned);

                    if (node.IsRequired && !result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
        
        #region 重载方法

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
