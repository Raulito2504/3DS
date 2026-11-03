using System.Runtime.CompilerServices;

public class Economia
{
    private const int SaldoInicial = 1000;

    public int Saldo { get; private set; } = SaldoInicial;

    // Identifica la instancia para comprobar en el Inspector que todos comparten la misma.
    public int IdDeInstancia => RuntimeHelpers.GetHashCode(this);

    public bool IntentarGastar(int costo)
    {
        if (costo > Saldo) return false;

        Saldo -= costo;
        return true;
    }
}
