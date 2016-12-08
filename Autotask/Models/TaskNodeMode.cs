using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask.Models
{
    /// <summary>
    /// 任务节点模式
    /// </summary>
    public enum TaskNodeMode
    {
        /// <summary>
        /// 跳转到指定页面
        /// </summary>
        [Description("跳转")]
        RedirectPage = 1,
        /// <summary>
        /// 刷新页面
        /// </summary>
        [Description("刷新")]
        RefreshPage = 2,
        /// <summary>
        /// 手动处理
        /// </summary>
        [Description("手动")]
        Manual = 3,
        /// <summary>
        /// 点击元素
        /// </summary>
        [Description("点击")]
        ClickElement = 4,
        /// <summary>
        /// 聚焦元素
        /// </summary>
        [Description("聚焦")]
        FocusElement = 5,
        /// <summary>
        /// 输入元素
        /// </summary>
        [Description("输入")]
        InputElement = 6,
        /// <summary>
        /// 等待
        /// </summary>
        [Description("等待")]
        Wait = 7
    }
}
