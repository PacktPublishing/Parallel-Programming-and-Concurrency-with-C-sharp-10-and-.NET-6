using System.Collections.Concurrent;
using System.Data;
using System.Reflection;

namespace FdaNdcDrugLookup
{
    public class DrugService
    {
        private ConcurrentDictionary<string, Drug> _drugData = new();
        public Drug GetDrugByNdc(string ndcCode)
        {
            bool result = _drugData.TryGetValue(ndcCode, out var drug);

            if (result && drug != null)
                return drug;
            else
                return new Drug();
        }
        public void LoadData(string fileName)
        {
            using DataTable dt = new();
            using StreamReader sr = new(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName));
            var del = new char[] { '\t' };
            string[] colheaders = sr.ReadLine().Split(del);
            foreach (string header in colheaders)
            {
                dt.Columns.Add(header); // add headers
            }
            while (sr.Peek() > 0)
            {
                DataRow dr = dt.NewRow(); // add rows
                dr.ItemArray = sr.ReadLine().Split(del);
                dt.Rows.Add(dr);
            }
            foreach (DataRow row in dt.Rows)
            {
                Drug drug = new(); // map to Drug object
                foreach (DataColumn column in dt.Columns)
                {
                    switch (column.ColumnName)
                    {
                        case "PRODUCTID":
                            drug.Id = row[column].ToString();
                            break;
                        case "PRODUCTNDC":
                            drug.Ndc = row[column].ToString();
                            break;
                        case "PRODUCTTYPENAME":
                            drug.TypeName = row[column].ToString();
                            break;
                        case "PROPRIETARYNAME":
                            drug.ProprietaryName = row[column].ToString();
                            break;
                        case "NONPROPRIETARYNAME":
                            drug.NonProprietaryName = row[column].ToString();
                            break;
                        case "DOSAGEFORMNAME":
                            drug.DosageForm = row[column].ToString();
                            break;
                        case "ROUTENAME":
                            drug.Route = row[column].ToString();
                            break;
                        case "SUBSTANCENAME":
                            drug.SubstanceName = row[column].ToString();
                            break;
                    }
                }
                _drugData.TryAdd(drug.Ndc, drug);
            }
        }
    }
}