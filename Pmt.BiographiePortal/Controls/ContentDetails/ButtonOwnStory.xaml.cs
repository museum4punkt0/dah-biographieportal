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

namespace Gemelo.Applications.Biographieportal.Controls.ContentDetails
{
    /// <summary>
    /// Interaktionslogik für ButtonOwnStory.xaml
    /// </summary>
    public partial class ButtonOwnStory : UserControl
    {


        public event EventHandler<EventArgs> ButtonClicked;

        protected void OnButtonClicked()
        {
            ButtonClicked?.Invoke(this, new EventArgs());
        }


        public ButtonOwnStory()
        {
            InitializeComponent();
            m_BtnOwnStory.ClickMode = ClickMode.Press;
            //m_BtnOwnStory.FireClickAtTouchDown = true;
        }

        private void BtnOwnStory_Click(object sender, RoutedEventArgs e)
        {
            OnButtonClicked();
        }
    }
}
