﻿using System.Windows;

namespace UniversalPackageExplorer
{
    /// <summary>
    /// Interaction logic for ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        public ConfirmationWindow(string title, string prompt, string yesText = "Yes", string noText = "No", string cancelText = "Cancel")
        {
            this.Title = title;
            this.Prompt = prompt;
            this.YesText = yesText;
            this.NoText = noText;
            this.CancelText = cancelText;

            InitializeComponent();
        }

        public string Prompt { get; }
        public string YesText { get; }
        public string NoText { get; }
        public string CancelText { get; }
        private bool WasCancelled = false;

        public new bool? ShowDialog()
        {
            var result = base.ShowDialog();

            if (this.WasCancelled)
            {
                return null;
            }

            return result;
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.WasCancelled = true;
            this.DialogResult = null;
            this.Close();
        }
    }
}
