namespace Services
{
    internal static class StringService
    {
        /// <summary>
        /// This code is particularly hideous
        /// Doesn't even work
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Capitalize(string str)
        {
            if (str == null)
                return null;
            if (str.Length == 0)
                return str;
            return str[0] + str.Length <= 1 ? "" : str[1..];
        }
    }
}
