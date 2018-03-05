using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain.ContentTypes
{
    public class OperationResult
    {
        public bool result { get; set; }
        public string Description { get; set; }

        public OperationResult(bool _result, string _desc = "")
        {
            result = _result;
            Description = _desc;
        }
    }
}