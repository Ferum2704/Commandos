﻿namespace Commandos.Models.Carts
{
    public class Check : ICheck
    {
        #region Props
        private string check;
        private double sum;
        private Guid id;
        private DateTime creatingTime;
        public string CheckString { get => check; private set => check = value; }
        public double Sum
        {
            get => sum;
            private set
            {
                if (value >= 0)
                {
                    sum = value;
                }
            }
        }
        public Guid Id { get => id; private set => id = value; }
        public DateTime CreatingTime { get => creatingTime; private set => creatingTime = value; }
        #endregion
        #region Ctors
        public Check(ICart cart)
        {
            if (cart == null)
            {
                return;
            }

            Sum = cart.Sum();
            CreatingTime = DateTime.Now;
            Id = Guid.NewGuid();
            check = $"\tЧЕК N {Id} вiд {CreatingTime.ToShortDateString()} {CreatingTime.ToShortTimeString()} \n{cart}\n\tДЯКУЄМО ЗА ПОКУПКУ!\n";
        }
        public Check(Guid id, double sum, string checkStr)
        {
            Id = id;
            Sum = sum;
            CheckString = checkStr;
            CreatingTime = DateTime.Now;
        }
        #endregion
        #region Ovverrides
        public override string ToString()
        {
            return CheckString;
        }
        #endregion
    }
}
