// This class is the base class of the interception structure which we will create.
// CrossCuttingConcerns are used as attributes like [ValidationAspect].

using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    // This attribute class is used for classes and methods.

    // This attribute class can be used for multiple times. For example; if we want to log to database and also to
    // file, we will need to use them for multiple times.

    // This attribute can be run at the inherited points.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
