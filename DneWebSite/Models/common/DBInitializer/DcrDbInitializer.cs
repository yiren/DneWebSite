using DneWebSite.Models.bulletin;
using DneWebSite.Models.DCR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.common.DBInitializer
{
    class DcrDbInitializer:CreateDatabaseIfNotExists<BulletinDbContext>
    {
        protected override void Seed(BulletinDbContext context)
        {
            List<Dcr> dcrs = new List<Dcr>();

            dcrs.Add(new Dcr()
            {
                DcrId=Guid.NewGuid(), DcrNo= "DCR-K1-4503P01", DcrEvaluationNo="NA",
                Subject= "更新#1 機主變壓器避雷器及附屬計數器",
                SourceNo= "核二改簽字106184號",
                DneNo= "會收106-0309",
                ReceivedDate= "2017/04/19",
                MainSection="E",
                Engineer="謝文龍",
                HasOperDep=true,
                SubmitToOperDepDate= "2017/04/20",
                HasSafeDep=true,
                SubmitToSafeDepDate= "2017/04/20"


            });

            base.Seed(context);
        }
    }
}