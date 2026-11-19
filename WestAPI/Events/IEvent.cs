using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestAPI.Events;

/// <summary>
/// 事件
/// </summary>
public interface IEvent
{

}

/// <summary>
/// 可被取消的事件
/// </summary>
public interface ICancelableEvent
{
    /// <summary>
    /// 事件是否取消
    /// </summary>
    public bool IsCanceled { get; }
}
