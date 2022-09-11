using DAL;
using MediatR;

namespace BLL.Values.Commands.DeleteValueCommand
{
    public class DeleteValueCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
