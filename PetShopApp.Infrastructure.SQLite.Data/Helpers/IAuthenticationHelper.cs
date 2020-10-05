using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.SQLite.Data.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);
    }
}
