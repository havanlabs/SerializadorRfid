# SerializadorRfid

Projeto base com o algoritmo de serialização do padrão GS1 criado pela Havan Labs. 

### Exemplo
**Serialização SGTIN:**

| Parâmetro | Tipo   | Descrição |
| ---       | ---    | ---       |
| barcode   | string | Código de Barras do Produto |
| serial    | long   | Numero do Serial da tag do produto|
| partition | int    | Numero da Partição a ser utilizada (lenght do prefixo da GS1, ler a documentação adicional para entender melhor) |

``` csharp
var aux = EpcHelper.SerializarSgtin(Barcode, Serie, Particao);
```

**Serialização outros Padrões:**

| Parâmetro | Tipo   | Descrição |
| ---       | ---    | ---       |
| Parametro | GS1 | Código de Barras do Produto |
``` csharp
var aux = EpcHelper.SerializarGenerico(Parametro);
```

**Leitura dos dados:**

| Parâmetro | Tipo   | Descrição |
| ---       | ---    | ---       |
| epcHexadecimal | string | Código de Barras do Produto |
``` csharp
var aux = EpcHelper.GetGS1(epcHexadecimal);
```
### Documentação adicional
* [EPC] - Documentação dos padrões na GS1

   [EPC]: <https://www.gs1br.org/codigos-e-padroes/epc-rfid>
   
