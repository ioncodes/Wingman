using System;
using System.Text;
using Wingman.Plugin;

namespace MD5
{
    public class MD5 : IPlugin
    {
        public string Name { get; } = "MD5";
        public string[] Keys { get; } = {"md5_timestamp"};
        public (string, string) GetData(string key)
        {
            if (key == Keys[0])
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                var md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(timestamp);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte t in hash)
                {
                    sb.Append(t.ToString("X2"));
                }
                return ("MD5-Timestamp", sb.ToString());
            }
            return (null, null);
        }
    }
}
