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

                while (true)
                {
                    LoginForm loginForm = new LoginForm();
                    DialogResult loginResult = loginForm.ShowDialog();

                    if (loginResult == DialogResult.OK)
                    {
                        // User logged in successfully. Globals.GetInstance().CurrentUser should be set by LoginForm.
                        Application.Run(new Vivian()); // This blocks until Vivian form is closed.

                        // After Vivian form is closed, check if it was due to logout
                        if (Globals.GetInstance().CurrentUser == null)
                        {
                            // User logged out, continue the loop to show login form again
                            continue;
                        }
                        else
                        {
                            // Vivian form closed for another reason (e.g., Exit menu)
                            break; // Exit the loop and the application
                        }
                    }
                    else
                    {
                        // LoginForm was closed or login failed (not DialogResult.OK)
                        break; // Exit the loop and the application
                    }
                }

                // Release the mutex when the application exits
                mutex.ReleaseMutex();
            }
            else
            {
                // Another instance is running, exit
                // Mutex is not acquired, so no need to release it here.
                return;
            }
        }
    }
}
