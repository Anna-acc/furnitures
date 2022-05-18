using FurnitureBy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureBy.Domain.Base
{
    public static class Base
    {
        public static string GetNameMainCategory(int id)
        {
            switch (id)
            {
                case 1 : return "Кровати";
                case 2 : return "Диваны";
                case 3:  return "Шкафы";
                case 4:  return "Столы";
                case 5:  return "Стулья";
            }
            return "";
        }

        public static string GetNameStatusOrder(int status)
        {
            switch (status)
            {
                case 0: return "Корзина";
                case 1: return "Заказ оформлен";
                case 2: return "Заказ подтвержден";
                case 3: return "Заказ доставлен";
                case 4: return "Заказ отклонен";
            }
            return "";
        }
    }
}
