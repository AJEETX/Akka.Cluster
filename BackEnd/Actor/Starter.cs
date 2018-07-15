namespace Backend.Actor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Akka.Actor;
    using Message;

    internal class Starter : ReceiveActor, ILogReceive
    {
        private IActorRef manager;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Starter()
        {
            this.manager = Context.ActorOf(Props.Create<Manager>(), "Manager");

            this.Receive<Initiate>(i => this.Init(i));
        }

        private void Init(Initiate initiate)
        {
            this.logger.Info(NLog.LogLevel.Info);

            Console.WriteLine($"Start processing !!!");

            var officeList = Data.CreateOfficeList;

            this.manager.Tell(officeList);
        }
    }
}