using System.Net;

namespace WooNet
{
    public interface IUdpServer
    {
        OnDisconnectedHandler DisconnectedCallbackHandler { get; set; }
        OnReceivedHandler ReceivedCallbackHandler { get; set; }
        OnReceivedSegmentHandler ReceivedOffsetHanlder { get; set; }
        OnSentHandler SentCallbackHandler { get; set; }

        void Dispose();
        bool Send(Segment dataSegment, IPEndPoint remoteEP, bool waiting = true);
        int SendSync(IPEndPoint remoteEP, Segment dataSegment);
        void Start(int port);
        void Stop();
    }
}