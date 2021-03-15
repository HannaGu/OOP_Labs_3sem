using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_08
{
    class NewExceptions : Exception
    {
        public string ErrorType { get; set; }
        public NewExceptions(string message, string errType) : base(message)
        {
            this.ErrorType = errType;
        }
    }
}
