using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace com.wuqiang.courseManagement.Common
{
    /// <summary>
    /// 附加类  用于特殊处理 Password 无法绑定关联属性的问题
    /// </summary>
    public class PasswordHelper
    {
        public static bool bIsUpdateing = false;
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));

        public static void SetPassword(DependencyObject d,string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        public static string GetPassword(DependencyObject d)
        {
            return d.GetValue(PasswordProperty).ToString();
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
            if (!bIsUpdateing&& e!=null&& e.NewValue!=null)
            {
                passwordBox.Password = e.NewValue.ToString();
            }
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }


        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttached)));

        private static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
            PasswordBox passwordBox = d as PasswordBox;
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            bIsUpdateing = true;
            SetPassword(passwordBox, passwordBox.Password);
            bIsUpdateing = false;
        }

        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(AttachProperty, value);
        }

        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(AttachProperty)/*.ToString()*/;
        }
    }
}
