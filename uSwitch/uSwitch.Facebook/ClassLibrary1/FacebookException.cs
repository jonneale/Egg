using System;

public class FacebookException : Exception
{
	public FacebookException(string message) : base(message)
	{
		
	}

	public FacebookException(string message, Exception inner)
		: base(message, inner)
	{

	}

	public FacebookException(Exception inner)
		: base("unhandled facebook exception", inner)
	{

	}
}