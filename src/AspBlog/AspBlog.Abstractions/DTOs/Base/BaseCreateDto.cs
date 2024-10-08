﻿using System.Text.Json.Serialization;

namespace AspBlog.Abstractions.DTOs.Base
{
    public record BaseCreateDto
    {
        public readonly DateTime CreatedAt = DateTime.Now;
    }
}