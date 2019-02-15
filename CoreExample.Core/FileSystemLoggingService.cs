using System;

namespace CoreExample.Core
{
    public class FileSystemLoggingService : ILoggingService
    {
        private static int? _id;

        public FileSystemLoggingService()
        {
            if (!_id.HasValue)
            {
                _id = 1;
            }
            else
            {
                _id += 1;
            }
        }

        public void Write(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException(message);
            }
            //System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:O}]{message} - (ID: {_id})");
            System.Diagnostics.Debug.WriteLine($"{message} - (ID: {_id})");
        }
    }
}