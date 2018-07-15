using Akka.Actor;
using Message;

namespace FrontEnd.Actor
{
    internal class StartActor : ReceiveActor, ILogReceive
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private IActorRef router;

        public StartActor(IActorRef router)
        {
            this.router = router;
            Receive<Initiate>(i => Start(i));
        }

        private void Start(Initiate initiate)
        {
            this.logger.Info(NLog.LogLevel.Info);

            router.Tell(new Initiate());
        }
    }
}