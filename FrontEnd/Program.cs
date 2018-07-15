using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using FrontEnd.Actor;
using Message;
using System;
using System.Diagnostics;

namespace Frontend
{
    internal class Program
    {
        public static ActorSystem ClusterSystem;
        private static IActorRef StartActor;

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
        deployment {
        /tasker {
          router = round-robin-pool # routing strategy
          nr-of-instances = 5 # max number of total routees
          cluster {
             enabled = on
             allow-local-routees = off
             use-role = tasker
             max-nr-of-instances-per-node = 1
          }
        }
      }
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
        roles=[""tasker""]
        }
}
");
            ClusterSystem = ActorSystem.Create("ClusterSystem", config);
            var tasker = ClusterSystem.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "tasker");

            StartActor = ClusterSystem.ActorOf(Props.Create(() => new StartActor(tasker)), "startactor");
            StartActor.Tell(new Initiate());
            ClusterSystem.WhenTerminated.Wait();
        }
    }
}