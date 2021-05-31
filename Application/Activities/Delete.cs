using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistance;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _contex;
            public Handler(DataContext contex)
            {
                this._contex = contex;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _contex.Activities.FindAsync(request.Id);
               // if(activity == null) return null;

                _contex.Remove(activity);
               var result = await _contex.SaveChangesAsync()> 0;

                if (!result) return Result<Unit>.Failure("Failed to Delete the activity");
                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}