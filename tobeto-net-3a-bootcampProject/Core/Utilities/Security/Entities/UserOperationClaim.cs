using Core.Entities;

namespace Core.Utilities.Security.Entities;

public class UserOperationClaim
{

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int OperationClaimId { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int userId, int operationClaimId) : this()
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}
