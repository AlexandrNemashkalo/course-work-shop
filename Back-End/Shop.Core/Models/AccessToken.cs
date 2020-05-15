using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Models
{
    public class AccessToken
    {
        public string Token { get; set; }

        public long ExpiresIn { get; set; }
    }
}
