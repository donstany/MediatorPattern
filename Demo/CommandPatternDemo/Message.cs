﻿//
// Message
//
public class Message
{
	public string CustomMessage { get; set; }

	public void EmailMessage()
	{
		Console.WriteLine($"{CustomMessage} : Email Message sent");
	}

	public void SmsMessage()
	{
		Console.WriteLine($"{CustomMessage} : Sms Message sent");
	}
}