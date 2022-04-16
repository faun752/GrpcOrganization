using Grpc.Core;
using GrpcOrganization.Models;
using GrpcOrganization.Protos;
using Organization = GrpcOrganization.Protos.Organization;

namespace GrpcOrganization.Services
{
    public class OrganizationService : OrganizationSrv.OrganizationSrvBase
    {
        private GrpcDbContext _db;

        public OrganizationService(GrpcDbContext db)
        {
            _db = db;
        }

        public override Task<Organizations> GetOrganizations(Empty requestData, ServerCallContext context)
        {
            Organizations responseData = new Organizations();
            var query = from org in _db.Organizations
                select new Organization()
                {
                    OrganizationCode = org.OrganizationCode,
                    OrganizationName = org.OrganizationName
                };

            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<Organization> GetOrganization(OrganizationKey requestData, ServerCallContext context)
        {
            var org = _db.Organizations.Find(requestData.OrganizationCode);

            Organization responseData = new Organization
            {
                OrganizationCode = org.OrganizationCode,
                OrganizationName = org.OrganizationName
            };

            return Task.FromResult(responseData);
        }

        public override Task<Empty> RegisterOrganization(Organization requestData, ServerCallContext context)
        {
            Models.Organization data = new Models.Organization
            {
                OrganizationCode = requestData.OrganizationCode,
                OrganizationName = requestData.OrganizationName
            };

            _db.Organizations.Add(data);
            _db.SaveChanges();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateOrganization(Organization requestData, ServerCallContext context)
        {
            Models.Organization data = new Models.Organization
            {
                OrganizationCode = requestData.OrganizationCode,
                OrganizationName = requestData.OrganizationName
            };

            _db.Organizations.Update(data);
            _db.SaveChanges();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DelteOrganization(OrganizationKey requestData, ServerCallContext context)
        {
            var data = _db.Organizations.Find(requestData.OrganizationCode);

            _db.Organizations.Remove(data);
            _db.SaveChanges();

            return Task.FromResult(new Empty());
        }
    }
}
