using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JungleApp.Batch.Services
{
    public class TaskServices
    {
        public void ExecuteConversation()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[MAIN TheadId { threadId }] : No Cancelable Approach!");

            var task = Task.Run(() => SayHello());

            if (!task.Wait(6000))
                Console.WriteLine("Task hasn't finished!");
            else
                Console.WriteLine("Task hasfinished successfully!");



            Console.WriteLine($"[MAIN TheadId { threadId }] : Cancelable Approach!");
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = tokenSource.Token;

            var cancellableTask = Task.Run(() => SayHelloWithCancellation(cancellationToken), cancellationToken);

            try
            {
                if (!cancellableTask.Wait(6000))
                {
                    tokenSource.Cancel();
                    Console.WriteLine("Task hasn't finished but we cancel it!");
                }
                else
                    Console.WriteLine("Task has finished successfully!");
            }
            catch (AggregateException ex)
            {
                foreach (var inner in ex.InnerExceptions)
                {
                    if (inner is TaskCanceledException)
                        Console.WriteLine("Tarea Cancelada y TaskCanceledException manejada.");
                    else
                        Console.WriteLine(inner.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"[MAIN TheadId { threadId }] : Cancelable Approach with TIMEOUT!");

            CancellationTokenSource tokenSourceTimeOut = new CancellationTokenSource(10000);
            CancellationToken cancellationTokenTimeOut = tokenSourceTimeOut.Token;

            var cancellableTimeOutTask = Task.Run(() => SayHelloWithCancellation(cancellationTokenTimeOut), cancellationTokenTimeOut);

            try
            {
                cancellableTimeOutTask.Wait();
                Console.WriteLine("[TIMEOUT TASK]Task has finished successfully!");
            }
            catch (AggregateException ex)
            {
                foreach (var inner in ex.InnerExceptions)
                {
                    if (inner is TaskCanceledException)
                        Console.WriteLine("[TIMEOUT TASK] Tarea Cancelada y TaskCanceledException manejada.");
                    else
                        Console.WriteLine(inner.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"[MAIN TheadId { threadId }] : Cancelable Approach IMMEDIATELY!");

            CancellationTokenSource tokenSourceImmediately = new CancellationTokenSource();
            CancellationToken cancellationTokenImmediately = tokenSourceImmediately.Token;
            Thread targetThread = null; 
            var immediatelyCancellableTask = Task.Run(() =>
            {
                targetThread = Thread.CurrentThread;
                SayHelloTenTimes(cancellationTokenImmediately);

            }, cancellationTokenImmediately);

            cancellationTokenImmediately.Register(() =>
            {
                Console.WriteLine($"[MAIN TheadId { threadId }] ------------ Register ------------");
                targetThread.Abort();
            });


            try
            {
                if (!immediatelyCancellableTask.Wait(6000))
                {
                    tokenSourceImmediately.Cancel();
                    Console.WriteLine("[IMMEDIATELY TASK FINISHED]Task has finished successfully - DANGEROUS APPROACH!");
                }
                else
                    Console.WriteLine("Task has finished successfully!");

            }
            catch (AggregateException ex)
            {
                foreach (var inner in ex.InnerExceptions)
                {
                    if (inner is TaskCanceledException)
                        Console.WriteLine("[IMMEDIATELY TASK FINISHED] Tarea Cancelada y TaskCanceledException manejada.");
                    else
                        Console.WriteLine(inner.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SayHello()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"[TheadId { threadId }] : Hello!");
                Thread.Sleep(5000);
            }
        }

        private void SayHelloWithCancellation(CancellationToken token)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine($"[TheadId { threadId }] : Hello!");
                Thread.Sleep(5000);
            }
        }

        private void SayHelloTenTimes(CancellationToken token)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"[TheadId { threadId }] : Hello!");
                Thread.Sleep(5000);
            }
        }
    }
}
