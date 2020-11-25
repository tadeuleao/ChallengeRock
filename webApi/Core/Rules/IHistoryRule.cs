using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Rules
{
    public interface IHistoryRule
    {
        List<HistoryDTO> ListAll();
        HistoryDTO List(int idHistory);
        HistoryDTO ListByUSer(int idUser);
        HistoryDTO ListByPost(int idPost);
        bool HasLikedPost(int idPost, int idUser);
        void AddHistory(int idPost, int idUser);
    }
}
