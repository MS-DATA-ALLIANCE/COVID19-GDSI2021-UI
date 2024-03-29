#!/usr/bin/env sh

# Acknowledgements:
# Most of this file was derived from https://github.com/ironPeakServices/iron-alpine/blob/master/Dockerfile
# with some additions from https://medium.com/asos-techblog/minimising-your-attack-surface-by-building-highly-specialised-docker-images-example-for-net-b7bb177ab647

# fail if a command fails
set -e
set -o pipefail

# ensure we only use apk repositories over HTTPS (altough APK contain an embedded signature)
echo "https://alpine.global.ssl.fastly.net/alpine/v$(cut -d . -f 1,2 < /etc/alpine-release)/main" > /etc/apk/repositories \
  && echo "https://alpine.global.ssl.fastly.net/alpine/v$(cut -d . -f 1,2 < /etc/alpine-release)/community" >> /etc/apk/repositories

# Update base system
apk update
apk add --no-cache ca-certificates

# Upgrade packages
apk upgrade -U
apk add bash
apk add nano

apk add --no-cache python3 py3-pip

echo "@testing http://dl-cdn.alpinelinux.org/alpine/edge/testing" >> /etc/apk/repositories
apk add --update --no-cache py3-numpy py3-pandas@testing
# Add custom user and setup home directory
adduser -s /bin/true -u 1000 -D -h $APP_DIR $APP_USER \
  && chown -R "$APP_USER" "$APP_DIR" \
  && chmod 700 "$APP_DIR"

# Remove existing crontabs, if any.
rm -fr /var/spool/cron \
  && rm -fr /etc/crontabs \
  && rm -fr /etc/periodic

# Remove all but a handful of admin commands.
find /sbin /usr/sbin \
  ! -type d -a ! -name apk -a ! -name ln \
  -delete

# Remove world-writeable permissions except for /tmp/
find / -xdev -type d -perm +0002 -exec chmod o-w {} + \
  && find / -xdev -type f -perm +0002 -exec chmod o-w {} + \
  && chmod 777 /tmp/ \
  && chown $APP_USER:root /tmp/

# Remove unnecessary accounts, excluding current app user and root
sed -i -r "/^($APP_USER|root|nobody)/!d" /etc/group \
  && sed -i -r "/^($APP_USER|root|nobody)/!d" /etc/passwd

# Remove interactive login shell for everybody
#sed -i -r 's#^(.*):[^:]*$#\1:/sbin/nologin#' /etc/passwd

# Disable password login for everybody
while IFS=: read -r username _; do passwd -l "$username"; done < /etc/passwd || true

# Remove apk configs
#find /bin /etc /lib /sbin /usr \
# -xdev -type f -regex '.*apk.*' \
# ! -name apk \
# -exec rm -fr {} +

# Remove temp shadow,passwd,group
find /bin /etc /lib /sbin /usr -xdev -type f -regex '.*-$' -exec rm -f {} +

# Ensure system dirs are owned by root and not writable by anybody else.
find /bin /etc /lib /sbin /usr -xdev -type d \
  -exec chown root:root {} \; \
  -exec chmod 0755 {} \;

# Remove suid & sgid files
find /bin /etc /lib /sbin /usr -xdev -type f -a \( -perm +4000 -o -perm +2000 \) -delete

# Remove dangerous commands
find /bin /etc /lib /sbin /usr -xdev \( \
  -iname hexdump -o \
  -iname chgrp -o \
  -iname ln -o \
  -iname od -o \
  -iname strings -o \
  -iname su -o \
  -iname sudo \
  \) -delete

# Remove init scripts since we do not use them.
rm -fr /etc/init.d /lib/rc /etc/conf.d /etc/inittab /etc/runlevels /etc/rc.conf /etc/logrotate.d

# Remove kernel tunables
rm -fr /etc/sysctl* /etc/modprobe.d /etc/modules /etc/mdev.conf /etc/acpi

# Remove root home dir
rm -fr /root

# Remove fstab
rm -f /etc/fstab

# Remove any symlinks that we broke during previous steps
find /bin /etc /lib /sbin /usr -xdev -type l -exec test ! -e {} \; -delete





