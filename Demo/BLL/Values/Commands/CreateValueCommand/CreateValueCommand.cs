using MediatR;

namespace BLL.Values.Commands.CreateValueCommand
{
    public class CreateValueCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
