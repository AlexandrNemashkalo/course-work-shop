using Shop.Core.Models;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Interfaces
{
    public interface IJwtGenerator
    {
        Task<Response<Token>> GenerateJwt(User user);
    }
}
