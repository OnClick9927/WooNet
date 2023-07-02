namespace WooNet
{
    public interface IWSServer
    {
        OnAcceptedHandler OnAccepted { get; set; }
        OnDisconnectedHandler OnDisconnected { get; set; }
        OnReceivedHandler OnReceived { get; set; }
        OnReceivedSegmentHandler OnReceivedBytes { get; set; }
        OnSentHandler OnSent { get; set; }

        void Close(SocketToken sToken);
        void Dispose();
        bool Send(SegmentToken session, bool waiting = true);
        bool Send(SocketToken sToken, string content, bool waiting = true);
        bool Start(int port, string ip = "0.0.0.0");
        void Stop();
    }
}