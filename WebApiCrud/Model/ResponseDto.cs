﻿namespace WebApiCrud.Model
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public Boolean ISSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
