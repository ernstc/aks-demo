# AKS-Demos

Sample web application that can be hosted in a Azure Kubernetes Cluster.

This web application has sample code for the features below.
* Connecting to an Azure SQL Database.
* Mounting an Azure Storage File Share as volume.
* Authentication with OpenId Connect Provider like Azure AD.

## Azure CLI useful commands

```powershell
az login

az account set --subscription <id>

az aks create --resource-group <rg-name> --name <cluster-name> \
    --enable-addons monitoring,http_application_routing \
    --kubernetes-version 1.19 --generate-ssh-keys \
    --service-principal <id> --client-secret <secret> --node-count 3 \
    --vm-set-type VirtualMachineScaleSets \
    --load-balancer-sku standard \
    --enable-cluster-autoscaler \
    --min-count 1 \
    --max-count 5  
    
az aks get-credentials --resource-group <rg-name> --name <cluster-name>
    
az acr create --resource-group <rg-name> --name <acr-name> --sku Basic --admin-enabled true

az aks get-credentials --resource-group <rg-name> --name <cluster-name>

az acr build --registry <acr-name> --image <image-name> <docker-file-path>
``` 

## Configuration of the ingress controller (NGINX)

```powershell
# Create a namespace for your ingress resources
kubectl create namespace ingress-basic

# Add the ingress-nginx repository
helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx

# Use Helm to deploy an NGINX ingress controller
helm install nginx-ingress ingress-nginx/ingress-nginx \
    --namespace ingress-basic \
    --set controller.replicaCount=2 \
    --set controller.nodeSelector."beta\.kubernetes\.io/os"=linux \
    --set defaultBackend.nodeSelector."beta\.kubernetes\.io/os"=linux \
    --set controller.admissionWebhooks.patch.nodeSelector."beta\.kubernetes\.io/os"=linux \
    --set controller.service.externalTrafficPolicy=Local
```
    
## Commands for creating a self-signed certificate

```powershell
# Create a self-signed certificate with OpenSSL
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -out <certificate-filename> -keyout <key-filename> -subj "/CN=<custom-domain>/O=<organization>"

# Extract Encrypted Key from .PFX
openssl pkcs12 -in [yourfile.pfx] -nocerts -out [drlive.key]

# Extract Certificate from .PFX
openssl pkcs12 -in [yourfile.pfx] -clcerts -nokeys -out [drlive.crt]

# Decript Key
openssl rsa -in [drlive.key] -out [drlive-decrypted.key]
```
    
## Kubernetes useful commands

```powershell
kubectl create secret tls <secret-name> \
    --namespace <namespace-name> \
    --key <decrypted-certificate-key-file-path> \
    --cert <certificate-file-path>

kubectl apply -f <yaml-file-path>
```
---

## References

* [How to build and deploy a containerized app to Azure Kubernetes Service (AKS) | Azure Friday](https://www.youtube.com/watch?v=E9YWmbUb9Ps)

* [Create an HTTPS ingress controller and use your own TLS certificates on Azure Kubernetes Service (AKS)](https://docs.microsoft.com/en-us/azure/aks/ingress-own-tls)

* [Storage options for applications in Azure Kubernetes Service (AKS)](https://docs.microsoft.com/en-us/azure/aks/use-azure-ad-pod-identity)

* [Use Azure Active Directory pod-managed identities in Azure Kubernetes Service (Preview)](https://docs.microsoft.com/en-us/azure/aks/use-azure-ad-pod-identity)
