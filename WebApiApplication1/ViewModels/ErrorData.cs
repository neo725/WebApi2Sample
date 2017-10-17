using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApiApplication1.ViewModels
{
    public class ErrorData
    {
        public ErrorData(int errorNumber, string errorMessage)
        {
            this.ErrorNumber = errorNumber;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 取得自訂的錯誤代碼
        /// </summary>
        [JsonProperty("error_number")]
        public int ErrorNumber { get; set; }

        /// <summary>
        /// 取得自訂的錯誤訊息
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}