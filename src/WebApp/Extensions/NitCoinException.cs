using System;

namespace ScoreClass.Web.Extensions
{
	[Serializable]
	public class NitCoinException : Exception
	{
		public NitCoinException() { }
		public NitCoinException(string message) : base(message) { }
		public NitCoinException(string message, Exception inner) : base(message, inner) { }
		protected NitCoinException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}