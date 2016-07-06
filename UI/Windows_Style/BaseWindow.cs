using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    public class BaseWindow : Window
    {
        public BaseWindow()
        {
            InitializeStyle();
            this.Loaded += delegate
            {
                InitializeEvent();
            };
        }

        private void InitializeEvent()
        {
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["BaseWindowControlTemplate"];

            this.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
           
            Label laBel = (Label)baseWindowTemplate.FindName("lab_Title", this);
            laBel.Content = this.Title;
           
            Button minBtn = (Button)baseWindowTemplate.FindName("btnMin", this);
            minBtn.Click += delegate
            {
                this.WindowState = WindowState.Minimized;
            };

            Button maxBtn = (Button)baseWindowTemplate.FindName("btnMax", this);
            maxBtn.Click += delegate
            {
                this.WindowState = (this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal);
            };

            Button closeBtn = (Button)baseWindowTemplate.FindName("btnClose", this);
            closeBtn.Click += delegate
            {
                this.Close();
            };

            Border borderTitle = (Border)baseWindowTemplate.FindName("borderTitle", this);
            borderTitle.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
            borderTitle.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
            {
                if (e.ClickCount >= 2)
                {
                    maxBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            };
        }

      
        private void InitializeStyle()
        {
            this.Style = (Style) App.Current.Resources["BaseWindowStyle"];
        }
    }
}
