using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNHClientUI
{
    /// <summary>
    /// Summary description for Download
    /// </summary>
    public class Download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.QueryString["FileName"].ToString().Replace("]", "\\");
            context.Response.AppendHeader("Content-Type", "application/msword");
            context.Response.AppendHeader("Content-disposition", "attachment; filename=" +filename.Substring(filename.LastIndexOf("\\")+1));
            context.Response.WriteFile(filename);
            context.Response.Flush();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}