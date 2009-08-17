
namespace CcdAddIn
{
    public static class CcdAddInDebug
    {
        [System.Diagnostics.Conditional("DEBUG")]
        public static void WriteLine(object o)
        {
            System.Diagnostics.Debug.WriteLine(o);
        }

    } // class

} // namespace