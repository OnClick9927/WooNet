using System.Net;
using System.Linq;
using System.Net.Sockets;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

namespace WooNet
{
    public static class NetTool
    {
        public static IPacketReader CreatePacketReader(int capacity = 4096)
        {
            return new PacketReader(capacity);
        }

        public static ITokenPool CreateTokenPool(int taskExecutePeriod = 60)
        {
            return new TokenPool(taskExecutePeriod);
        }


        public static ITcpClient CreateTcpClient(int chunkBufferSize = 4096, int sendConcurrentSize = 8)
        {
            return new TcpClient(chunkBufferSize, sendConcurrentSize);
        }
        public static ITcpServer CreateTcpSever(int chunkBufferSize = 4096, int maxNumberOfConnections = 32)
        {
            return new TcpServer(chunkBufferSize, maxNumberOfConnections);
        }
        public static IUdpClient CreateUdpClient(int chunkBufferSize = 4096, int sendConcurrentSize = 8)
        {
            return new UdpClient(chunkBufferSize, sendConcurrentSize);
        }
        public static IUdpServer CreateUdpSever(int chunkBufferSize = 4096, int maxNumberOfConnections = 32, bool broadcast = false)
        {
            return new UdpServer(chunkBufferSize, maxNumberOfConnections, broadcast);
        }
        public static IWSClient CreateWSClient(int chunkBufferSize = 4096, int sendConcurrentSize = 8)
        {
            return new WSClient(chunkBufferSize, sendConcurrentSize);
        }
        public static IWSServer CreateWSSever(int chunkBufferSize = 4096, int maxNumberOfConnections = 32)
        {
            return new WSServer(maxNumberOfConnections, chunkBufferSize);
        }
        public static IHttpServer CreateHttpSever(int maxPoolCount = 64, int blockSize = 4096)
        {
            return new HttpServer(maxPoolCount, blockSize);
        }





        public static IPAddress[] GetLoacalIpv4()
        {
            IPAddress[] addresses = Dns.GetHostAddresses("localhost");
            return (from x in addresses where x.AddressFamily == AddressFamily.InterNetwork select x).ToArray();
        }
        public static IPAddress[] GetLoacalIpv6()
        {
            IPAddress[] addresses = Dns.GetHostAddresses("localhost");
            return (from x in addresses where x.AddressFamily == AddressFamily.InterNetworkV6 select x).ToArray();
        }
        public static string GetOutSideIP()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(@"http://icanhazip.com/").Replace("\n", "");
            }
        }
        public static string ToSha1Base64(string value, Encoding encoding)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes = sha1.ComputeHash(encoding.GetBytes(value));
            return Convert.ToBase64String(bytes);
        }

        public static string ToMd5(string value, Encoding encoding)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(encoding.GetBytes(value));
            return Convert.ToBase64String(bytes);
        }

        public static string UnzipToString(byte[] content, string encoding = "UTF-8")
        {
            using (GZipStream deStream = new GZipStream(new MemoryStream(content), CompressionMode.Decompress))
            using (StreamReader reader = new StreamReader(deStream, Encoding.GetEncoding(encoding)))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

        public static byte[] UnzipToBytes(byte[] content)
        {
            using (GZipStream deStream = new GZipStream(new MemoryStream(content), CompressionMode.Decompress))
            using (MemoryStream ms = new MemoryStream())
            {
                deStream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static byte[] ZipToBytes(byte[] content)
        {
            using (MemoryStream ms = new MemoryStream())
            using (GZipStream ComStream = new GZipStream(ms, CompressionMode.Compress))
            {
                ComStream.Write(content, 0, content.Length);
                return ms.ToArray();
            }
        }

        public static byte[] ZipToBytes(string content, string encoding = "UTF-8")
        {
            using (MemoryStream ms = new MemoryStream())
            using (GZipStream ComStream = new GZipStream(ms, CompressionMode.Compress))
            {
                byte[] buf = Encoding.GetEncoding(encoding).GetBytes(content);
                ComStream.Write(buf, 0, buf.Length);
                return ms.ToArray();
            }
        }
    }
}
