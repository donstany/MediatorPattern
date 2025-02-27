﻿//
// Concrete Commands
//
public class EmailMessageCommand : IMessageCommand
{
	private readonly Message _message;

	public EmailMessageCommand(Message message)
	{
		_message = message;
	}

	public void Send()
	{
		_message.EmailMessage();
	}
}
