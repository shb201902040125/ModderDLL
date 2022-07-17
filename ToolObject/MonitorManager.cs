namespace ModderDLL.ToolObject
{
    /// <summary>
    /// 追踪管理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MonitorManager<T> where T : notnull
    {
        /// <summary>
        /// 管理器的所有者，如果为null则为ModderDLL创建
        /// </summary>
        public Mod Mod { get; internal set; }
        internal readonly Dictionary<MonitorToken<T>, MonitorInfo<T>> Monitor = new();
        internal readonly Dictionary<T, MonitorToken<T>> Target = new();
        /// <summary>
        /// 通过管理器分发的令牌从管理器获取托管的信息
        /// </summary>
        /// <param name="token">创建追踪任务时从管理器获得令牌，或者来自令牌所有者的移交</param>
        /// <returns>令牌对应的信息</returns>
        /// <exception cref="KeyNotFoundException">如果管理器不存在该令牌对应的信息则会抛出该异常</exception>
        public virtual MonitorInfo<T> GetMonitiorInfo(MonitorToken<T> token)
        {
            if (Monitor.TryGetValue(token, out var info))
            {
                return info;
            }
            throw new KeyNotFoundException($"{token} is not found");
        }
        /// <summary>
        /// 通过管理器分发的令牌尝试从管理器获取托管的信息
        /// </summary>
        /// <param name="token">创建追踪任务时从管理器获得令牌，或者来自令牌所有者的移交</param>
        /// <param name="info">令牌对应的信息</param>
        /// <returns>令牌存在对应信息且获取成功返回true，其余false</returns>
        public virtual bool TryGetMonitiorInfo(MonitorToken<T> token, out MonitorInfo<T> info)
        {
            if (Monitor.TryGetValue(token, out info))
            {
                return true;
            }
            info = null;
            return false;
        }
        /// <summary>
        /// 创建一个追踪任务
        /// </summary>
        /// <param name="mod">创建者</param>
        /// <param name="target">追踪的目标</param>
        /// <param name="info">创建的追踪任务的信息</param>
        /// <returns>创建的追踪任务的令牌</returns>
        public virtual MonitorToken<T> CreatMonitor(Mod mod!!, T target!!, out MonitorInfo<T> info)
        {
            MonitorToken<T> token = MonitorToken<T>.Creat(mod, target);
            info = MonitorInfo<T>.Creat(token);
            Monitor.Add(token, info);
            return token;
        }
        /// <summary>
        /// 提交一个追踪任务
        /// </summary>
        /// <param name="info">提交的追踪任务</param>
        /// <exception cref="NullReferenceException">提交的任务的令牌为null</exception>
        public virtual void AddMonitor(MonitorInfo<T> info)
        {
            if(info._token is null)
            {
                throw new NullReferenceException("This MonitorInfo's Token is null");
            }
            Monitor.Add(info._token, info);
        }
        /// <summary>
        /// 通过令牌注销追踪任务
        /// </summary>
        /// <param name="token">创建追踪任务时从管理器获得令牌，或者来自令牌所有者的移交</param>
        /// <returns>如果令牌具有对应信息且成功注销返回true，其余false</returns>
        public virtual bool Cancel(MonitorToken<T> token)
        {
            return Monitor.Remove(token);
        }
        internal void Run(T target, Enum @enum)
        {
            if (Target.TryGetValue(target, out var token))
            {
                Monitor[token].Run(@enum);
            }
        }
    }
}
