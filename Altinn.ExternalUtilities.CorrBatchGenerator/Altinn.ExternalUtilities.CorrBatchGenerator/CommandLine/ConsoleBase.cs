using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

using Altinn.ExternalUtilities.CorrBatchGenerator.Utils;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.CommandLine
{
    /// <summary>
    /// Base class for console applications.
    /// Provides command-line argument handling, a default error-handler, and convenience methods.
    /// </summary>
    /// <typeparam name="TArguments">
    /// Type of arguments.
    /// </typeparam>
    public abstract class ConsoleBase<TArguments>
        where TArguments : ConsoleArguments, new()
    {
        /// <summary>
        /// Console write synchronized
        /// </summary>
        public readonly object ConsoleWriteSyncRoot = new object();

        /// <summary>
        /// Gets the LogCategory, so we can override in batch and log to specific batch
        /// </summary>
        public virtual string[] LogCategories
        {
            get
            {
                // StyleCop complains about one-liner.
                // ReSharper disable once ConvertPropertyToExpressionBody
                return new[] { "APPLICATION" };
            }
        }

        /// <summary>
        /// Gets the object representing console arguments. The property values on this object reflect parsed
        /// command-line arguments when provided, or default values (defined by decorating the argument type with
        /// DefaultValue attributes).
        /// </summary>
        protected TArguments Arguments { get; private set; }

        /// <summary>
        /// Runs the console application. Call this method from the entry point of the exe file
        /// (by default Program.Main(string[] args) in a console application project).
        /// </summary>
        /// <typeparam name="TConsole">
        /// The type of console class to instantiate and execute.
        /// </typeparam>
        /// <param name="args">
        /// Command-line arguments.
        /// </param>
        /// <param name="timeSpanWait">How long the program waits before terminating.</param>
        public static void Run<TConsole>(string[] args, int timeSpanWait = 30) where TConsole : ConsoleBase<TArguments>
        {
            RunInternal<TConsole>(args, timeSpanWait);
        }

        /// <summary>
        /// Used by test methods to assign arguments.
        /// </summary>
        /// <param name="arguments">Arguments to assign.</param>
        public void AssignArguments(TArguments arguments)
        {
            this.Arguments = arguments;
        }

        /// <summary>
        /// Maps the given arguments to properties on the given arguments object and returns
        /// the list of TArguments properties that have not been assigned a value from internalArgs.
        /// </summary>
        /// <param name="args">
        /// Arguments as string
        /// </param>
        /// <returns>
        /// Argument Information
        /// </returns>
        internal virtual ArgumentInfo<TArguments> ParseArguments(string[] args)
        {
            return ArgumentParser<TArguments>.Parse(args);
        }

        /// <summary>
        /// Empties the input buffer (so any key press done before calling AwaitKey don't count),
        /// then waits until either a key is pressed or the operation times out.
        /// </summary>
        /// <param name="timeout">
        /// Maximum time to wait for a key.
        /// </param>
        /// <returns>
        /// The key pressed, or null if the operation timed out.
        /// </returns>
        protected ConsoleKeyInfo? AwaitKey(TimeSpan timeout)
        {
            DateTime until = DateTime.Now.Add(timeout);
            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            while (DateTime.Now < until)
            {
                if (Console.KeyAvailable)
                {
                    return Console.ReadKey(true);
                }

                Thread.Sleep(128);
            }

            return null;
        }

        /// <summary>
        /// Executes the application logic of the console.
        /// </summary>
        protected abstract void Execute();

        /// <summary>
        /// Moves the cursor to the given position.
        /// </summary>
        /// <param name="left">
        /// Left position
        /// </param>
        /// <param name="top">
        /// Top position
        /// </param>
        protected void MoveCursor(int left, int top)
        {
            Console.CursorLeft = left;
            Console.CursorTop = top;
        }

        /// <summary>
        /// Validates the argument object semantically (see remarks).
        /// </summary>
        /// <param name="errorMessages">
        /// Error messages
        /// </param>
        /// <remarks>
        /// ConsoleBase parses arguments and checks that provided arguments are of the correct
        /// type, e.g. "5" will work as argument value for an argument of type integer, but "5.5" will
        /// not.
        /// A console may perform additional validation by overriding this method. For instance,
        /// say we have an argument DateTime ActivationDate, but the date cannot occur in the past.
        /// </remarks>
        protected virtual void OnArgumentsParsed(List<string> errorMessages)
        {
        }

        /// <summary>
        /// Presents the given list of error messages.
        /// </summary>
        /// <param name="errorMessages">
        /// List of errors.
        /// </param>
        protected virtual void PresentErrors(List<string> errorMessages)
        {
            if (errorMessages.Count <= 0)
            {
                return;
            }

            this.WriteLine(ConsoleColor.Red, "{0} {1}:", errorMessages.Count, errorMessages.Count > 1 ? "errors" : "error");
            foreach (string msg in errorMessages)
            {
                this.WriteLine(msg);
            }

            this.WriteLine();
        }

        /// <summary>
        /// Presents the given list of warning messages.
        /// </summary>
        /// <param name="warningMessages">
        /// List of warnings.
        /// </param>
        protected virtual void PresentWarnings(List<string> warningMessages)
        {
            if (warningMessages.Count <= 0)
            {
                return;
            }

            this.WriteLine(ConsoleColor.Yellow, "Warning");
            foreach (string msg in warningMessages)
            {
                this.WriteLine(msg);
            }

            this.WriteLine();
        }

        /// <summary>
        /// Convenience method for writing to the console using a specific color.
        /// </summary>
        /// <param name="c">
        /// Text color.
        /// </param>
        /// <param name="s">
        /// String to write (may contain placeholders for string.Format).
        /// </param>
        /// <param name="args">
        /// 0 or more arguments to format the given string with.
        /// </param>
        /// <returns>
        /// The formatted string.
        /// </returns>
        protected string Write(ConsoleColor c, string s, params object[] args)
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = c;
            try
            {
                return this.Write(s, args);
            }
            finally
            {
                Console.ForegroundColor = temp;
            }
        }

        /// <summary>
        /// Convenience method for writing to the console.
        /// </summary>
        /// <param name="s">
        /// String to write (may contain placeholders for string.Format).
        /// </param>
        /// <param name="args">
        /// 0 or more arguments to format the given string with.
        /// </param>
        /// <returns>
        /// The formatted string.
        /// </returns>
        protected string Write(string s, params object[] args)
        {
            if (args.Length > 0)
            {
                s = string.Format(s, args);
            }

            lock (this.ConsoleWriteSyncRoot)
            {
                Console.Write(s);
            }

            return s;
        }

        /// <summary>
        /// Writes the legal values for a parameter that is of an enumerated type.
        /// </summary>
        /// <param name="enumType">
        /// Enumeration type
        /// </param>
        protected virtual void WriteLegalValues(Type enumType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  Legal values:  ");
            int w = Console.WindowWidth;
            int strW = sb.Length;

            foreach (object member in Enum.GetValues(enumType))
            {
                string str = member.ToString();
                if (strW + str.Length + 3 < w)
                {
                    sb.Append(str).Append(" | ");
                    strW += str.Length + 3;
                }
                else
                {
                    sb.Append("\r\n    ").Append(str).Append(" | ");
                    strW += str.Length + 7;
                }
            }

            sb.Length -= 3;
            this.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Writes line
        /// </summary>
        /// <param name="c">
        /// Console color
        /// </param>
        /// <param name="s">
        /// Data as string
        /// </param>
        /// <param name="args">
        /// Argument list
        /// </param>
        /// <returns>
        /// Statement as string
        /// </returns>
        protected string WriteLine(ConsoleColor c, string s, params object[] args)
        {
            return this.Write(c, s + "\r\n", args);
        }

        /// <summary>
        /// Equivalent to Console.WriteLine.
        /// </summary>
        protected void WriteLine()
        {
            this.Write("\r\n");
        }

        /// <summary>
        /// Writes line
        /// </summary>
        /// <param name="s">
        /// Data as string
        /// </param>
        /// <param name="args">
        /// Argument list
        /// </param>
        /// <returns>
        /// Statement as string
        /// </returns>
        protected string WriteLine(string s, params object[] args)
        {
            return this.Write(s + "\r\n", args);
        }

        /// <summary>
        /// Writes a progress bar at the given position.
        /// </summary>
        /// <param name="left">
        /// Console CursorLeft
        /// </param>
        /// <param name="top">
        /// Console CursorTop
        /// </param>
        /// <param name="width">
        /// Width of progress bar (excluding percentage text).
        /// </param>
        /// <param name="progress">
        /// Progress (0.0 to 1.0).
        /// </param>
        protected void WriteProgressBar(int left, int top, int width, double progress)
        {
            this.WriteProgressBar(left, top, width, progress, '░', '█');
        }

        /// <summary>
        /// Writes a progress bar at the given position.
        /// </summary>
        /// <param name="left">
        /// Console CursorLeft
        /// </param>
        /// <param name="top">
        /// Console CursorTop
        /// </param>
        /// <param name="width">
        /// Width of progress bar (excluding percentage text).
        /// </param>
        /// <param name="progress">
        /// Progress (0.0 to 1.0).
        /// </param>
        /// <param name="remainingChar">
        /// Character representing remaining work.
        /// </param>
        /// <param name="completedChar">
        /// Character representing completed work.
        /// </param>
        protected void WriteProgressBar(int left, int top, int width, double progress, char remainingChar, char completedChar)
        {
            int x = Console.CursorLeft, y = Console.CursorTop;
            try
            {
                this.MoveCursor(left, top);
                this.WriteLine(string.Empty.PadLeft((int)Math.Floor(progress * width), completedChar).PadRight(width, remainingChar) + " {0:p}", progress);
            }
            finally
            {
                this.MoveCursor(x, y);
            }
        }

        /// <summary>
        /// Writes the usage screen to the console.
        /// </summary>
        protected virtual void WriteUsage()
        {
            this.WriteLine(ConsoleColor.White, "---- {0} usage:", this.GetType().Name);
            this.WriteLine();

            foreach (PropertyInfo p in typeof(TArguments).GetProperties())
            {
                object defaultValue;
                bool hasDefault = ReflectionUtil.TryGetDefaultValue(p, out defaultValue);
                ConsoleColor color = hasDefault ? ConsoleColor.Green : ConsoleColor.Yellow;
                this.WriteLine(color, "{0} ({1}, {2})", p.Name, p.PropertyType.Name, hasDefault ? "optional" : "required");
                this.WriteLine("  {0}", ReflectionUtil.GetDescription(p));
                if (hasDefault)
                {
                    this.WriteLine("  default value: {0}", defaultValue);
                }

                if (p.PropertyType.IsEnum)
                {
                    this.WriteLegalValues(p.PropertyType);
                }

                this.WriteLine();
            }
        }

        private static void RunInternal<TConsole>(string[] args, int waitTimeSpan = 30) where TConsole : ConsoleBase<TArguments>
        {
            ConsoleBase<TArguments> consoleBase = (ConsoleBase<TArguments>)Activator.CreateInstance(typeof(TConsole));
            try
            {
                if (consoleBase.Initialize(args))
                {
                    consoleBase.Execute();
                }
                else
                {
                    consoleBase.WriteUsage();
                }
            }
            catch (Exception ex)
            {
                consoleBase.WriteLine(ConsoleColor.Red, "Exception caught:\r\n");
                consoleBase.WriteLine(ex.Message);
                if (consoleBase.Arguments != null)
                {
                    if (consoleBase.Arguments.Debug)
                    {
                        consoleBase.WriteLine("\r\n{0}", ex);
                    }
                }
                else
                {
                    StringBuilder suppliedArguments = new StringBuilder();
                    foreach (string arg in args)
                    {
                        suppliedArguments.Append(arg + " ");
                    }
                }
            }
            finally
            {
                consoleBase.WriteLine("\r\nPress any key to exit..");
                consoleBase.AwaitKey(TimeSpan.FromSeconds(waitTimeSpan));
            }
        }

        private void AwaitDebugger()
        {
            Process proc = Process.GetCurrentProcess();
            this.WriteLine(ConsoleColor.White, "Awaiting debugger - please attach to process {0}.\r\n", proc.Id);

            // Empty input buffer (to ignore keypresses made before this method was invoked).
            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            string[] signsOfLife = new[] { "Attach", "your", "debugger" };

            int x = Console.CursorLeft, y = Console.CursorTop;
            int i = 0;

            while (!Debugger.IsAttached)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.WriteLine($"  {signsOfLife[++i%signsOfLife.Length].PadRight(8, '.')} [Alt-X] Kill process");

                Thread.Sleep(250);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Modifiers == ConsoleModifiers.Alt && key.Key == ConsoleKey.X)
                    {
                        proc.Kill();
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the console, and returns whether the application logic should execute. Initialization consists of:
        ///  - Parsing command-line arguments
        ///  - Applying default values
        ///  - Validating arguments (if the console implements it)
        ///  - Presenting errors and warnings
        /// </summary>
        /// <param name="args">
        /// Command-line arguments.
        /// </param>
        /// <returns>
        /// Whether application logic should execute (i.e. arguments are ok).
        /// </returns>
        private bool Initialize(string[] args)
        {
            ArgumentInfo<TArguments> result = this.ParseArguments(args);
            this.Arguments = result.Arguments;
            this.OnArgumentsParsed(result.ErrorMessages);

            this.SetDefaultBehaviors(result);
            this.PresentErrors(result.ErrorMessages);
            this.PresentWarnings(result.WarningMessages);

            return result.ErrorMessages.Count == 0;
        }

        private void SetDefaultBehaviors(ArgumentInfo<TArguments> result)
        {
            if (result.Arguments == null)
            {
                return;
            }

            if (!result.Arguments.Debug || Debugger.IsAttached)
            {
                return;
            }

            this.AwaitDebugger();
            Debugger.Break();
        }
    }
}