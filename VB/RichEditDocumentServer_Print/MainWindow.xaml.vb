Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Printing
Imports System.Printing

Namespace RichEditDocumentServer_Print
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim srv As New RichEditDocumentServer()
			srv.LoadDocument("test.docx")
			CType(New CustomXpfRichEditPrinter(srv), CustomXpfRichEditPrinter).PrintToMyPrinter()
		End Sub
	End Class

	#Region "customprinter"
	Public Class CustomXpfRichEditPrinter
		Inherits XpfRichEditPrinter

		Public Sub New(ByVal server As RichEditDocumentServer)
			MyBase.New(server)
		End Sub

		Public Sub PrintToMyPrinter()
            Dim pDialog As New PrintDialog()
            Dim enumerationFlag() As EnumeratedPrintQueueTypes
            enumerationFlag = {EnumeratedPrintQueueTypes.Connections}

			Dim queues As PrintQueueCollection = New PrintServer().GetPrintQueues(enumerationFlag)
			Dim localPrinterEnumerator As System.Collections.IEnumerator = queues.GetEnumerator()
			Dim printQueue As PrintQueue = Nothing

			Do
				localPrinterEnumerator.MoveNext()
				printQueue = CType(localPrinterEnumerator.Current, PrintQueue)
			Loop While Not printQueue.FullName.Contains("Canon")
			
			If printQueue IsNot Nothing Then
				pDialog.PrintQueue = printQueue
				Dim document As FixedDocument = Me.CreateFixedDocument()
				pDialog.PrintDocument(document.DocumentPaginator, String.Empty)
			End If
		End Sub
	End Class
	#End Region ' #customprinter
End Namespace
