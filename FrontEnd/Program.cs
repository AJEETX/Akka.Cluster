using Akka.Actor;
using Akka.Configuration;
using FrontEnd.Actor;
using Message;
using System;

namespace Frontend
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "FrontEnd";
            var config = ConfigurationFactory.ParseString(@"
akka
    {
    loglevel = INFO
    loggers=[""Akka.Logger.NLog.NLogLogger, Akka.Logger.NLog""]
    actor {
		provider=cluster
        debug
            {
              receive = on      # log any received message
              autoreceive = on  # log automatically received messages, e.g. PoisonPill
              lifecycle = on    # log actor lifecycle changes
              event-stream = on # log subscription changes for Akka.NET event stream
              unhandled = on    # log unhandled messages sent to actors
            }
        }
    remote
        {
        dot-netty.tcp {
        port = 8081
        hostname = ""localhost""
        }
    }
    cluster {
        seed-nodes = [""akka.tcp://ClusterSystem@localhost:8081""]
        roles=[""frontend""]
        }
}
");
            var system = ActorSystem.Create("ClusterSystem", config);
            var director = system.ActorOf(Props.Create(() => new Director()), "director");
            director.Tell(new Initiate());
            Console.Read();
        }
    }
}