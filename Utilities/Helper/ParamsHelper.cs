using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using static Dapper.SqlMapper;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Data;
using System;
namespace Utilities
{
    public class ParamsHelper
    {
        public static ICustomQueryParameter AttachedFileParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "FileGroupCode", "ProductID", "FileKey", "FileName", "FileType", "FileSize", "FilePath" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_AttachedFile");
        }       
    }
}
