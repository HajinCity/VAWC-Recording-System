using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace VAWC_Recording_System.NewForms
{
    public partial class CustomPrintPreviewForm : Form
    {
        private PrintDocument printDocument;

        public CustomPrintPreviewForm(PrintDocument printDoc)
        {
            InitializeComponent();
            this.printDocument = printDoc;
            this.printPreviewControl1.Document = this.printDocument;

            // Enable AutoZoom
            this.printPreviewControl1.AutoZoom = true;

            // Set the initial display to show 2 pages across
            this.printPreviewControl1.Rows = 1; // Number of pages in a column
            this.printPreviewControl1.Columns = 2; // Number of pages in a row
        }


        private void SavePDF_Button_Click(object sender, EventArgs e)
        {
            if (Copies_NumUpDown.Value > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveDocumentAsPDF(saveFileDialog.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please set the number of copies to at least 1.", "Invalid Number of Copies", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int pageNumber = 0;

        private void SaveDocumentAsPDF(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var document = new Document();
                var writer = PdfWriter.GetInstance(document, stream);
                document.Open();

                bool hasMorePages = true;
                Bitmap bmp = null; // Declare bmp outside the PrintPage event handler

                printDocument.PrintPage += (s, ev) =>
                {
                    bmp = new Bitmap(printDocument.DefaultPageSettings.Bounds.Width, printDocument.DefaultPageSettings.Bounds.Height);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        // Draw the content for the current page
                        ev.Graphics.DrawImage(bmp, 0, 0);
                    }

                    pageNumber++;
                    ev.HasMorePages = pageNumber < 2;
                };

                while (hasMorePages)
                {
                    printDocument.PrintController = new StandardPrintController();
                    printDocument.Print();

                    if (bmp != null) // Ensure bmp is not null
                    {
                        using (var pdfBmp = new Bitmap(printDocument.DefaultPageSettings.Bounds.Width, printDocument.DefaultPageSettings.Bounds.Height))
                        {
                            using (var g = Graphics.FromImage(pdfBmp))
                            {
                                g.DrawImageUnscaled(bmp, 0, 0); // Use bmp here
                            }

                            var pdfImage = iTextSharp.text.Image.GetInstance(pdfBmp, System.Drawing.Imaging.ImageFormat.Bmp);
                            document.Add(pdfImage);
                        }

                        bmp.Dispose(); // Dispose of bmp after using it
                        bmp = null; // Set bmp to null after disposing
                    }

                    // Check if we need to add another page
                    hasMorePages = pageNumber < 2;
                    if (hasMorePages)
                    {
                        document.NewPage();
                    }
                }

                document.Close();
            }

            // Reset pageNumber for the next print job
            pageNumber = 0;

            // Unsubscribe from the PrintPage event to prevent multiple subscriptions
            printDocument.PrintPage -= (s, ev) => { };
        }




        private void Print_Button_Click(object sender, EventArgs e)
        {
            if (Copies_NumUpDown.Value > 0)
            {
                for (int i = 0; i < Copies_NumUpDown.Value; i++)
                {
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Please set the number of copies to at least 1.", "Invalid Number of Copies", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Existing event handlers
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Add your logic here if needed
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {
            // Add your logic here if needed
        }
    }
}