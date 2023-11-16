# Verificar a(s) versão(ões) do .NET SDK instalada(s) (Windows/Linux/macOS):
dotnet --version

# Listar todas as versões instaladas do .NET SDK:
dotnet --list-sdks

# Remover uma versão específica do .NET SDK:
dotnet sdk uninstall <version> // Substitua <version> pela versão específica que você deseja desinstalar.

# Atualizar para a versão mais recente do .NET SDK:

#    Para atualizar o SDK no Linux usando apt:

        sudo apt update
        sudo apt install dotnet-sdk

#    Para atualizar o SDK no macOS usando brew:

        brew update
        brew upgrade --cask dotnet-sdk

#    Para atualizar o .NET SDK usando o .NET CLI:

    Execute o seguinte comando no PowerShell ou no Prompt de Comando:
    dotnet --version


# Lembre-se de que, no caso de sistemas Linux ou macOS, você pode precisar adicionar o caminho do executável dotnet ao seu PATH se ainda não o tiver feito.