﻿using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;

namespace BuyMe.Domain.Interfaces.Infrastructure
{
    public interface IBookRepositiory
    {
        public PagedResultDto<Book> GetBooks(int pageSize, int PageNumber);
        public Book GetBook(int id);
        public void Delete(int id);
        public void Update(Book book);
        public int Create(Book book);
        public void CreateComment(BookComment comment);
    }
}
