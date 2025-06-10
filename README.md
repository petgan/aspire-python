# Python / Django - Aspired

## Exporting dev-certs

1. **Export the certificate:** Run the following command to export the development certificate to a .pfx file:

```bash
dotnet dev-certs https -ep ./dev-cert.pfx -p <password>
dotnet dev-certs https -ep ./dev-cert.pfx --no-password
dotnet dev-certs https -ep ./dev-cert.crt --trust --format Pem
dotnet dev-certs https -ep /usr/local/share/ca-certificates/dev-cert.crt --format Pem

```

2. **Trust the certificate:** Install the exported certificate into the system's trusted certificate store. Use the following commands:

```bash
export CURL_CA_BUNDLE=/usr/local/share/ca-certificates/dev-cert.crt
curl --verbose https://localhost:21204

sudo cp dev-cert.crt /usr/local/share/ca-certificates/
sudo chmod u=rw,g=r,o=r /usr/local/share/ca-certificates/dev-cert.crt
sudo update-ca-certificates --fresh

curl --verbose https://localhost:21204
```

3. **Verify:** Ensure the certificate is trusted by checking the system's certificate store:

```bash
sudo ls /etc/ssl/certs/ | grep dev-cert
```

4. Setup Aspire (optionnal)

```bash
dotnet new install Aspire.ProjectTemplates::9.3.0 --force
dotnet tool install --global aspire.cli --prerelease
```

5. Python

```bash

uv add opentelemetry-distro[otlp]
uv add $(uv run opentelemetry-bootstrap -a requirements)

```