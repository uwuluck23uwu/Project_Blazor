namespace WebLucky_API.Helper
{
    public class APISettings
    {
        public string SecretKey { get; set; } //รหัสลับ
        public string ValidAudience { get; set; } //ส่งจากที่ไหน
        public string ValidIssuer { get; set; } //ส่งไปที่ไหน
    }
}
