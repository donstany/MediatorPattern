//
// Main
//
Message message = new Message();
message.CustomMessage = "Welcome by Email";
EmailMessageCommand emailMessageCommand = new EmailMessageCommand(message);

Message message2 = new Message();
message2.CustomMessage = "Welcome by SMS";
SmsMessageCommand smsMessageCommand = new SmsMessageCommand(message2);

Sender sender = new Sender();
sender.SendMessage(emailMessageCommand);
sender.SendMessage(smsMessageCommand);
Console.ReadKey();
