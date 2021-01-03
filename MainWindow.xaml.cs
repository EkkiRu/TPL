using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
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

namespace TPLHomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static WebClient webClient;

        readonly string url = "https://nemaloknig.net/glav/wp-content/uploads/2019/Fedor_Evsevskiy-Bibliya_barmena_Vse_o_napitkakh.pdf";
        readonly string path = @"C:\Users\Mephistos\source\repos\TPLHomeWork\Bibliya_barmena_Vse_o_napitkakh.pdf";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DownloadButton(object sender, RoutedEventArgs e)
        {
            webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            webClient.DownloadFileAsync(new Uri(url), path);
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            webClient.CancelAsync();
        }

        public void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            textBox.Text = Convert.ToString(progressBar.Value) + " %";
        }
    }
}