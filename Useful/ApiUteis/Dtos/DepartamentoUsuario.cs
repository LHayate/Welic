namespace UseFul.ClientApi.Dtos
{
    public class DepartamentoUsuario: BaseDto<DepartamentoUsuario>
    {
        public int IdDepartamento { get; set; }
        public string UserId { get; set; }
    

        public DepartamentoUsuario() 
        {
            
        }
    }
}
