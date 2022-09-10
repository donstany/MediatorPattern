using MediatR;

namespace BLL.Requests.ValuesRequest
{
    public class ValuesRequestHandler : IRequestHandler<ValueRequest, ValueResponse>
    {
        private List<ValueResponse> _values;
        public ValuesRequestHandler()
        {
            _values = new List<ValueResponse>()
            {
                new ValueResponse { Id = 1, Name = "TEst" },
                new ValueResponse { Id = 2 }
            };
        }

        public async Task<ValueResponse> Handle(ValueRequest request, CancellationToken cancellationToken)
        {
            var result = _values.Find(x => x.Id == request.Id) ?? new ValueResponse { Id = 0, Name = "N/A" };
            await Task.Run(() => { }, cancellationToken);
            return result;
        }
    }
}
