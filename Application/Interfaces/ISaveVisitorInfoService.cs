using Application.Dto;
using Domain.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaveVisitorInfoService
    {
        void Execute(RequestSaveVisitorInfoDto request);
    }
}
