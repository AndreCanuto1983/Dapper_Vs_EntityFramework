namespace ProjectDapperVsEntityFramework.Infra.Configuration
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int Expiration { get; set; }
        public string Emissor { get; set; }
        public string OriginValidate { get; set; }
    }
}
