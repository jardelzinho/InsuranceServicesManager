FROM golang:alpine as cert

# so no HSTS:

#ENV ASPNETCORE_ENVIRONMENT Development
#ENV ASPNETCORE_URLS https://+:9000;http://+:8099
EXPOSE 8099 9000

RUN apk update \
    && apk add git openssl nss-tools \
    && rm -rf /var/cache/apk/*

RUN cd /go && \
    go get -u github.com/FiloSottile/mkcert && \
    cd src/github.com/FiloSottile/mkcert && \
    go build -o /bin/mkcert

WORKDIR /root/.local/share/mkcert
# copied from %localappdata%\mkcert
COPY scripts/rootCA*.pem /root/.local/share/mkcert/


# make a pfx with known password by making a pem/key then converting it
# includes minikube and docker ips
RUN mkcert -install \
    && mkcert -key-file https-web.key -cert-file https-web.pem insurance.microservices 192.168.1.191 localhost 127.0.0.1 \
    && openssl pkcs12 -export -out https-web.pfx -inkey https-web.key -in https-web.pem -certfile rootCA.pem -passout pass:https-web


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY AgentPortalApiGateway/ $APP_HOME/
RUN cd $APP_HOME && dotnet build

FROM build AS publish
WORKDIR $APP_HOME
RUN cd $APP_HOME && dotnet publish -c Release -o out



FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine

COPY --from=cert /bin/mkcert /bin/mkcert
# root cert but not root private key:
COPY --from=cert /root/.local/share/mkcert/rootCA.pem /root/.local/share/mkcert/rootCA.pem
COPY --from=cert /root/.local/share/mkcert/https-web.pfx /app/

# TODO: consider `chmod 600 *.pem and *.pfx`



# tell ASP.NET Core to use the cert
ENV Kestrel__Certificates__Default__Path=/app/https-web.pfx
ENV Kestrel__Certificates__Default__Password=https-web


# trust root cert
RUN apk update \
    && apk add nss-tools \
    && rm -rf /var/cache/apk/* \
    && mkcert -install \
    && apk del nss-tools \
    && rm -rf /bin/mkcert


#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
#ENV ASPNETCORE_URLS=http://+:8099
COPY --from=publish /opt/app/out ./
ENTRYPOINT ["dotnet", "AgentPortalApiGateway.dll"]