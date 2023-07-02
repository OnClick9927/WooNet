namespace WooNet
{
    public class Segment
    {
        public byte[] buffer { get; set; }

        public int offset { get; set; }

        public int size { get; set; }

        public Segment()
        {

        }

        public Segment(byte[] buffer)
        {
            this.buffer = buffer;
            this.size = buffer.Length;
        }

        public Segment(byte[] buffer, int offset, int size)
        {
            this.buffer = buffer;
            this.offset = offset;
            this.size = size;
        }
    }
}
