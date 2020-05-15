using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.ViewModels
{
    public class RefreshViewToken
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
