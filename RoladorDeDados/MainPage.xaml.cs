namespace RoladorDeDados;

public partial class MainPage : ContentPage
{
    private readonly Random random = new Random();

    public MainPage()
    {
        InitializeComponent();
        pickerLados.SelectedIndex = 1; // começa com 6 lados
    }

    private async void OnRolarClicked(object sender, EventArgs e)
    {
        int lados = (int)pickerLados.SelectedItem;

        // gira o dado
        // vira o dado como um cubo
        await areaDado.RotateTo(360, 400);
        areaDado.Rotation = 0;


        int resultado = random.Next(1, lados + 1);
        MostrarResultado(lados, resultado);
    }

    private void OnLadosChanged(object sender, EventArgs e)
    {
        if (pickerLados.SelectedItem == null)
            return;

        int lados = (int)pickerLados.SelectedItem;
        MostrarResultado(lados, lados); // mostra o maior valor ao trocar o tipo
    }

    private void MostrarResultado(int lados, int resultado)
    {
        //Teste
        if (lados == 6)
        {
            imgDado.Source = $"dado{resultado}.png";
            imgDado.IsVisible = true;
            dadoNumero.IsVisible = false;
        }
        else
        {
            lblResultado.Text = resultado.ToString();
            imgDado.IsVisible = false;
            dadoNumero.IsVisible = true;
        }
    }
}