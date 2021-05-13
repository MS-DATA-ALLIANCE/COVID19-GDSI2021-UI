ARG VERSION=3.1-alpine

# Acknowledgements:
# This file was dervied with the help of a combination of https://github.com/ironPeakServices/iron-alpine/blob/master/Dockerfile
# and these 2 blog posts https://medium.com/01001101/containerize-your-net-core-app-the-right-way-35c267224a8d and https://medium.com/asos-techblog/minimising-your-attack-surface-by-building-highly-specialised-docker-images-example-for-net-b7bb177ab647

# Stage 1: Build application
FROM mcr.microsoft.com/dotnet/core/sdk:$VERSION AS build-env

WORKDIR /build
COPY . .

# Publish app
RUN dotnet publish \
  -c Release \
  -o ./output \
  -r alpine-x64 \
  --self-contained true \
  /p:PublishReadyToRun=true \
  /p:PublishReadyToRunShowWarnings=true \
  /p:PublishSingleFile=true
# Use with caution, you can trim this binary even further by adding /p:PublishTrimmed=true

# Make the self contained ASP.NET Core executable
# This is done in the stage 1 to reduce final image size,
# as chmod in stage 2 will copy the file to another layer.
# As per below blog, COPY command now supports the —-chown as you'll see in stage 2.
# https://medium.com/@lmakarov/the-backlash-of-chmod-chown-mv-in-your-dockerfile-f12fe08c0b55
RUN chmod u+x,o+x ./output/Federated

# Stage 2: Copy application artifacts into a smaller, hardened runtime 
# environment, which is then used as our final image
FROM mcr.microsoft.com/dotnet/runtime-deps:$VERSION

# The user the app should run as
ENV APP_USER=app
# The home directory
ENV APP_DIR="/$APP_USER"

# default directory is /app
WORKDIR $APP_DIR

# Harden docker image
RUN apk add dos2unix
COPY --from=build-env /build/harden.sh .
RUN dos2unix harden.sh
RUN chmod +x harden.sh && \
  sh harden.sh && \
  rm harden.sh

# Copy application and chown all app files in the COPY command 
# to reduce size, as stated in stage 1.
COPY --from=build-env --chown=$APP_USER:$APP_USER /build/output .

ENV DOTNET_RUNNING_IN_CONTAINER=true \
  ASPNETCORE_URLS=http://+:8080

# Run some post install hardening commands
COPY --from=build-env /build/post-install.sh .
RUN chmod +x post-install.sh && \
  sh post-install.sh Federated && \
  rm post-install.sh
    
# Run app as non root user
USER $APP_USER
EXPOSE 8080
ENTRYPOINT ["./Federated"]