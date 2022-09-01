using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // Defensive Coding : If you do not compare whether the given type is IValidator or not, 
            // the program still works but there is a strict rule which the given type has to be IValidator.
            // If it is not, the program gives error on the running time. To avoid from the running time
            // error, we use defensive coding.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("It is not an validation class!");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
