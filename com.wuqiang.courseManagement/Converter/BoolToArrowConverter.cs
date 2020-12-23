using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace com.wuqiang.courseManagement.Converter
{
    public class BoolToArrowConverter : IValueConverter
    {
        //从模型向视图转化
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null&&bool.Parse(value.ToString()))
            {
                return "↑";
            }
            return "↓";
        }

        //从视图向模型转
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
