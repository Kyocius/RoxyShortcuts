using System;
using System.IO;
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
using Roxy.Tools;
using Path = System.IO.Path;

namespace Roxy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBox.Text = RoxySetting.Default.DirectoryName;

            Loaded += (_, _) =>
            {
                WPFUI.Appearance.Watcher.Watch(
                    this, // Window class
                    WPFUI.Appearance.BackgroundType.Mica, // Background type
                    true // Whether to change accents automatically
                );
            };
        }

        private void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    RoxyTools.CreateShortcut($"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\{RoxySetting.Default.DirectoryName}", 
                        Path.GetFileName(file), $"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\{RoxySetting.Default.DirectoryName}");
                }
            }
        }

        private void ButtonConfirm_OnClick(object sender, RoutedEventArgs e)
        {
            RoxySetting.Default.DirectoryName = TextBox.Text;
        }

        private void ButtonOpenExplorer_OnClick(object sender, RoutedEventArgs e)
        {
            RoxyTools.OpenExplorer(RoxyTools.GetStartMenuPath());
        }
    }
}