using System;

namespace Zatomic.AI.Providers.Exceptions
{
    public class AIException : Exception
    {
		public string Model { get; set; }
		public string Provider { get; set; }
		public string Request { get; set; }
		public string Response { get; set; }

		public AIException(string message) : base(message)
		{
		}
	}
}
