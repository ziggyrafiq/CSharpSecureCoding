using System.Web;
using System.Web.UI.WebControls;


namespace ZR.CodingExamples.SecureCodeing.Functions;

public static class WebFormsExample
{
    //Please note that this is the WebForm Code Example and is real no longer used with .net Framework 5+
    //protected static void PageLoad(object sender, EventArgs e)
    //{
    //    string userInput = Request.QueryString["input"];
    //    string encodedInput = HttpUtility.HtmlEncode(userInput);
    //    Label1.Text = encodedInput;
    //}
    public static string SanitizeInput(string input)
    {
        // Perform sanitization on the input by HTML encoding
        string sanitizedInput = HttpUtility.HtmlEncode(input);
        return sanitizedInput;
    }
}
