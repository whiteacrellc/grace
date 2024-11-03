namespace grace
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, "UniqueApplicationMutexName");
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check if the mutex is already taken (another instance is running)
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Vivian());

                // Release the mutex when the application exits
                mutex.ReleaseMutex();

            }
            else
            {
                // Another instance is running, exit
                return;
            }
        }
    }
}
