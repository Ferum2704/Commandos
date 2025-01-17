﻿using Commandos.Models.Carts;
using Commandos.Models.Users;

namespace Commandos.Services
{
    public class BuyService
    {
        public event Action<string>? OnInfo;
        public event Func<string, object>? OnGetInfo;

        public ICheck Buy()
        {
            Buy buy = new Buy(new CheckCreator());
            bool result = buy.TryBuy(CartsRepository.GetInstance()
                .GetCart((UserAccount.GetInstance()
                .User ?? throw new NullReferenceException("User not logged in"))));

            OnInfo?.Invoke("Successfullly buyed!");
            OnInfo?.Invoke("Your check:");
            if (!result)
            {
                CartsRepository.GetInstance()
                    .GetCart(UserAccount.GetInstance()
                    .User ?? throw new NullReferenceException("User not logged in"))
                    .ClearCart();
            }
            return buy.GetCheck();
        }

    }
}
