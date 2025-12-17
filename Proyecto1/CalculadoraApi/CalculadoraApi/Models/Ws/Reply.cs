using System;

namespace CalculadoraAPI.Models.WS
{
    public class Reply
    {
        public int Result { get; set; }      
        public object Data { get; set; }     
        public string Message { get; set; } 
    }
}