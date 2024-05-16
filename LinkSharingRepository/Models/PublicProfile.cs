namespace LinkSharingRepository.Models
{
    public class PublicProfile()
    {
        public String Name { get; set; } = "";
        public String Email { get; set; } = "";
        public String PublicUrl { get; set; } = "";

        public IEnumerable<String> CustomLinks { get; set; } = Enumerable.Empty<String>();
    }
}
