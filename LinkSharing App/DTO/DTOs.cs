using LinkSharingRepository.Models;
namespace LinkSharing_App.DTO;

public record UserAuthDetailsResponse(string jwtoken, User user);
