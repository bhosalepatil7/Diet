using EvoPdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GNHClientUI
{
    public partial class PrintForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnFileName.Value = Request.QueryString["FileName"];
            }
        }

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{
        //    string urlToConvert = string.Empty;

        //    PdfConverter pdfConverter = new PdfConverter();

        //    pdfConverter.EvoInternalFileName = System.AppDomain.CurrentDomain.BaseDirectory + "bin\\evointernal.dat";
        //    //pdfConverter.EvoInternalFileName = @"G:\PleskVhosts\geetanutriheal.com\app\bin\evointernal.dat";

        //    pdfConverter.LicenseKey = "831ufGlsfGprfGlybHxvbXJtbnJlZWVl";
        //    pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
        //    pdfConverter.PdfDocumentOptions.RightMargin = 30;
        //    pdfConverter.PdfDocumentOptions.LeftMargin = 30;
        //    pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.NoCompression;
        //    pdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
        //    //  pdfConverter.RenderedHtmlElementSelector = "#divcontener";

        //    pdfConverter.PdfFooterOptions.FooterHeight = 55;
        //    //pdfConverter.PdfFooterOptions.AddElement(footerHtml);
        //    pdfConverter.PdfDocumentOptions.ShowHeader = true;
        //    pdfConverter.PdfDocumentOptions.ShowFooter = true;
        //    pdfConverter.PdfDocumentOptions.FitWidth = true;
        //    pdfConverter.PdfDocumentOptions.EmbedFonts = true;
        //    pdfConverter.JavaScriptEnabled = true;
        //    pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = true;
        //    pdfConverter.PdfDocumentOptions.AvoidImageBreak = true;
        //    pdfConverter.ConversionDelay = 3;

        //    /////////////////////////////////////////

        //    // Optionally add a space between header and the page body
        //    // The spacing for first page and the subsequent pages can be set independently
        //    // Leave this option not set for no spacing
        //    pdfConverter.PdfDocumentOptions.Y = float.Parse("5");
        //    pdfConverter.PdfDocumentOptions.TopSpacing = float.Parse("5");

        //    // Draw header elements
        //    if (pdfConverter.PdfDocumentOptions.ShowHeader)
        //        DrawHeader(pdfConverter, true);

        //    // Draw footer elements
        //    if (pdfConverter.PdfDocumentOptions.ShowFooter)
        //        DrawFooter(pdfConverter, false, true);

        //    ////////////////////////////////////////

        //    urlToConvert = Request.Url.AbsoluteUri;

        //    string fileName = Convert.ToString(Request.QueryString["FileName"] ?? "EmptyFile");
        //    string rptHtmlFile = System.AppDomain.CurrentDomain.BaseDirectory + "Download/" + fileName + ".htm";
        //    string htmlRptString = string.Empty;

        //    if (hdnEditedContents.Value != "EMPTY")
        //    {
        //        XElement xEditableContents = XElement.Parse(HttpUtility.HtmlDecode(hdnEditedContents.Value) ?? string.Empty);

        //        IEnumerable<XElement> editableFields = xEditableContents.Elements();

        //        string supplement = string.Empty;
        //        string investigation = string.Empty;

        //        foreach (var field in editableFields)
        //        {
        //            if (field.Name == "Supplements")
        //            {
        //                supplement = field.Value;
        //            }

        //            if (field.Name == "Investigations")
        //            {
        //                investigation = field.Value;
        //            }

        //        }

        //        if ((supplement != string.Empty || investigation != string.Empty) && File.Exists(rptHtmlFile))
        //        {
        //            //Read the contents of existing rpt template file
        //            htmlRptString = File.ReadAllText(rptHtmlFile);

        //            //Modify edited contents
        //            if (xEditableContents.Value != string.Empty)
        //            {
        //                htmlRptString = htmlRptString.Replace("{SUPPLEMENTS}", supplement).Replace("{INVESTIGATION}", investigation);
        //            }

        //            //Delete the existing rpt file because contents need to be changed
        //            if (File.Exists(rptHtmlFile))
        //                File.Delete(rptHtmlFile);

        //            //Create updated rpt file
        //            using (StreamWriter Sw = File.CreateText(rptHtmlFile))
        //            {
        //                Sw.WriteLine(htmlRptString);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //Read the contents of existing rpt template file
        //        htmlRptString = File.ReadAllText(rptHtmlFile);

        //        //Delete the existing rpt file because contents need to be changed
        //        if (File.Exists(rptHtmlFile))
        //            File.Delete(rptHtmlFile);

        //        //Create updated rpt file
        //        using (StreamWriter Sw = File.CreateText(rptHtmlFile))
        //        {
        //            Sw.WriteLine(htmlRptString.Replace("{SUPPLEMENTS}", "").Replace("{INVESTIGATION}", ""));
        //        }

        //    }



        //    //byte[] pdfBytes = pdfConverter.GetPdfBytesFromUrl(urlToConvert);
        //    byte[] pdfBytes = pdfConverter.GetPdfBytesFromUrl(rptHtmlFile);

        //    //Clean report file once downloaded
        //    //if (File.Exists(rptHtmlFile))
        //    //    File.Delete(rptHtmlFile);



        //    HttpResponse httpResponse = HttpContext.Current.Response;
        //    httpResponse.AddHeader("Content-Type", "application/pdf");
        //    httpResponse.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".pdf");
        //    httpResponse.BinaryWrite(pdfBytes);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //    //string downLoadFileName = reportLabel.Replace(" ", "_") + "_" + Convert.ToString(dtReportInfo.Rows[0]["ProjectName"]).Replace(" ", "_") + "_" + month.Trim() + "_" + (DateTime.Now).ToString("dd_MM_yyyy_HH_mm").Trim() + ".pdf";

        //    //byte[] pdfBytes = pdfConverter.GetPdfBytesFromUrl(htmlToConvert);

        //    //StringBuilder readText = new StringBuilder();
        //    ////readText.Append(File.ReadAllText("Report-Test.htm"));          


        //    //readText.Append("<html><body>");
        //    ////string html = ReportData.InnerHtml;
        //    //StringWriter sw = new StringWriter();
        //    //HtmlTextWriter w = new HtmlTextWriter(sw);
        //    //ReportData.RenderControl(w);
        //    //string html = sw.GetStringBuilder().ToString();

        //    //HtmlDocument doc = new HtmlDocument();
        //    //doc.LoadHtml(html);
        //    //string whatUrLookingFor = doc.DocumentNode.SelectNodes("div[@id='ReportData']").First().InnerHtml;
        //    //readText.Append(html);
        //    //readText.Append("<body></html>");

        //    //string temp = readText.ToString();
        //    //string dir = System.IO.Directory.GetCurrentDirectory();

        //    //string file = "Test" + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm");


        //    //using (StreamWriter swReport = new StreamWriter(file + ".html"))
        //    //{
        //    //    swReport.Write(html);
        //    //}


        //    ////pdfConverter.SavePdfFromHtmlFileToFile(dir+"\\Report-Test.htm", file+".pdf");
        //    //pdfConverter.SavePdfFromHtmlFileToFile(dir + "\\" + file + ".html", file + ".pdf");


        //    //pdfConverter.ConvertUrlToPdfDocumentObject("Report-Test.htm");
        //    //pdfConverter.ConvertHtmlFileToPdfDocumentObject("Report-Test.htm");
        //    //pdfConverter.SavePdfFromHtmlStringToFile(temp, "Test2.pdf");

        //}

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string urlToConvert = string.Empty;

            string fileName = Convert.ToString(Request.QueryString["FileName"] ?? "EmptyFile");
            string rptHtmlFile = System.AppDomain.CurrentDomain.BaseDirectory + "Download/" + fileName + ".htm";
            string htmlRptString = string.Empty;

            if (hdnEditedContents.Value != "EMPTY")
            {
                XElement xEditableContents = XElement.Parse(HttpUtility.HtmlDecode(hdnEditedContents.Value) ?? string.Empty);

                IEnumerable<XElement> editableFields = xEditableContents.Elements();

                string supplement = string.Empty;
                string investigation = string.Empty;

                foreach (var field in editableFields)
                {
                    if (field.Name == "Supplements")
                    {
                        supplement = field.Value;
                    }

                    if (field.Name == "Investigations")
                    {
                        investigation = field.Value;
                    }

                }

                if ((supplement != string.Empty || investigation != string.Empty) && File.Exists(rptHtmlFile))
                {
                    //Read the contents of existing rpt template file
                    htmlRptString = File.ReadAllText(rptHtmlFile);

                    //Modify edited contents
                    if (xEditableContents.Value != string.Empty)
                    {
                        htmlRptString = htmlRptString.Replace("{SUPPLEMENTS}", supplement).Replace("{INVESTIGATION}", investigation);
                    }

                    //Delete the existing rpt file because contents need to be changed
                    if (File.Exists(rptHtmlFile))
                        File.Delete(rptHtmlFile);

                    //Create updated rpt file
                    using (StreamWriter Sw = File.CreateText(rptHtmlFile))
                    {
                        Sw.WriteLine(htmlRptString);
                    }
                }
            }
            else
            {
                //Read the contents of existing rpt template file
                htmlRptString = File.ReadAllText(rptHtmlFile);

                //Delete the existing rpt file because contents need to be changed
                if (File.Exists(rptHtmlFile))
                    File.Delete(rptHtmlFile);

                //Create updated rpt file
                using (StreamWriter Sw = File.CreateText(rptHtmlFile))
                {
                    Sw.WriteLine(htmlRptString.Replace("{SUPPLEMENTS}", "").Replace("{INVESTIGATION}", ""));
                }

            }



            HttpResponse httpResponse = HttpContext.Current.Response;
            httpResponse.AddHeader("Content-Type", "text/HTML");
            //httpResponse.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".pdf");
            httpResponse.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".htm");
            //httpResponse.BinaryWrite(pdfBytes);
            httpResponse.WriteFile(rptHtmlFile);
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            httpResponse.End();

        }
        /// <summary>
        /// Draw the header elements
        /// </summary>
        /// <param name="htmlToPdfConverter">The HTML to PDF Converter object</param>
        /// <param name="drawHeaderLine">A flag indicating if a line should be drawn at the bottom of the header</param>
        //private void DrawHeader(HtmlToPdfConverter htmlToPdfConverter, bool drawHeaderLine)
        //{
        //    string headerHtmlUrl = Server.MapPath("~/Download/HTML_Files/Header_HTML.html");

        //    // Set the header height in points
        //    htmlToPdfConverter.PdfHeaderOptions.HeaderHeight = 60;

        //    // Set header background color
        //    htmlToPdfConverter.PdfHeaderOptions.HeaderBackColor = Color.White;

        //    // Create a HTML element to be added in header
        //    HtmlToPdfElement headerHtml = new HtmlToPdfElement(headerHtmlUrl);

        //    // Set the HTML element to fit the container height
        //    headerHtml.FitHeight = true;

        //    // Add HTML element to header
        //    htmlToPdfConverter.PdfHeaderOptions.AddElement(headerHtml);

        //    if (drawHeaderLine)
        //    {
        //        // Calculate the header width based on PDF page size and margins
        //        float headerWidth = htmlToPdfConverter.PdfDocumentOptions.PdfPageSize.Width -
        //                    htmlToPdfConverter.PdfDocumentOptions.LeftMargin - htmlToPdfConverter.PdfDocumentOptions.RightMargin;

        //        // Calculate header height
        //        float headerHeight = htmlToPdfConverter.PdfHeaderOptions.HeaderHeight;

        //        // Create a line element for the bottom of the header
        //        LineElement headerLine = new LineElement(0, headerHeight - 1, headerWidth, headerHeight - 1);

        //        // Set line color
        //        headerLine.ForeColor = Color.Gray;

        //        // Add line element to the bottom of the header
        //        htmlToPdfConverter.PdfHeaderOptions.AddElement(headerLine);
        //    }
        //}

        ///// <summary>
        ///// Draw the footer elements
        ///// </summary>
        ///// <param name="htmlToPdfConverter">The HTML to PDF Converter object</param>
        ///// <param name="addPageNumbers">A flag indicating if the page numbering is present in footer</param>
        ///// <param name="drawFooterLine">A flag indicating if a line should be drawn at the top of the footer</param>
        //private void DrawFooter(HtmlToPdfConverter htmlToPdfConverter, bool addPageNumbers, bool drawFooterLine)
        //{
        //    string footerHtmlUrl = Server.MapPath("~/Download/HTML_Files/Footer_HTML.html");

        //    // Set the footer height in points
        //    htmlToPdfConverter.PdfFooterOptions.FooterHeight = 60;

        //    // Set footer background color
        //    //htmlToPdfConverter.PdfFooterOptions.FooterBackColor = Color.WhiteSmoke;

        //    // Create a HTML element to be added in footer
        //    HtmlToPdfElement footerHtml = new HtmlToPdfElement(footerHtmlUrl);

        //    // Set the HTML element to fit the container height
        //    footerHtml.FitHeight = true;

        //    // Add HTML element to footer
        //    htmlToPdfConverter.PdfFooterOptions.AddElement(footerHtml);

        //    // Add page numbering
        //    if (addPageNumbers)
        //    {
        //        // Create a text element with page numbering place holders &p; and & P;
        //        TextElement footerText = new TextElement(0, 30, "Page &p; of &P;  ",
        //            new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

        //        // Align the text at the right of the footer
        //        footerText.TextAlign = HorizontalTextAlign.Right;

        //        // Set page numbering text color
        //        footerText.ForeColor = Color.Navy;

        //        // Embed the text element font in PDF
        //        footerText.EmbedSysFont = true;

        //        // Add the text element to footer
        //        htmlToPdfConverter.PdfFooterOptions.AddElement(footerText);
        //    }

        //    if (drawFooterLine)
        //    {
        //        // Calculate the footer width based on PDF page size and margins
        //        float footerWidth = htmlToPdfConverter.PdfDocumentOptions.PdfPageSize.Width -
        //                    htmlToPdfConverter.PdfDocumentOptions.LeftMargin - htmlToPdfConverter.PdfDocumentOptions.RightMargin;

        //        // Create a line element for the top of the footer
        //        LineElement footerLine = new LineElement(0, 0, footerWidth, 0);

        //        // Set line color
        //        footerLine.ForeColor = Color.Gray;

        //        // Add line element to the bottom of the footer
        //        htmlToPdfConverter.PdfFooterOptions.AddElement(footerLine);
        //    }
        //}
    }
}