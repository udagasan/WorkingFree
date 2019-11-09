using System;
using System.Collections.Generic;

namespace Process
{
    /// <summary>
    /// FindSubString  
    /// </summary>
    public class FindSubString
    {
        /// <summary>
        /// Finds the specified s1.
        /// </summary>
        /// <param name="s1">The s1.</param>
        /// <param name="s2">The s2.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// s2
        /// or
        /// s1
        /// </exception>
        public static int Find(string s1, string s2)
        {
            string source = string.Empty;
            string value = string.Empty;

            if (String.IsNullOrWhiteSpace(s2))
                throw new ArgumentNullException(nameof(s2));
            if (String.IsNullOrWhiteSpace(s1))
                throw new ArgumentNullException(nameof(s1));
            s1 = s1.ToUpper();
            s2 = s2.ToUpper();


            source = s1.Length >= s2.Length ? s1 : s2;
            value = s1.Equals(source) ? s2 : s1;

            var indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = source.IndexOf(value, index);
                if (index == -1)
                {
                    return indexes.Count;
                }
                indexes.Add(index);
            }
        }
    }
}
