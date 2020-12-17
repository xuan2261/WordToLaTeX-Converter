using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using IterateWordEquations;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using Sys = System.IO;
using System.Text.RegularExpressions;
using MSWord = Microsoft.Office.Interop.Word;
using System.IO.Compression;

namespace WordToKaTeX
{
    

    public partial class WordToLaTeX : Form
    {
        
        string MathMLPath;
        string outputSolutionPath;
        string inputSolutionPath;
        string fpath;
        public WordToLaTeX()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            statusBox.Clear();
            ExtractMathTypes();
            MessageBox.Show("Done!","Word To LaTeX Converter");
        }
        

        public void ExtractMathTypes()
        {
            statusLabel.Text = "Converting MathType Equations To LaTeX...";
            inputSolutionPath = inputPathTextBox.Text + @"\";
            outputSolutionPath = outputPathTextBox.Text + @"\";
            fpath = inputSolutionPath.ToString();
            MathMLPath = fpath;
            int count;
            int fileCounter = 0;
            try
            {
                string logPath = outputSolutionPath + "/Done Files/Logs";

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                DirectoryInfo di = new DirectoryInfo(MathMLPath);

                int tFiles = di.GetFiles("*.docx", SearchOption.AllDirectories).Length;
                //int tFiles = Directory.GetFiles(MathMLPath,".docx").Length;
                string[] allfiles = Directory.GetFiles(MathMLPath, "*.docx", SearchOption.AllDirectories);

                MSWord.Application app = new MSWord.Application();
                statusBar.Maximum = tFiles;
                statusBar.Minimum = 0;

                using (StreamWriter er = new StreamWriter(logPath + "/" + "MathType-Error-Log.csv"))
                {

                    using (StreamWriter lr = new StreamWriter(logPath + "/" + "MathType-Conversion-Log.csv"))
                    {
                        DateTime now = DateTime.Now;
                        lr.WriteLine("Word to LaTeX - V-0.2.0.0");
                        //lr.WriteLine("Book code, Folder name,Number of files converted to KaTeX,Start time,End Time");
                        lr.WriteLine("Process start time:," + now.ToString("F"));
                        //lr.WriteLine("------------------------------------------------------------------");
                        foreach (string file in allfiles)
                        {
                            Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                            List<string> mathMLList = new List<string>();
                            List<string> KatexList = new List<string>();
                            fileCounter += 1;
                            statusBar.Value = fileCounter;
                           // mathMLList.Clear();
                            try
                            {
                                MSWord.Document doc = app.Documents.Open(file, ReadOnly: false);
                                statusBox.AppendText(Path.GetFileName(file).ToString().Replace(".docx", "").ToString() + "-" + "(" + fileCounter.ToString() + " of " + tFiles.ToString() + ")" + "-");
                                count = 0;
                                List<MSWord.Range> ranges = new List<Microsoft.Office.Interop.Word.Range>();
                               // ranges.Clear();
                                
                                foreach (MSWord.Section sec in doc.Sections)
                                {
                                    foreach (MSWord.Paragraph para in sec.Range.Paragraphs)
                                    {
                                        foreach (InlineShape ishape in para.Range.InlineShapes)
                                        {
                                            Boolean isMathType = false;
                                            Boolean isDelete = false;
                                            try
                                            {
                                                if (ishape.OLEFormat.ProgID.StartsWith("Equation."))
                                                {
                                                    try
                                                    {
                                                        MathTypeEquation mobj = new MathTypeEquation(ishape.OLEFormat);
                                                        
                                                        mathMLList.Add(mobj.LaTeX);
                                                        while(isMathType==false)
                                                        {
                                                            mobj.Dispose();
                                                            isMathType = true;
                                                        }

                                                        while(isMathType == true && isDelete == false)
                                                        {
                                                            ranges.Add(ishape.Range);
                                                            ishape.Delete();
                                                            isDelete = true;
                                                        }
                                                        count++;
                                                    }
                                                    catch (NullReferenceException exce)
                                                    {

                                                        continue;
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        //Console.WriteLine(ex.ToString());
                                                       // MessageBox.Show(ex.ToString() + Environment.NewLine + count.ToString());
                                                    }
                                                }
                                            }
                                            catch (NullReferenceException exce)
                                            {
                                                continue;
                                            }
                                            catch (Exception ex)
                                            {
                                                continue;
                                            }
                                        }

                                    }
                                    
                                    foreach (Process process in Process.GetProcessesByName("MathType"))
                                    {                                                                          
                                        process.Kill();
                                    }
                                }

                               

                                foreach (string item in mathMLList)
                                {
                                    string citem = item.ToString().Replace(Environment.NewLine, "").Replace(@"\[", @"$$").Replace(@"\]", @"$$");
                                    KatexList.Add(citem);
                                }

                                //---------------
                                int mcount = 0;
                                foreach (MSWord.Range r in ranges)
                                {
                                    r.Text = KatexList[mcount].ToString();
                                    
                                    mcount++;
                                }


                                lr.WriteLine(Path.GetFileName(file).ToString().Replace(".docx", "") + "," + count.ToString() + " MathType(s) Converted.");
                                statusBox.AppendText(count.ToString() + " MathType(s) Converted." + Environment.NewLine);


                                string tempPath = outputSolutionPath + "Done Files\\";

                                string tempFilePath = tempPath + Path.GetFileName(Path.GetDirectoryName(file));
                                if (!Directory.Exists(tempFilePath))
                                    Directory.CreateDirectory(tempFilePath);

                                doc.SaveAs2(tempFilePath + @"\" + Path.GetFileName(file));
                                doc.Close();
                                
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show(ex.ToString());
                                statusBox.AppendText(ex.Message.ToString() + Environment.NewLine);
                            }
                        }
                        //lr.WriteLine("------------------------------------------------------------------");
                        lr.WriteLine("Total files processed:," + tFiles.ToString());
                        //lr.WriteLine("------------------------------------------------------------------");
                        DateTime now1 = DateTime.Now;
                        lr.WriteLine("Process end time:," + now1.ToString("F"));
                        //lr.WriteLine("------------------------------------------------------------------");
                        lr.WriteLine("");
                        lr.WriteLine("For any query regarding LaTeX/KaTeX, please write to chandan.kumar@evelynlearning.com");
                        lr.Close();
                    }
                    er.WriteLine("");
                    //er.WriteLine("------------------------------------------------------------------");
                    er.WriteLine("For any query regarding LaTeX/KaTeX, please write to chandan.kumar@evelynlearning.com");
                    er.Close();
                }

                app.Quit();

            }
            catch { }
            //MessageBox.Show("MathType Conversion Done" + Environment.NewLine + @"click on ""Go Back"" button.", "Latex Converter");
            Console.ReadLine();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void WordToKaTeX_Load(Object sender, EventArgs e)
        {
            statusLabel.Text = "";
            //nonChemistry.Checked = true;
            statusBox.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            statusBox.Clear();
            statusLabel.Text = "Zipping directories....";
            string fpath = zipPathTextBox.Text;
            string[] subdirectoryEntries = Directory.GetDirectories(fpath);
            int dirCount = subdirectoryEntries.Length;
            statusBar.Minimum = 0;
            statusBar.Maximum = dirCount;
            int dirCounter = 0;
            foreach (string subdirectory in subdirectoryEntries)
            {
                dirCounter += 1;
                statusBar.Value = dirCounter;
                string startPath = subdirectory;
                string zipPath = subdirectory + ".zip";//URL for your ZIP file
                
                try
                {
                    ZipFile.CreateFromDirectory(startPath, zipPath);
                }
                catch (System.IO.IOException )
                {
                    continue;
                   
                }
                //statusBox.AppendText(Path.GetFileName(subdirectory) + ": File(s) open in this directory. Retry after closing the file(s)." + Environment.NewLine);


                // ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);
                //int count = Directory.GetFiles(subdirectory, "*.docx", SearchOption.AllDirectories).Length;
                statusBox.AppendText(Path.GetFileName(subdirectory) + Environment.NewLine);
            }
            MessageBox.Show("Zipping Done!");
        }
    }
}
