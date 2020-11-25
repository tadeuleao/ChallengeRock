using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Rules
{
    public interface IPostRule
    {
        List<PostDTO> ListPaged(int pageCurrent, int quantityItems);
        List<PostDTO> ListAllPost();
        bool LikePost(int idPost, int idUser);
        int SavePost(PostDTO postDto);
    }
}
