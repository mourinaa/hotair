using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Used to export the file to a Summary description for Exporter
/// </summary>
public class Exporter
{
    private const string STR_DOUBLE_QUOTE = "\"";

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This is logical file path 
    /// </summary>
    /// -----------------------------------------------------------------------------
    private string FilePath = ConfigurationSettings.AppSettings["EXPORT_FILEPATH"];
    private string FileExtension = ConfigurationSettings.AppSettings["EXPORT_FILEEXTENSION"];

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// A special function that generates the virtual filename and physical path to the file. 
    /// </summary>
    /// <param name="table"></param>
    /// <returns>String - Virtual path to the file for URL redirects. If the return value is blank then something
    /// happened during the creation of the file so return an error message.</returns>
    /// -----------------------------------------------------------------------------
    public string ConvertDataTable2TxtTab(DataTable table)
    {
        //Add ticks to make the name unique so not cache at browser or site
        string FileName = "file-";
        //Calls the default CSV format
        string fullFileName = ConvertDataTable(table, FileName, "\t", false);
        if (!string.IsNullOrEmpty(fullFileName))
        {
            //ok return filename
            return fullFileName;
        }
        else
        {
            //some went wrong, return blank
            return string.Empty;
        }
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Save the input DataTable to a file. 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="FullFileName"></param>
    /// <param name="sepChar"></param>
    /// <param name="includeHeader"></param>
    /// <returns></returns>
    /// <remarks>
    ///  Example:
    ///    ConvertDataTable(ds.Tables("Customer"), "D:\Users.txt",";",false)
    /// </remarks>
    /// -----------------------------------------------------------------------------
    public string ConvertDataTable(DataTable table, string fileName, string sepChar, bool includeHeader)
    {
        System.IO.StreamWriter writer = null;
        string fullFileName;
        try
        {
            //create a full path to the file
            //Add ticks to make the name unique so not cached at browser or site
            string virtualFullFileName = string.Format("{0}{1}{2}", FilePath, fileName + DateTime.Now.Ticks.ToString(), FileExtension);
            fullFileName = HttpContext.Current.Server.MapPath(virtualFullFileName);

            //writer = New System.IO.StreamWriter(FullFileName) 'Same as File.CreateText(filename)
            //Encoding added for special characters 
            writer = new System.IO.StreamWriter(fullFileName, false, System.Text.Encoding.GetEncoding("ISO-8859-1"));

            // first write a line with the columns name
            string sep = "";
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            if (includeHeader)
            {
                foreach (DataColumn col in table.Columns)
                {
                    builder.Append(sep).Append(col.ColumnName);
                    sep = sepChar;
                }
                writer.WriteLine(builder.ToString());
            }

            // then write all the rows
            foreach (DataRow row in table.Rows)
            {
                sep = "";
                builder = new System.Text.StringBuilder();

                //Have to Remove Nulls or blank them out
                foreach (DataColumn col in table.Columns)
                {
                    builder.Append(sep).Append(row[col.ColumnName].ToString());
                    sep = sepChar;
                }
                writer.WriteLine(builder.ToString());
            }
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
        finally
        {
            if (writer != null) writer.Close();
        }

        return fullFileName;
    }

}
