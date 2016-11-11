using System;
using System.ComponentModel;
using System.Reflection;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.Utils
{
    /// <summary>
    /// Utility class facilitating use of reflection.
    /// </summary>
    public static class ReflectionUtil
    {
        /// <summary>
        /// Gets the property description from the Description attribute associated with the property,
        /// or null if the property has no description.
        /// </summary>
        /// <param name="p">
        /// Property to get description for.
        /// </param>
        /// <returns>
        /// The property description.
        /// </returns>
        public static string GetDescription(PropertyInfo p)
        {
            DescriptionAttribute a = GetFirstAttribute<DescriptionAttribute>(p, true);
            return a?.Description;
        }

        /// <summary>
        /// Gets the first attribute of the given type, if available, from the given object, or null otherwise.
        /// </summary>
        /// <typeparam name="T">
        /// Attribute type to get.
        /// </typeparam>
        /// <param name="obj">
        /// MemberInfo or enumeration-value to search for attributes.
        /// </param>
        /// <param name="inherit">
        /// Whether to inherit attribute from base types (MemberInfo only).
        /// </param>
        /// <returns>
        /// The first attribute of the given type, or null if the attribute does not exist.
        /// </returns>
        public static T GetFirstAttribute<T>(object obj, bool inherit) where T : Attribute
        {
            MemberInfo memberInfo = obj as MemberInfo;
            object[] attributes;

            if (memberInfo != null)
            {
                attributes = memberInfo.GetCustomAttributes(typeof(T), inherit);
            }
            else
            {
                Type type = obj.GetType();

                if (type.IsEnum)
                {
                    return GetFirstAttribute<T>(type.GetMember(obj.ToString())[0], inherit);
                }

                attributes = type.GetCustomAttributes(typeof(T), inherit);
            }

            return (T)(attributes.Length > 0 ? attributes[0] : null);
        }

        /// <summary>
        /// Gets the default value for the given property from the DefaultValue attribute associated with the property.
        /// </summary>
        /// <param name="p">
        /// Property to get default value for.
        /// </param>
        /// <param name="value">
        /// Output; the default value for the given property.
        /// </param>
        /// <returns>
        /// Whether or not the property has a default value.
        /// </returns>
        public static bool TryGetDefaultValue(PropertyInfo p, out object value)
        {
            DefaultValueAttribute a = GetFirstAttribute<DefaultValueAttribute>(p, true);
            if (a != null)
            {
                value = a.Value;
                return true;
            }

            value = null;
            return false;
        }
    }
}