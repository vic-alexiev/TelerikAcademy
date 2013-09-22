using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KendoFileUpload
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            try
            {
                HttpPostedFile postedFile = Request.Files["uploaded"];
                string contentType = postedFile.ContentType;
                if (contentType.StartsWith("application/octet-stream") && postedFile.FileName.EndsWith(".zip") ||
                    contentType.StartsWith("application/x-zip-compressed") ||
                    contentType.StartsWith("application/zip") ||
                    contentType.StartsWith("multipart/x-zip"))
                {
                    using (var context = new StorageEntities())
                    {
                        using (ZipFile zipFile = ZipFile.Read(postedFile.InputStream))
                        {
                            foreach (ZipEntry zipEntry in zipFile.Entries.Where(ze => !ze.IsDirectory))
                            {
                                using (MemoryStream memoryStream = new MemoryStream())
                                {
                                    zipEntry.Extract(memoryStream);

                                    // return the reader to the beginning,
                                    // otherwise no data will be read
                                    memoryStream.Position = 0;

                                    using (StreamReader reader = new StreamReader(memoryStream))
                                    {
                                        string entryContents = reader.ReadToEnd();

                                        var textFile = new TextFile
                                        {
                                            Name = zipEntry.FileName,
                                            Contents = entryContents
                                        };

                                        context.TextFiles.Add(textFile);
                                    }
                                }
                            }
                        }

                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new InvalidOperationException("This file type is not supported.");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}