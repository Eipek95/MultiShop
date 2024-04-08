namespace MultiShop.DtoLayer.IdentityDtos.LoginDtos
{
    public class CreateLoginDto
    {

        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
