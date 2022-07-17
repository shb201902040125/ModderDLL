namespace ModderDLL.ToolObject
{
    /// <summary>
    /// 追踪任务信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonitorInfo<T> where T : notnull
    {
        internal MonitorInfo(Mod mod, MonitorToken<T> token)
        {
            _token = token;
            Mod = mod;
        }
        /// <summary>
        /// 追踪任务委托类型
        /// </summary>
        /// <param name="monitorobj"></param>
        public delegate void MonitorDelegate(T monitorobj);
        internal readonly MonitorToken<T> _token;
        private readonly Dictionary<Enum, MonitorDelegate> delegates = new();
        /// <summary>
        /// 追踪任务的创建者
        /// </summary>
        public Mod Mod { get; private set; }
        /// <summary>
        /// 委托一个任务
        /// </summary>
        /// <param name="enum">委托任务的类型，请使用对应的枚举类进行委托</param>
        /// <param name="delegate">所委托的任务</param>
        public void SetDelegate(Enum @enum, MonitorDelegate @delegate)
        {
            if (delegates.ContainsKey(@enum))
            {
                delegates[@enum] += @delegate;
            }
            else
            {
                delegates.Add(@enum, @delegate);
            }
        }
        /// <summary>
        /// 移除一个任务
        /// </summary>
        /// <param name="enum">移除任务的类型，请使用对应的枚举类进行委托</param>
        /// <param name="delegate">所移除的任务</param>
        public void RemoveDelegate(Enum @enum, MonitorDelegate @delegate)
        {
            if (delegates.ContainsKey(@enum))
            {
                delegates[@enum] -= @delegate;
            }
        }
        internal void Run(Enum @enum)
        {
            if(delegates.ContainsKey(@enum))
            {
                delegates[@enum](_token.MonitorObject);
            }
        }
        /// <summary>
        /// 通过令牌创建一个追踪任务
        /// </summary>
        /// <param name="token">来自管理器分发的令牌</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">令牌为null</exception>
        public static MonitorInfo<T> Creat(MonitorToken<T> token)
        {
            if(token.Mod is null)
            {
                throw new NullReferenceException($"Token's Mod is null");
            }
            return new MonitorInfo<T>(token.Mod, token);
        }
    }
}
