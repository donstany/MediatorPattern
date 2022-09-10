// See https://aka.ms/new-console-template for more information




public class SmsMessageCommand : IMessageCommand
{
	private Message oMessage;

	public SmsMessageCommand(Message oMessage)
	{
		this.oMessage = oMessage;
	}
	public void DoAction()
	{

		oMessage.SmsMessage();
	}
}
