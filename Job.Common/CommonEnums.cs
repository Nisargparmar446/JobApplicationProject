using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Common
{
    public static class CommonEnums
    {

        public enum DropdownMasterType
        {
            //DistrictMaster = 1,
            //TalukaMaster = 2 ,
            //CityMaster = 3,
            //GetAllTaluka = 4,
            //GetAllCity = 5
            EducationType =1,
            LanguageType=2
            //GetHangerType = 2,
            //    GetStructureType =3,
            //    StateMaster = 4,
            //    CityMaster = 5,
            //    AllCity=6,
            //    Airfield = 7
        }

        public enum ResultStatus
        {
            Success = 0,
            Error = 1
        }
    }
}
