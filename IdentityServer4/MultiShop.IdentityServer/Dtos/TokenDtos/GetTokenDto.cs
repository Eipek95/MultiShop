﻿namespace MultiShop.IdentityServer.Dtos.TokenDtos
{
    public class GetTokenDto
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; }
    }
}
