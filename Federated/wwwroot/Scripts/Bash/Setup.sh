#!/bin/bash
cd /app/wwwroot/Scripts/Bash/
RUN chmod +x harden.sh && \
    sh harden.sh && \
    rm harden.sh

RUN chmod +x post-install.sh && \
    sh post-install.sh && \
    rm post-install
