using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELRD.Helpers
{
    public static class EnumHelper
    {
        public static List<EnumItem> GetEnumItems<T>() where T : Enum
        {
            var list = new List<EnumItem>();

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                var field = typeof(T).GetField(value.ToString());
                var descriptionAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                .FirstOrDefault() as DescriptionAttribute;

                list.Add(new EnumItem
                {
                    Code = value.ToString(),
                    Description = descriptionAttribute?.Description ?? value.ToString()
                });
            }

            return list.OrderBy(item => item.Description != "República Dominicana").ThenBy(item => item.Description).ToList();

        }
    }
}
