namespace WooNet
{
    public interface IHttpServer
    {
        HttpOnReceived hOnReceived { get; set; }
        int Port { get; }

        void Disconnect(SocketToken sToken);
        bool Send(SegmentToken segment);
        bool Send(SocketToken sToken, byte[] data);
        bool Start(int port = 80);
    }
}