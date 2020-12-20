using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace com.wuqiang.Controls
{

    //依赖属性：

    /// <summary>
    /// Instrument.xaml 的交互逻辑
    /// </summary>
    public partial class Instrument : UserControl
    {
        //依赖属性  依赖对象
        public double Value
        {
            get { return (double)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Instrument),new PropertyMetadata(double.NaN,new PropertyChangedCallback(OnPropertyChanged)));


        public int Mininum
        {
            get { return (int)GetValue(MininumProperty); }
            set { SetValue(MininumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mininum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MininumProperty =
            DependencyProperty.Register("Mininum", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));



        public int Maxinum
        {
            get { return (int)GetValue(MaxinumProperty); }
            set { SetValue(MaxinumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maxinum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxinumProperty =
            DependencyProperty.Register("Maxinum", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));



        public int Interval
        {
            get { return (int)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Interval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));


        public Brush PlateBackground
        {
            get { return (Brush)GetValue(PlateBackgroundProperty); }
            set { SetValue(PlateBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlateBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlateBackgroundProperty =
            DependencyProperty.Register("PlateBackground", typeof(Brush), typeof(Instrument), new PropertyMetadata(default(Brush)));


        public int InstrumentFontSize
        {
            get { return (int)GetValue(InstrumentFontSizeProperty); }
            set { SetValue(InstrumentFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InstrumentFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InstrumentFontSizeProperty =
            DependencyProperty.Register("InstrumentFontSize", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public Brush ScaleBrush
        {
            get { return (Brush)GetValue(ScaleBrushProperty); }
            set { SetValue(ScaleBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScaleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleBrushProperty =
            DependencyProperty.Register("ScaleBrush", typeof(Brush), typeof(Instrument), new PropertyMetadata(default(Brush), new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            Instrument instrument = d as Instrument;
            instrument?.Refresh();
        }

        public Instrument()
        {
            InitializeComponent();

            this.SizeChanged += Instrument_SizeChanged;
        }

        private void Instrument_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double minSize = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
            this.backEllipse.Width = minSize;
            this.backEllipse.Height = minSize;
        }


        private void Refresh()
        {
            if((this.Mininum == 0 && this.Maxinum == 0)||double.IsNaN(this.backEllipse.Width))
            {
                return;
            }
            double radius = this.backEllipse.Width / 2;
            this.mainCanvas.Children.Clear();
            double min = this.Mininum, max = this.Maxinum;
            double step = 270.0 / (max - min);
            int scaleAreaCount = this.Interval;

            for (int i = 0; i < (max-min); i++)
            {
                Line lineScale = new Line();

                lineScale.X1 = radius-(radius-12)*Math.Cos((i*step-45)*Math.PI/180);
                lineScale.Y1 = radius - (radius - 12) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.Stroke =this.ScaleBrush;
                lineScale.StrokeThickness = 1;

                this.mainCanvas.Children.Add(lineScale);
            }

            step = 270.0 / scaleAreaCount;
            int scaleText = (int)min;
            for (int i = 0; i <=scaleAreaCount; i++)
            {
                Line lineScale = new Line();

                lineScale.X1 = radius - (radius - 20) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 20) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);
                lineScale.Stroke = this.ScaleBrush;
                lineScale.StrokeThickness = 1;

                this.mainCanvas.Children.Add(lineScale);

                TextBlock textBlock = new TextBlock();
                textBlock.Width = 34;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.FontSize = this.InstrumentFontSize;

                textBlock.Text = (scaleText + (max-min)/ scaleAreaCount * i).ToString();
                textBlock.Foreground = this.ScaleBrush;
                Canvas.SetLeft(textBlock, radius - (radius - 36) * Math.Cos((i * step - 45) * Math.PI / 180)-17);
                Canvas.SetTop(textBlock, radius - (radius - 36) * Math.Sin((i * step - 45) * Math.PI / 180) - 10);
                this.mainCanvas.Children.Add(textBlock);
            }
            //内环
            string strData = "M{0} {1} A{0} {0} 0 1 1 {1} {2}";
            strData = string.Format(strData, radius / 2, radius, radius * 1.5);
            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.circle.Data = (Geometry)typeConverter.ConvertFrom(strData);


            step = 270.0 / (max - min);
            //this.pointValue.Angle = this.Value * step-45;
            //double value = double.IsNaN(this.Value) ? 0 : this.Value;
            //指针 移动绑定 动画
            DoubleAnimation doubleAnimation = new DoubleAnimation((int)((this.Value - this.Mininum) * step) - 45, new Duration(TimeSpan.FromMilliseconds(200)));
            this.pointValue.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);

            //指针
            strData = "M{0} {1},{1} {2},{1} {3}";
            strData = string.Format(strData, radius * 0.3, radius, radius -5, radius + 5);
            //TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.point.Data = (Geometry)typeConverter.ConvertFrom(strData);
        }

    }
}
