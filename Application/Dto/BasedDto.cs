using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{


    /// /////////////



    public class BasedDto
    {
      
        public bool IsSuccess { get; private set; }
        public List<string> Message { get; private set; }
        public BasedDto(bool IsSuccess, List<string> Message)
        {

            this.IsSuccess = IsSuccess;
            this.Message = Message;

        } }
    public class BasedDto<T>
    {
        public T Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public List<string> Message { get; private set; }



        public BasedDto(T Data, bool IsSuccess, List<string> Message)
        {
            this.Data = Data;
            this.IsSuccess = IsSuccess;
            this.Message = Message;

        }
        
    }
}
