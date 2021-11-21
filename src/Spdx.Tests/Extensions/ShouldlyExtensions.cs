namespace Spdx.Tests.Extensions
{
    public static class ShouldlyExtensions
    {
        public static void And<T>(this T obj, Action<T> action)
        {
            action(obj);
        }
    }
}
