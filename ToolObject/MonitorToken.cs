namespace ModderDLL.ToolObject
{
    /// <summary>
    /// 追踪令牌，持有令牌才能访问追踪管理器对应项目
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonitorToken<T> where T : notnull
    {
        internal MonitorToken(Mod mod, T monitorobj)
        {
            MonitorObject = monitorobj;
            Mod = mod;
            _token = MD5Support.GetMD5CodeBySystemTime();
        }
        /// <summary>
        /// 追踪的对象
        /// </summary>
        public T MonitorObject { get; private set; }
        /// <summary>
        /// 令牌的所有者，如果为null则为ModderDLL创建
        /// </summary>
        public Mod Mod { get; private set; }
        internal string _token;
        internal static MonitorToken<T> Creat(T target!!)
        {
            return new MonitorToken<T>(null, target);
        }
        /// <summary>
        /// 创建一枚新的令牌
        /// </summary>
        /// <param name="mod">令牌的创建者</param>
        /// <param name="target">令牌要追踪的对象</param>
        /// <returns></returns>
        public static MonitorToken<T> Creat(Mod mod!!, T target!!)
        {
            return new MonitorToken<T>(mod, target);
        }
        /// <summary>
        /// 字符串化的令牌信息摘要
        /// 内容为[Owner:所有者,MonitorToken:追踪对象字符串化,HashCode:哈希码]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[Owner{(Mod is null ? ModderDLL.Instance.Name : Mod.Name)},MonitorToken:{MonitorObject},HashCode:{GetHashCode()}]";
        }
        /// <summary>
        /// 令牌的哈希码
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _token.GetHashCode();
        }
        /// <summary>
        /// 对比一个对象是否为该令牌
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is MonitorToken<T> other)
            {
                return _token == other._token;
            }
            return false;
        }
        /// <summary>
        /// 移交令牌的权限，移交后该令牌不再能从管理器获取原先对应的信息
        /// </summary>
        /// <param name="handto">移交权限对象，另一块令牌</param>
        /// <exception cref="NullReferenceException">移交对象为null</exception>
        public void HandedOver(MonitorToken<T> handto)
        {
            if (handto is null)
            {
                throw new NullReferenceException("Token is null.");
            }
            handto._token = _token;
            _token = MD5Support.GetMD5CodeBySystemTime();
        }
        /// <summary>
        /// 对比两块令牌是否相同
        /// 相同指从管理器能获得同一份信息
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator ==(MonitorToken<T> m1, MonitorToken<T> m2)
        {
            if (m1 is null || m2 is null)
            {
                return false;
            }
            return m1._token == m2._token;
        }
        /// <summary>
        /// 对比两块令牌是否不同
        /// 不同指从管理器不能获得同一份信息
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator !=(MonitorToken<T> m1, MonitorToken<T> m2)
        {
            if (m1 is null || m2 is null)
            {
                return true;
            }
            return m1._token != m2._token;
        }
    }
}
