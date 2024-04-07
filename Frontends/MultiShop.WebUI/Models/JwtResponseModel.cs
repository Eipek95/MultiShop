namespace MultiShop.WebUI.Models
{
    public class JwtResponseModel
    {
        //public string Token { get; set; }
        //public DateTime ExpireDate { get; set; }

        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
}
