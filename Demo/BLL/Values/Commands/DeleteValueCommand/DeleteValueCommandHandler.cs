using MediatR;

namespace BLL.Values.Commands.DeleteValueCommand
{
    public class DeleteValueCommandHandler : IRequestHandler<DeleteValueCommand, bool>
    {
        private readonly IDatabase _database;
        public DeleteValueCommandHandler(IDatabase database)
        {
            _database = database;
        }

        public async Task<bool> Handle(DeleteValueCommand request, CancellationToken cancellationToken)
        {
            return await _database.DeleteAsync(request.Id);
        }
    }
}
