using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Printing;
using System.Printing;

namespace RichEditDocumentServer_Print
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RichEditDocumentServer srv = new RichEditDocumentServer();
            srv.LoadDocument("test.docx");
            new CustomXpfRichEditPrinter(srv).PrintToMyPrinter();
        }
    }

    #region customprinter
    public class CustomXpfRichEditPrinter : XpfRichEditPrinter
    {

        public CustomXpfRichEditPrinter(RichEditDocumentServer server)
            : base(server) { }

        public void PrintToMyPrinter()
        {
            PrintDialog pDialog = new PrintDialog();
            PrintQueueCollection queues = new PrintServer().GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local,
                EnumeratedPrintQueueTypes.Connections });
            System.Collections.IEnumerator localPrinterEnumerator = queues.GetEnumerator();
            PrintQueue printQueue = null;

            do {
                localPrinterEnumerator.MoveNext();
                printQueue = (PrintQueue)localPrinterEnumerator.Current;
            }
            while (!printQueue.FullName.Contains("Canon"));
            
            if (printQueue != null) {
                pDialog.PrintQueue = printQueue;
                FixedDocument document = this.CreateFixedDocument();
                pDialog.PrintDocument(document.DocumentPaginator, string.Empty);
            }
        }
    }
    #endregion #customprinter
}
