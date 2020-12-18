# WordToLaTeX-Converter

The Evelyn Learning has various project in which the MathType equations has to be converted to their corresponding LaTeX codes to proceed further. To do so, WordToLaTeX1.0 software has been developed which does exactly the same.
Writing manual LaTeX code may take a lot of the valuable time and is not easy implement for a huge number of files.
WordToLaTeX1.0  does exactly the same with ease and save the time and effort of the responsible. This takes a bunch of documents as input and produce documents with all the MathType equations converted to KaTeX codes at their corresponding locations in the document file.
This project extends the functionality of the content creation process at Evelyn.

## [LaTeX](https://www.latex-project.org/)
LaTeX is a high-quality typesetting system; it includes features designed for the production of technical and scientific documentation. LaTeX is the de facto standard for the communication and publication of scientific documents. LaTeX is available as free software.

LaTeX, which is pronounced «Lah-tech» or «Lay-tech» (to rhyme with «blech» or «Bertolt Brecht»), is a document preparation system for high-quality typesetting. It is most often used for medium-to-large technical or scientific documents but it can be used for almost any form of publishing.

LaTeX is not a word processor! Instead, LaTeX encourages authors not to worry too much about the appearance of their documents but to concentrate on getting the right content. For example, consider this document:
```
Cartesian closed categories and the price of eggs
Jane Doe
September 1994
Hello world!
```
To produce this in most typesetting or word-processing systems, the author would have to decide what layout to use, so would select (say) 18pt Times Roman for the title, 12pt Times Italic for the name, and so on. This has two results: authors wasting their time with designs; and a lot of badly designed documents!

LaTeX is based on the idea that it is better to leave document design to document designers, and to let authors get on with writing documents. So, in LaTeX you would input this document as:
```
\documentclass{article}
\title{Cartesian closed categories and the price of eggs}
\author{Jane Doe}
\date{September 1994}
\begin{document}
   \maketitle
   Hello world!
\end{document}
```
## LaTeX Features
- Typesetting journal articles, technical reports, books, and slide presentations.
- Control over large documents containing sectioning, cross-references, tables and figures.
- Typesetting of complex mathematical formulas.
- Advanced typesetting of mathematics with AMS-LaTeX.
- Automatic generation of bibliographies and indexes.
- Multi-lingual typesetting.
- Inclusion of artwork, and process or spot colour.
- Using PostScript or Metafont fonts.

## [MathType SDK](https://docs.wiris.com/en/mathtype/mathtype_desktop/mathtype-sdk)
The MathType SDK is primarily for developers who want to explore the advanced capabilities of MathType. The SDK also includes documentation about equation formats and other related information. The MathType SDK is available to developers who:

* want to customize the special commands that MathType installs into Microsoft Word
* want documentation for MathType's DLL interface
* want to modify MathType's translators or create their own translators
* want to extend MathType's knowledge of fonts and characters
* want to make their product "equation-friendly" by aligning imported equations with the baseline of surrounding text

The MathType SDK is available for both Windows and Mac and has been updated to the latest releases, 6.9 for Windows, 6.7 for Mac. There are no changes for MathType 7.x.

## WordToLaTeX1.0 Getting Started!
The WordToLaTeX1.0 has the following dependencies:
| Programming language | C#.NET |
| ------ | ------ |
|Object Librariy | Microsoft.Office.Interop.Word |
|Compression| System.IO.Compression |
|SDK | [MathType SDK](https://docs.wiris.com/en/mathtype/mathtype_desktop/mathtype-sdk)|
|System Environment | Windows 10 |
|MathType Software | 7.x+ Licensed |
|Microsoft Office | 16+ |
|.NET Framework | 4.0+|
|IDE | Visual Studio 17 Pro |

### MathType SDK Introduction

The MathType API consists of a WLL, two Microsoft Word document templates containing VBA macros, and a separate DLL (on Windows only).

On Windows, the DLL is named MT6.DLL and is located in the System folder inside the MathType folder. This DLL manages all communications with MathType itself, launching MathType when necessary. Most of the functions in the DLL provide support for the MathType commands added to Word. All API functions in MT6.DLL begin with the prefix MT.

The WLL (basically a DLL with some Word-specific entry points) is named MathPage.WLL. On Windows, it is installed in the Office Startup folder. For the MathType 6 Word Commands on Windows, all entry points to the DLL are accessed via the WLL. This is partly due to the way VBA code calls functions in a DLL, and partly because a single entry-point makes for a cleaner architecture. We recommend that you follow this model. The WLL contains the MathPage functions (prefixed by MP), which help in converting a Word document to HTML. This is a fairly complicated process and you're unlikely to use any of the individual MathPage functions. The WLL also contains other functions used by the MathType Commands for Word; these functions begin with the MT prefix.

There are two Word templates located in the Office Support folder inside the MathType folder: the stub, named MathType 6 Commands for Word.dot; and the commands, named WordCmds.dot. The stub template is also copied to the Microsoft Word Startup location during installation, and gets loaded when Word starts. The first time a MathType command is used in Word, the commands template is explicitly loaded from the Office Support folder inside the MathType folder. These two templates are used in this manner in order to avoid long Word startup times. The stub template has been kept as small as possible so that a minimal delay will occur when Word starts. The commands template takes a few seconds to load; users only pay this price the first time they use any MathType command. The stub contains handlers for each toolbar button and menu command; each of them loads the commands template if it isn't loaded yet, and then calls a function in the commands template that actually does the work. If you want to call your own function in the WordCmds.dot template, be sure to use the same kind of handler as the existing commands. The handler functions not only verify the correct versions of the WLLs and load the WordCmds.dot template, they also call some initialization routines that are necessary for the API functions to work.

The best way to understand how a particular command works is to follow through the VBA code. The SDK contains unlocked copies of these templates so that you can see the code. It contains comments which should make it easier to understand. The file MT6SDK.dot (in the SDK's templates folder) contains some additional functions that may be useful if you want to suppress the dialogs that normally appear during Format, Convert, Export and Toggle Equations. See the MathType Commands For Word API for details.

Two sample templates are provided: SDKTest.dot and MTVarSub.dot. The first template,SDKTest.dot, contains examples of how to call Format, Convert, Export and Toggle Equations non-interactively, as well as a simple search-and-replace example. MTVarSub.dot shows the many variations possible for search-and-replace, a.k.a variable substitution.  To avoid problems with macro security in Word 2000 and above on Windows, set your security level to Medium or Low, since these macros are unsigned.You must create a reference to MT6SDK.dot before running any of the test macros in these two templates. To do this, switch to the Visual Basic Editor via ALT-F11 on Windows and select Tools|References, then select MT6SDK.dot from the list. If it is not in the list, use the Browse button to locate it in the templates folder inside the SDK folder.

### Office locations
The MathType installer places the stub template into the Word Startup folder which, on Windows, varies depending on the version of Office installed. This is a per-machine location as opposed to a per-user location, and Word will use this folder no matter which user is logged on. On Windows, the WLL is also copied to this location. On a Mac, it's a per-user location, and like Windows, varies depending on the version of Office installed.

### MathTypeEquation.cs
MathTypeEquation.cs is a program file containing all the methods to create objects of MathType equations embedded in Word documents. It contains methods to convert the OLEObjects embedded in Word document to LaTeX, AMSTeX,MathML, MTEF, etc. It also contains the methods to create the MathTypeEquation object and to dispose the created object.

To activate a MathType OLE Object, the following is used within MathTypeEquation
```sh
 public MathTypeEquation(OLEFormat oleFormat)
{
    // Activate MathType and update the equation object according to the current MathType version.
    oleFormat.DoVerb(2); 
    oleObject  = oleFormat.Object as IOleObject;
    dataObject = oleObject as IDataObject;
}
```
Get/Set default LaTeX from/to MathType:

```sh
public string LaTeX
{
    get {
        return Encoding.ASCII.GetString(GetData(FormatTeXInputLanguage, TYMED.TYMED_HGLOBAL));
            }
    set {
        SetData(Encoding.Unicode.GetBytes(value), FormatTeXInputLanguage, TYMED.TYMED_HGLOBAL);
    }
}
```
Get/Set default MathML from/to MathType:
```sh
public string MathML
{
    get
    {
        return Encoding.ASCII.GetString(GetData(FormatMathMl, TYMED.TYMED_HGLOBAL));
    }
    set 
    { 
        SetData(Encoding.Unicode.GetBytes(value), FormatMathMl, TYMED.TYMED_HGLOBAL); 
    }
}
```

To Dispose the MathTyepEquation Object:
```sh
public void Dispose()
{
    oleObject.Close((uint)OLECLOSE.OLECLOSE_SAVEIFDIRTY);
}
```

### WordToKaTeX.cs
WordToKaTeX.cs is the driver program which consists of the following two main modules:
* `ExtractMathTypes()`

`ExtractMahTypes()`:
This module extracts all the embedded MathType objects (OLEObjects) form the Word documents in `LaTeX` format by iterating through all the embedded OLEObjects. The OLEObjects are identified if they are MathType equations and later converted to LaTeX. Later the MathType objects are replaced with their converted corresponding LaTeX codes.

To open MS Word file use the following:
```sh 
Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(FileName, ReadOnly: false);
```
Here, FineName is the `FileName` is the path to the file which is supposed to be opened to proceed further. We can iterate over the files using any loop.

This modules uses the following lists in order to store the `LaTeX` code, ` Processed LaTeX` codes and `MathType` objects respectively.
```sh
List<string> mathMLList = new List<string>();
List<string> KatexList = new List<string>();
List<MSWord.Range> ranges = new List<Microsoft.Office.Interop.Word.Range>();
```
To iterate through the oleobjects within a Word file, use the following:
```sh
foreach (MSWord.Section sec in doc.Sections)
{
	foreach (MSWord.Paragraph para in sec.Range.Paragraphs)
	{
		foreach (InlineShape ishape in para.Range.InlineShapes)
		{
			if (ishape.OLEFormat.ProgID.StartsWith("Equation."))
			{
				MathTypeEquation mobj = new MathTypeEquation(ishape.OLEFormat);
				mathMLList.Add(mobj.LaTeX);
				mobj.Dispose();
				ranges.Add(ishape.Range);
				ishape.Delete();
			}
		}
	}
}
```
Here,
* `ishape.OLEFormat.ProgID.StartsWith("Equation.")` checks if the oleobject(`ishape`) is a MathType object.
* `MathTypeEquation mobj = new MathTypeEquation(ishape.OLEFormat)` creates the MathTypeEquation object which need to be converted to `LaTeX`.
* `mobj.LaTeX` converts the MathType object to its corresponding `LaTeX` code. We can use `mobj.MathML` to convert MathType objects to their corresponding `MathML` and `mobj.AMSTeX` to `AMSTeX`.
* `mobj.Dispose()` closes the OLEObject.
* `ranges.Add(ishape.Range)` is adding the current MathType object `ishape` to the `ranges` list for replacing the MathType to their corresponding `KaTeX` code.
* `ishape.Delete()` deletes the object form the Word file.

The following section of the code adds the opening and closing markers to the generated `LaTeX` codes:

```sh
foreach (string item in mathMLList)
{
    string citem = item.ToString().Replace(Environment.NewLine, "").Replace(@"\[", @"$$").Replace(@"\]", @"$$");
    KatexList.Add(citem);
}
```
Here, we have used `$$` as opening and closing markers of the `LaTeX` code. We can use the following as per our requirement:
* `\[` and `\]`
* `\(` and `\)`
* `$` and `$`

To replace the MathType Objects with their corresponding KaTeX codes, use the following:
```sh
int mcount = 0;
foreach (MSWord.Range r in ranges)
{
	r.Text = KatexList[mcount].ToString();
	mcount++;
}
```


This software also includes zipping of directories and files in one go.
To make ZIP of directories in a directory, use the following piece of code:

```sh
string[] subdirectoryEntries = Directory.GetDirectories("path to the root directory");
foreach (string subdirectory in subdirectoryEntries)
{
    string startPath = subdirectory;
    string zipPath = subdirectory + ".zip";
    ZipFile.CreateFromDirectory(startPath, zipPath);
}
```
You need to include the `System.IO.Compression` in references of your project within the VisualStudio.



### Todos

 - Write MORE Tests
 - Updates on new Issues with `LaTeX` codes.

License
----

Evelyn Learning Systems Pvt. Ltd.


**For any query or help, write to `chandan.kumar@evelynlearning.com`.**

[![EvelynLearning](https://evelynlearning.com/wp-content/uploads/2018/08/evelyn-logo-web-1.png)](Https://evelynlearning.com)
