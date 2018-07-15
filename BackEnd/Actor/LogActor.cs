namespace Backend.Actor
{
    using Akka.Actor;
    using Message;

    internal class LogActor : ReceiveActor
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public LogActor()
        {
            this.Receive<LogData>(s => this.logger.Info(s.LogMessage));
        }
    }
}