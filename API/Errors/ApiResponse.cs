using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; }
        public string Message { get; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Pedido efetuado, não existe",
                401 => "Autorização, não esta autorizado",
                404 => "Falta de resource, não existe",
                500 => "Errors are the path to the dark side. Errors lead to anger. " +
                "Anger leads to career charge",
                _=> null
            };
        }


    }
}
