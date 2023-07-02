using System;

namespace WooNet
{
    public interface IUdpClient
    {
        OnReceivedHandler ReceivedCallbackHandler { get; set; }
        OnReceivedSegmentHandler ReceivedOffsetHandler { get; set; }
        int SendBufferPoolNumber { get; }
        OnSentHandler SentCallbackHandler { get; set; }

        bool Connect(int port, string ip);
        void Disconnect();
        void Dispose();
        void ReceiveSync(Segment receiveSegment, Action<Segment> receiveAction);
        bool Send(Segment sendSegment, bool waiting = true);
        int SendSync(Segment sendSegment, Segment receiveSegment);
        void StartReceive();
    }
}