using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05.Exceptions
{
    class NewExceptions : Exception
    {
        public string ErrorType { get; set; }
        public NewExceptions(string message, string errType) : base(message)
        {
            this.ErrorType = errType;
        }
    }

    class WrongData : NewExceptions
    {
        public int ErrorData { get; set; }
        public WrongData(string message, int data) : base(message, "Wrong Data")
        {
            this.ErrorData = data;
        }
    }
    class NullReferensEx : NewExceptions
    {
        public int ErrorData { get; set; }
        public NullReferensEx(string message, int data) : base(message, "Null reference exception")
        {
            this.ErrorData = data;
        }
    }

    class IndexOutofRange : NewExceptions
    {
        public int ErrorData { get; set; }
        public IndexOutofRange(string message, int data) : base(message, "Index out of range")
        {
            this.ErrorData = data;
        }
    }

    class FileException:NewExceptions
    {
        public FileException(string message) : base(message, "File exception")
        {  }
    }
}
