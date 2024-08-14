using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
using System.Web;
using System.Configuration;



namespace Utilities
{

    public static class FileManageHelper
    {
        public static readonly string encryptKey = ConfigurationManager.AppSettings["EncryptKey"].ToString();
        private static readonly List<string> DefaultExtAccept = new List<string>() {
            MimeMapping.KnownMimeTypes.Doc,
            MimeMapping.KnownMimeTypes.Docx,
            MimeMapping.KnownMimeTypes.Pdf,
            MimeMapping.KnownMimeTypes.Xlsx,
            MimeMapping.KnownMimeTypes.Xls,
            MimeMapping.KnownMimeTypes.Png,
            MimeMapping.KnownMimeTypes.Jpg,
            MimeMapping.KnownMimeTypes.Jpeg
        };

        public static string SaveFile(this Controller controller, HttpPostedFileBase file, string type)
        {
            try
            {
                string filePath = string.Empty;
                if (!DefaultExtAccept.Contains(file.ContentType))
                {
                    return filePath;
                }
                string fileDirectory = (!String.IsNullOrEmpty(type) ? (type + @"/") : "") + DateTime.Today.ToString("yyyyMMdd");
                string uploadDir = Constants.UPLOAD_DIR + fileDirectory;
                if (!Directory.Exists(controller.Server.MapPath(Constants.UPLOAD_DIR)))
                    Directory.CreateDirectory(controller.Server.MapPath(uploadDir));
                if (!Directory.Exists(controller.Server.MapPath(uploadDir)))
                    Directory.CreateDirectory(controller.Server.MapPath(uploadDir));
                var time = DateTime.Now.ToFileTime();
                string ext = Path.GetExtension(file.FileName);
                var fileName = $"{time}{Guid.NewGuid()}{ext}";
                filePath = $"{uploadDir}/{fileName}";
                string fileLocation = controller.Server.MapPath(filePath);
                if (File.Exists(fileLocation))
                    File.Delete(fileLocation);
                file.SaveAs(fileLocation);
                string path = Encryptor.Encrypt($"{fileDirectory}/{fileName}", encryptKey);
                return path;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FileManageHelper error: {ex.Message}");
                return string.Empty;
            }
        }
        /// <summary>
        /// Convert file Word to Pdf
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        public static void convertWordToPdf(this Controller controller, string sourceFile, string destinationFile)
        {
            Application wordApplication = new Application();

            object oMissing = Missing.Value;
            Object oFalse = false;
            Object filename = (Object)sourceFile;

            Microsoft.Office.Interop.Word.Document doc = wordApplication.Documents.Open(ref filename, ref oMissing,
                ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            try
            {
                doc.Activate();

                Object filename2 = (Object)destinationFile;

                doc.SaveAs(ref filename2, WdSaveFormat.wdFormatPDF,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing);


                // close word doc and word app.
                object saveChanges = WdSaveOptions.wdDoNotSaveChanges;

                ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);

                ((_Application)wordApplication).Quit(ref oMissing, ref oMissing, ref oMissing);

                wordApplication = null;
                doc = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FileManageHelper error: {ex.Message}");
                // close word doc and word app.
                object saveChanges = WdSaveOptions.wdDoNotSaveChanges;

                ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);

                ((_Application)wordApplication).Quit(ref oMissing, ref oMissing, ref oMissing);

                wordApplication = null;
                doc = null;
            }
        }

        /// <summary>
        /// Generate file Word from template file
        /// </summary>
        /// <param name="sourceTemplatePath"></param>
        /// <param name="outputPath"></param>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public static bool GenerateWordWithTemplate(string sourceTemplatePath, string outputPath, DataSet sourceData)
        {
            try
            {
                //create document from template
                using (WordprocessingDocument doc = WordprocessingDocument.CreateFromTemplate(sourceTemplatePath, true))
                {
                    //change document type to docx
                    doc.ChangeDocumentType(WordprocessingDocumentType.Document);
                    //get body document
                    Body bod = doc.MainDocumentPart.Document.Body;

                    //generate main content to main region
                    var paragraphs = bod.ChildElements.Where(x => x.GetType() == typeof(DocumentFormat.OpenXml.Wordprocessing.Paragraph));
                    List<Run> paragraphRuns = new List<Run>();
                    foreach (DocumentFormat.OpenXml.Wordprocessing.Paragraph p in paragraphs)
                    {
                        //add merge fields to list
                        paragraphRuns.AddRange(p.Descendants<Run>().Where(x => x.InnerText.Contains("«") && x.InnerText.Contains("»")).ToList());
                    }
                    //list region fields
                    var regionRun = paragraphRuns.Where(x => x.InnerText.Contains("TableStart:") || x.InnerText.Contains("TableEnd:"));
                    foreach (Run run in regionRun)
                    {
                        var txtFromRun = run.Descendants<Text>().Where(a => a.Text.Contains("«") && a.Text.Contains("»")).FirstOrDefault();
                        txtFromRun.Text = String.Empty;
                    }
                    //merge fields with data
                    foreach (DataRow dr in sourceData.Tables[0].Rows)
                    {
                        foreach (DataColumn dc in sourceData.Tables[0].Columns)
                        {
                            string fieldName = dc.ColumnName;
                            // replace text of field
                            var listRun = paragraphRuns.Where(x => x.InnerText.Contains($"«{fieldName}»"));
                            if (listRun != null)
                            {
                                foreach (Run run in listRun)
                                {
                                    var txtFromRun = run.Descendants<Text>().Where(a => a.Text == $"«{fieldName}»").FirstOrDefault();
                                    txtFromRun.Text = dr[fieldName] != null ? dr[fieldName].ToString() : "";
                                }
                            }
                        }
                    }

                    //generate tables
                    var tables = bod.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>();
                    foreach (DocumentFormat.OpenXml.Wordprocessing.Table t in tables)
                    {
                        //insert each rows
                        var listGenTableRows = t.Descendants<TableRow>().Where(x => x.InnerText.Contains("TableStart:")).ToList();
                        if (listGenTableRows.Count > 0)
                        {
                            foreach (var tempRow in listGenTableRows)
                            {
                                if (tempRow != null)
                                {
                                    //get all run object in table
                                    var tRun = tempRow.Descendants<Run>().Where(x => x.InnerText.Contains("«") && x.InnerText.Contains("»"));
                                    //get list fields
                                    List<string> listFields = tRun.Select(x => x.InnerText.Replace("«", "").Replace("»", "")).ToList();
                                    //get table name
                                    string tableName = listFields.Where(x => x.StartsWith("TableStart:")).FirstOrDefault().Replace("TableStart:", "");
                                    //merge fields with data
                                    System.Data.DataTable dt = sourceData.Tables[tableName];
                                    if (dt != null)
                                    {
                                        //current row for loop
                                        TableRow currentRow = tempRow;
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            //create row
                                            TableRow tr = (TableRow)tempRow.Clone();
                                            var trRuns = tr.Descendants<Run>().Where(x => x.InnerText.Contains("«") && x.InnerText.Contains("»"));
                                            foreach (string fieldName in listFields)
                                            {
                                                // replace text of field
                                                var listRun = trRuns.Where(x => x.InnerText.Contains($"«{fieldName}»"));
                                                if (listRun != null)
                                                {
                                                    foreach (Run run in listRun)
                                                    {
                                                        var txtFromRun = run.Descendants<Text>().Where(a => a.Text == $"«{fieldName}»").FirstOrDefault();
                                                        if (fieldName.StartsWith("TableStart:") || fieldName.StartsWith("TableEnd:"))
                                                            txtFromRun.Text = String.Empty;
                                                        else
                                                            txtFromRun.Text = dr[fieldName] != null ? dr[fieldName].ToString() : "";
                                                    }
                                                }
                                            }
                                            t.InsertAfter(tr, currentRow);
                                            currentRow = tr;
                                        }
                                        //remove row temp
                                        t.RemoveChild(tempRow);
                                    }
                                    else
                                    {
                                        var trRuns = tempRow.Descendants<Run>().Where(x => x.InnerText.Contains("«") && x.InnerText.Contains("»"));
                                        var listRun = trRuns.Where(x => x.InnerText.Contains("«") && x.InnerText.Contains("»"));
                                        if (listRun != null)
                                        {
                                            foreach (Run run in listRun)
                                            {
                                                var txtFromRun = run.Descendants<Text>().Where(a => a.InnerText.Contains("«") && a.InnerText.Contains("»")).FirstOrDefault();
                                                txtFromRun.Text = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //data table
                            System.Data.DataTable dt = sourceData.Tables[0];
                            DataRow dr = dt.Rows[0];
                            var tRun = t.Descendants<Run>().Where(x => x.InnerText.Contains("«") && x.InnerText.Contains("»"));
                            //get list fields
                            List<string> listFields = tRun.Select(x => x.InnerText.Replace("«", "").Replace("»", "")).ToList();
                            //merge field
                            foreach (string fieldName in listFields)
                            {
                                // replace text of field
                                var listRun = tRun.Where(x => x.InnerText.Contains($"«{fieldName}»"));
                                if (listRun != null)
                                {
                                    foreach (Run run in listRun)
                                    {
                                        var txtFromRun = run.Descendants<Text>().Where(a => a.Text == $"«{fieldName}»").FirstOrDefault();
                                        txtFromRun.Text = dr[fieldName] != null ? dr[fieldName].ToString() : "";
                                    }
                                }
                            }
                        }
                    }

                    //save file
                    doc.SaveAs(outputPath).Close();
                    doc.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FileManageHelper error: " + ex.Message);
                return false;
            }
        }


        public static IEnumerable<T> MultipleSort<T>(this IEnumerable<T> data, List<GridSort> gridsorts)
        {
            var sortExpressions = new List<Tuple<string,
                string>>();
            for (int i = 0; i < gridsorts.Count(); i++)
            {
                var fieldName = gridsorts[i].Field.Trim();
                var sortOrder = (gridsorts[i].Dir.Length > 1) ?
                    gridsorts[i].Dir.Trim().ToLower() : "asc";
                sortExpressions.Add(new Tuple<string, string>(fieldName, sortOrder));
            }
            // No sorting needed  
            if ((sortExpressions == null) || (sortExpressions.Count <= 0))
            {
                return data;
            }
            // Let us sort it  
            IEnumerable<T> query = from item in data select item;
            IOrderedEnumerable<T> orderedQuery = null;
            for (int i = 0; i < sortExpressions.Count; i++)
            {
                // We need to keep the loop index, not sure why it is altered by the Linq.  
                var index = i;
                Func<T, object> expression = item => item.GetType()
                 .GetProperty(sortExpressions[index].Item1)
                 .GetValue(item, null);
                if (sortExpressions[index].Item2 == "asc")
                {
                    orderedQuery = (index == 0) ? query.OrderBy(expression) :
                        orderedQuery.ThenBy(expression);
                }
                else
                {
                    orderedQuery = (index == 0) ? query.OrderByDescending(expression) :
                        orderedQuery.ThenByDescending(expression);
                }
            }
            query = orderedQuery;
            return query;
        }
    }

    public class GridSort
    {
        public string Field
        {
            get;
            set;
        }
        public string Dir
        {
            get;
            set;
        }
    }

}
