using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace GeetaNeutriHealUtility
{
    public class MsWordUtility
    {
        /*
        object oTrue = true;
            object oFalse = false;
            object oMissing = System.Reflection.Missing.Value;
            object novalue = System.Reflection.Missing.Value;
            object missing = System.Reflection.Missing.Value;
            object fileName = "normal.dot";
            object newTemplate = false;
            object docType = 0;
            object isVisible = true;
            Microsoft.Office.Interop.Word.ApplicationClass questionClient = new Microsoft.Office.Interop.Word.ApplicationClass();


            Microsoft.Office.Interop.Word.Document questionDoc = questionClient.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
            questionDoc.Activate();


            //adding header
            string logoPath = Server.MapPath("~//photos//logica_logo_black.JPG");
            Microsoft.Office.Interop.Word.Shape logoCustom = null;
            questionClient.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekCurrentPageHeader;
            logoCustom = questionClient.Selection.HeaderFooter.Shapes.AddPicture(logoPath, ref oFalse, ref oTrue, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            logoCustom.Select(ref oMissing);
            logoCustom.Name = "CustomLogo";
            logoCustom.Left = -47;
            logoCustom.Top = -19;


            //adding footer
            questionClient.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekCurrentPageFooter;
            questionClient.ActiveWindow.Selection.Font.Name = "Verdana";
            questionClient.ActiveWindow.Selection.Font.Size = 8;
            Object CurrentPage = Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage;
            questionClient.ActiveWindow.Selection.TypeText("For Logica Internal Use Only");
            questionClient.ActiveWindow.Selection.TypeText("                                             ");
            questionClient.ActiveWindow.Selection.TypeText("Page ");
            questionClient.ActiveWindow.Selection.Fields.Add(questionClient.Selection.Range, ref CurrentPage, ref oMissing, ref oMissing);
            questionClient.ActiveWindow.Selection.TypeText("                                                     ");
            questionClient.ActiveWindow.Selection.TypeText(DateTime.Today.ToString("MM/dd/yyyy"));


            //saving and closing the document
            questionClient.Documents.Save(ref oMissing, ref oMissing);
            questionClient.Quit(ref oMissing, ref oMissing, ref oMissing);
         * 
         */
        int noOfFilesProcessed = 0;

        public int NoOfFilesProcessed
        {
            get
            {
                return noOfFilesProcessed;
            }
        }

        public void AddHeaderAndFooterToDocFile()
        {

            try
            {
                //Gets Gnh Utility Process Path
                string gnhAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                string rawReportDirectory = gnhAppPath + @"\Raw\";
                string processedReportDirectory = gnhAppPath + @"\Processed\";

                if (!System.IO.Directory.Exists(rawReportDirectory))
                {
                    System.IO.Directory.CreateDirectory(rawReportDirectory);
                }

                if (!System.IO.Directory.Exists(processedReportDirectory))
                {
                    System.IO.Directory.CreateDirectory(processedReportDirectory);
                }

                object oTrue = true;
                object oFalse = false;
                object oMissing = System.Reflection.Missing.Value;
                object novalue = System.Reflection.Missing.Value;
                object missing = System.Reflection.Missing.Value;
                object gnhHeaderFooterTemplate = gnhAppPath + @"\Template\GNH_Template.doc";
                //object fileName2 = @"C:\Users\ckakdep\Desktop\Interpidians\POC\Subhash\Project\Project\Diet_20170215\Diet\GeetaNeutriHealUtility\Report\Alka_15Feb2017.doc";
                object newTemplate = false;
                object docType = 0;
                object isVisible = true;
                Microsoft.Office.Interop.Word.ApplicationClass questionClient = new Microsoft.Office.Interop.Word.ApplicationClass();


                Microsoft.Office.Interop.Word.Document questionDoc1 = questionClient.Documents.Open(ref gnhHeaderFooterTemplate, ref newTemplate, ref docType, ref isVisible);
                questionDoc1.Activate();

                Console.WriteLine("Report Processing Started");

                foreach (var fileName in System.IO.Directory.GetFiles(rawReportDirectory, "*.doc"))
                {
                    Object fileName2 = fileName;
                    Microsoft.Office.Interop.Word.Document questionDoc2 = questionClient.Documents.Open(ref fileName2, ref newTemplate, ref docType, ref isVisible);
                    questionDoc2.Activate();

                    questionDoc1.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.CopyAsPicture();
                    questionDoc2.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Paste();
                    questionDoc1.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.CopyAsPicture();
                    questionDoc2.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Paste();

                    //saving the document
                    questionDoc2.SaveAs2(fileName2.ToString().Replace("Raw", "Processed"), Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument);
                    questionDoc2.Close(true, oMissing, oMissing);

                    //icrement the processed file count
                    noOfFilesProcessed++;

                }

                //questionDoc2.Save(); // Don't use this to save as it create extra folders while saving word file

                //closing the document
                questionClient.Documents.Save(ref oMissing, ref oMissing);

                //closing word instance
                questionClient.Quit(ref oMissing, ref oMissing, ref oMissing);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured during processing");
                Console.WriteLine("Kill the winword.exe process from task manager and try again or call administrator for assistance");
            }

        }



    }
}
