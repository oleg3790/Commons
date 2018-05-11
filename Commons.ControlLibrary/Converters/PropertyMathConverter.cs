using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace Commons.ControlLibrary
{
    public class PropertyMathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {                
                if (targetType == typeof(double) || targetType == typeof(int))
                {
                    Match modParam = Regex.Match(parameter.ToString(), @"^(\+|\*|/|-)[ ]?(\d+)");

                    var modifiedResult = (dynamic)null;
                    if (modParam.Success)
                    {
                        switch(modParam.Groups[1].Value.ToString())
                        {
                            case "+":
                                modifiedResult = (dynamic)System.Convert.ChangeType(value, targetType) + (dynamic)System.Convert.ChangeType(modParam.Groups[2].Value, targetType);
                                break;
                            case "*":
                                modifiedResult = (dynamic)System.Convert.ChangeType(value, targetType) * (dynamic)System.Convert.ChangeType(modParam.Groups[2].Value, targetType);
                                break;
                            case "/":
                                modifiedResult = (dynamic)System.Convert.ChangeType(value, targetType) / (dynamic)System.Convert.ChangeType(modParam.Groups[2].Value, targetType);
                                break;
                            case "-":
                                modifiedResult = (dynamic)System.Convert.ChangeType(value, targetType) - (dynamic)System.Convert.ChangeType(modParam.Groups[2].Value, targetType);
                                break;
                        }
                        return modifiedResult;
                    }                        
                    else
                        throw new Exception("Converter parameter needs to match the following convention: [+|*|/|-][digit]");
                }
                else
                    throw new Exception("Target type needs to be either double or int");                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
