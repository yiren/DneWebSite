using DneWebSite.Models.DCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Helper
{
    public class InMemoryData
    {
        public static List<Dcr> DcrDataInMemoryStore = new List<Dcr>();
        public static List<Dcr> DcrDataForExcelExport(List<Dcr> dcrs)
        {
            if (DcrDataInMemoryStore.Count > 1)
            {
                DcrDataInMemoryStore = new List<Dcr>();
            }
            DcrDataInMemoryStore.AddRange(dcrs);
            return DcrDataInMemoryStore;
        }
        
    }
}