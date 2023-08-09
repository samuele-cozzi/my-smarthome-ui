# Angular basic

[Azure Static Web Apps](https://docs.microsoft.com/azure/static-web-apps/overview) allows you to easily build [Angular](https://angular.io/) apps in minutes. Use this repo with the [Angular quickstart](https://docs.microsoft.com/azure/static-web-apps/getting-started?tabs=angular) to build and customize a new static site.

This project was generated with [Angular CLI](https://github.com/angular/angular-cli).

## Environment setup

```bash
# azure cli
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-$(lsb_release -cs)-prod $(lsb_release -cs) main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-get update
sudo apt-get install azure-functions-core-tools-4

# azure swa
npm install -g @angular/cli@13
swa --version

# angular
npm install -g @azure/static-web-apps-cli
```

### References

- [azure cli](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Cportal%2Cv2%2Cbash&pivots=programming-language-csharp)

## Project setup

```bash
npm install
```

### Start the dev server

```bash
ng build
swa start dist/angular-basic --api-location api
```

> Note: This command will use the local configuration file `swa-cli.config.json`.

### Run unit tests

```bash
npm test
```

### Run e2e tests

```bash
npm run e2e
```

### Lints and fixes files

```bash
npm run lint
```

### Compiles and minifies for production

```bash
npm run build
```

### Login to Azure

```bash
npm run swa:login
```

### Deploy to Azure

```bash
npm run swa:deploy
```

## Reference

- [auth](https://anthonychu.ca/post/static-web-apps-restrict-aad-users/)