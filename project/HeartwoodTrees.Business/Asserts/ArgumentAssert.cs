// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentAssert.cs" company="Eyedentify Limited">
//   Copyright © eyedentify.co.nz. All rights reserved.
// </copyright>
// <summary>
//   The argument assert.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Asserts
{
    using System;
    using System.Collections;

    /// <summary>
    /// The argument assert.
    /// </summary>
    public static class ArgumentAssert
    {
        /// <summary>
        /// Assert an argument is not null.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentPath">Name of the argument or argument path.</param>
        /// <example>ArgumentAssert.IsNotNull(customerName, "customerName")</example>
        ///   <example>ArgumentAssert.IsNotNull(customer.Name, "customer.Name")</example>
        /// <exception cref="System.ArgumentNullException">The argument is null </exception>
        [System.Diagnostics.DebuggerHidden]
        public static void IsNotNull<T>(T argument, string argumentPath)
        {
            if (argument == null)
            {
                if (string.IsNullOrWhiteSpace(argumentPath))
                {
                    throw new ArgumentNullException("argument", "The argument is null");
                }

                throw new ArgumentNullException(argumentPath, "The argument is null");
            }
        }

        /// <summary>
        /// Assert string argument is not null or empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentPath">Name of the argument or argument path</param>
        /// <example>ArgumentAssert.IsNotNullOrEmpty(customerOrders, "customerOrders")</example>
        [System.Diagnostics.DebuggerHidden]
        public static void IsNotNullOrEmpty(string argument, string argumentPath)
        {
            IsNotNull(argument, argumentPath);

            if (string.IsNullOrWhiteSpace(argument))
            {
                if (string.IsNullOrWhiteSpace(argumentPath))
                {
                    throw new ArgumentException("The string argument is empty.");
                }

                throw new ArgumentException(string.Format("The string argument {0} is empty.", argumentPath));
            }
        }

        /// <summary>
        /// The is not null or empty.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="argumentPath">
        /// The argument path.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        [System.Diagnostics.DebuggerHidden]
        public static void IsNotNullOrEmpty(Guid argument, string argumentPath)
        {
            if (argument.Equals(Guid.Empty))
            {
                if (string.IsNullOrWhiteSpace(argumentPath))
                {
                    throw new ArgumentException("The string argument is empty.");
                }

                throw new ArgumentException(string.Format("The string argument {0} is empty.", argumentPath));
            }
        }

        /// <summary>
        /// Assert an enumerable argument is not null or empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentPath">Name of the argument or argument path</param>
        /// <example>ArgumentAssert.IsNotNull(customerOrders, "customerOrders")</example>
        /// <example>ArgumentAssert.IsNotNull(customer.Orders, "customer.Orders")</example>
        [System.Diagnostics.DebuggerHidden]
        public static void IsNotNullOrEmpty(IEnumerable argument, string argumentPath)
        {
            IsNotNull(argument, argumentPath);

            if (argument.GetEnumerator().MoveNext() == false)
            {
                if (string.IsNullOrWhiteSpace(argumentPath))
                {
                    throw new ArgumentException("The enumerable argument is empty.");
                }

                throw new ArgumentException(string.Format("The enumerable argument {0} is empty.", argumentPath));
            }
        }

        /// <summary>
        /// Determines whether an argument is inside a specified range
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="firstValue">The first value in the range.</param>
        /// <param name="lastValue">The last value in the range.</param>
        /// <param name="argumentPath">The name of the argument or the argument path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsInRange(int argument, int firstValue, int lastValue, string argumentPath)
        {
            if (argument < firstValue || argument > lastValue)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be between {0} and {1}", firstValue, lastValue));
            }
        }

        /// <summary>
        /// Determines whether an argument is inside a specified range
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="firstValue">The first value in the range.</param>
        /// <param name="lastValue">The last value in the range.</param>
        /// <param name="argumentPath">The name of the argument or the argument path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsInRange(long argument, long firstValue, long lastValue, string argumentPath)
        {
            if (argument < firstValue || argument > lastValue)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be between {0} and {1}", firstValue, lastValue));
            }
        }

        /// <summary>
        /// Determines whether an argument is inside a specified range
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="firstValue">The first value in the range.</param>
        /// <param name="lastValue">The last value in the range.</param>
        /// <param name="argumentPath">The name of the argument or the argument path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsInRange(decimal argument, decimal firstValue, decimal lastValue, string argumentPath)
        {
            if (argument < firstValue || argument > lastValue)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be between {0} and {1}", firstValue, lastValue));
            }
        }

        /// <summary>
        /// Determines whether an argument is inside a specified range
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="firstValue">The first value in the range.</param>
        /// <param name="lastValue">The last value in the range.</param>
        /// <param name="argumentPath">The name of the argument or the argument path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsInRange(float argument, float firstValue, float lastValue, string argumentPath)
        {
            if (argument < firstValue || argument > lastValue)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be between {0} and {1}", firstValue, lastValue));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater than.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThan(int argument, int value, string argumentPath)
        {
            if (argument <= value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater than.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThan(decimal argument, decimal value, string argumentPath)
        {
            if (argument <= value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater than.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThan(float argument, float value, string argumentPath)
        {
            if (argument <= value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater than.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThan(long argument, long value, string argumentPath)
        {
            if (argument <= value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThanOrEqualsTo(int argument, int value, string argumentPath)
        {
            if (argument < value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThanOrEqualsTo(long argument, long value, string argumentPath)
        {
            if (argument < value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThanOrEqualsTo(DateTime argument, DateTime value, string argumentPath)
        {
            if (argument < value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThanOrEqualsTo(decimal argument, decimal value, string argumentPath)
        {
            if (argument < value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is greater than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be greater or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsGreaterThanOrEqualsTo(float argument, float value, string argumentPath)
        {
            if (argument < value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be greater than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is less than the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be Less than.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsLessThan(int argument, int value, string argumentPath)
        {
            if (argument >= value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be less than {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is less than the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be Less than.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsLessThan(decimal argument, decimal value, string argumentPath)
        {
            if (argument >= value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be less than {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is less than the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be Less than.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsLessThan(float argument, float value, string argumentPath)
        {
            if (argument >= value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be less than {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is less than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be Less or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsLessThanOrEqualsTo(int argument, int value, string argumentPath)
        {
            if (argument > value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be less than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is less than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be Less or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsLessThanOrEqualsTo(DateTime argument, DateTime value, string argumentPath)
        {
            if (argument > value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be less than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is less than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be Less or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsLessThanOrEqualsTo(decimal argument, decimal value, string argumentPath)
        {
            if (argument > value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be less than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Determines whether the argument is less than or equal the specified value
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="value">The value which the argument must be Less or equal.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsLessThanOrEqualsTo(float argument, float value, string argumentPath)
        {
            if (argument > value)
            {
                throw new ArgumentOutOfRangeException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("Argument must be less than or equals to {0}", value));
            }
        }

        /// <summary>
        /// Asserts the <see cref="Guid"/> argument is not empty
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="argumentPath">The argument name or path.</param>
        [System.Diagnostics.DebuggerHidden]
        public static void IsNotEmpty(Guid argument, string argumentPath)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentException(
                    string.IsNullOrWhiteSpace(argumentPath) ? "[Not Set]" : argumentPath,
                    string.Format("The Guid argument {0} is empty", argument));
            }
        }
    }
}
