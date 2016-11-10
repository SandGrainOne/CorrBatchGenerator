using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

using Altinn.ExternalUtilities.CorrBatchGenerator.Utils;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine
{
    /// <summary>
    /// Base class for console arguments.
    /// </summary>
    public class ConsoleArguments
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not to enable debugging. When enabled, the console will halt and wait for a debugger to attach to the process
        /// before continuing execution.
        /// </summary>
        [DefaultValue(false)]
        [Description("Whether to enable debugging.")]
        public bool Debug { get; set; }

        /// <summary>
        /// Applies default value to the argument
        /// </summary>
        /// <param name="argumentName">
        /// Argument name
        /// </param>
        /// <exception cref="ApplicationException">
        /// Throws ApplicationException if property is null
        /// </exception>
        public virtual void ApplyDefaultValue(string argumentName)
        {
            PropertyInfo property = this.GetType().GetProperty(argumentName);
            if (property == null)
            {
                throw new ApplicationException($"Internal error: '{argumentName}' is not a valid argument.");
            }

            object defaultValue;
            if (!ReflectionUtil.TryGetDefaultValue(property, out defaultValue))
            {
                throw new ApplicationException($"Internal error: '{argumentName}' has no default value.");
            }
            else
            {
                try
                {
                    property.SetValue(this, defaultValue, null);
                }
                catch (Exception ex)
                {
                    const string Pattern = "Internal error: Failed applying default value '{0}' to argument {1}.\r\nMessage = {2}";
                    throw new ApplicationException(string.Format(Pattern, defaultValue, property.Name, ex.Message));
                }
            }
        }

        /// <summary>
        /// Converts to string
        /// </summary>
        /// <returns>
        /// String details
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                if (property.PropertyType.IsArray)
                {
                    object[] values = (object[])property.GetValue(this, null);
                    sb.AppendFormat("{0}={1}\r\n", property.Name, values != null ? string.Join(",", values) : null);
                }
                else if (property.PropertyType.IsGenericType)
                {
                    Type sfs = GetEnumerableType(property.PropertyType);
                    if (sfs != null)
                    {
                        IEnumerable values = (IEnumerable)property.GetValue(this, null);
                        List<string> valuesList = new List<string>();
                        if (values != null)
                        {
                            foreach (object value in values)
                            {
                                valuesList.Add(value.ToString());
                            }
                        }

                        sb.AppendFormat("{0}={1}\r\n", property.Name, values != null ? string.Join(",", valuesList.ToArray()) : null);
                    }
                    else
                    {
                        sb.AppendFormat("{0}={1}\r\n", property.Name, property.GetValue(this, null));
                    }
                }
                else
                {
                    sb.AppendFormat("{0}={1}\r\n", property.Name, property.GetValue(this, null));
                }
            }

            return sb.ToString();
        }

        private static Type GetEnumerableType(Type type)
        {
            foreach (Type intType in type.GetInterfaces())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return intType.GetGenericArguments()[0];
                }
            }

            return null;
        }
    }
}