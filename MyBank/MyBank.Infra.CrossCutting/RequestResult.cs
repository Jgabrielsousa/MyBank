using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Infra.CrossCutting
{
    public class RequestResult
    {
        public object Data { get; set; }
        public RequestResult(object data)
        {
            Data = data;
        }
    }
}
