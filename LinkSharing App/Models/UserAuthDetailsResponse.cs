using LinkSharingRepository.Models;
namespace LinkSharing_App.Models;

public record UserAuthDetailsResponse(string jwtoken, User user);
