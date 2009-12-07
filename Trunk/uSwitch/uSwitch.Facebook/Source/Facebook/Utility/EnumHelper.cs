using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Facebook.Utility
{
    public class EnumHelper
    {
        private EnumHelper() { }

        public static string GetEnumDescription<T>(T enumeratedType)
        {
            string description = enumeratedType.ToString();

            Type enumType = typeof(T);
            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            FieldInfo fieldInfo =
                enumeratedType.GetType().GetField(enumeratedType.ToString());

            if (fieldInfo != null)
            {
                object[] attribues = 
                    fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attribues != null && attribues.Length > 0)
                {
                    description = ((DescriptionAttribute)attribues[0]).Description;
                }
            }
            
            return description;
        }

        public static string GetEnumCollectionDescription<T>(Collection<T> enums)
        {
            StringBuilder sb = new StringBuilder();

            Type enumType = typeof(T);
            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            foreach (T enumeratedType in enums)
            {
                sb.AppendLine(GetEnumDescription(enumeratedType));
            }

            return sb.ToString();
        }
    }
}
