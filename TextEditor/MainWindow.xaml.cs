using Microsoft.Win32;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog OpenFileDialog=new OpenFileDialog();

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rtxtBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
        }

        private void rtxtBox_DragLeave(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filenames = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (filenames != null)
                {
                    foreach (var name in filenames)
                    {
                        try
                        {
                            rtxtBox.AppendText(File.ReadAllText(name));
                        }
                        catch (Exception ex)
                        {
                            
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

       
        private void btn_copy_Click(object sender, RoutedEventArgs e)
        {
            rtxtBox.Copy();  
        }

        private void btn_paste_Click(object sender, RoutedEventArgs e)
        {
            rtxtBox.Paste();
        }

        private void btn_cut_Click(object sender, RoutedEventArgs e)
        {
            rtxtBox.Cut();
        }

        private void btn_selectall_Click(object sender, RoutedEventArgs e)
        {
            rtxtBox.SelectAll();
        }

        

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem item)
            {
                if (item.Header.ToString() == "Open")
                {
                    OpenFileDialog.Filter = "All files|*.*|Text files|*.txt";
                    OpenFileDialog.FilterIndex = 2;

                    if (OpenFileDialog.ShowDialog()==true)
                    {

                        using (StreamReader sr = new StreamReader(OpenFileDialog.FileName))
                        {
                            rtxtBox.Selection.Text = sr.ReadToEnd();
                            txb_path.Text = OpenFileDialog.FileName;
                        }

                    }
                }
                if (item.Header.ToString() == "Save")
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.FileName = "Default.txt";
                    save.Filter = "Text File | *.txt";
                    if (save.ShowDialog()==true)
                    {
                        StreamWriter writer = new StreamWriter(save.OpenFile());
                        string myText = new TextRange(rtxtBox.Document.ContentStart, rtxtBox.Document.ContentEnd).Text;
                        writer.WriteLine(myText);
                        writer.Dispose();
                        writer.Close();
                        MessageBox.Show("Succesfully saved", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                if (item.Header.ToString() == "Exit")
                {
                    System.Environment.Exit(1);
                }

            }
        }


        private void ToggleButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btn_toggle.Toggle == true)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                
                StreamWriter writer = new StreamWriter(docPath+".txt");
            
                string myText = new TextRange(rtxtBox.Document.ContentStart, rtxtBox.Document.ContentEnd).Text;
                writer.WriteLine(myText);
                writer.Dispose();
                writer.Close();
                MessageBox.Show("Succesfully saved", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
