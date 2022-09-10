public class Broker
{
	public void SendMessage(IMessageCommand command)
	{
		command.DoAction();
	}
}
