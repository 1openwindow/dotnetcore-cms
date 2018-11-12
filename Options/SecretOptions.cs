namespace Sky.SelfServe.Options
{
    public class SecretOptions
    {
        public string RedisConnection { get; set; }

        public string SelfServeDatabase { get; set; }

        public string StorageConnection { get; set; }

        public string SelfServeAadClientSecret { get; set; }
    }
}
