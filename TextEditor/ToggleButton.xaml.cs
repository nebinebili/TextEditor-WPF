﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        Thickness LeftSide = new Thickness(-39, 0, 0, 0);
        Thickness RightSide = new Thickness(0, 0,-39, 0);

        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(160, 160, 160));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(130, 190, 125));

        public bool Toggle { get; set; }

        public ToggleButton()
        {
            InitializeComponent();
            Dot.Margin = LeftSide;
            back.Fill = Off;
            Toggle = false;
        }

        private void Dot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Toggle)
            {
                Dot.Margin = RightSide;
                back.Fill = On;
                Toggle = true;
            }
            else
            {
                Dot.Margin = LeftSide;
                back.Fill = Off;
                Toggle = false;
            }
        }
    }
}
