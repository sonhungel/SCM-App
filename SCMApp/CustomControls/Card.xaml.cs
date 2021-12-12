using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SCMApp.CustomControls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }
        public Uri imageSource
        {
            get { return (Uri)GetValue(imageSourceProperty); }
            set { SetValue(imageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for imageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty imageSourceProperty =
            DependencyProperty.Register("imageSource", typeof(Uri), typeof(Card));



        public string text1
        {
            get { return (string)GetValue(text1Property); }
            set { SetValue(text1Property, value); }
        }

        // Using a DependencyProperty as the backing store for text1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty text1Property =
            DependencyProperty.Register("text1", typeof(string), typeof(Card));



        public string text2
        {
            get { return (string)GetValue(text2Property); }
            set { SetValue(text2Property, value); }
        }

        // Using a DependencyProperty as the backing store for text2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty text2Property =
            DependencyProperty.Register("text2", typeof(string), typeof(Card));

        public SolidColorBrush IconBackground
        {
            get { return (SolidColorBrush)GetValue(IconBackgroundProperty); }
            set { SetValue(IconBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconBackgroundProperty =
            DependencyProperty.Register("IconBackground", typeof(SolidColorBrush), typeof(Card));

        public SolidColorBrush IconBackgroundMouseOver
        {
            get { return (SolidColorBrush)GetValue(IconBackgroundMouseOverProperty); }
            set { SetValue(IconBackgroundMouseOverProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicatorBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconBackgroundMouseOverProperty =
            DependencyProperty.Register("IconBackgroundMouseOver", typeof(SolidColorBrush), typeof(Card));

        public SolidColorBrush BackGroundColor
        {
            get { return (SolidColorBrush)GetValue(BackGroundColorProperty); }
            set { SetValue(BackGroundColorProperty, value); }
        }

        public static readonly DependencyProperty BackGroundColorProperty =
            DependencyProperty.Register("BackGroundColor", typeof(SolidColorBrush), typeof(Card));
    }
}
