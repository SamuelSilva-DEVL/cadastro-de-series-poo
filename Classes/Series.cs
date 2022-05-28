using CadastroDeSeries.Enum;

namespace CadastroDeSeries.Classes
{
  public class Series : EntidadeBase
  {
    //Atributos
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }
    private bool Excluido { get; set; }

    //Métodos
    public Series(int id, Genero genero, string titulo, string descricao, int ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Excluido = false;
    }

    public override string ToString()
    {
      return "Tituro: " + this.Titulo + "\n"
           + "Genero: " + this.Genero + "\n"
           + "Ano: " + this.Ano + "\n"
           + "Descricao: " + this.Descricao + "\n"
           + "Excluido: " + this.Excluido;
    }

    public string retornaTitulo()
    {
      return this.Titulo;
    }

    public int retornaId()
    {
      return this.Id;
    }
    public bool retornaExcluido()
    {
      return this.Excluido;
    }
    public void Excluir()
    {
      this.Excluido = true;
    }

  }
}