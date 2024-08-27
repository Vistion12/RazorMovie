namespace RazorMovie.Services.Interfaces;
using CloudinaryDotNet.Actions;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicUrl);
}
