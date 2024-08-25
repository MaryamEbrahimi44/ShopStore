using Application.Interfaces;
using MongoDB.Driver;
using Domain.Visitors;
using Application.Dto;

namespace Application.Visitor
{
    public class SaveVisitorInfoService : ISaveVisitorInfoService
    {

        private readonly IMongoDbContext<Domain.Visitors.Visitor> _mongoDbContext;
        private readonly IMongoCollection<Domain.Visitors.Visitor> _visitorMongoCollection;
        public SaveVisitorInfoService(IMongoDbContext<Domain.Visitors.Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _visitorMongoCollection = _mongoDbContext.GetCollection();
            
        }
        public void Execute(RequestSaveVisitorInfoDto request)
        {
            _visitorMongoCollection.InsertOne(new Domain.Visitors.Visitor
            {
                CurrentLink = request.CurrentLink,
                VisitorId = request.VisitorId,
                Time=DateTime.Now,
                Ip = request.Ip,
                Method = request.Method,    
                PhysicalPath = request.PhysicalPath,
                Protocol = request.Protocol,
                RefferLink=request.RefferLink,
                OperationSystem=new VisitorVersion
                {
                    Family = request.OperationSystem.Family,
                    Version = request.OperationSystem.Version
                },
               Browser=new VisitorVersion
               {
                   Family=request.Browser.Family,
                   Version=request.Browser.Version
               },
               Device=new Device
               {
                   Brand=request.Device.Brand,
                   Family=request.Device.Family,
                   IsSpider=request.Device.IsSpider,
                   Model=request.Device.Model
               }
               
            });
        }
    }
}
