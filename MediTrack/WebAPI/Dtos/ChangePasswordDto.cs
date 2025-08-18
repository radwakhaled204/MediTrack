namespace MediTrack.WebAPI.Dtos
{
    public class ChangePasswordDto
    {
        public int user_id { get; set; }
        public string old_password { get; set; } = string.Empty;
        public string new_password { get; set; } = string.Empty;
    }
}
