using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFlib_dotnet;

namespace PdfBookmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfFile = @"f:\Dev\PdfBookmarks\PdfBookmarks\PdfBookmarks\bin\Debug\Untitled-1.pdf";


            var bookmarks = GetBookmarks(pdfFile);

            Console.WriteLine($"Found {bookmarks.Length} bookmarks");

            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark);
            }

            Console.Read();
        }

        private static string[] GetBookmarks(string pdfFile)
        {
            var bookmarks = new List<string>();

            var p = new PDFlib();

            var doc = p.open_pdi_document(pdfFile, "");

            int bookmarkCnt = (int) p.pcos_get_number(doc, "length:bookmarks");

            Console.WriteLine($"Pdflib: Count bookmarks: {bookmarkCnt}");

            for (int i = 0; i < bookmarkCnt; i++)
            {
                var bookmark = p.pcos_get_string(doc, "bookmarks[" + i + "]/Title");
                bookmarks.Add(bookmark);
            }


            p.close_pdi_document(doc);

            p.Dispose();

            return bookmarks.ToArray();
        }
    }
}
