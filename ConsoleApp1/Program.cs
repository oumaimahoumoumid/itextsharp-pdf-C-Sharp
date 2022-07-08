using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfReader reader = new PdfReader(@"C:\Users\hPro\test2.pdf");
            string newFile = @"C:\Users\hPro\test.pdf";
            Document doc = new Document();
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            PdfContentByte cb = writer.DirectContent;

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                PdfImportedPage page = writer.GetImportedPage(reader, i);
                float pageHeight = reader.GetPageSizeWithRotation(i).Height;
                float pageWidth = reader.GetPageSizeWithRotation(i).Width;

                int rotation = reader.GetPageRotation(i);

                Rectangle pageRectangle = reader.GetPageSizeWithRotation(i);

                Rectangle PageRect = null;

              


                switch (rotation)
                {
                    case 0:
                        PageRect = new Rectangle(pageRectangle.Width, pageRectangle
                                .Height);
                        doc.SetPageSize(PageRect);
                        doc.NewPage();
                        AffineTransform af = new AffineTransform();
                        //af.Scale(1, 0.84f);
                        af.Translate(1, 0);
                        cb.SetColorFill(BaseColor.RED);
                        
                        cb.AddTemplate(page, af);
                        cb.Fill();
                        break;
                }
            }
            doc.Close();
            fs.Close();
            writer.Close();
            reader.Close();
        }
    }
}
