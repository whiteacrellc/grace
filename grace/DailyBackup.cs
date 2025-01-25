using System;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace grace
{
    public class DailyBackup
    {
        private System.Threading.Timer _timer;
        private readonly TimeSpan _interval = TimeSpan.FromHours(1);

        public DailyBackup(Action action)
        {
            _timer = new System.Threading.Timer(async _ => await ExecuteActionAsync(action), null, TimeSpan.Zero, _interval);
        }

        private async Task ExecuteActionAsync(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine($"Error executing action: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
