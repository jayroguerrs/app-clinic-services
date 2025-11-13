using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DepilZone.Application.Responses
{
    public class ApiResponse<T>
    {
        public string Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Result<T> Result { get; set; }
        public List<ErrorResponse> Errors { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Token { get; set; }

    }
}
