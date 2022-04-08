using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class MessageManager
    {
        public void Save()
        {
            Console.WriteLine("messaged saved!");
        }

        //tek tek SendSms ,SendEmail yapmak yerine
        
        abstract class MessageManagerBase
        {
            public void Save()
            {
                Console.WriteLine("messaged saved!");
            }
            public abstract void Send();

        }
        class Body
        {
            public string Title { get; set; }
            public string Text { get; set; }
        }
        class MailSender : MessageManagerBase
        {
            public override void Send(Body body)
            {
                Console.WriteLine("");
            }

            public override void Send()
            {
                throw new NotImplementedException();
            }
        }
        class EMailSender : MessageManagerBase
        {
            public override void Send()
            {
                throw new NotImplementedException();
            }
        }

    }
    
}
