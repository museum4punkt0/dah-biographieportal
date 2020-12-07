﻿using Pete.Components.Extensions.Classes;
using Pete.Components.WpfExtensions.Localization;

using System;
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

namespace Gemelo.Applications.Biographieportal.Controls.SendOwnStories
{
    /// <summary>
    /// Interaktionslogik für EditBox.xaml
    /// </summary>
    public partial class EditBox : UserControl
    {
        #region öffentliche Properties


        #region DependencyProperty MaxLines

        public static readonly DependencyProperty MaxLinesProperty =
           DependencyProperty.Register(
           "MaxLines", typeof(int),
           typeof(EditBox),
           new PropertyMetadata(int.MaxValue, new PropertyChangedCallback(OnMaxLinesChanged)));

        [System.ComponentModel.Description("MaxLines")]
        [System.ComponentModel.Category("gemelo")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public int MaxLines
        {
            get { return ((int)(GetValue(EditBox.MaxLinesProperty))); }
            set { SetValue(EditBox.MaxLinesProperty, value); }
        }

        private static void OnMaxLinesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EditBox ctrl = d as EditBox;
            if (ctrl != null)
            {
                int newValue = (int)e.NewValue;
                int oldValue = (int)e.OldValue;

                ctrl.m_Edit.MaxLines = newValue;
            }
        }

        #endregion DependencyProperty MaxLines


        private LocalizationString m_Description = null;

        public LocalizationString Description
        {
            get { return m_Description; }
            set { SetDescription(value); }
        }

        private void SetDescription(LocalizationString value)
        {
            if (value != m_Description)
            {
                m_Description = value;
                m_Txt.SetTextsFromLocalizationString(value);
            }
        }


        public string Text
        {
            get { return m_Edit.Text; }
            set { SetText(value); }
        }

        public bool AllowEnter { get; internal set; }

        private void SetText(string value)
        {
            m_Edit.Text = value;
        }


        #endregion öffentliche Properties

        #region Events

        public event EventHandler<EditLostFocusEventArgs> EditChanged;

        protected void OnEditChanged(TextBox _TextBox, EditBox _EditBox)
        {
            EditChanged?.Invoke(this, new EditLostFocusEventArgs(_TextBox, _EditBox));
        }

        #region Event EditLostFocus

        public event EventHandler<EditLostFocusEventArgs> EditLostFocus;

        public class EditLostFocusEventArgs : EventArgs
        {
            public TextBox TextBox { get; private set; }
            public EditBox EditBox { get; private set; }

            public EditLostFocusEventArgs(TextBox _TextBox, EditBox _EditBox)
            {
                TextBox = _TextBox;
                EditBox = _EditBox;
            }
        }

        protected void OnEditLostFocus(TextBox _TextBox, EditBox _EditBox)
        {
            EditLostFocus?.Invoke(this, new EditLostFocusEventArgs(_TextBox, _EditBox));
        }

        #endregion Event EditLostFocus

        #region Event EditFocused

        public event EventHandler<EditFocusedEventArgs> EditFocused;

        public class EditFocusedEventArgs : EventArgs
        {
            public TextBox TextBox { get; private set; }
            public EditBox EditBox { get; private set; }

            public EditFocusedEventArgs(TextBox _TextBox, EditBox _EditBox)
            {
                TextBox = _TextBox;
                EditBox = _EditBox;
            }
        }

        protected void OnEditFocused(TextBox _TextBox, EditBox _EditBox)
        {
            EditFocused?.Invoke(this, new EditFocusedEventArgs(_TextBox, _EditBox));
        }

        #endregion Event EditFocused

        #endregion Events

        public EditBox()
        {
            InitializeComponent();
            m_Edit.GotFocus += Edit_GotFocus;
        }

        private void Edit_GotFocus(object sender, RoutedEventArgs e)
        {
            OnEditFocused(m_Edit, this);
        }

        private void Edit_LostFocus(object sender, RoutedEventArgs e)
        {
            OnEditLostFocus(m_Edit, this);
        }

        private void Edit_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }

        private void Grid_TouchDown(object sender, TouchEventArgs e)
        {
            m_Edit.Focus();
        }


        private void Edit_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnEditChanged(m_Edit, this);
        }
    }
}
