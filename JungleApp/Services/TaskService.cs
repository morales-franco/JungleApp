using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JungleApp.Services
{
    public class TaskServices
    {
        public void ExecuteConversation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() => SayHello(i));
            }

  
        }


        private void SayHello(int iterationNumber)
        {
            for (int i = 0; i < 3; i++)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"[Iteration Number { iterationNumber } - TheadId { threadId }] : Hello!");
            }
        }
    }
}
