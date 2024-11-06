using System.Collections;

namespace jump;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	bool estaMorto = false;
	bool estaPulando = false;
	const int tempoEntreFrames = 25;

	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int velocidade = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
	}

	void CalculaVelocidade(double w)
	{
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
		velocidade = (int)(w * 0.01);
	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var a in stack)
			(a as Image).WidthRequest = w;
		foreach (var a in stack1)
			(a as Image).WidthRequest = w;
		foreach (var a in stack2)
			(a as Image).WidthRequest = w;
	

		stack.WidthRequest = w * 1.5;
		stack1.WidthRequest = w * 1.5;
		stack2.WidthRequest = w * 1.5;
		

	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios(stack1);
		GerenciaCenarios(stack2);
		
		GerenciaCenarios(stack);


	}

	void MoveCenario()
	{
		stack1.TranslationX -= velocidade1;
		stack2.TranslationX -= velocidade2;
		stack.TranslationX -= velocidade;

	}

	void GerenciaCenarios(HorizontalStackLayout hsl)
	{
		var view =(hsl.Children.First() as Image);
		if (view.WidthRequest + hsl.TranslationX < 0)
		{
			hsl.Children.Remove(view);
			hsl.Children.Add(view);
			hsl.TranslationX = view.TranslationX;
		}
	}

	async Task Desenha()
	{
		while(!estaMorto)
		{
			GerenciaCenarios();
			 await Task.Delay(tempoEntreFrames);
		}
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenha();
    }


	


}

