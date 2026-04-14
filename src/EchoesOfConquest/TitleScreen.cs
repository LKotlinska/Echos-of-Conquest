namespace EchoesOfConquest;

public static class TitleScreen
{
    public static void Show()
    {
        string[] title = [
            "  ▄▄▄▄▄▄▄                                        ▄▄   ▄   ▄▄▄▄",
            " █▀██▀▀▀        █▄                              ██    ▀██████▀                                     █▄",
            "   ██           ██                             ▄██▄     ██           ▄                            ▄██▄",
            "   ████   ▄███▀ ████▄ ▄███▄ ▄█▀█▄ ▄██▀█   ▄███▄ ██      ██     ▄███▄ ████▄ ▄████ ██ ██ ▄█▀█▄ ▄██▀█ ██",
            "   ██     ██    ██ ██ ██ ██ ██▄█▀ ▀███▄   ██ ██ ██      ██     ██ ██ ██ ██ ██ ██ ██ ██ ██▄█▀ ▀███▄ ██",
            "   ▀█████▄▀███▄▄██ ██▄▀███▀▄▀█▄▄▄█▄▄██▀  ▄▀███▀▄██      ▀█████▄▀███▀▄██ ▀█▄▀████▄▀██▀█▄▀█▄▄▄█▄▄██▀▄██",
            "                                                ██                            ██",
            "                                               ▀▀                              ▀",
        ];
        string[] tagline = [
            "┌─╴┌─┐┌─┐┌─╴┌─╴   ╷ ╷┌─┐╷ ╷┌─┐   ╷  ┌─╴┌─╴┌─╴┌┐╷╶┬┐",
            "├╴ │ │├┬┘│╶┐├╴    └┬┘│ ││ │├┬┘   │  ├╴ │╶┐├╴ │└┤ ││",
            "╵  └─┘╵└╴└─┘└─╴    ╵ └─┘└─┘╵└╴   └─╴└─╴└─┘└─╴╵ ╵╶┴┘",
        ];
        string[] prompt = [
            "┌─┐┌─┐┌─╴┌─┐┌─┐   ┌─╴┌┐╷╶┬╴┌─╴┌─┐   ╶┬╴┌─┐   ┌┐ ┌─╴┌─╴╷┌┐╷",
            "├─┘├┬┘├╴ └─┐└─┐   ├╴ │└┤ │ ├╴ ├┬┘    │ │ │   ├┴┐├╴ │╶┐││└┤",
            "╵  ╵└╴└─╴└─┘└─┘   └─╴╵ ╵ ╵ └─╴╵└╴    ╵ └─┘   └─┘└─╴└─┘╵╵ ╵╵╵╵",
        ];

        Console.Clear();
        Console.WriteLine();
        foreach (var line in title) Console.WriteLine(line);
        Console.WriteLine();
        foreach (var line in tagline) Console.WriteLine(line);
        Console.WriteLine();
        foreach (var line in prompt) Console.WriteLine(line);
        Console.ReadLine();
    }
}
