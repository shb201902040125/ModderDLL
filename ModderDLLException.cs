using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace ModderDLL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModderDLLException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public ModderDLLException() : base()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ModderDLLException(string? message) : base(message)
        {

        }
        /// <summary>
        /// Nothing in Visual Basic) if no inner exception is specified.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ModderDLLException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ModderDLLException(SerializationInfo info, StreamingContext context)
        {

        }
    }
    /// <summary>
    /// 访问许可不足异常
    /// </summary>
    public class UnauthorizedException:ModderDLLException
    {
        /// <summary>
        /// 
        /// </summary>
        public UnauthorizedException():base("您没有使用权限")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "对方拒绝了您的访问或调用,因为您不具备访问该数据或调用该方法的权限。";
        }
    }
}
#nullable disable
