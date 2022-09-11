using DAL;
using MediatR;

namespace BLL.Requests.ValuesRequest
{
    public class ValuesRequestHandler : IRequestHandler<ValueRequest, ValueResponse>
    {
        private readonly IDatabase _database;

        public ValuesRequestHandler(IDatabase database)
        {
            _database = database;
        }

        public async Task<ValueResponse> Handle(ValueRequest request, CancellationToken cancellationToken)
        {
            return (await _database.FilterAsync(x => x.Id == request.Id, cancellationToken))
                .Select(x => new ValueResponse { Id = x.Id, Name = x.Name })
                .First();
        }
    }
}
