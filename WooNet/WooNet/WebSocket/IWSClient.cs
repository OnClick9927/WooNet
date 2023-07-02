namespace WooNet
{
    public interface IWSClient
    {
        bool IsConnected { get; }
        OnConnectedHandler OnConnected { get; set; }
        OnDisconnectedHandler OnDisconnected { get; set; }
        OnReceivedHandler OnReceived { get; set; }
        OnReceivedSegmentHandler OnReceivedBytes { get; set; }
        OnSentHandler OnSent { get; set; }

        bool Connect(string wsUrl);
        bool Connect(WSConnectionItem wsUrl);
        void Dispose();
        bool Send(Segment data, bool waiting = true);
        bool Send(string msg, bool waiting = true);
        void SendPing();
        void SendPong(Segment buf);
    }
}