using Timer = System.Timers.Timer;
using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PISDK;

namespace UI2.User_Controls
{
    public partial class InfoCard : UserControl
    {
        
        public InfoCard()
        {
            InitializeComponent();
            
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(InfoCard));
        public string StackerTitle
        {
            get { return (string)GetValue(StackerTitleProperty); }
            set { SetValue(StackerTitleProperty, value); }
        }
        public static readonly DependencyProperty StackerTitleProperty = DependencyProperty.Register("StackerTitle", typeof(string), typeof(InfoCard));

        public string OEETitle
        {
            get { return (string)GetValue(OEETitleProperty); }
            set { SetValue(OEETitleProperty, value); }
        }
        public static readonly DependencyProperty OEETitleProperty = DependencyProperty.Register("OEETitle", typeof(string), typeof(InfoCard));
        public string WasteTitle
        {
            get { return (string)GetValue(WasteTitleProperty); }
            set { SetValue(WasteTitleProperty, value); }
        }
        public static readonly DependencyProperty WasteTitleProperty = DependencyProperty.Register("WasteTitle", typeof(string), typeof(InfoCard));
        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(string), typeof(InfoCard));

        public string PrevDownTime
        {
            get { return (string)GetValue(PrevDownTimeProperty); }
            set { SetValue(PrevDownTimeProperty, value); }
        }
        public static readonly DependencyProperty PrevDownTimeProperty = DependencyProperty.Register("PrevDownTime", typeof(string), typeof(InfoCard), new PropertyMetadata(""));
        public string Bagger1Speed
        {
            get { return (string)GetValue(Bagger1SpeedProperty); }
            set { SetValue(Bagger1SpeedProperty, value); }
        }
        public static readonly DependencyProperty Bagger1SpeedProperty = DependencyProperty.Register("Bagger1Speed", typeof(string), typeof(InfoCard), new PropertyMetadata(""));

        public string Bagger2Speed
        {
            get { return (string)GetValue(Bagger2SpeedProperty); }
            set { SetValue(Bagger2SpeedProperty, value); }
        }
        public static readonly DependencyProperty Bagger2SpeedProperty = DependencyProperty.Register("Bagger2Speed", typeof(string), typeof(InfoCard), new PropertyMetadata(""));


        public string StackerSpeed
        {
            get { return (string)GetValue(StackerSpeedProperty); }
            set { SetValue(StackerSpeedProperty, value); }
        }
        public static readonly DependencyProperty StackerSpeedProperty = DependencyProperty.Register("StackerSpeed", typeof(string), typeof(InfoCard), new PropertyMetadata(""));
        public string StopNumber
        {
            get { return (string)GetValue(StopNumberProperty); }
            set { SetValue(StopNumberProperty, value); }
        }
        public static readonly DependencyProperty StopNumberProperty = DependencyProperty.Register("StopNumber", typeof(string), typeof(InfoCard), new PropertyMetadata(""));
        public string ActualSpeed
        {
            get { return (string)GetValue(ActualSpeedProperty); }
            set { SetValue(ActualSpeedProperty, value); }
        }
        public static readonly DependencyProperty ActualSpeedProperty = DependencyProperty.Register("ActualSpeed", typeof(string), typeof(InfoCard), new PropertyMetadata(""));
        public string OEE
        {
            get { return (string)GetValue(OEEProperty); }
            set { SetValue(OEEProperty, value); }
        }
        public static readonly DependencyProperty OEEProperty = DependencyProperty.Register("OEE", typeof(string), typeof(InfoCard), new PropertyMetadata(""));

        public string Waste
        {
            get { return (string)GetValue(WasteProperty); }
            set { SetValue(WasteProperty, value); }
        }
        public static readonly DependencyProperty WasteProperty = DependencyProperty.Register("Waste", typeof(string), typeof(InfoCard), new PropertyMetadata(""));

        public FontAwesome.Sharp.IconChar Icon
        {
            get { return (FontAwesome.Sharp.IconChar)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(InfoCard));

        public Color Background1
        {
            get { return (Color)GetValue(Background1Property); }
            set { SetValue(Background1Property, value); }
        }
        public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(InfoCard));

        public Color Background2
        {
            get { return (Color)GetValue(Background2Property); }
            set { SetValue(Background2Property, value); }
        }
        public static readonly DependencyProperty Background2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(InfoCard));

        public Color EllipseBackground1
        {
            get { return (Color)GetValue(EllipseBackground1Property); }
            set { SetValue(EllipseBackground1Property, value); }
        }
        public static readonly DependencyProperty EllipseBackground1Property = DependencyProperty.Register("EllipseBackground1", typeof(Color), typeof(InfoCard));

        public Color EllipseBackground2
        {
            get { return (Color)GetValue(EllipseBackground2Property); }
            set { SetValue(EllipseBackground2Property, value); }
        }
        public static readonly DependencyProperty EllipseBackground2Property = DependencyProperty.Register("EllipseBackground2", typeof(Color), typeof(InfoCard));
    }
}

