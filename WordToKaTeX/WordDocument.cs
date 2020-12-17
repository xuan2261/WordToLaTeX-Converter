using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;



namespace IterateWordEquations
{
    /// <summary>
    /// A Microsoft Word Document
    /// </summary>
    class WordDocument : IDisposable
    {
        /// <summary>
        /// Open a Microsoft Word document
        /// </summary>
        /// <param name="documentPath">Path to a Microsoft Word document</param>
        public WordDocument(string documentPath, bool readOnly = true)
        {
            saveChanges = !readOnly;
            application = new Application();
            document    = application.Documents.Open(documentPath, ReadOnly: readOnly);
            
        }

        /// <summary>
        /// Enumerate all embeded MathType equation objects
        /// </summary>
        public IEnumerable<OLEFormat> Equations
        {
            get
            {
                return from InlineShape shape in document.InlineShapes 
                where shape.OLEFormat.ProgID.StartsWith("Equation.")
                select shape.OLEFormat;
            }
        }

        public IEnumerable<Section> Sections { get; internal set; }

        public IEnumerable<Paragraph> Paragraphs { get; internal set; }

        #region Private fields

        bool saveChanges;
        Application application;
        Document document;

        #endregion Private fields

        #region IDisposable implementation
        public void Dispose()
        {
            document.Close(SaveChanges: saveChanges);
            application.Quit(SaveChanges: saveChanges);
        }
        #endregion IDisposable implementation
    }
}
