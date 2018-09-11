namespace MiscHelper_ionic.Common
{
    public static class Extentions
    {
        public static T To<T>(this object o) => (T) o;
        public static T To<T>(this object o, out T x) => x = (T)o;
    }
}