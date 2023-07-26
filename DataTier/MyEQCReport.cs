using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyEQCReport
    {

        public int ID;
        public string DtFrom = "";
        public string DtTo = "";
        public string CntrNo = "";
        public string CntrType = "";
        public string DtMovement = "";
        public string Days = "";
        public string StatusCode = "";
        public string GeoLoc = "";
        public string Location = "";
        public string DaysV = "";
        public string ShipmentType = "";
        public string ToDt = "";
        public string FromDt = "";
        public string FromStatus = "";
        public string FromLocation = "";
        public string FromGeoLocation = "";
        public string FromDate = "";
        public string ToStatus = "";
        public string ToLocation = "";
        public string ToGeoLocation = "";
        public string ToDate = "";
        public string Agency = "";

    }
    public class MyEQCDCMR
    {
        public string Agency = "";
        public string GeoLoc = "";
        public int ID;
        public string ImpFull20GP = "";
        public string ImpFull20HC = "";
        public string ImpFull40HC = "";
        public string ImpFull40RF = "";
        public string DeStuff20GP = "";
        public string DeStuff40HC = "";
        public string MtyReturn20GP = "";
        public string MtyReturn20HC = "";
        public string MtyReturn40HC = "";
        public string MtyReturn40OT = "";
        public string DmgUr20GP = "";
        public string DmgUr20HC = "";
        public string DmgUr40HC = "";
        public string DmgUr40OT = "";
        public string Avail20GP = "";
        public string Avail20HC = "";
        public string Avail20RF = "";
        public string Avail20FR = "";
        public string Avail40GP = "";
        public string Avail40HC = "";
        public string Avail40RF = "";
        public string OutTo20GP = "";
        public string OutTo40HC = "";
        public string ExpFull20GP = "";
        public string ExpFull20HC = "";
        public string ExpFull40GP = "";
        public string ExpFull40OT = "";
        public string ExpFull40RF = "";
        public string ExpFull40HC = "";
        public string MtyRepo20GP = "";
        public string MtyReturn20OT = "";
        public string MtyRepo40HC = "";
        public string Trans20GP = "";
        public string Trans20OT = "";
        public string Trans40HC = "";
        public string Description = "";
        public string DCMRLoc20GP = "";
        public string DCMRLoc20HC = "";
        public string DCMRLoc40GP = "";
        public string DCMRLoc40HC = "";

    }
    public class MyEQCStock
    {
        public string Agency = "";
        public string GeoLoc = "";
        public int ID;
        public string Country = "";
        public string Ports = "";
        public string OFFDRY20GP = "";
        public string OFFDRY40GP = "";
        public string OFFREF20GP = "";
        public string OFFREF40GP = "";
        public string OFFFLAT20GP = "";
        public string OFFFLAT40GP = "";
        public string OFFOT20GP = "";
        public string OFFOT40GP = "";
        public string ACTDRY20GP = "";
        public string ACTDRY40GP = "";
        public string ACTREF20GP = "";
        public string ACTREF40GP = "";
        public string ACTFLAT20GP = "";
        public string ACTFLAT40GP = "";
        public string ACTOT20GP = "";
        public string ACTOT40GP = "";

    }
    public class MyEQCAgewise
    {
        public string Agency = "";
        public string GeoLoc = "";
        public int ID;
        public string Country = "";
        public string Ports = "";
        public string StatusCode = "";
        public string Dry20L7 = "";
        public string Dry40L7 = "";
        public string DryHQL7 = "";
        public string Dry20HQL7 = "";
        public string Dry208To14 = "";
        public string Dry408To14 = "";
        public string DryHQ8To14 = "";
        public string Dry20HQ8To14 = "";
        public string Dry2015To29 = "";
        public string Dry4015To29 = "";
        public string DryHQ15To29 = "";
        public string Dry20HQ15To29 = "";
        public string Dry2030To59 = "";
        public string Dry4030To59 = "";
        public string DryHQ30To59 = "";
        public string Dry20HQ30To59 = "";
        public string Dry20G59 = "";
        public string Dry40G59 = "";
        public string DryHQG59 = "";
        public string Dry20HQG59 = "";
        public string FlRack20L7 = "";
        public string FlRack40L7 = "";
        public string FlRackHQL7 = "";
        public string FlRack208To14 = "";
        public string FlRack408To14 = "";
        public string FlRackHQ8To14 = "";
        public string FlRack2015To29 = "";
        public string FlRack4015To29 = "";
        public string FlRackHQ15To29 = "";
        public string FlRack2030To59 = "";
        public string FlRack4030To59 = "";
        public string FlRackHQ30To59 = "";
        public string FlRack20G59 = "";
        public string FlRack40G59 = "";
        public string FlRackHQG59 = "";
        public string OpTop20L7 = "";
        public string OpTop40L7 = "";
        public string OpTopHQL7 = "";
        public string OpTop208To14 = "";
        public string OpTop408To14 = "";
        public string OpTopHQ8To14 = "";
        public string OpTop2015To29 = "";
        public string OpTop4015To29 = "";
        public string OpTopHQ15To29 = "";
        public string OpTop2030To59 = "";
        public string OpTop4030To59 = "";
        public string OpTopHQ30To59 = "";
        public string OpTop20G59 = "";
        public string OpTop40G59 = "";
        public string OpTopHQG59 = "";
        public string RF20L7 = "";
        public string RF40L7 = "";
        public string RFHQL7 = "";
        public string RF208To14 = "";
        public string RF408To14 = "";
        public string RFHQ8To14 = "";
        public string RF2015To29 = "";
        public string RF4015To29 = "";
        public string RFHQ15To29 = "";
        public string RF2030To59 = "";
        public string RF4030To59 = "";
        public string RFHQ30To59 = "";
        public string RF20G59 = "";
        public string RF40G59 = "";
        public string RFHQG59 = "";
        public string Tank20L7 = "";
        public string Tank40L7 = "";
        public string TankHQL7 = "";
        public string Tank208To14 = "";
        public string Tank408To14 = "";
        public string TankHQ8To14 = "";
        public string Tank2015To29 = "";
        public string Tank4015To29 = "";
        public string TankHQ15To29 = "";
        public string Tank2030To59 = "";
        public string Tank4030To59 = "";
        public string TankHQ30To59 = "";
        public string Tank20G59 = "";
        public string Tank40G59 = "";
        public string TankHQG59 = "";
           
    }
        
}


                                                                                                                                     