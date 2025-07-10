namespace MediTrack.Configurations
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issure {  get; set; }
        public string Audience { get; set; }
    }
}
