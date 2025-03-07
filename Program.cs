using System.Runtime.CompilerServices;

namespace slidegrid
{
    internal static class Program
    {
        internal static string[] args;

        [STAThread]
        static void Main(string[] args)
        {
            Program.args = args;
            ApplicationConfiguration.Initialize();
            var form = new MainForm();
            Application.Run(form);
        }
    }
}