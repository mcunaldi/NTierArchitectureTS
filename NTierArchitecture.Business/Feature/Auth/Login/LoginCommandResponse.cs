namespace NTierArchitecture.Business.Feature.Auth.Login;

public sealed record LoginCommandResponse(
    string AccessToken,
    Guid UserId);