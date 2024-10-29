// <copyright file="StringExeptions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Exeptions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);

        public static string? TrimOrNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty()
                 ? null
                 : trimmed;

        }
    }
}
