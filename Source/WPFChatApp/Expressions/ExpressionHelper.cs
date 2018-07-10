using System;
using System.Linq.Expressions;
using System.Reflection;

namespace WPFChatApp
{
    public static class ExpressionHelper
    {
        /// <summary>
        /// Compiles an Expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambda"></param>
        /// <returns>Runtime code</returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }
        /// <summary>
        /// Setter to the getter above ^^^
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambda"></param>

        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //LINQ type casting
            //Converts a lamba() => some.property to another.property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;
            //Get property Info 
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
