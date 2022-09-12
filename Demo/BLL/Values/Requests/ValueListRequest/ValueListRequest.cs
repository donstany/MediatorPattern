using MediatR;
using Models;

namespace BLL.Values.Requests.ValuesRequest
{
    public class ValueListRequest : IRequest<ValueListResponse>
    {
    }

    public class ValueListResponse
    {
        public List<Value> Values { get; set; }
    }

    public class ValueListRequestHandler : IRequestHandler<ValueListRequest, ValueListResponse>
    {
        private readonly IDatabase _database;
        public ValueListRequestHandler(IDatabase database)
        {
            _database = database;
        }

        public async Task<ValueListResponse> Handle(ValueListRequest request, CancellationToken cancellationToken)
        {
            var result = (await _database.GetAllAsync(cancellationToken)).Select(x=>new Value { Id = x.Id, Name = x.Name}).ToList();
            return new ValueListResponse { Values = result };
        }
    }
}
