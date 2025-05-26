using System.Text;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

string azureKey = "xxxxxxxxxxxx";
string azureLocation = "eastus";
string textFile = "Shakespeare.txt";
string waveFile = "Shakespeare.wav";

try
{
    FileInfo fileInfo = new FileInfo(textFile);
    if (fileInfo.Exists)
    {
        string textContent = File.ReadAllText(fileInfo.FullName);
        var speechConfig = SpeechConfig.FromSubscription(azureKey, azureLocation);
        using var speechSynthesizer = new SpeechSynthesizer(speechConfig, null);
        var speechResult = await speechSynthesizer.SpeakTextAsync(textContent);
        using var audioDataStream = AudioDataStream.FromResult(speechResult);
        await audioDataStream.SaveToWaveFileAsync(waveFile);       
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

}
