namespace WooNet
{
    public interface ITcpServer
    {
        OnAcceptedHandler AcceptedCallback { get; set; }
        OnDisconnectedHandler DisconnectedCallback { get; set; }
        int NumberOfConnections { get; }
        OnReceivedHandler ReceivedCallback { get; set; }
        OnReceivedSegmentHandler ReceivedOffsetCallback { get; set; }
        OnSentHandler SentCallback { get; set; }

        void Close(SocketToken sToken);
        void Dispose();
        bool Send(SegmentToken segToken, bool waiting = true);
        int SendSync(SegmentToken segToken);
        bool Start(int port, string ip = "0.0.0.0");
        void Stop();
    }
}