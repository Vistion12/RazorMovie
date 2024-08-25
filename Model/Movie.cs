using System.ComponentModel.DataAnnotations;


namespace RazorMovie.Model;

public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле 'Название фильма' не заполнено")]
    [StringLength(
        maximumLength: 50,
        MinimumLength = 1,
        ErrorMessage = "Длина 'Название фильма' должно быть в диапазоне от {1} до {2}")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Поле 'URL фотографии' не заполнено")]
    public required string URL { get; set; }

    [Required(ErrorMessage = "Поле 'Описание фильма' не заполнено")]
    [StringLength(
        maximumLength: 500,
        MinimumLength = 1,
        ErrorMessage = "Длина 'Название фильма' должно быть в диапазоне от {1} до {2}")]
    public required string Description { get; set; }
    public required TimeSpan Duration { get; set; } = default(TimeSpan);
}

