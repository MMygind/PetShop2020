using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.SQLite.Data
{
    public interface IDBInitializer
    {
        void SeedDB(PetShopAppLiteContext ctx);
    }
}
