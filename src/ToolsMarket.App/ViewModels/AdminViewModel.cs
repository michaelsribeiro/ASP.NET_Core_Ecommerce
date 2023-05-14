namespace ToolsMarket.App.ViewModels
{
    public class AdminViewModel
    {        
        public decimal TotalVendido { get; set; }
        public int TotalUsuarios { get; set; }
        public int TotalPedidos { get; set; }

        public AdminViewModel(decimal totalVendido, int totalUsuarios, int totalPedidos)
        {
            TotalVendido = totalVendido;
            TotalUsuarios = totalUsuarios;
            TotalPedidos = totalPedidos;
        }
    }
}
