using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Altinn.ExternalUtilities.CorrBatchGenerator.Utils;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine
{
    /// <summary>
    /// Parses command-line arguments for console applications.
    /// </summary>
    /// <typeparam name="TArguments">
    /// The type that describes and represents the console's command-line arguments.
    /// </typeparam>
    /// <remarks>
    /// This parser uses reflection to map command-line arguments to properties on an object (of type TArguments)
    /// that represents those same arguments. Provide a description by putting a DescriptionAttribute on the property,
    /// and optionally a default value with a DefaultValueAttribute. Default values should be provided IF AND ONLY IF the
    /// parameter is optional. (Think: It makes no sense to have a default if the argument is required, likewise no sense
    /// to not require an argument that has no default value.)
    /// The command-line arguments should be on the form (arguments_name) '=' (arguments_value).
    ///      e.g. "myApplication X=50 FromDate=2012-06-31 Transactional=true".
    /// Argument names are case-insensitive. (If you use a TArguments type with property names
    /// that differ only in casing, e.g. "InputDirectory" and "InputDirectory", you'll get an exception
    /// on run-time, as this is bad practice and there is no reason to allow it.
    /// Supported argument types:
    ///  - Any type that can be handled by Convert.ChangeType(string, Type).
    ///     - this includes all primitives (integer, double, boolean, decimal, DateTime, ...)
    ///  - Enumerations.
    ///     - please use rather than generic types like string whenever legal values
    ///       can be easily enumerated.
    /// Example:
    ///     c:\&gt;helloWorld verbose=true x=false greeting="What a wonderful day!"
    ///     would map to (regardless of class name; only properties are taken into account)
    ///     class HelloWorldParameters : ConsoleArguments
    ///     {
    ///         [Description("Whether to output verbose information to the console, or only minimal information.")]
    ///         [DefaultValue(false)]
    ///         public boolean Verbose { get; set; }        // true
    ///         [Description("Whether to X.")]
    ///         public boolean X { get; set; }              // false
    ///         [Description("Greeting text to put on card.")]
    ///         [DefaultValue("Happy birthday!")]
    ///         public string Greeting { get; set; }     // "What a wonderful day!"
    ///     }
    /// Note that the above type has one required parameter, X (has no default value), and two optional parameters
    /// (that do have a default value). Also note the description does not say whether or not a parameter is optional,
    /// as it is the ConsoleBase class that is responsible for presentation.
    /// </remarks>
    internal class ArgumentParser<TArguments>
        where TArguments : ConsoleArguments, new()
    {
        /// <summary>
        /// Parses command line arguments and returns a metadata object bundling the argument object with
        /// error messages.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments.
        /// </param>
        /// <returns>
        /// An ArgumentInfo(TArguments) instance representing the parsed arguments.
        /// </returns>
        public static ArgumentInfo<TArguments> Parse(string[] args)
        {
            ArgumentInfo<TArguments> result = new ArgumentInfo<TArguments>();

            AssignCommandLineParameters(args, result);
            AssignDefaults(result);

            foreach (PropertyInfo p in result.UnassignedProperties)
            {
                result.ErrorMessages.Add($"The parameter '{p.Name}' is undefined.");
            }

            return result;
        }

        /// <summary>
        /// Updates the given ArgumentInfo, populates the argument object properties with values from
        /// command-line arguments, removes properties that are assigned from the "unassigned" list,
        /// and adds errors/warnings.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments.
        /// </param>
        /// <param name="result">
        /// The object representing the result of parsing command-line arguments (and applying default
        /// values, though this method does not do that).
        /// </param>
        private static void AssignCommandLineParameters(string[] args, ArgumentInfo<TArguments> result)
        {
            foreach (KeyValuePair<string, string> pair in SplitNameValuePairs(args))
            {
                PropertyInfo p = GetProperty(result.UnassignedProperties, pair.Key);
                if (p != null)
                {
                    object argValue;
                    if (TryInterpretArgumentValue(p.PropertyType, pair.Value, out argValue))
                    {                       
                        p.SetValue(result.Arguments, argValue, null);
                        result.UnassignedProperties.Remove(p);
                    }
                    else
                    {
                        result.ErrorMessages.Add(
                            $"Argument '{pair.Key}': '{pair.Value}' is not a valid value (argument type is '{p.PropertyType.Name}').");
                    }
                }
                else
                {
                    result.ErrorMessages.Add($"'{pair.Key}' is not recognized as a valid argument.");
                }
            }
        }

        /// <summary>
        /// Assigns unassigned properties their default values, if specified, and removes those
        /// properties from the UnassignedProperties list).
        /// </summary>
        /// <param name="result">
        /// The object representing the result of parsing command-line parameters.
        /// </param>
        private static void AssignDefaults(ArgumentInfo<TArguments> result)
        {
            for (int i = 0; i < result.UnassignedProperties.Count; i++)
            {
                PropertyInfo property = result.UnassignedProperties[i];
                object defaultValue;
                if (!ReflectionUtil.TryGetDefaultValue(property, out defaultValue))
                {
                    continue;
                }

                try
                {
                    result.Arguments.ApplyDefaultValue(property.Name);
                    result.UnassignedProperties.RemoveAt(i--);

                    // Removing an item => post-decrement index, making "next" the item at the *same* index.
                }
                catch (ApplicationException ex)
                {
                    result.ErrorMessages.Add(ex.Message);
                }
            }
        }

        /// <summary>
        /// Gets the property corresponding to the given argument name, or null if it does not exist.
        /// </summary>
        /// <param name="properties">
        /// List of properties
        /// </param>
        /// <param name="argName">
        /// Argument name
        /// </param>
        /// <returns>
        /// Property Information
        /// </returns>
        private static PropertyInfo GetProperty(List<PropertyInfo> properties, string argName)
        {
            // Case-sensitive mapping if and only if ignoring case leads to ambiguity.
            List<PropertyInfo> matches = properties.FindAll(p => p.Name.Equals(argName, StringComparison.CurrentCultureIgnoreCase));

            if (matches.Count == 1)
            {
                return matches[0];
            }

            if (matches.Count == 0)
            {
                return null;
            }

            // Ambigoius; return the property that exactly matches argument name (there can only be 1 by the laws of C#/CLS).
            return matches.Find(p => p.Name == argName);
        }

        /// <summary>
        /// Gets a dictionary of argument name, argument value (string representation) from
        /// the command line arguments array.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments.
        /// </param>
        /// <returns>
        /// A dictionary of argumentName-argumentValue pairs.
        /// </returns>
        private static Dictionary<string, string> SplitNameValuePairs(string[] args)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string arg in args)
            {
                int idx = arg.IndexOf('=');
                if (idx > 0)
                {
                    result.Add(arg.Substring(0, idx), arg.Substring(idx + 1));
                }
                else
                {
                    result.Add(arg, null);
                }
            }

            return result;
        }

        /// <summary>
        /// Interprets the given string representation of an argument value as the indicated type.
        /// </summary>
        /// <param name="type">
        /// Type to interpret argument as.
        /// </param>
        /// <param name="s">
        /// String representation of argument value.
        /// </param>
        /// <param name="argValue">
        /// Output; the interpretation of the string value.
        /// </param>
        /// <returns>
        /// Whether or not the string value was successfully interpreted.
        /// </returns>
        private static bool TryInterpretArgumentValue(Type type, string s, out object argValue)
        {
            if (s == null)
            {
                argValue = null;
                return false;
            }

            if (type.IsArray)
            {
                string[] parts = s.Split(',');
                Type t = type.GetElementType();
                Array array = Array.CreateInstance(t, parts.Length);
                int a = 0;
                foreach (string part in parts)
                {
                    object tempObject;
                    if (TryInterpretArgumentValue(type.GetElementType(), part, out tempObject))
                    {
                        array.SetValue(tempObject, a);
                        a++;
                    }
                    else
                    {
                        argValue = null;
                        return false;
                    }
                }

                argValue = array;
                return true;
            }

            if (type.IsGenericType)
            {
                Type[] types = type.GetGenericArguments();
                if (types.Length > 1)
                {
                    argValue = null;
                    return false;
                }

                if (s.Length == 0)
                {
                    argValue = null;
                    return true;
                }

                Type sfs = GetEnumerableType(type);
                if (sfs != null)
                {
                    string[] parts = s.Split(',');
                    IList list = (IList)Activator.CreateInstance(type);
                    foreach (string part in parts)
                    {
                        object tempObject;
                        if (TryInterpretArgumentValue(sfs, part, out tempObject))
                        {
                            list.Add(tempObject);
                        }
                        else
                        {
                            argValue = null;
                            return false;
                        }
                    }

                    argValue = list;
                    return true;
                }

                return TryInterpretArgumentValue(types[0], s, out argValue);
            }

            if (type.IsSubclassOf(typeof(Enum)))
            {
                Array enumValues = Enum.GetValues(type);
                for (int i = 0; i < enumValues.Length; i++)
                {
                    string v = enumValues.GetValue(i).ToString();
                    if (s.Equals(v, StringComparison.CurrentCultureIgnoreCase))
                    {
                        argValue = enumValues.GetValue(i); // v;
                        return true;
                    }
                }

                argValue = null;
                return false;
            }

            try
            {
                argValue = Convert.ChangeType(s, type);
                return true;
            }
            catch
            {
                argValue = null;
                return false;
            }
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