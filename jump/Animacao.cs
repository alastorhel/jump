
namespace jump;

public class Animacao
{
    protected List<String> animacao1 = new List<String>();
    protected List<String> animacao2 = new List<String>();
    protected List<String> animacao3 = new List<String>();

    protected bool loop = true;

    protected int animacaoAtiva = 1;

    bool parado = true;

    int frameAtual = 1;

    protected CachedImageView imageView;


    public Animacao(Image a)
    {
        compImagem = a;
    }

    public void Stop()
    {
        parado = true;
    }

    public void Play()
    {
        parado = false;
    }

    public void SetAnimacaoAtiva(int a)
    {
        animacaoAtiva = a;
    }

    public void Desenha()
    {
        if (parado)
            return;
        string nomedoarquivo ="";
        int tamanhoAnimacao = 0;
        if (animacaoAtiva == 1)
        {
             nomedoarquivo = animacao1 [frameAtual];
            tamanhoAnimacao = animacao1.Count;
        }
        else if (animacaoAtiva == 2)
        {
            nomedoarquivo = animacao2 [frameAtual];
            tamanhoAnimacao = animacao2.Count;
        }
        else if (animacaoAtiva == 3)
        {
          nomedoarquivo = animacao3 [frameAtual];
            tamanhoAnimacao = animacao3.Count;
        }
        compImagem.Source = ImageSource.FromFile(nomedoarquivo);
        frameAtual++;

        if (frameAtual >= tamanhoAnimacao)
        {
                if (loop)
                   frameAtual = 0;
                else
                {
                    parado = true;
                    QuandoParar();
                }

                
        }

    }

    public virtual void QuandoParar()
    {

    }


}