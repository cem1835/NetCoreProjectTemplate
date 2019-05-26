using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Project.Extensions.ObjectExtensions
{
    public struct EnumsProperties
    {

        public static T GetAttribute<T>(Enum enumValue) where T : Attribute
        {
            T attribute;

            MemberInfo memberInfo = enumValue.GetType().GetMember(enumValue.ToString())
                                            .FirstOrDefault();

            if (memberInfo != null)
            {
                attribute = (T)memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                return attribute;
            }
            return null;
        }


        public static string GetDescriptionFromEnumValue(Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(
                                typeof(DescriptionAttribute), false), (
                                    f, a) => new { Field = f, Att = a })
                            .Where(a => ((DescriptionAttribute)a.Att)
                                .Description == description).SingleOrDefault();
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }



        public static IEnumerable<Item> EnumToArray<T>()
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {

                var deger = item.ToString().Replace("_", "");
                yield return new Item { Key = deger.ToString(), Value = GetDescriptionFromEnumValue((Enum)item) };

            }
        }

        public static IEnumerable<Item> EnumToArrayValues<T>()
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {

                var deger = (int)item;

                yield return new Item { Key = deger.ToString(), Value = GetDescriptionFromEnumValue((Enum)item), EnumKey = item.ToString() };


            }
        }



        //public static string EnumKeyToDescription<T>(dynamic key)
        //{
        //    if (key == null)
        //        return string.Empty;

        //    var result = EnumsProperties.EnumToArrayValues<T>().Where(p => p.Key.Equals(key.ToString())).FirstOrDefault();
        //    return result != null ? result.Value : string.Empty;
        //}

        public class Item
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public string EnumKey { get; set; }
        }

    }

}