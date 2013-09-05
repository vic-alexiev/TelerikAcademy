using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

/// <summary>
/// For more info:
/// http://www.hanselman.com/blog/ASPNETFuturesGeneratingDynamicImagesWithHttpHandlersGetsEasier.aspx
/// </summary>
public class TextToImageHttpHandler : IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    // *.img?text=sample%20text
    public void ProcessRequest(HttpContext context)
    {
        string content = context.Request.QueryString["text"];
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new InvalidOperationException("No text content specified.");
        }

        this.GenerateImage(
            context.Response,
            content,
            300,
            60,
            Color.DarkTurquoise,
            FontFamily.GenericSansSerif,
            18,
            Brushes.Black,
            0,
            0,
            "image/png",
            ImageFormat.Png);
    }

    private void GenerateImage(
        HttpResponse response,
        string textToInsert,
        int width,
        int height,
        Color backgroundColor,
        FontFamily fontFamily,
        float emSize,
        Brush brush,
        float x,
        float y,
        string contentType,
        ImageFormat imageFormat)
    {
        using (Bitmap bitmap = new Bitmap(width, height))
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(backgroundColor);
                graphics.DrawString(textToInsert, new Font(fontFamily, emSize), brush, x, y);
                response.ContentType = contentType;
                bitmap.Save(response.OutputStream, imageFormat);
            }
        }
    }
}