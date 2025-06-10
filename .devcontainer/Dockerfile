# [Choice] .NET version: 8.0-bookworm, 8.0-jammy, 8.0-bullseye
# [Choice] .NET version: 9.0-bookworm
FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm

# Add .NET global tools path
ENV PATH $PATH:/home/vscode/.dotnet:/home/vscode/.dotnet/tools

# [Optional] Uncomment this section to install additional OS packages.
RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends software-properties-common

# Update .NET workload and install .NET Aspire
RUN sudo dotnet workload update \
    && sudo dotnet workload install aspire