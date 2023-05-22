using System;

namespace CleanArchMvc6.API.Models;

public class UserToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
