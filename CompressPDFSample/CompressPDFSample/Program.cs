using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace CompressPDFSample {
    internal class Program {
        static void Main(string[] args) {

            //Get stream from an existing PDF document. 
            FileStream documentStream = new FileStream(Path.GetFullPath("../../../PDF_succinctly.pdf"), FileMode.Open, FileAccess.Read);
            //Load the existing PDF document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);
            //Create a new compression option object.
            PdfCompressionOptions options = new PdfCompressionOptions();
            //Enable the compress image.
            options.CompressImages = true;
            //Set the image quality.
            options.ImageQuality = 50;
            //Enable the optimize font option.
            options.OptimizeFont = true;
            //Enable the optimize page contents option.
            options.OptimizePageContents = true;
            //Set to remove the metadata information.
            options.RemoveMetadata = true;
            //Assign the compression option to the document.
            loadedDocument.Compress(options);

            //Create file stream.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                loadedDocument.Save(outputFileStream);
            }
            //Close the PDF document.
            loadedDocument.Close(true);
        }
    }
}