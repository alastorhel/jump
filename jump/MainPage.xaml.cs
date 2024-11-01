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
		foreach (var a in stack3)
			(a as Image).WidthRequest = w;

			stack. WidthRequest =w *1.5;
	stack1.WidthRequest =w *1.5;
	stack2.WidthRequest =w *1.5;
	stack3.WidthRequest =w *1.5;

	}

	

}

