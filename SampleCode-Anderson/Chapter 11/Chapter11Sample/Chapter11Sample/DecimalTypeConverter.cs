using System;
using System.ComponentModel;

namespace Chapter11Sample
{
    public class DecimalTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, 
                                            Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, 
                                            Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, 
                                            System.Globalization.CultureInfo culture,
                                            object value)
        {
            return Convert.ToDecimal(value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, 
                                            System.Globalization.CultureInfo culture,
                                            object value, Type destinationType)
        {
            return value.ToString();
        }
    }
}
