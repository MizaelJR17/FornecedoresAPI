using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FornecedoresAPI.Models
{
    public class ApiErrorResponse
    {
        public string Title { get; set; }
        public string Detail { get; set; }

        public ApiErrorResponse(string title, string detail)
        {
            Title = title;
            Detail = detail;
        }
    }
}