using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotSharp;
using TelegramBotSharp.Types;

namespace ConsoleApplication3
{
    class Program
    {
        public static TelegramBot bot;
        static void Main(string[] args)
        {

            



            Console.WriteLine("Bot Starting");
                bot = new TelegramBot("Your code from @botfather here!");
                Console.WriteLine("Bot Started !");
                Console.WriteLine("Hi my name is :{0} And My Username is : {1}", bot.Me.FirstName, bot.Me.Username);
                new Task(PullMessage).Start();


   

        



        Console.ReadLine();

        }

        static async void PullMessage()
        {


            while (true)
            {

                var result = await bot.GetMessages();
                foreach (Message m in result)
                {
                    if (m.Chat != null)
                    {
                        Console.WriteLine("[{0}] {1} : {2}",m.Chat.Title,m.From.Username,m.Text);
                      
                    }

                    else
                    {

                        Console.WriteLine("{0} : {1}",m.From.Username,m.Text);
                        

                    }

                    ConstrolMessages(m);

                }

            }



        }

        private static void ConstrolMessages(Message m)
        {

            if (m.Text == null) return;
            MessageTarget target = (MessageTarget)m.Chat ?? m.From;

            if (m.Text.Contains("/start"))
            {
                bot.SendMessage(target, " Hello  " + m.From.FirstName + " How can i help you? " , false, m);
            }

            else if (m.Text.Contains("you"))		//echos the whole message
            {
                bot.SendMessage(target, m.Text, false, m);
            }
            else if (m.Text.Contains("bye"))
            {
                bot.SendMessage(target, "good bye." , false, m);
            }
            else if (m.Text.Contains("hi"))
            {
                bot.SendMessage(target, "hello ^^", false, m);
            }


        }

    }
}
