using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction
{
    public static class EnumLookup
    {
            public enum ResponseMsgType
            {
                success = 1,
                error = 2,
                warning = 3,
                info = 4
            }
            public enum APIMethod
            {
                GET = 1,
                POST = 2,
            }
            public enum PermissionConstant
            {
                //IsNone = 0,
                //IsInsert = 1,
                //IsUpdate = 2,
                //IsDelete = 3,
                //IsView = 4,

                Admin = -1,
                StateLevel = 1,
                DistrictLevel = 2,
                TalukaLevel = 3,
                BlockLevel = 4,
                SejaLevel = 5,
                VillageLevel = 6,
                AnaganwadiLevel = 7,
                RDDLevel = 10,
            }

            //Status Code for Api Response
            public enum StatusCode
            {
                Bad_Request = 400,
                Sucess = 200,
                Internal_Server_Error = 500,
                Not_Found = 404,
                Unauthorized = 401,
                TooManyRequests = 429
            }

            public enum Status
            {
                [Description("Success")]
                Success = 1,
                [Description("Not Found")]
                Not_Found = 2,
                [Description("Fail")]
                Fail = 3,
                [Description("Unauthorized")]
                Unauthorized = 4

            }

            public enum AuthenticateType
            {
                MobileOTP = 1,
                WhatsAppOTP = 2,
                BioMetric = 3,
                QRCode = 4,
                Image = 5,
            }

            public enum DropdownMasterType
            {
                //DistrictMaster = 1,
                //TalukaMaster = 2 ,
                //CityMaster = 3,
                //GetAllTaluka = 4,
                //GetAllCity = 5
                ApplicationType = 1,
                GetHangerType = 2,
                GetStructureType = 3,
                StateMaster = 4,
                CityMaster = 5,
                AllCity = 6,
                Airfield = 7
            }

            public enum ResultStatus
            {
                Success = 0,
                Error = 1
            }
            public static string GetDescription(this Enum enumValue)
            {
                return enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description ?? string.Empty;
            }
        
    }
}
