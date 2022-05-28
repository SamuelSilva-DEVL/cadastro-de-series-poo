using CadastroDeSeries.Interfaces;

namespace CadastroDeSeries.Classes
{
  public class SerieRepositorio : IRepositorio<Series>
  {
    private List<Series> listaSeries = new List<Series>();

    public void Atualiza(int id, Series objeto)
    {
      listaSeries[id] = objeto;
    }

    public void Excluir(int id)
    {
      listaSeries[id].Excluir();
    }

    public void Insere(Series objeto)
    {
      listaSeries.Add(objeto);
    }

    public List<Series> Lista()
    {
      return listaSeries;
    }

    public int ProximoId()
    {
      return listaSeries.Count;
    }

    public Series RetornaPorId(int id)
    {
      return listaSeries[id];
    }
  }
}