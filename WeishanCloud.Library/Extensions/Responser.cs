using Microsoft.AspNetCore.Mvc;
using WeishanCloud.Library.Models;

namespace WeishanCloud.Library.Extensions
{
    public static class Responser
    {
        public static JsonResult Protocol(this Controller controller, ErrorType errorType, string errorMessage)
        {
            return controller.Json(new WeishanProtocol
            {
                Code = errorType,
                Message = errorMessage
            });
        }
    }
}