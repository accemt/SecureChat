using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain.ContentTypes
{
    public class OperationResult<T>
    {
        public bool result { get; set; }
        public string Description { get; set; }
        public T context { get; set; }

        public OperationResult(bool _result, string _desc = "", T _context = default(T))
        {
            result = _result;
            Description = _desc;
            context = _context;
        }
    }
}