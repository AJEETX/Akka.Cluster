using Akka.Actor;
using Akka.Cluster;
using Message;
using System;

namespace FrontEnd.Actor
{
    internal class Director : ReceiveActor
    {
        protected Cluster Cluster = Cluster.Get(Context.System);

        protected override void PreStart()
        {
            Cluster.Subscribe(Self, new[] { typeof(ClusterEvent.MemberUp), typeof(ClusterEvent.MemberJoined) });
        }

        protected override void PostStop()
        {
            Cluster.Unsubscribe(Self);
        }

        public Director()
        {
            Receive<ClusterEvent.MemberJoined>(m =>
            {
                Console.WriteLine($"{m.Member.Address}");
            });

            Receive<ClusterEvent.MemberUp>(m =>
            {
                Console.WriteLine($"{m.Member.Address}");
                if (m.Member.HasRole("backend"))
                {
                    Context.ActorSelection(m.Member.Address + "/user/tasker").Tell(new Initiate(), Self);
                }
            });
        }
    }
}