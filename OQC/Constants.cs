using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQC
{
    public class Constants
    {
        public static int SUCCESS = 0;
        public static int ERROR = 1;
        public static string EXCEL_STAFF = "Danh sách ODI";
    }
    public class Customers
    {
        public static string CANON = "CANON";
        public static string HLDS = "HLDS";
        public static string FUJIXEROX = "FUJIXEROX";
        public static string SCHNEIDER = "SCHNEIDER";
        public static string KYOCERA = "KYOCERA";
        public static string FORMLABS = "FORMLABS";
        public static string DIGITAL = "DIGITAL";
        public static string TOYODENSO = "TOYODENSO";
        public static string YOKOWO = "YOKOWO";
        public static string NIHON = "NIHON";
        public static string HONDALOCK = "HONDALOCK";
        public static string STANDLEY = "STANDLEY";
        public static string VALEO = "VALEO";
        public static string ICHIKOH = "ICHIKOH";
        public static string BROTHER = "BROTHER";
        public static string NICHICON = "NICHICON";
        public static string YASKAWA = "YASKAWA";

    }
    public class Areas
    {
        public static string AUTO = "AUTO";
        public static string ID = "ID";
        public static string OA = "OA";
        public static string PICKUP = "PICKUP";
        public static string ALL = "ALL";
    }
    public class SHIFT
    {
        public static string DAY = "Day";
        public static string NIGHT = "Night";
    }

    public class Station
    {
        public static string OQC1 = "OQC1";
        public static string OQC2 = "OQC2";
        public static string CSL = "CSL";
    }
    public class SampleForm
    {
        public static string SF100PER = "100%";
        public static string SF50PER = "50%(other)";
        public static string SFAQL = "AQL";

    }
    public class RoleName
    {
        public static int ADMIN = 1;
        public static int LEADER = 2;
        public static int OPERATOR = 3;
    }
}
