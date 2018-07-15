namespace Backend.Actor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using Akka.Actor;
    using Message;

    internal class Supervisor : ReceiveActor
    {
        private readonly string name = string.Empty;

        public Supervisor(string name)
        {
            this.name = name;
            this.Receive<Office>(o => Do(o));
        }

        private void Do(Office office)
        {
            Console.WriteLine($"{Context.Self.Path} - {office.ID} : {office.Data}");
            var data = new OfficePnrList(office, Data.Pnrs);
            Thread.Sleep(2000);
            this.Sender.Tell(data);
        }
    }
}