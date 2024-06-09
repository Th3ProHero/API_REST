using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.FurnitureStore.API.Configuration
{
    public class JwtConfig
    {
        public string Secret {  get; set; }
    }
}
