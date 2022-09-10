//
// Sender (Invoker)
//
public class Sender
{
	public void SendMessage(IMessageCommand command)
	{
		command.DoAction();
	}
}
