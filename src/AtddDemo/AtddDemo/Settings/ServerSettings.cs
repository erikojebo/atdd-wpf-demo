namespace AtddDemo.Settings
{
    public class ServerSettings
    {
        public string ServerIp { get; set; }
        public int Port { get; set; }
        public int TimeoutInSeconds { get; set; }

        public override int GetHashCode()
        {
            return ServerIp.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ServerSettings;

            if (obj == null)
                return false;

            return ServerIp == other.ServerIp &&
                   Port == other.Port &&
                   TimeoutInSeconds == other.TimeoutInSeconds;
        }

        public override string ToString()
        {
            return string.Format("ip: {0}, port: {1}, timeout: {2}", ServerIp, Port, TimeoutInSeconds);
        }
    }
}