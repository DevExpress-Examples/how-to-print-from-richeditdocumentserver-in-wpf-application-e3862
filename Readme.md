# How to print from RichEditDocumentServer in WPF application


<p>This example utilizes the <strong>DevExpress.XtraRichEdit.Printing.XpfRichEditPrinter</strong> descendant to print the document loaded into the <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditRichEditDocumentServertopic"><u>RichEditDocumentServer</u></a> instance. A custom method iterates all available printers and chooses the one that contains a word "Canon" in its name.<br />Starting from v2014 vol.1.8 (and also v2013 starting from vol.2.12) the <strong>DevExpress.XtraRichEdit.Printing.XpfRichEditPrinter</strong> class is not capable of creating fixed documents from the <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditRichEditDocumentServertopic"><u>RichEditDocumentServer</u></a> instance. A new class <strong>RichEditDocumentXpfPrinter </strong>should be used instead. The updated example utilizes the <strong>RichEditDocumentXpfPrinter.CreateFixedDocument</strong> method to create a fixed document.</p>

<br/>


