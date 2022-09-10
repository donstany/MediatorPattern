using DAL;
using MediatR;

namespace BLL.Requests.ValuesRequest
{
    public class ValuesRequestHandler : IRequestHandler<ValueRequest, ValueResponse>
    {
        private readonly Database database;
        public ValuesRequestHandler()
        {
            database = new Database();
        }

        public async Task<ValueResponse> Handle(ValueRequest request, CancellationToken cancellationToken)
        {
            return (await database.FilterAsync(x => x.Id == request.Id, cancellationToken))
                .Select(x => new ValueResponse { Id = x.Id, Name = x.Name })
                .First();
        }
    }
}
