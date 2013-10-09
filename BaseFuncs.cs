using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace Avalon
{
    //Специальный класс предназначенный для работы с базой
    //base.sdf
    class BaseWork
    {
        private System.Collections.Generic.Dictionary<string, int> colIndex_;
        private System.Collections.Generic.Dictionary<string, string> ColType;

        

        public BaseWork()
        {
            colIndex_ = new System.Collections.Generic.Dictionary<string, int>();
            ColType = new System.Collections.Generic.Dictionary<string, string>();

            /*Кто не быдлокодил пусть первый кинет в меня камень*/
            {
                colIndex_["DecF1" + "id"] = 0;
                colIndex_["DecF1" + "Hid"] = 1;
                colIndex_["DecF1" + "vidCode"] = 2;
                colIndex_["DecF1" + "P3"] = 3;
                colIndex_["DecF1" + "P4"] = 4;
                colIndex_["DecF1" + "P5"] = 5;
                colIndex_["DecF1" + "P6"] = 6;
                colIndex_["DecF1" + "P7"] = 7;
                colIndex_["DecF1" + "P8"] = 8;
                colIndex_["DecF1" + "P9"] = 9;
                colIndex_["DecF1" + "P10"] = 10;
                colIndex_["DecF1" + "P11"] = 11;
                colIndex_["DecF1" + "P12"] = 12;
                colIndex_["DecF1" + "P13"] = 13;
                colIndex_["DecF1" + "P14"] = 14;
                colIndex_["DecF1" + "P15"] = 15;
                colIndex_["DecF1" + "P16"] = 16;
                colIndex_["DecF1" + "P17"] = 17;
                colIndex_["DecF1" + "P18"] = 18;
                colIndex_["DecF1" + "P19"] = 19;
                colIndex_["DecF1" + "P20"] = 20;
                colIndex_["DecF1" + "P21"] = 21;
                colIndex_["DecF1" + "TTYPE"] = 22;
                colIndex_["DecF1" + "idOrg"] = 23;
                colIndex_["DecF1" + "parID"] = 24;
                colIndex_["DecF1" + "p33"] = 25;
                colIndex_["DecF10" + "id"] = 0;
                colIndex_["DecF10" + "Hid"] = 1;
                colIndex_["DecF10" + "adress"] = 2;
                colIndex_["DecF10" + "vidLic"] = 3;
                colIndex_["DecF10" + "vidCodeDescr"] = 4;
                colIndex_["DecF10" + "vidCode"] = 5;
                colIndex_["DecF10" + "norma"] = 6;
                colIndex_["DecF10" + "power"] = 7;
                colIndex_["DecF10" + "p1"] = 8;
                colIndex_["DecF10" + "p2"] = 9;
                colIndex_["DecF10" + "p3"] = 10;
                colIndex_["DecF10" + "p4"] = 11;
                colIndex_["DecF10" + "p5"] = 12;
                colIndex_["DecF10" + "koeff"] = 13;
                colIndex_["DecF10" + "idOrg"] = 14;
                colIndex_["DecF11" + "id"] = 0;
                colIndex_["DecF11" + "Hid"] = 1;
                colIndex_["DecF11" + "vidCode"] = 2;
                colIndex_["DecF11" + "ProdId"] = 3;
                colIndex_["DecF11" + "idPost"] = 4;
                colIndex_["DecF11" + "idLic"] = 5;
                colIndex_["DecF11" + "P213"] = 6;
                colIndex_["DecF11" + "P214"] = 7;
                colIndex_["DecF11" + "P215"] = 8;
                colIndex_["DecF11" + "P216"] = 9;
                colIndex_["DecF11" + "P106"] = 10;
                colIndex_["DecF11" + "P107"] = 11;
                colIndex_["DecF11" + "P108"] = 12;
                colIndex_["DecF11" + "P109"] = 13;
                colIndex_["DecF11" + "P110"] = 14;
                colIndex_["DecF11" + "P111"] = 15;
                colIndex_["DecF11" + "P112"] = 16;
                colIndex_["DecF11" + "P113"] = 17;
                colIndex_["DecF11" + "P114"] = 18;
                colIndex_["DecF11" + "P115"] = 19;
                colIndex_["DecF11" + "P116"] = 20;
                colIndex_["DecF11" + "P117"] = 21;
                colIndex_["DecF11" + "P118"] = 22;
                colIndex_["DecF11" + "P119"] = 23;
                colIndex_["DecF11" + "P120"] = 24;
                colIndex_["DecF11" + "TTYPE"] = 25;
                colIndex_["DecF11" + "idOrg"] = 26;
                colIndex_["DecF12" + "id"] = 0;
                colIndex_["DecF12" + "Hid"] = 1;
                colIndex_["DecF12" + "vidCode"] = 2;
                colIndex_["DecF12" + "ProdId"] = 3;
                colIndex_["DecF12" + "idPost"] = 4;
                colIndex_["DecF12" + "P29"] = 5;
                colIndex_["DecF12" + "P210"] = 6;
                colIndex_["DecF12" + "P211"] = 7;
                colIndex_["DecF12" + "P212"] = 8;
                colIndex_["DecF12" + "P106"] = 9;
                colIndex_["DecF12" + "P107"] = 10;
                colIndex_["DecF12" + "P108"] = 11;
                colIndex_["DecF12" + "P109"] = 12;
                colIndex_["DecF12" + "P110"] = 13;
                colIndex_["DecF12" + "P111"] = 14;
                colIndex_["DecF12" + "P112"] = 15;
                colIndex_["DecF12" + "P113"] = 16;
                colIndex_["DecF12" + "P114"] = 17;
                colIndex_["DecF12" + "P115"] = 18;
                colIndex_["DecF12" + "P116"] = 19;
                colIndex_["DecF12" + "P117"] = 20;
                colIndex_["DecF12" + "P118"] = 21;
                colIndex_["DecF12" + "TTYPE"] = 22;
                colIndex_["DecF12" + "idOrg"] = 23;
                colIndex_["DecF2" + "id"] = 0;
                colIndex_["DecF2" + "Hid"] = 1;
                colIndex_["DecF2" + "vidCode"] = 2;
                colIndex_["DecF2" + "P3"] = 3;
                colIndex_["DecF2" + "P4"] = 4;
                colIndex_["DecF2" + "P5"] = 5;
                colIndex_["DecF2" + "P6"] = 6;
                colIndex_["DecF2" + "P7"] = 7;
                colIndex_["DecF2" + "P8"] = 8;
                colIndex_["DecF2" + "P9"] = 9;
                colIndex_["DecF2" + "P10"] = 10;
                colIndex_["DecF2" + "P11"] = 11;
                colIndex_["DecF2" + "P12"] = 12;
                colIndex_["DecF2" + "P13"] = 13;
                colIndex_["DecF2" + "P14"] = 14;
                colIndex_["DecF2" + "P15"] = 15;
                colIndex_["DecF2" + "P16"] = 16;
                colIndex_["DecF2" + "P17"] = 17;
                colIndex_["DecF2" + "P18"] = 18;
                colIndex_["DecF2" + "P19"] = 19;
                colIndex_["DecF2" + "idOrg"] = 20;
                colIndex_["DecF2" + "p33"] = 21;
                colIndex_["DecF3" + "id"] = 0;
                colIndex_["DecF3" + "Hid"] = 1;
                colIndex_["DecF3" + "vidCode"] = 2;
                colIndex_["DecF3" + "P3"] = 3;
                colIndex_["DecF3" + "P4"] = 4;
                colIndex_["DecF3" + "P5"] = 5;
                colIndex_["DecF3" + "P6"] = 6;
                colIndex_["DecF3" + "P7"] = 7;
                colIndex_["DecF3" + "P8"] = 8;
                colIndex_["DecF3" + "P9"] = 9;
                colIndex_["DecF3" + "P10"] = 10;
                colIndex_["DecF3" + "P11"] = 11;
                colIndex_["DecF3" + "P12"] = 12;
                colIndex_["DecF3" + "P13"] = 13;
                colIndex_["DecF3" + "P14"] = 14;
                colIndex_["DecF3" + "P15"] = 15;
                colIndex_["DecF3" + "P16"] = 16;
                colIndex_["DecF3" + "P17"] = 17;
                colIndex_["DecF3" + "TTYPE"] = 18;
                colIndex_["DecF3" + "idOrg"] = 19;
                colIndex_["DecF3" + "parId"] = 20;
                colIndex_["DecF4" + "id"] = 0;
                colIndex_["DecF4" + "Hid"] = 1;
                colIndex_["DecF4" + "vidCode"] = 2;
                colIndex_["DecF4" + "P3"] = 3;
                colIndex_["DecF4" + "P4"] = 4;
                colIndex_["DecF4" + "P5"] = 5;
                colIndex_["DecF4" + "P6"] = 6;
                colIndex_["DecF4" + "P7"] = 7;
                colIndex_["DecF4" + "P8"] = 8;
                colIndex_["DecF4" + "P9"] = 9;
                colIndex_["DecF4" + "P10"] = 10;
                colIndex_["DecF4" + "P11"] = 11;
                colIndex_["DecF4" + "P12"] = 12;
                colIndex_["DecF4" + "P13"] = 13;
                colIndex_["DecF4" + "P14"] = 14;
                colIndex_["DecF4" + "P15"] = 15;
                colIndex_["DecF4" + "idOrg"] = 16;
                colIndex_["DecF5" + "id"] = 0;
                colIndex_["DecF5" + "Hid"] = 1;
                colIndex_["DecF5" + "vidCode"] = 2;
                colIndex_["DecF5" + "ProdId"] = 3;
                colIndex_["DecF5" + "P6"] = 4;
                colIndex_["DecF5" + "P7"] = 5;
                colIndex_["DecF5" + "P8"] = 6;
                colIndex_["DecF5" + "P9"] = 7;
                colIndex_["DecF5" + "P10"] = 8;
                colIndex_["DecF5" + "P11"] = 9;
                colIndex_["DecF5" + "P12"] = 10;
                colIndex_["DecF5" + "P13"] = 11;
                colIndex_["DecF5" + "P14"] = 12;
                colIndex_["DecF5" + "P15"] = 13;
                colIndex_["DecF5" + "P16"] = 14;
                colIndex_["DecF5" + "P17"] = 15;
                colIndex_["DecF5" + "P18"] = 16;
                colIndex_["DecF5" + "P19"] = 17;
                colIndex_["DecF5" + "P20"] = 18;
                colIndex_["DecF5" + "P21"] = 19;
                colIndex_["DecF5" + "P22"] = 20;
                colIndex_["DecF5" + "P23"] = 21;
                colIndex_["DecF5" + "idOrg"] = 22;
                colIndex_["DecF6" + "id"] = 0;
                colIndex_["DecF6" + "Hid"] = 1;
                colIndex_["DecF6" + "vidCode"] = 2;
                colIndex_["DecF6" + "ProdId"] = 3;
                colIndex_["DecF6" + "idPost"] = 4;
                colIndex_["DecF6" + "idLic"] = 5;
                colIndex_["DecF6" + "P14"] = 6;
                colIndex_["DecF6" + "P15"] = 7;
                colIndex_["DecF6" + "P16"] = 8;
                colIndex_["DecF6" + "P17"] = 9;
                colIndex_["DecF6" + "P18"] = 10;
                colIndex_["DecF6" + "P19"] = 11;
                colIndex_["DecF6" + "P20"] = 12;
                colIndex_["DecF6" + "TTYPE"] = 13;
                colIndex_["DecF6" + "idOrg"] = 14;
                colIndex_["DecF7" + "id"] = 0;
                colIndex_["DecF7" + "Hid"] = 1;
                colIndex_["DecF7" + "vidCode"] = 2;
                colIndex_["DecF7" + "ProdId"] = 3;
                colIndex_["DecF7" + "idPost"] = 4;
                colIndex_["DecF7" + "idLic"] = 5;
                colIndex_["DecF7" + "P14"] = 6;
                colIndex_["DecF7" + "P15"] = 7;
                colIndex_["DecF7" + "P16"] = 8;
                colIndex_["DecF7" + "P17"] = 9;
                colIndex_["DecF7" + "P18"] = 10;
                colIndex_["DecF7" + "P19"] = 11;
                colIndex_["DecF7" + "P20"] = 12;
                colIndex_["DecF7" + "TTYPE"] = 13;
                colIndex_["DecF7" + "idOrg"] = 14;
                colIndex_["DecF8" + "id"] = 0;
                colIndex_["DecF8" + "Hid"] = 1;
                colIndex_["DecF8" + "vidTraffic"] = 2;
                colIndex_["DecF8" + "vidProduce"] = 3;
                colIndex_["DecF8" + "idCarrier"] = 4;
                colIndex_["DecF8" + "p5"] = 5;
                colIndex_["DecF8" + "p6"] = 6;
                colIndex_["DecF8" + "p7"] = 7;
                colIndex_["DecF8" + "p8"] = 8;
                colIndex_["DecF8" + "p9"] = 9;
                colIndex_["DecF8" + "p10"] = 10;
                colIndex_["DecF8" + "p11"] = 11;
                colIndex_["DecF8" + "p12"] = 12;
                colIndex_["DecF8" + "p13"] = 13;
                colIndex_["DecF8" + "p14"] = 14;
                colIndex_["DecF8" + "p15"] = 15;
                colIndex_["DecF8" + "p16"] = 16;
                colIndex_["DecF8" + "p17"] = 17;
                colIndex_["DecF8" + "idOrg"] = 18;
                colIndex_["DecF9" + "id"] = 0;
                colIndex_["DecF9" + "Hid"] = 1;
                colIndex_["DecF9" + "vidTraffic"] = 2;
                colIndex_["DecF9" + "vidCode"] = 3;
                colIndex_["DecF9" + "idContrOtpr"] = 4;
                colIndex_["DecF9" + "idContrPol"] = 5;
                colIndex_["DecF9" + "p6"] = 6;
                colIndex_["DecF9" + "p7"] = 7;
                colIndex_["DecF9" + "p8"] = 8;
                colIndex_["DecF9" + "p9"] = 9;
                colIndex_["DecF9" + "p10"] = 10;
                colIndex_["DecF9" + "p11"] = 11;
                colIndex_["DecF9" + "idOrg"] = 12;
                colIndex_["DecHeader" + "id"] = 0;
                colIndex_["DecHeader" + "type_id"] = 1;
                colIndex_["DecHeader" + "PrizPeriod"] = 2;
                colIndex_["DecHeader" + "PrizFotch"] = 3;
                colIndex_["DecHeader" + "Yearotch"] = 4;
                colIndex_["DecHeader" + "typePK"] = 5;
                colIndex_["DecHeader" + "korrNum"] = 6;
                colIndex_["DecHeader" + "Lics"] = 7;
                colIndex_["DecHeader" + "where_submit"] = 8;
                colIndex_["KLADR_Regions" + "NAME"] = 0;
                colIndex_["KLADR_Regions" + "SOCR"] = 1;
                colIndex_["KLADR_Regions" + "CODE"] = 2;
                colIndex_["Proxy" + "id"] = 0;
                colIndex_["Proxy" + "exist"] = 1;
                colIndex_["Proxy" + "http"] = 2;
                colIndex_["Proxy" + "port"] = 3;
                colIndex_["Proxy" + "name"] = 4;
                colIndex_["Proxy" + "password"] = 5;
                colIndex_["ref_alckinds" + "code"] = 0;
                colIndex_["ref_alckinds" + "descr"] = 1;
                colIndex_["ref_alckinds" + "f1"] = 2;
                colIndex_["ref_alckinds" + "f2"] = 3;
                colIndex_["ref_alckinds" + "f3"] = 4;
                colIndex_["ref_alckinds" + "f4"] = 5;
                colIndex_["ref_alckinds" + "f5"] = 6;
                colIndex_["ref_alckinds" + "f6"] = 7;
                colIndex_["ref_alckinds" + "f7"] = 8;
                colIndex_["ref_alckinds" + "f8"] = 9;
                colIndex_["ref_alckinds" + "f9"] = 10;
                colIndex_["ref_alckinds" + "f10"] = 11;
                colIndex_["ref_alckinds" + "f11"] = 12;
                colIndex_["ref_alckinds" + "f12"] = 13;
                colIndex_["ref_declforms" + "code"] = 0;
                colIndex_["ref_declforms" + "Descr"] = 1;
                colIndex_["ref_declPeriod" + "code"] = 0;
                colIndex_["ref_declPeriod" + "Descr"] = 1;
                colIndex_["ref_fotch" + "code"] = 0;
                colIndex_["ref_fotch" + "descr"] = 1;
                colIndex_["ref_lic_types" + "id"] = 0;
                colIndex_["ref_lic_types" + "code"] = 1;
                colIndex_["ref_lic_types" + "Descr"] = 2;
                colIndex_["ref_type_produce" + "id"] = 0;
                colIndex_["ref_type_produce" + "vid"] = 1;
                colIndex_["ref_type_produce" + "descr"] = 2;
                colIndex_["ref_type_traffic" + "id"] = 0;
                colIndex_["ref_type_traffic" + "vid"] = 1;
                colIndex_["ref_type_traffic" + "descr"] = 2;
                colIndex_["ref_typedec" + "code"] = 0;
                colIndex_["ref_typedec" + "data"] = 1;
                colIndex_["sys_pinfo" + "id"] = 0;
                colIndex_["sys_pinfo" + "info_code"] = 1;
                colIndex_["sys_pinfo" + "info_value"] = 2;
                colIndex_["wrk_contr_licenses" + "id"] = 0;
                colIndex_["wrk_contr_licenses" + "ref_contr_id"] = 1;
                colIndex_["wrk_contr_licenses" + "series"] = 2;
                colIndex_["wrk_contr_licenses" + "number"] = 3;
                colIndex_["wrk_contr_licenses" + "dateBegin"] = 4;
                colIndex_["wrk_contr_licenses" + "dateEnd"] = 5;
                colIndex_["wrk_contr_licenses" + "ref_licTypeId"] = 6;
                colIndex_["wrk_contr_licenses" + "Vidana"] = 7;
                colIndex_["wrk_Contragents" + "id"] = 0;
                colIndex_["wrk_Contragents" + "INN"] = 1;
                colIndex_["wrk_Contragents" + "KPP"] = 2;
                colIndex_["wrk_Contragents" + "OrgName"] = 3;
                colIndex_["wrk_Contragents" + "CCode"] = 4;
                colIndex_["wrk_Contragents" + "Index"] = 5;
                colIndex_["wrk_Contragents" + "RCode"] = 6;
                colIndex_["wrk_Contragents" + "Area"] = 7;
                colIndex_["wrk_Contragents" + "City"] = 8;
                colIndex_["wrk_Contragents" + "Place"] = 9;
                colIndex_["wrk_Contragents" + "Street"] = 10;
                colIndex_["wrk_Contragents" + "Building"] = 11;
                colIndex_["wrk_Contragents" + "Korp"] = 12;
                colIndex_["wrk_Contragents" + "Flat"] = 13;
                colIndex_["wrk_Contragents" + "Ref_org_id"] = 14;
                colIndex_["wrk_Contragents" + "fl_surname"] = 15;
                colIndex_["wrk_Contragents" + "fl_name"] = 16;
                colIndex_["wrk_Contragents" + "fl_secname"] = 17;
                colIndex_["wrk_Contragents" + "fl_address"] = 18;
                colIndex_["wrk_Contragents" + "foreign_addres"] = 19;
                colIndex_["wrk_Contragents" + "OrgType"] = 20;
                colIndex_["wrk_Contragents" + "producer"] = 21;
                colIndex_["wrk_Contragents" + "Liter"] = 22;
                colIndex_["wrk_Contragents" + "carrier"] = 23;
                colIndex_["wrk_org" + "id"] = 0;
                colIndex_["wrk_org" + "INN"] = 1;
                colIndex_["wrk_org" + "KPP"] = 2;
                colIndex_["wrk_org" + "OrgName"] = 3;
                colIndex_["wrk_org" + "Phone"] = 4;
                colIndex_["wrk_org" + "Email"] = 5;
                colIndex_["wrk_org" + "CCode"] = 6;
                colIndex_["wrk_org" + "Index"] = 7;
                colIndex_["wrk_org" + "Rcode"] = 8;
                colIndex_["wrk_org" + "Area"] = 9;
                colIndex_["wrk_org" + "City"] = 10;
                colIndex_["wrk_org" + "Place"] = 11;
                colIndex_["wrk_org" + "Street"] = 12;
                colIndex_["wrk_org" + "Building"] = 13;
                colIndex_["wrk_org" + "Korp"] = 14;
                colIndex_["wrk_org" + "Flat"] = 15;
                colIndex_["wrk_org" + "Head_id"] = 16;
                colIndex_["wrk_org" + "OrgType"] = 17;
                colIndex_["wrk_org" + "DirID"] = 18;
                colIndex_["wrk_org" + "BuhID"] = 19;
                colIndex_["wrk_org" + "Liter"] = 20;
                colIndex_["wrk_org_license" + "id"] = 0;
                colIndex_["wrk_org_license" + "ref_org_id"] = 1;
                colIndex_["wrk_org_license" + "Series"] = 2;
                colIndex_["wrk_org_license" + "Number"] = 3;
                colIndex_["wrk_org_license" + "DateBegin"] = 4;
                colIndex_["wrk_org_license" + "DateEnd"] = 5;
                colIndex_["wrk_org_license" + "ref_licType_id"] = 6;
                colIndex_["wrk_org_license" + "Vidana"] = 7;
                colIndex_["wrk_org_persons" + "id"] = 0;
                colIndex_["wrk_org_persons" + "Surname"] = 1;
                colIndex_["wrk_org_persons" + "Name"] = 2;
                colIndex_["wrk_org_persons" + "SecName"] = 3;
                colIndex_["wrk_org_persons" + "INN"] = 4;
                colIndex_["wrk_org_persons" + "Phone"] = 5;
                colIndex_["wrk_org_persons" + "ref_DocType_id"] = 6;
                colIndex_["wrk_org_persons" + "DocNumber"] = 7;
                colIndex_["wrk_org_persons" + "DocVidan"] = 8;
                colIndex_["wrk_org_persons" + "DocDate"] = 9;
                colIndex_["wrk_org_persons" + "ad_CCode"] = 10;
                colIndex_["wrk_org_persons" + "ad_Index"] = 11;
                colIndex_["wrk_org_persons" + "ad_RCode"] = 12;
                colIndex_["wrk_org_persons" + "ad_Area"] = 13;
                colIndex_["wrk_org_persons" + "ad_City"] = 14;
                colIndex_["wrk_org_persons" + "ad_Place"] = 15;
                colIndex_["wrk_org_persons" + "ad_Street"] = 16;
                colIndex_["wrk_org_persons" + "ad_House"] = 17;
                colIndex_["wrk_org_persons" + "ad_Building"] = 18;
                colIndex_["wrk_org_persons" + "ad_Flat"] = 19;
                colIndex_["wrk_org_persons" + "Type"] = 20;
                colIndex_["wrk_organization" + "id"] = 0;
                colIndex_["wrk_organization" + "FullName"] = 1;
                colIndex_["wrk_organization" + "ShortName"] = 2;
                colIndex_["wrk_organization" + "INN"] = 3;
                colIndex_["wrk_organization" + "KPP"] = 4;
                colIndex_["wrk_organization" + "OGRN"] = 5;
                colIndex_["wrk_organization" + "OKATO"] = 6;
                colIndex_["wrk_organization" + "Phone"] = 7;
                colIndex_["wrk_organization" + "Addres"] = 8;
                colIndex_["wrk_organization" + "Head_id"] = 9;
                colIndex_["wrk_organization" + "OrgType"] = 10;
                colIndex_["wrk_organization" + "DirID"] = 11;
                colIndex_["wrk_organization" + "BuhID"] = 12;
            }
            {
                ColType["DecF1" + "id"] = "int";
                ColType["DecF1" + "Hid"] = "int";
                ColType["DecF1" + "vidCode"] = "nvarchar";
                ColType["DecF1" + "P3"] = "nvarchar";
                ColType["DecF1" + "P4"] = "numeric";
                ColType["DecF1" + "P5"] = "numeric";
                ColType["DecF1" + "P6"] = "numeric";
                ColType["DecF1" + "P7"] = "numeric";
                ColType["DecF1" + "P8"] = "numeric";
                ColType["DecF1" + "P9"] = "numeric";
                ColType["DecF1" + "P10"] = "numeric";
                ColType["DecF1" + "P11"] = "numeric";
                ColType["DecF1" + "P12"] = "numeric";
                ColType["DecF1" + "P13"] = "numeric";
                ColType["DecF1" + "P14"] = "numeric";
                ColType["DecF1" + "P15"] = "numeric";
                ColType["DecF1" + "P16"] = "numeric";
                ColType["DecF1" + "P17"] = "numeric";
                ColType["DecF1" + "P18"] = "numeric";
                ColType["DecF1" + "P19"] = "numeric";
                ColType["DecF1" + "P20"] = "numeric";
                ColType["DecF1" + "P21"] = "numeric";
                ColType["DecF1" + "TTYPE"] = "int";
                ColType["DecF1" + "idOrg"] = "nvarchar";
                ColType["DecF1" + "parID"] = "int";
                ColType["DecF1" + "p33"] = "numeric";
                ColType["DecF10" + "id"] = "int";
                ColType["DecF10" + "Hid"] = "int";
                ColType["DecF10" + "adress"] = "nvarchar";
                ColType["DecF10" + "vidLic"] = "int";
                ColType["DecF10" + "vidCodeDescr"] = "nvarchar";
                ColType["DecF10" + "vidCode"] = "nvarchar";
                ColType["DecF10" + "norma"] = "numeric";
                ColType["DecF10" + "power"] = "numeric";
                ColType["DecF10" + "p1"] = "numeric";
                ColType["DecF10" + "p2"] = "numeric";
                ColType["DecF10" + "p3"] = "numeric";
                ColType["DecF10" + "p4"] = "numeric";
                ColType["DecF10" + "p5"] = "numeric";
                ColType["DecF10" + "koeff"] = "numeric";
                ColType["DecF10" + "idOrg"] = "nvarchar";
                ColType["DecF11" + "id"] = "int";
                ColType["DecF11" + "Hid"] = "int";
                ColType["DecF11" + "vidCode"] = "nvarchar";
                ColType["DecF11" + "ProdId"] = "int";
                ColType["DecF11" + "idPost"] = "int";
                ColType["DecF11" + "idLic"] = "int";
                ColType["DecF11" + "P213"] = "nvarchar";
                ColType["DecF11" + "P214"] = "nvarchar";
                ColType["DecF11" + "P215"] = "nvarchar";
                ColType["DecF11" + "P216"] = "numeric";
                ColType["DecF11" + "P106"] = "numeric";
                ColType["DecF11" + "P107"] = "numeric";
                ColType["DecF11" + "P108"] = "numeric";
                ColType["DecF11" + "P109"] = "numeric";
                ColType["DecF11" + "P110"] = "numeric";
                ColType["DecF11" + "P111"] = "numeric";
                ColType["DecF11" + "P112"] = "numeric";
                ColType["DecF11" + "P113"] = "numeric";
                ColType["DecF11" + "P114"] = "numeric";
                ColType["DecF11" + "P115"] = "numeric";
                ColType["DecF11" + "P116"] = "numeric";
                ColType["DecF11" + "P117"] = "numeric";
                ColType["DecF11" + "P118"] = "numeric";
                ColType["DecF11" + "P119"] = "numeric";
                ColType["DecF11" + "P120"] = "numeric";
                ColType["DecF11" + "TTYPE"] = "int";
                ColType["DecF11" + "idOrg"] = "nvarchar";
                ColType["DecF12" + "id"] = "int";
                ColType["DecF12" + "Hid"] = "int";
                ColType["DecF12" + "vidCode"] = "nvarchar";
                ColType["DecF12" + "ProdId"] = "int";
                ColType["DecF12" + "idPost"] = "int";
                ColType["DecF12" + "P29"] = "nvarchar";
                ColType["DecF12" + "P210"] = "nvarchar";
                ColType["DecF12" + "P211"] = "nvarchar";
                ColType["DecF12" + "P212"] = "numeric";
                ColType["DecF12" + "P106"] = "numeric";
                ColType["DecF12" + "P107"] = "numeric";
                ColType["DecF12" + "P108"] = "numeric";
                ColType["DecF12" + "P109"] = "numeric";
                ColType["DecF12" + "P110"] = "numeric";
                ColType["DecF12" + "P111"] = "numeric";
                ColType["DecF12" + "P112"] = "numeric";
                ColType["DecF12" + "P113"] = "numeric";
                ColType["DecF12" + "P114"] = "numeric";
                ColType["DecF12" + "P115"] = "numeric";
                ColType["DecF12" + "P116"] = "numeric";
                ColType["DecF12" + "P117"] = "numeric";
                ColType["DecF12" + "P118"] = "numeric";
                ColType["DecF12" + "TTYPE"] = "int";
                ColType["DecF12" + "idOrg"] = "nvarchar";
                ColType["DecF2" + "id"] = "int";
                ColType["DecF2" + "Hid"] = "int";
                ColType["DecF2" + "vidCode"] = "nvarchar";
                ColType["DecF2" + "P3"] = "numeric";
                ColType["DecF2" + "P4"] = "numeric";
                ColType["DecF2" + "P5"] = "numeric";
                ColType["DecF2" + "P6"] = "numeric";
                ColType["DecF2" + "P7"] = "numeric";
                ColType["DecF2" + "P8"] = "numeric";
                ColType["DecF2" + "P9"] = "numeric";
                ColType["DecF2" + "P10"] = "numeric";
                ColType["DecF2" + "P11"] = "numeric";
                ColType["DecF2" + "P12"] = "numeric";
                ColType["DecF2" + "P13"] = "numeric";
                ColType["DecF2" + "P14"] = "numeric";
                ColType["DecF2" + "P15"] = "numeric";
                ColType["DecF2" + "P16"] = "numeric";
                ColType["DecF2" + "P17"] = "numeric";
                ColType["DecF2" + "P18"] = "numeric";
                ColType["DecF2" + "P19"] = "numeric";
                ColType["DecF2" + "idOrg"] = "nvarchar";
                ColType["DecF2" + "p33"] = "numeric";
                ColType["DecF3" + "id"] = "int";
                ColType["DecF3" + "Hid"] = "int";
                ColType["DecF3" + "vidCode"] = "nvarchar";
                ColType["DecF3" + "P3"] = "numeric";
                ColType["DecF3" + "P4"] = "numeric";
                ColType["DecF3" + "P5"] = "numeric";
                ColType["DecF3" + "P6"] = "numeric";
                ColType["DecF3" + "P7"] = "numeric";
                ColType["DecF3" + "P8"] = "nvarchar";
                ColType["DecF3" + "P9"] = "numeric";
                ColType["DecF3" + "P10"] = "numeric";
                ColType["DecF3" + "P11"] = "numeric";
                ColType["DecF3" + "P12"] = "numeric";
                ColType["DecF3" + "P13"] = "numeric";
                ColType["DecF3" + "P14"] = "numeric";
                ColType["DecF3" + "P15"] = "numeric";
                ColType["DecF3" + "P16"] = "numeric";
                ColType["DecF3" + "P17"] = "numeric";
                ColType["DecF3" + "TTYPE"] = "int";
                ColType["DecF3" + "idOrg"] = "nvarchar";
                ColType["DecF3" + "parId"] = "int";
                ColType["DecF4" + "id"] = "int";
                ColType["DecF4" + "Hid"] = "int";
                ColType["DecF4" + "vidCode"] = "nvarchar";
                ColType["DecF4" + "P3"] = "numeric";
                ColType["DecF4" + "P4"] = "numeric";
                ColType["DecF4" + "P5"] = "numeric";
                ColType["DecF4" + "P6"] = "numeric";
                ColType["DecF4" + "P7"] = "numeric";
                ColType["DecF4" + "P8"] = "numeric";
                ColType["DecF4" + "P9"] = "numeric";
                ColType["DecF4" + "P10"] = "numeric";
                ColType["DecF4" + "P11"] = "numeric";
                ColType["DecF4" + "P12"] = "numeric";
                ColType["DecF4" + "P13"] = "numeric";
                ColType["DecF4" + "P14"] = "numeric";
                ColType["DecF4" + "P15"] = "numeric";
                ColType["DecF4" + "idOrg"] = "nvarchar";
                ColType["DecF5" + "id"] = "int";
                ColType["DecF5" + "Hid"] = "int";
                ColType["DecF5" + "vidCode"] = "nvarchar";
                ColType["DecF5" + "ProdId"] = "int";
                ColType["DecF5" + "P6"] = "numeric";
                ColType["DecF5" + "P7"] = "numeric";
                ColType["DecF5" + "P8"] = "numeric";
                ColType["DecF5" + "P9"] = "numeric";
                ColType["DecF5" + "P10"] = "numeric";
                ColType["DecF5" + "P11"] = "numeric";
                ColType["DecF5" + "P12"] = "numeric";
                ColType["DecF5" + "P13"] = "numeric";
                ColType["DecF5" + "P14"] = "numeric";
                ColType["DecF5" + "P15"] = "numeric";
                ColType["DecF5" + "P16"] = "numeric";
                ColType["DecF5" + "P17"] = "numeric";
                ColType["DecF5" + "P18"] = "numeric";
                ColType["DecF5" + "P19"] = "numeric";
                ColType["DecF5" + "P20"] = "numeric";
                ColType["DecF5" + "P21"] = "numeric";
                ColType["DecF5" + "P22"] = "numeric";
                ColType["DecF5" + "P23"] = "numeric";
                ColType["DecF5" + "idOrg"] = "nvarchar";
                ColType["DecF6" + "id"] = "int";
                ColType["DecF6" + "Hid"] = "int";
                ColType["DecF6" + "vidCode"] = "nvarchar";
                ColType["DecF6" + "ProdId"] = "int";
                ColType["DecF6" + "idPost"] = "int";
                ColType["DecF6" + "idLic"] = "int";
                ColType["DecF6" + "P14"] = "nvarchar";
                ColType["DecF6" + "P15"] = "nvarchar";
                ColType["DecF6" + "P16"] = "numeric";
                ColType["DecF6" + "P17"] = "nvarchar";
                ColType["DecF6" + "P18"] = "nvarchar";
                ColType["DecF6" + "P19"] = "nvarchar";
                ColType["DecF6" + "P20"] = "numeric";
                ColType["DecF6" + "TTYPE"] = "int";
                ColType["DecF6" + "idOrg"] = "nvarchar";
                ColType["DecF7" + "id"] = "int";
                ColType["DecF7" + "Hid"] = "int";
                ColType["DecF7" + "vidCode"] = "nvarchar";
                ColType["DecF7" + "ProdId"] = "int";
                ColType["DecF7" + "idPost"] = "int";
                ColType["DecF7" + "idLic"] = "int";
                ColType["DecF7" + "P14"] = "nvarchar";
                ColType["DecF7" + "P15"] = "nvarchar";
                ColType["DecF7" + "P16"] = "numeric";
                ColType["DecF7" + "P17"] = "nvarchar";
                ColType["DecF7" + "P18"] = "nvarchar";
                ColType["DecF7" + "P19"] = "nvarchar";
                ColType["DecF7" + "P20"] = "numeric";
                ColType["DecF7" + "TTYPE"] = "int";
                ColType["DecF7" + "idOrg"] = "nvarchar";
                ColType["DecF8" + "id"] = "int";
                ColType["DecF8" + "Hid"] = "int";
                ColType["DecF8" + "vidTraffic"] = "tinyint";
                ColType["DecF8" + "vidProduce"] = "tinyint";
                ColType["DecF8" + "idCarrier"] = "tinyint";
                ColType["DecF8" + "p5"] = "nvarchar";
                ColType["DecF8" + "p6"] = "numeric";
                ColType["DecF8" + "p7"] = "nvarchar";
                ColType["DecF8" + "p8"] = "nvarchar";
                ColType["DecF8" + "p9"] = "nvarchar";
                ColType["DecF8" + "p10"] = "numeric";
                ColType["DecF8" + "p11"] = "nvarchar";
                ColType["DecF8" + "p12"] = "nvarchar";
                ColType["DecF8" + "p13"] = "nvarchar";
                ColType["DecF8" + "p14"] = "nvarchar";
                ColType["DecF8" + "p15"] = "nvarchar";
                ColType["DecF8" + "p16"] = "numeric";
                ColType["DecF8" + "p17"] = "numeric";
                ColType["DecF8" + "idOrg"] = "nvarchar";
                ColType["DecF9" + "id"] = "int";
                ColType["DecF9" + "Hid"] = "int";
                ColType["DecF9" + "vidTraffic"] = "int";
                ColType["DecF9" + "vidCode"] = "nvarchar";
                ColType["DecF9" + "idContrOtpr"] = "int";
                ColType["DecF9" + "idContrPol"] = "int";
                ColType["DecF9" + "p6"] = "nvarchar";
                ColType["DecF9" + "p7"] = "numeric";
                ColType["DecF9" + "p8"] = "nvarchar";
                ColType["DecF9" + "p9"] = "nvarchar";
                ColType["DecF9" + "p10"] = "nvarchar";
                ColType["DecF9" + "p11"] = "numeric";
                ColType["DecF9" + "idOrg"] = "nvarchar";
                ColType["DecHeader" + "id"] = "int";
                ColType["DecHeader" + "type_id"] = "int";
                ColType["DecHeader" + "PrizPeriod"] = "nvarchar";
                ColType["DecHeader" + "PrizFotch"] = "int";
                ColType["DecHeader" + "Yearotch"] = "int";
                ColType["DecHeader" + "typePK"] = "int";
                ColType["DecHeader" + "korrNum"] = "nchar";
                ColType["DecHeader" + "Lics"] = "nvarchar";
                ColType["DecHeader" + "where_submit"] = "nvarchar";
                ColType["KLADR_Regions" + "NAME"] = "nvarchar";
                ColType["KLADR_Regions" + "SOCR"] = "nvarchar";
                ColType["KLADR_Regions" + "CODE"] = "nvarchar";
                ColType["Proxy" + "id"] = "int";
                ColType["Proxy" + "exist"] = "int";
                ColType["Proxy" + "http"] = "nvarchar";
                ColType["Proxy" + "port"] = "int";
                ColType["Proxy" + "name"] = "nvarchar";
                ColType["Proxy" + "password"] = "nvarchar";
                ColType["ref_alckinds" + "code"] = "nvarchar";
                ColType["ref_alckinds" + "descr"] = "nvarchar";
                ColType["ref_alckinds" + "f1"] = "bit";
                ColType["ref_alckinds" + "f2"] = "bit";
                ColType["ref_alckinds" + "f3"] = "bit";
                ColType["ref_alckinds" + "f4"] = "bit";
                ColType["ref_alckinds" + "f5"] = "bit";
                ColType["ref_alckinds" + "f6"] = "bit";
                ColType["ref_alckinds" + "f7"] = "bit";
                ColType["ref_alckinds" + "f8"] = "bit";
                ColType["ref_alckinds" + "f9"] = "bit";
                ColType["ref_alckinds" + "f10"] = "bit";
                ColType["ref_alckinds" + "f11"] = "bit";
                ColType["ref_alckinds" + "f12"] = "bit";
                ColType["ref_declforms" + "code"] = "nvarchar";
                ColType["ref_declforms" + "Descr"] = "nvarchar";
                ColType["ref_declPeriod" + "code"] = "nvarchar";
                ColType["ref_declPeriod" + "Descr"] = "nvarchar";
                ColType["ref_fotch" + "code"] = "nvarchar";
                ColType["ref_fotch" + "descr"] = "nvarchar";
                ColType["ref_lic_types" + "id"] = "int";
                ColType["ref_lic_types" + "code"] = "nvarchar";
                ColType["ref_lic_types" + "Descr"] = "nvarchar";
                ColType["ref_type_produce" + "id"] = "int";
                ColType["ref_type_produce" + "vid"] = "nvarchar";
                ColType["ref_type_produce" + "descr"] = "nvarchar";
                ColType["ref_type_traffic" + "id"] = "int";
                ColType["ref_type_traffic" + "vid"] = "nvarchar";
                ColType["ref_type_traffic" + "descr"] = "nvarchar";
                ColType["ref_typedec" + "code"] = "nvarchar";
                ColType["ref_typedec" + "data"] = "nvarchar";
                ColType["sys_pinfo" + "id"] = "int";
                ColType["sys_pinfo" + "info_code"] = "int";
                ColType["sys_pinfo" + "info_value"] = "nvarchar";
                ColType["wrk_contr_licenses" + "id"] = "int";
                ColType["wrk_contr_licenses" + "ref_contr_id"] = "int";
                ColType["wrk_contr_licenses" + "series"] = "nvarchar";
                ColType["wrk_contr_licenses" + "number"] = "nvarchar";
                ColType["wrk_contr_licenses" + "dateBegin"] = "nvarchar";
                ColType["wrk_contr_licenses" + "dateEnd"] = "nvarchar";
                ColType["wrk_contr_licenses" + "ref_licTypeId"] = "int";
                ColType["wrk_contr_licenses" + "Vidana"] = "nvarchar";
                ColType["wrk_Contragents" + "id"] = "int";
                ColType["wrk_Contragents" + "INN"] = "nvarchar";
                ColType["wrk_Contragents" + "KPP"] = "nvarchar";
                ColType["wrk_Contragents" + "OrgName"] = "nvarchar";
                ColType["wrk_Contragents" + "CCode"] = "nvarchar";
                ColType["wrk_Contragents" + "Index"] = "nvarchar";
                ColType["wrk_Contragents" + "RCode"] = "nvarchar";
                ColType["wrk_Contragents" + "Area"] = "nvarchar";
                ColType["wrk_Contragents" + "City"] = "nvarchar";
                ColType["wrk_Contragents" + "Place"] = "nvarchar";
                ColType["wrk_Contragents" + "Street"] = "nvarchar";
                ColType["wrk_Contragents" + "Building"] = "nvarchar";
                ColType["wrk_Contragents" + "Korp"] = "nvarchar";
                ColType["wrk_Contragents" + "Flat"] = "nvarchar";
                ColType["wrk_Contragents" + "Ref_org_id"] = "int";
                ColType["wrk_Contragents" + "fl_surname"] = "nvarchar";
                ColType["wrk_Contragents" + "fl_name"] = "nvarchar";
                ColType["wrk_Contragents" + "fl_secname"] = "nvarchar";
                ColType["wrk_Contragents" + "fl_address"] = "nvarchar";
                ColType["wrk_Contragents" + "foreign_addres"] = "nvarchar";
                ColType["wrk_Contragents" + "OrgType"] = "int";
                ColType["wrk_Contragents" + "producer"] = "bit";
                ColType["wrk_Contragents" + "Liter"] = "nvarchar";
                ColType["wrk_Contragents" + "carrier"] = "bit";
                ColType["wrk_org" + "id"] = "int";
                ColType["wrk_org" + "INN"] = "nvarchar";
                ColType["wrk_org" + "KPP"] = "nvarchar";
                ColType["wrk_org" + "OrgName"] = "nvarchar";
                ColType["wrk_org" + "Phone"] = "nvarchar";
                ColType["wrk_org" + "Email"] = "nvarchar";
                ColType["wrk_org" + "CCode"] = "nvarchar";
                ColType["wrk_org" + "Index"] = "nvarchar";
                ColType["wrk_org" + "Rcode"] = "nvarchar";
                ColType["wrk_org" + "Area"] = "nvarchar";
                ColType["wrk_org" + "City"] = "nvarchar";
                ColType["wrk_org" + "Place"] = "nvarchar";
                ColType["wrk_org" + "Street"] = "nvarchar";
                ColType["wrk_org" + "Building"] = "nvarchar";
                ColType["wrk_org" + "Korp"] = "nvarchar";
                ColType["wrk_org" + "Flat"] = "nvarchar";
                ColType["wrk_org" + "Head_id"] = "int";
                ColType["wrk_org" + "OrgType"] = "int";
                ColType["wrk_org" + "DirID"] = "int";
                ColType["wrk_org" + "BuhID"] = "int";
                ColType["wrk_org" + "Liter"] = "nvarchar";
                ColType["wrk_org_license" + "id"] = "int";
                ColType["wrk_org_license" + "ref_org_id"] = "int";
                ColType["wrk_org_license" + "Series"] = "nvarchar";
                ColType["wrk_org_license" + "Number"] = "nvarchar";
                ColType["wrk_org_license" + "DateBegin"] = "nvarchar";
                ColType["wrk_org_license" + "DateEnd"] = "nvarchar";
                ColType["wrk_org_license" + "ref_licType_id"] = "int";
                ColType["wrk_org_license" + "Vidana"] = "nvarchar";
                ColType["wrk_org_persons" + "id"] = "int";
                ColType["wrk_org_persons" + "Surname"] = "nvarchar";
                ColType["wrk_org_persons" + "Name"] = "nvarchar";
                ColType["wrk_org_persons" + "SecName"] = "nvarchar";
                ColType["wrk_org_persons" + "INN"] = "nvarchar";
                ColType["wrk_org_persons" + "Phone"] = "nvarchar";
                ColType["wrk_org_persons" + "ref_DocType_id"] = "int";
                ColType["wrk_org_persons" + "DocNumber"] = "nvarchar";
                ColType["wrk_org_persons" + "DocVidan"] = "nvarchar";
                ColType["wrk_org_persons" + "DocDate"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_CCode"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_Index"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_RCode"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_Area"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_City"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_Place"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_Street"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_House"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_Building"] = "nvarchar";
                ColType["wrk_org_persons" + "ad_Flat"] = "nvarchar";
                ColType["wrk_org_persons" + "Type"] = "int";
                ColType["wrk_organization" + "id"] = "int";
                ColType["wrk_organization" + "FullName"] = "nvarchar";
                ColType["wrk_organization" + "ShortName"] = "nvarchar";
                ColType["wrk_organization" + "INN"] = "nvarchar";
                ColType["wrk_organization" + "KPP"] = "nvarchar";
                ColType["wrk_organization" + "OGRN"] = "nvarchar";
                ColType["wrk_organization" + "OKATO"] = "nvarchar";
                ColType["wrk_organization" + "Phone"] = "nvarchar";
                ColType["wrk_organization" + "Addres"] = "nvarchar";
                ColType["wrk_organization" + "Head_id"] = "int";
                ColType["wrk_organization" + "OrgType"] = "int";
                ColType["wrk_organization" + "DirID"] = "int";
                ColType["wrk_organization" + "BuhID"] = "int";
            }

        }

        public string InsertInto(string table, DataRow dr,SqlCeConnection con)
        {
            string parameters = "", values = ""; 

            return parameters;
        }

        public DataRow[] GetRow( string query, SqlCeConnection con)
        {
            DataSet DS = new DataSet("table");
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");
            return DS.Tables["table"].Select("id <> 0");

        }

        //выполнение запроса
        //ACHTUNGEN
        //Реализовано криво, как заполнение
        //Набора данных - при первом нахождении лучшего
        //решения - переписать
        public void query(string query, SqlCeConnection con)
        {
            DataSet DS = new DataSet("table");
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS,"table");      


        }

        //Сравнение строк из базы очень долгая операция
        //т.к. используется - разделение, сравнения в цикле foreach
        //и запросов к словарю = к-вопар*2 в случае если строки равны
        private bool RowEq(DataRow C1, DataRow C2, string table, string par)
        {
            Char[] ch = new Char[]{'|'};
            string[] param = par.Split(ch);

            foreach (string st in param)
            {
                if (!C1[colIndex_[table + st]].Equals(C2[colIndex_[table + st]]))
                    return false;
            }

            return true ;
        }

         private string[] ColNames(SqlCeConnection con, string table)
        {

            string query = "select Column_name from INFORMATION_SCHEMA.Columns where table_name = '" + table + "'";

            DataRow[] Names = GetRow(query, con);
            string[] ColNames;
            ColNames = new string[Names.Length];

            for (int i = 0; i < Names.Length; i++) ColNames[i] = Convert.ToString(Names[0][i]);

            return ColNames;

        }

        //Удаляет пробелы в базе по бокам, если
        //Не ДОПИСАНО
        //ACHTUNG
        //НЕ ДОПИСАНО
        private void NormalizeRec(SqlCeConnection con, string table)
        {
            string[] ColNames = this.ColNames(con, table);
        }

        //Копирование Контрагентов, которых нет
        //ACHTUNG -Копипаст
        private void ConCpy(SqlCeConnection Src, SqlCeConnection Dst)
        {

            //Выбираем сразу строки полностью, чтобы проследить, Cdst выбираем постольку поскольку
            //выбираем сразу по возрастанию ИНН, чтобы не сравнивать
            DataRow[] Csrc = GetRow( "Select * from wrk_Contragents order by INN asc", Src);
            DataRow[] Cdst = GetRow("Select * from wrk_Contragents order by INN asc", Dst);

            int scnt = Csrc.Count();
            int dcnt = Cdst.Count();
    
            int inn = 1;
            int kpp = 2;


           

            Int64[] contar, kppar;

            contar = new Int64[dcnt];
            kppar = new Int64[dcnt];

            for (int i = 0; i < dcnt; i++)
            {
                if (Cdst[i][inn].ToString().Length > 9)
                {
                    contar[i] = Convert.ToInt64(Cdst[i][inn].ToString().Substring(0, 10));
                }
                else contar[i] = 0;


                if (Cdst[i][kpp].ToString().Length > 8)
                {
                    kppar[i] = Convert.ToInt64(Cdst[i][kpp].ToString().Substring(0, 9));
                }
                else kppar[i] = 0;
            }

            Array.Sort(contar);
            Array.Sort(kppar);


            Int64 index, indexp;
            for (int i = 0; i < scnt; i++)
            {
                Int64 INN = 0;
                if (Csrc[i][inn].ToString().Length > 9) INN = Convert.ToInt64(Csrc[i][inn].ToString().Substring(0, 10));
                index = Array.BinarySearch(contar,
                                              INN
                                               );
                Int64 KPP = 0;
                if (Csrc[i][kpp].ToString().Length > 8) KPP = Convert.ToInt64(Csrc[i][kpp].ToString().Substring(0, 9));
                indexp = Array.BinarySearch(kppar,
                                               KPP
                                               );

                if ((index < 0) || (indexp < 0))
                {


                    string st = Csrc[i][23].ToString();
                    if (st == "")
                    {
                        st = "0";
                    }


                    String CommandText = "insert into wrk_contragents ([INN],[KPP],[OrgName],[CCode],[Index],[RCode],[Area],[City],[Place],[Street],[Building],[Korp],[Flat],[Ref_org_id],[fl_surname],[fl_name],[fl_secname],[fl_address],[foreign_addres],[OrgType],[producer],[Liter],[carrier])  Values('" + Csrc[i][1] + "', '" + Csrc[i][2] + "', '" + Csrc[i][3] + "', '" + Csrc[i][4] + "', '" + Csrc[i][5] + "', '" + Csrc[i][6] + "', '" + Csrc[i][7] + "', '" + Csrc[i][8] + "', '" + Csrc[i][9] + "', '" + Csrc[i][10] + "', '" + Csrc[i][11] + "', '" + Csrc[i][12] + "', '" + Csrc[i][13] + "', NULL, '" + Csrc[i][15] + "', '" + Csrc[i][16] + "', '" + Csrc[i][17] + "', '" + Csrc[i][18] + "', '" + Csrc[i][19] + "', " + Csrc[i][20] + ", " + Csrc[i][21] + ",'" + Csrc[i][22] + "', " + st + ")";

                    CommandText = CommandText.Replace("True", "1");
                    CommandText = CommandText.Replace("False", "0");


                    query( CommandText, Dst);

                }

            }


        }

        public int KillProd(SqlCeConnection Dst, int type)
        {
            string query = "select * from DecF" + type.ToString();
            string tp = "DecF" + type.ToString();
            int hid, vid, prod, idPost, time, TTN, price;

            if (type == 12)
            {
                hid = colIndex_[tp + "Hid"];
                vid = colIndex_[tp + "vidCode"];
                prod = colIndex_[tp + "ProdId"];
                idPost = colIndex_[tp + "idPost"];
                time = colIndex_[tp + "P29"];
                TTN = colIndex_[tp + "P210"];
                price = colIndex_[tp + "P212"];
            }
            else
            {
                hid = colIndex_[tp + "Hid"];
                vid = colIndex_[tp + "vidCode"];
                prod = colIndex_[tp + "ProdId"];
                idPost = colIndex_[tp + "idPost"];
                time = colIndex_[tp + "P213"];
                TTN = colIndex_[tp + "P214"];
                price = colIndex_[tp + "P216"];
            }

            DataRow[] DR = GetRow(query, Dst);

//            int[] indxs = new int[DR.Count()];
            List<string> lst;
            lst = new List<string>();
            query = "delete from DecF" + type.ToString() + " where ";
            int cnt = 0;

            for (int i = 0; i < DR.Count(); i++)
            {
                string str = DR[i][hid].ToString() +
                    DR[i][hid].ToString() +
                    DR[i][vid].ToString() +
                    DR[i][prod].ToString() +
                    DR[i][idPost].ToString() +
                    DR[i][time].ToString() +
                    DR[i][TTN].ToString() +
                    DR[i][price].ToString();

                if (lst.Contains(str))
                {
//                    indxs[i] = Convert.ToInt32(DR[i][0]);
                    query += " id = " + DR[i][0].ToString() + " or ";
                    cnt++;
                }
                else
                {
 //                   indxs[i] = 0;
                    lst.Add(str);
                }
            }
            
            query = query.Substring(0, query.Count() - 4);

            if (cnt != 0)
            this.query(query, Dst);



            return cnt;
        }

        //Копирование Лицензий
        private void LicCpy(SqlCeConnection Src, SqlCeConnection Dst, Dictionary<object, object> indC)
        {
            DataRow[] Ldst = GetRow( "Select * From  wrk_Contr_licenses order by  ref_contr_id	asc",Dst);
            DataRow[] Lsrc = GetRow( "Select * From  wrk_Contr_licenses order by  ref_contr_id	asc",Src);

            bool havelic = false;
            bool noncontr = false;
  
            //переписываем контрагентов в соответствии
            for (int j = 0; j < Lsrc.Count(); j++)
            {
                havelic = false;
                for (int i = 0; i < Ldst.Count(); i++)
                {
                    //Проверяем серию и номер
                    if (Ldst[i][3].Equals(Lsrc[j][3]) &&
                        Ldst[i][2].Equals(Lsrc[j][2]))
                    {
                        //                               indL[Lsrc[j][0]] = Ldst[i][0];
                        havelic = true;
                    }

                }

                if (!havelic)
                {
                    try
                    {
                        System.String CommandText = "insert into wrk_contr_licenses ([ref_contr_id],[series],[number],[dateBegin],[dateEnd],[ref_licTypeId],[Vidana]) Values (" + indC[Lsrc[j][1]] + ",'" + Lsrc[j][2] + "','" + Lsrc[j][3] + "','" + Lsrc[j][4] + "','" + Lsrc[j][5] + "'," + Lsrc[j][6] + ",'" + Lsrc[j][7] + "')";
                        CommandText = CommandText.Replace("True", "1");
                        CommandText = CommandText.Replace("False", "0");

                        query(CommandText, Dst);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        MessageBox.Show("Есть лицензии не связанные с котрагентами " + ex.ToString());
                    }
                }
            }

        }

        //Перепись деклараций 
        //ACHTUNG - Копипаст
        private void DecCpy(SqlCeConnection Src, SqlCeConnection Dst)
        {
            //Переписываем декларации
            DataRow[] DSrc = GetRow( "Select * from DecHeader", Src);
            DataRow[] DDst = GetRow( "Select * from DecHeader", Dst);

            int dc = DDst.Count();
            int sc = DSrc.Count();
            int e = 0;

            for (int j = 0; j < sc; j++)
            {
                bool K = true;

                for (int i = 0; i < dc; i++)
                {
                    if (DDst[i][1].Equals(DSrc[j][1]) &&    //проверяем тип
                        DDst[i][2].Equals(DSrc[j][2]) &&    //проверяем период
                        DDst[i][4].Equals(DSrc[j][4]) &&    //год
                        DDst[i][5].Equals(DSrc[j][5]) &&    //тип-первичная, корректирующая
                        DDst[i][6].Equals(DSrc[j][6]))      //корректирующий номер
                    {

                        K = false;
                        break;
                    }

                }
                e = j;
                if (K)
                {
                    string CommandText = "insert into DecHeader ([type_id],[PrizPeriod],[PrizFotch],[Yearotch],[typePK],[korrNum],[Lics],[where_submit]) VALUES (" + DSrc[e][1] + ",'" + DSrc[e][2] + "'," + DSrc[e][3] + "," + DSrc[e][4] + "," + DSrc[e][5] + ",'" + DSrc[e][6] + "','" + DSrc[e][7] + "','" + DSrc[e][8] + "')";
                    CommandText = CommandText.Replace("True", "1");
                    CommandText = CommandText.Replace("False", "0");

                    query(CommandText, Dst);

                }

            }
        }

        //Составляет таблицу совместимости 
        //dict[Src]  = Dst
        //par - параметры сравнения
        //param - параметр по которому идет совместимость
        private Dictionary<object, object> GetTable(string table, string par,string param, SqlCeConnection Src, SqlCeConnection Dst)
        {
            Dictionary<object, object> dict;
            dict = new Dictionary<object, object>();

            string que1 = "select * from " + table;

            DataRow[] dst = GetRow(que1, Dst);
            DataRow[] src = GetRow(que1, Src);

            try
            {

                for (int i = 0; i < dst.Count(); i++)
                {
                    for (int j = 0; j < src.Count(); j++)
                    {
                        if (RowEq(dst[i], src[j], table, par))
                        {
                            dict[src[j][colIndex_[table + param]]] =
                                dst[i][colIndex_[table + param]];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Не найдена таблица " + table + "\r\n либо один из столбцов: \r\n " + par.Replace("|", "\t"));
            }


            return dict;
        }
        


        //Сравнение организаций в базах
        private bool BaseCmp(SqlCeConnection Con1, SqlCeConnection Con2)
        {
            //Проверка ИНН в базах
            string INNS = Convert.ToString(GetRow("SELECT * From wrk_org where id = 1", Con1)[0][colIndex_["wrk_orgINN"]]);
            string INND = Convert.ToString(GetRow("SELECT * From wrk_org where id = 1", Con2)[0][colIndex_["wrk_orgINN"]]);

            if (!INNS.Equals(INND))
            {
                MessageBox.Show("Не совпадают организации в базах " + INND + " " + INNS);
                return true;
            }
            //Конец проверки ИНН
            return false;
        }

        //Здесь будут сравниваться строки из DecF12 и DecF11
        //Если они равны либо не равны будет проивзодиться решение о переписи в новую базу
        public void StrCmp(SqlCeConnection Src, SqlCeConnection Dst)
        {
            int[] DecF12, DecF11;

            
            DataRow[] DecF2  = GetRow("select * from DecF12", Src);
            DecF12 = new int[DecF2.Count()];

            DataRow[] DecDst = GetRow("select * from DecF12", Dst);

            for (int i = 0; i < DecF2.Count(); i++)
            {
                bool equ = false;
                for (int j = 0; j < DecDst.Count(); j++)
                {
                    if (RowEq(DecF2[i],DecDst[j],"DecF12","vidCode|P106|P29|P210")){
                        equ = true;
                        break;
                    }
                }
                 if (equ) DecF12[i] = Convert.ToInt32(DecF2[i][0]); else DecF12[i] = 0;
                
            }

            DecF2  = GetRow("select * from DecF11", Src);
            DecF11 = new int[DecF2.Count()];
            DecDst = GetRow("select * from DecF11", Dst);

            for (int i = 0; i < DecF2.Count(); i++)
            {
                bool equ = false;
                for (int j = 0; j < DecDst.Count(); j++)
                {
                    if (RowEq(DecF2[i],DecDst[j],"DecF11","vidCode|P213|P214|P106|P216|P120")){
                        equ = true;
                        break;
                    }
                }
                 if (equ) DecF11[i] = Convert.ToInt32(DecF2[i][0]); else DecF11[i] = 0;
            }

            CompareForm cmp;
            cmp = new CompareForm(DecF11,DecF12,Src);
            cmp.Show();




        }

        //Перепись из одной БД  в другую
        private void CmpRec(SqlCeConnection Src, SqlCeConnection Dst)
        {
            ConCpy(Src, Dst);
            DecCpy(Src, Dst);
            Dictionary<object, object> indC = GetTable("wrk_Contragents", "INN|KPP", "id", Src, Dst);
            LicCpy(Src, Dst, indC);
            Dictionary<object, object> indL = GetTable("wrk_contr_licenses", "series|number", "id", Src, Dst);
            Dictionary<object, object> indD = GetTable("DecHeader", "type_id|PrizPeriod|Yearotch|typePK|korrNum","id", Src, Dst);

                
            DataRow[] SrcRows = GetRow( "Select * from decF11 where TTYPE = 2", Src);

                for (int i = 0; i < SrcRows.Count(); i++)
                {
                    string CommandText = "insert into DecF11 ([Hid],[vidCode],[ProdId],[idPost],[idLic],[P213],[P214],[P216],[TTYPE],[idOrg]) values (" + indD[SrcRows[i][1]] + ",'" + SrcRows[i][2] + "'," + indC[SrcRows[i][3]] + "," + indC[SrcRows[i][4]] + "," + indL[SrcRows[i][5]] + ",'" + SrcRows[i][6] +  "','" + SrcRows[i][7] + "'," + Convert.ToString(SrcRows[i][9]).Replace(",",".") + ",2,1)";
                    query(CommandText, Dst);
                }

                 SrcRows = GetRow("Select * from decF11 where TTYPE = 1", Src);

                for (int i = 0; i < SrcRows.Count(); i++)
                {
                    string CommandText = "insert into DecF11 ([Hid],[vidCode],[ProdId],[P106],[P107],[P108],[P109],[P110],[P111],[P112],[P113],[P114],[P115],[P116],[P117],[P118],[P119],[P120], [TTYPE],[idOrg]) values (" + 
                        indD[SrcRows[i][1]] + ",'" + 
                        SrcRows[i][2] + "'," + 
                        indC[SrcRows[i][3]] + "," + 
                        Convert.ToString(SrcRows[i][10]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][11]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][12]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][13]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][14]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][15]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][16]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][17]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][18]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][19]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][20]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][21]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][22]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][23]).Replace(",", ".") + ","+
                        Convert.ToString(SrcRows[i][24]).Replace(",", ".") 
                        + ",1,1)";
                    query( CommandText, Dst);
                }

                SrcRows = GetRow("Select * from decF12 where TTYPE = 2", Src );

                for (int i = 0; i < SrcRows.Count(); i++)
                {
                    string CommandText = "insert into DecF12 ([Hid],[vidCode],[ProdId],[idPost],[P29],[P210],[P212],[TTYPE],[idOrg]) values (" + indD[SrcRows[i][1]] + ",'" + SrcRows[i][2] + "'," + indC[SrcRows[i][3]] + "," + indC[SrcRows[i][4]] /*+ "," + indL[SrcRows[i][5]]*/ + ",'" + SrcRows[i][5] + "','" + SrcRows[i][6] + "'," + Convert.ToString(SrcRows[i][8]).Replace(",", ".") + ",2,1)";                    
                    query( CommandText,Dst);
                }

                SrcRows = GetRow( "Select * from decF12 where TTYPE = 1", Src);

                for (int i = 0; i < SrcRows.Count(); i++)
                {
                    string CommandText = "insert into DecF12 ([Hid],[vidCode],[ProdId],[P106],[P107],[P108],[P109],[P110],[P111],[P112],[P113],[P114],[P115],[P116],[P117],[P118],[TTYPE],[idOrg]) values (" + indD[SrcRows[i][1]] + ",'" + SrcRows[i][2] + "'," + indC[SrcRows[i][3]] + ","
                    + Convert.ToString(SrcRows[i][9]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][10]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][11]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][12]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][13]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][14]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][15]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][16]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][17]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][18]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][19]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][20]).Replace(",", ".") + ","
                    + Convert.ToString(SrcRows[i][21]).Replace(",", ".") 
                        + ",1,1)";
                    query( CommandText, Dst);
                }

        }

        public string EndsSet(SqlCeConnection Src, SqlCeConnection Dst, string info)
        {
            Char[] ch1 = new Char[]{'+'};
            Char[] ch2 = new Char[] { '|' };
            string[] st = info.Split(ch1);
            string[] src = st[0].Split(ch2);
            string[] dst = st[1].Split(ch2);
            if (!dst[1].Equals(src[1]))
            {
                MessageBox.Show("Различные типы таблиц");
                return "Tables not match";
            }
            //Чтобы было наверняка копируем контрагентов
            CLCpy(Src, Dst);
            Dictionary<object, object> indC = GetTable("wrk_Contragents", "INN|KPP", "id", Src, Dst);

            string q;
            if (dst[1].Equals("11")) q = "120"; else q = "118";

            DataRow[] Srow = GetRow("Select P" + q + ",vidCode,ProdId,id from decF" + dst[1] + " where TTYPE = 1 and Hid = "+src[0], Src);

            for (int i = 0; i < Srow.Count(); i++)
            {
                try
                {
                    string query = "update decF" + dst[1] + " set P106 = " + Srow[i][0].ToString().Replace(',', '.') + " where TTYPE = 1 and Hid = " + dst[0] + " and vidCode='" + Srow[i][1] + "' and ProdId = " + indC[Srow[i][2]];
                    this.query(query, Dst);
                }
                catch (Exception ex) { }
            }
            
            return "a";
        }

        public void CLCpy(SqlCeConnection Src, SqlCeConnection Dst)
        {
            ConCpy(Src, Dst);
            Dictionary<object, object> indC = GetTable("wrk_Contragents", "INN|KPP", "id", Src, Dst);
            LicCpy(Src, Dst, indC);
        }

        public void CopyBases(string src, string dst)
        {
            string ConSrc =  "DataSource =" + src + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";
            string ConDst =  "DataSource =" + dst + "; Password=7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";

            SqlCeConnection consrc = new SqlCeConnection(ConSrc);
            SqlCeConnection condst = new SqlCeConnection(ConDst);

            //Сравнение реквизитов
            if (BaseCmp(consrc, condst)) return;

            CmpRec(consrc, condst);

 


            




        }
    }

    /*Простой класс с возвращением результата и т.д.*/
    class SqlCeWork
    {
        String SqlCePassword = "7338a7e6-fd3b-49d1-8d90-ddbbc1b39fa1";

        SqlCeConnection con;

        public SqlCeWork(string basename)
        {
            string ConSrc = "DataSource =" + basename + "; Password="+SqlCePassword;
            con = new SqlCeConnection(ConSrc);
        }

        /*ХЗ. Почему так просто не выхоит по-другому сделать запрос*/
        public void query(string query)
        {
            DataSet DS = new DataSet("table");
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");     
        }

        public DataRow[] GetRow(string query)
        {
            DataSet DS = new DataSet("table");
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);

            sda.Fill(DS, "table");
            return DS.Tables["table"].Select("");

        }
    }
}
