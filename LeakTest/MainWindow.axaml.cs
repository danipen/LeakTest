using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LeakTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            Button openModalButton = new Button();
            openModalButton.Content = "Open modal";

            openModalButton.Click += OpenModalButton_Click;

            Button runGCButton = new Button();
            runGCButton.Click += RunCGButton_Click;
            runGCButton.Content = "Run CG";

            StackPanel panel = new StackPanel();
            panel.Children.Add(openModalButton);
            panel.Children.Add(runGCButton);
            Content = panel;
        }

        private async void OpenModalButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ChildWindow child = new ChildWindow();
            await child.ShowDialog(this);
        }

        private void RunCGButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        class ChildWindow : Window
        {

        }
    }
}
