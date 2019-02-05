/*
 * TODO: Extension Methods
Extension methods are special static methods. They inject addition methods without changing, deriving, or
recompiling the original type. They are always called as if they were instance method.
1) Extension methods are always defined inside static class.
2) The first parameter of extension method must have “this” operator, which tells on
whose instance this extension method should give access.
3) The extension method should be defined in the same namespace in which it is used,
or import the namespace in which the extension method was defined and the method must be static
 */

namespace System //1.Defined method in the same namespace of string
{
    public static class StringExtensions
    {
        /*
         * 2.use a static method
         * 3. this + type/class want extended
         * In this case we want extend string
         */
        public static bool IsMichiOrEmpty(this string origin) 
        {
            return string.IsNullOrEmpty(origin) || origin.ToLower() == "michi";
        }
    }
}
