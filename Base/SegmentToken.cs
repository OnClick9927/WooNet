namespace WooNet
{

    public class SegmentToken
    {
        public SocketToken sToken { get; set; }

        public Segment Data { get; set; }

        public SegmentToken()
        {

        }

        public SegmentToken(SocketToken sToken)
        {
            this.sToken = sToken;
        }

        public SegmentToken(SocketToken sToken,Segment data)
        {
            this.sToken = sToken;
            this.Data = data;
        }

        public SegmentToken (SocketToken sToken,byte[] buffer)
        {
            this.sToken = sToken;
            this.Data = new Segment(buffer);
        }

        public SegmentToken(SocketToken sToken,byte[] buffer,int offset,int size)
        {
            this.sToken = sToken;
            this.Data = new Segment(buffer, offset, size);
        }
    }
}
