namespace Backend.Actor
{
    using System;
    using Akka.Actor;
    using Message;

    internal class TaskActor : ReceiveActor, ILogReceive
    {
        private readonly IActorRef manager;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public TaskActor()
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