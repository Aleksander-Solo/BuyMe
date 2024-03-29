﻿using BuyMe.Domain.DTO;

namespace BuyMe.Domain.Interfaces.Application
{
    public interface IBookService
    {
        public PagedResultDto<BookDto> GetBooks(int pageSize, int PageNumber, string category, string phrase, string sort);
        public BookDto GetBook(int id);
        public void Delete(int id);
        public void Update(int id, BookDto book);
        public int Create(CreateBookDto book);
        public void CreateComment(BookCommentDto comment);
        public List<BookCategoryDto> GetCategories();
    }
}
