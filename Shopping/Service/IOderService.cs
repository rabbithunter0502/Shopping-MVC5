using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopping.Models;

namespace Shopping.Service
{
    interface IOderService 
    {
        bool CreateOrder(Models.ShoppingCart cart, CartInformation cartInformation);
    }
}