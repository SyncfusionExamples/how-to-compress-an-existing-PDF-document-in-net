using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace CompressPDFSample {
    internal class Program {
        static void Main(string[] args) {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VFhhQlVEfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Qd0FjUH5fdX1RR2ZZ  ");

            FileStream documentStream = new FileStream(Path.GetFullPath("../../../PDF_succinctly.pdf"), FileMode.Open, FileAccess.Read);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);
            PdfCompressionOptions options = new PdfCompressionOptions();
            options.CompressImages = true;
            options.ImageQuality = 50; 
            options.OptimizeFont = true;
            options.OptimizePageContents = true;
            options.RemoveMetadata = true;
            loadedDocument.Compress(options);

            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite)) {
                loadedDocument.Save(outputFileStream);
            }
            loadedDocument.Close(true);
        }
    }
}