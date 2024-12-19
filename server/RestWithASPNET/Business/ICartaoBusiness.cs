using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface ICartaoBusiness
    {
        CartaoVO Create(CartaoVO cartao);
        CartaoVO FindByID(long id);
        List<CartaoVO> FindAll();
        PagedSearchVO<CartaoVO> FindWithPagedSearch(
            string nome, string sortDirection, int pageSize, int page);
        CartaoVO Update(CartaoVO cartao);
        void Delete(long id);

        string BuscaIdCartaoPorIdPerson(string id);
    }
}
