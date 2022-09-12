//
// Concrete Command
//
public class SmsMessageCommand : IMessageCommand
{
	private readonly Message _message;

	public SmsMessageCommand(Message message)
	{
		_message = message;
	}

	public void Send()
	{
		_message.SmsMessage();
	}
}
