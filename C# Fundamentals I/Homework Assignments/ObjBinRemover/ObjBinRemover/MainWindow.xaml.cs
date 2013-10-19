using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjBinRemover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                textBoxChosenFolder.Text = folderBrowser.SelectedPath;
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            string solutionDirectory = textBoxChosenFolder.Text;

            string[] objDirectories = Directory.GetDirectories(solutionDirectory, "*obj", SearchOption.AllDirectories);
            string[] binDirectories = Directory.GetDirectories(solutionDirectory, "*bin", SearchOption.AllDirectories);

            for (int i = 0; i < objDirectories.Length; i++)
            {
                DeleteDirectory(objDirectories[i]);
            }

            for (int j = 0; j < binDirectories.Length; j++)
            {
                DeleteDirectory(binDirectories[j]);                
            }
        }

        private void DeleteDirectory(string path)
        {
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(path, false);
        }
    }
}
