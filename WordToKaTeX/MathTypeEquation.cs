using Microsoft.Office.Interop.Word;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using DataFormats = System.Windows.Forms.DataFormats;
using IOleObject = Microsoft.VisualStudio.OLE.Interop.IOleObject;
using OLECLOSE = Microsoft.VisualStudio.OLE.Interop.OLECLOSE;


namespace IterateWordEquations
{
    /// <summary>
    /// A MathType equation object as embedded in Word documents
    /// </summary>
    class MathTypeEquation : IDisposable
    {
        #region Public properties and methods

        /// <summary>
        /// Activate a MathType OLE object. This should be used in a <code>using</code> statement.
        /// </summary>
        /// <param name="oleFormat">OLE object from Microsoft Word</param>
        public MathTypeEquation(OLEFormat oleFormat)
        {
            oleFormat.DoVerb(2); // Activate MathType and update the equation object according to the current MathType version.
            oleObject  = oleFormat.Object as IOleObject;
            dataObject = oleObject as IDataObject;
        }

        /// <summary>
        /// Get/Set default LaTeX from/to MathType.
        /// </summary>
        public string LaTeX
        {
            get {
                return Encoding.ASCII.GetString(GetData(FormatTeXInputLanguage, TYMED.TYMED_HGLOBAL));
                    }
            set {
                SetData(Encoding.Unicode.GetBytes(value), FormatTeXInputLanguage, TYMED.TYMED_HGLOBAL);
            }
        }

        public string AMSTeX
        {
            get
            {
                return Encoding.ASCII.GetString(GetData(FormatAMSTeX, TYMED.TYMED_HGLOBAL));
            }
            set
            {
                SetData(Encoding.Unicode.GetBytes(value), FormatAMSTeX, TYMED.TYMED_HGLOBAL);
            }
        }
        /// <summary>
        /// Get/Set default MathML from/to MathType.
        /// </summary>
        public string MathML
        {
            get
            {
                return Encoding.ASCII.GetString(GetData(FormatMathMl, TYMED.TYMED_HGLOBAL));
            }
            set { SetData(Encoding.Unicode.GetBytes(value), FormatMathMl, TYMED.TYMED_HGLOBAL); }
        }

        /// <summary>
        /// Get/Set MTEF from/to MathType.
        /// </summary>
        public byte[] MTEF
        {
            get {
                return GetData(FormatMTEF, TYMED.TYMED_ISTORAGE);
                    }
            set { SetData(value, FormatMTEF, TYMED.TYMED_ISTORAGE); }
        }

        #endregion Public properties and methods

        #region Private fields

        private IOleObject oleObject;
        private IDataObject dataObject;

        private const string FormatOle1Native			= "Native";
        private const string FormatOwnerLink			= "OwnerLink";
        private const string FormatRtf					= "Rich Text Format";
        private const string FormatMTEF					= "MathType EF";
        private const string FormatMacPict				= "Mac PICT";
        private const string FormatEmbeddedSource		= "Embed Source";
        private const string FormatObjectDescriptor		= "Object Descriptor";
        private const string FormatLinkSourceDescriptor	= "Link Source Descriptor";
        private const string FormatEmbeddedObject		= "Embedded Object";
        private const string FormatMtMacro				= "MathType Macro";
        private const string FormatHtml				    = "HTML Format";
        private const string FormatMacroPict			= "MathType Macro PICT";
        private const string FormatMathMlPresentation   = "MathML Presentation";
        private const string FormatMathMl				= "MathML";
        private const string FormatAMSTeX               = "AMS-LaTeX";
        private const string FormatMathMlMime			= "application/mathml+xml";
        private const string FormatTeXInputLanguage		= "TeX Input Language";
        private const string FormatUrl					= "UniformResourceLocatorW";
        #endregion Private fields

        #region Private methods
        private byte[] GetData(string formatName, TYMED tymed)
        {
            FORMATETC format = new FORMATETC
            {
                cfFormat = (short)DataFormats.GetFormat(formatName).Id,
                dwAspect = DVASPECT.DVASPECT_CONTENT,
                lindex = -1,
                ptd = (IntPtr)0,
                tymed = tymed
            };

            STGMEDIUM medium = new STGMEDIUM
            {
                tymed = TYMED.TYMED_NULL,
                pUnkForRelease = 0
            };

            dataObject.GetData(ref format, out medium);

            HandleRef handleRef = new HandleRef(null, medium.unionmember);

            try
            {
                IntPtr ptrToHandle = GlobalLock(handleRef);
                int length = GlobalSize(handleRef);
                byte[] data = new byte[length];
                Marshal.Copy(ptrToHandle, data, 0, length);
                return data;
            }
            finally
            {
                GlobalUnlock(handleRef);
            }
        }

        private void SetData(byte[] data, string formatName, TYMED tymed)
        {
            IntPtr ptrToHandle = Marshal.AllocHGlobal(data.Length);

            try
            {
                Marshal.Copy(data, 0, ptrToHandle, data.Length);

                FORMATETC format = new FORMATETC
                {
                    cfFormat = (short)DataFormats.GetFormat(formatName).Id,
                    dwAspect = DVASPECT.DVASPECT_CONTENT,
                    lindex = -1,
                    ptd = (IntPtr)0,
                    tymed = tymed
                };

                STGMEDIUM medium = new STGMEDIUM
                {
                    unionmember = ptrToHandle,
                    tymed = TYMED.TYMED_HGLOBAL,
                    pUnkForRelease = 0
                };

                dataObject.SetData(ref format, ref medium, false);
            }
            finally
            {
                Marshal.FreeHGlobal(ptrToHandle);
            }
        }
        #endregion Private methods

        #region IDisposable implementation
        public void Dispose()
        {
            oleObject.Close((uint)OLECLOSE.OLECLOSE_SAVEIFDIRTY);
           // Console.WriteLine("MathType Object Disposed!");
            
        }
        #endregion IDisposable implementation

        #region Kernel32 function calls
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GlobalLock(HandleRef handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        private static extern bool GlobalUnlock(HandleRef handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        private static extern int GlobalSize(HandleRef handle);

        #endregion Kernel32 function calls
    }
}
