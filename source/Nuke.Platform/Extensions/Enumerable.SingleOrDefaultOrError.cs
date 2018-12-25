﻿// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Platform.Extensions
{
    public static partial class EnumerableExtensions
    {
        [CanBeNull]
        public static T SingleOrDefaultOrError<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, string message)
        {
            try
            {
                return enumerable.SingleOrDefault(predicate);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }

        [CanBeNull]
        public static T SingleOrDefaultOrError<T>(this IEnumerable<T> enumerable, string message)
        {
            try
            {
                return enumerable.SingleOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }
    }
}