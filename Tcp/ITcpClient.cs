using System;

namespace WooNet
{
    public interface ITcpClient
    {
        OnConnectedHandler ConnectedCallback { get; set; }
        OnDisconnectedHandler DisconnectedCallback { get; set; }
        bool IsConnected { get; }
        OnReceivedSegmentHandler ReceivedOffsetCallback { get; set; }
        OnReceivedHandler RecievedCallback { get; set; }
        int SendBufferPoolNumber { get; }
        OnSentHandler SentCallback { get; set; }

        void Connect(int port, string ip);
        bool ConnectSync(int port, string ip);
        bool ConnectTo(int port, string ip);
        void Disconnect();
        void Dispose();
        void ReceiveSync(Segment receiveSegment, Action<Segment> receivedAction);
        bool Send(Segment sendSegment, bool waiting = true);
        void SendFile(string filename);
        int SendSync(Segment sendSegment, Segment receiveSegment);
    }
}