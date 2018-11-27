namespace Welic.App.Models.MenuOpcoes
{

    public enum Opcoes
    {
        Add,
        Excluir,
        Editar
    }
    public class MenuOpcoes
    {
        public Opcoes Id { get; set; }
        public string Title { get; set; }
    }
}
