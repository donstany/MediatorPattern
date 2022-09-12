using MediatR;

namespace BLL.Requests.ValuesRequest
{
    public class ValueRequest : IRequest<ValueResponse>
    {
        public int Id { get; set; }
    }
}
