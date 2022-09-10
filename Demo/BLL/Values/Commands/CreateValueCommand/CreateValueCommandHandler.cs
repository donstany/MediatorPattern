using DAL;
using MediatR;

namespace BLL.Values.Commands.CreateValueCommand
{
    public class CreateValueCommandHandler : IRequestHandler<CreateValueCommand, int>
    {
        private readonly Database _database;

        public CreateValueCommandHandler()
        {
            _database = new Database();
        }

        public async Task<int> Handle(CreateValueCommand request, CancellationToken cancellationToken)
        {
            return await _database.AddAsync(new DAL.Models.ValueEntity
            {
                Name = request.Name,
                Description = request.Description
            }, cancellationToken);
        }
    }
}
