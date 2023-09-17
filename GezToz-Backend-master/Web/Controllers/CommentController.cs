using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
 
    public class CommentController : BaseCRUDController<Comment, int, CreateCommentDto, CommentUpdateDTO, CommentInfoDto>
    {
        public CommentController(ICommentService service) : base(service)
        {
        }

    }
}
