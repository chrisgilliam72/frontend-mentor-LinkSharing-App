using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace LinkSharing_App.Pages
{
    partial class Phone
    {
        [Parameter]
        public String ImageSrc { get; set; } = default!;

        [Parameter]
        public String FirstName { get; set; } = default!;
        [Parameter] public String LastName { get; set; } = default!;

        [Parameter]
        public String Email { get; set; } = default!;

        [Parameter]
        public List<String> Links { get; set; } = new();

        [Parameter]
        public CustomizeLinks CustomLinks { get; set; } = null!;

        protected override void OnInitialized()
        {

            base.OnInitialized();
        }
    }
}
