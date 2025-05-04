
using System;
using System.Collections.Generic;

class User
{
    public string Username { get; set; }
    public User(string username)
    {
        Username = username;
    }
}

class Message
{
    public string Sender { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }

    public Message(string sender, string content)
    {
        Sender = sender;
        Content = content;
        Timestamp = DateTime.Now;
    }
}

class ChatApp
{
    private List<Message> messages = new List<Message>();

    public void SendMessage(string sender, string content)
    {
        messages.Add(new Message(sender, content));
    }

    public void ShowMessages()
    {
        Console.Clear();
        Console.WriteLine("💬 Mesajlaşma Geçmişi:\n");
        foreach (var msg in messages)
        {
            Console.WriteLine($"[{msg.Timestamp:HH:mm}] {msg.Sender}: {msg.Content}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("1. Kullanıcı adı: ");
        var user1 = new User(Console.ReadLine());

        Console.Write("2. Kullanıcı adı: ");
        var user2 = new User(Console.ReadLine());

        var chat = new ChatApp();
        bool devam = true;

        while (devam)
        {
            chat.ShowMessages();

            Console.Write($"{user1.Username}: ");
            string msg1 = Console.ReadLine();
            if (msg1.ToLower() == "çıkış") break;
            chat.SendMessage(user1.Username, msg1);

            chat.ShowMessages();

            Console.Write($"{user2.Username}: ");
            string msg2 = Console.ReadLine();
            if (msg2.ToLower() == "çıkış") break;
            chat.SendMessage(user2.Username, msg2);
        }

        Console.WriteLine("Sohbet sona erdi. 👋");
    }
}
