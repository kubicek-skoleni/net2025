namespace BlazorApp.Services
{
    /// <summary>
    /// Jednoduchý logger do souboru
    /// </summary>
    public  class SimpleLogger
    {
        private object _lock = new object();
        public void Log(string message) 
        {
            lock(_lock)
            {
                Console.WriteLine(message);

                var date = DateTime.Now.ToString("yyyy-MM-dd");
                var file = $"{date}.txt";

                var line = $"{DateTime.Now} {message} {Environment.NewLine}";
                File.AppendAllTextAsync(file, line);
                
            }
        }
    }
}
