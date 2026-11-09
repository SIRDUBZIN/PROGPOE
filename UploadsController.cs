using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Authorization;using RaceDay.Api.Services;
namespace RaceDay.Api.Controllers;
[ApiController,Route("api/uploads")]
public class UploadsController(BlobStorageService blobs):ControllerBase {
 [Authorize(Roles="Organiser,Admin"),HttpPost("event-banner")] public async Task<IActionResult> Banner(IFormFile file,CancellationToken ct){try{return Ok(new{url=await blobs.UploadAsync(file,ct)});}catch(InvalidOperationException ex){return BadRequest(new{message=ex.Message});}}
 [Authorize(Roles="Participant"),HttpPost("profile-picture")] public async Task<IActionResult> Profile(IFormFile file,CancellationToken ct){try{return Ok(new{url=await blobs.UploadAsync(file,ct)});}catch(InvalidOperationException ex){return BadRequest(new{message=ex.Message});}}
}
