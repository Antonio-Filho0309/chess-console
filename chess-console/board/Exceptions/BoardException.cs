using System;
namespace board.Exceptions
   
{
    class BoardException : Exception
    {
        public BoardException(string msg): base(msg)
     {
            
        }
    }
}
