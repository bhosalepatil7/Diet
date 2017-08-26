using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test();
        }

        protected void btnYes_Click(object sender, ImageClickEventArgs e)
        {

        }
        private void test()
        {


            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
            strBody.Append("<table border=1 width=90% style='border-collapse: collapse;' bordercolor='black'><tr><td align=center><b>Food Group</b></td><td align=center><b>Servings</b></td></tr>");
            strBody.Append("<tr><td>Grains and Cereals</td><td>4 - 5 serving /day Chapathi  1 or phulka 1 and half or any other grain raw handfist  like Pasta or Rice or rawa or poha or Bread 2 slice ( domestic)</td></tr>");
            strBody.Append("<tr><td>Dals, Pulses and Legumes</td><td>2 servings/day Thick or sprouts or Soya etc</td></tr>");
            strBody.Append("<tr><td>Milk and Milk Products</td><td>300ml/day  can be curd - 2 bowls/day</td></tr>");
            strBody.Append("<tr><td>Egg and Non-veg</td><td>3 eggs / week Fish / Chicken twice  week ( 100gm each time)</td></tr>");
            strBody.Append("<tr><td>Vegetables</td><td>4 serving /day Any vegetable except potato  2 handful  is one serving</td></tr>");
            strBody.Append("<tr><td>Fruits</td><td>2 whole : any Fruit should be size of Tennis ball / size or whole</td></tr>");
            strBody.Append("<tr><td>Sugar</td><td>2 tsp /day. If sweet tooth , Then avoid visible sugar in beverages</td></tr>");
            strBody.Append("<tr><td>Fat</td><td>500ml/person/month Presently the type of oil which you are using is perfect.</td></tr>");
            strBody.Append("<tr><td>Water</td><td>3 liters/day</td></tr>");
            strBody.Append("</table><br/>");
            strBody.Append("<table width=90%><tr><td><b>Things to Remember :</b></td></tr>");
            strBody.Append("<tr><td><ol><li>Suspected food allergens are dairy, soy, gluten . ( you need to be cautious with these foods.) eat small meals if it does'nt  bother you can increase the intake</li>");
            strBody.Append("<li>Take adequate rest</li><li>Drink water</li><li>If you feel muscle spasms  include calcium supplments/ and monitor vitamin D and B12</li><li>Reduce your exercise to normal walk/swim 45 minutes /daily</li></td></tr></table>");
            strBody.Append("<table width=90%><tr><td><b>Supplements Advised:</b></td></tr></table><br/><br/><br/>");
            strBody.Append("<table width=90%><tr><td><b>Investigation Advised:</b></td></tr></table><br/><br/><br/>");
            strBody.Append("<table width=90%><tr><td><b>Follow up date :</b></td></tr><tr><td>After 15 days with weight and improvement symptoms.</td></tr></table><br/><br/>");
            strBody.Append("<table width=90%><tr><td>PH_USER</td></tr><tr><td>Consultant Nutritionist & Registered Dietician</td></tr><tr><td>PH_CLINIC</td></tr><tr><td>Mob No:&nbsp;PH_MOB</td></tr></table><br/><br/>");

            //Create word document 
            Document document = new Document();
            document.LoadFromFile(@"C:\Users\PATIL\Downloads\Alka_16Feb2017.doc");


            //Get Paragraph
            var s = document.Sections[0];
            Paragraph p = s.Paragraphs[1];

            ParagraphStyle style = new ParagraphStyle(document);
            style.Name = "FontStyle";
            style.CharacterFormat.FontName = "Calibri";
            style.CharacterFormat.FontSize = 10;
            document.Styles.Add(style);
            p.ApplyStyle(style.Name);

            Section section = document.AddSection();

            //Add Header   
            HeaderFooter header = section.HeadersFooters.Header;
            Paragraph HParagraph = header.AddParagraph();
            //HParagraph.Format.HorizontalAlignment=HorizontalAlignment.Right;            
            DocPicture footerimage = HParagraph.AppendPicture(System.Drawing.Image.FromFile(@"D:\Intrepidians\Diet Project\Diet_20160422_1\Diet_20160422_1\Diet\GNHClientUI\Images\header-1.png"));
            footerimage.Height = 100;
            footerimage.Width = 100;
            TextRange HText = HParagraph.AppendText("Right Nutrition for Health");
            HText.CharacterFormat.FontName = "Calibri";
            HText.CharacterFormat.FontSize = 20;
            HText.CharacterFormat.Italic = true;
            HText.CharacterFormat.TextColor = Color.Green;
            footerimage.TextWrappingStyle = TextWrappingStyle.Inline;

            //Add Footer 
            HeaderFooter footer = section.HeadersFooters.Footer;
            Paragraph FParagraph = footer.AddParagraph();
            HText = FParagraph.AppendText("+91 7722 0070 68 | info@geetanutriheal.com |www.geetanutriheal.com");

            //Set Footer Paragrah Format 
            FParagraph.Format.HorizontalAlignment = HorizontalAlignment.Center;
            FParagraph.Format.Borders.Top.BorderType = Spire.Doc.Documents.BorderStyle.ThinThinSmallGap;
            FParagraph.Format.Borders.Top.Space = 0.15f;
            FParagraph.Format.Borders.Color = Color.DarkGray;

            //Append Picture for Footer Paragraph             
            HText.CharacterFormat.FontName = "Calibri";
            HText.CharacterFormat.FontSize = 12;
            HText.CharacterFormat.Italic = true;
            HText.CharacterFormat.TextColor = Color.DodgerBlue;

            //document.Replace("")
            ////Save doc file. 
            document.SaveToFile(Server.MapPath("~/Download") + "\\" + "Sample.doc", FileFormat.Doc);

            //return strBody.ToString();
        }
    }
}