namespace Backend.Actor
{
    using System;
    using System.Threading;
    using Akka.Actor;
    using Message;
    using Shared;

    internal class Processor : ReceiveActor
    {
        private readonly string name = string.Empty;

        public Processor(string name)
        {
            this.name = name;
            this.Receive<Pnr>(pnr => this.Process(pnr));
        }

        private void Process(Pnr pnr)
        {
            Console.WriteLine($" Processing pnr {pnr.Locator}");
            Thread.Sleep(1000);
            this.Sender.Tell(new CompletedResponse());
        }
    }
}