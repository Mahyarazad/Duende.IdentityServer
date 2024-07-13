using ImageGallery.API.Services;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;

namespace ImageGallery.API.Authorization
{
    public class MustOwnImageHandler : AuthorizationHandler<MustOwnImageRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IGalleryRepository _galleryRepository;

        public MustOwnImageHandler(IHttpContextAccessor contextAccessor, IGalleryRepository galleryRepository)
        {
            _contextAccessor = contextAccessor ?? throw new NullReferenceException(nameof(contextAccessor));
            _galleryRepository = galleryRepository ?? throw new NullReferenceException(nameof(galleryRepository)); ;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MustOwnImageRequirement requirement)
        {
            var imageId = _contextAccessor.HttpContext!.GetRouteValue("id")!.ToString();

            if(!Guid.TryParse(imageId, out Guid res))
            {
                context.Fail();
                return;
            }

            var ownerId = context.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            if(ownerId == null)
            {
                context.Fail();
                return;
            }

            var image = _galleryRepository.GetImageAsync(res);
            if (!await _galleryRepository.IsImageOwnerAsync(res, ownerId))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
            return;
        }
    }
}
